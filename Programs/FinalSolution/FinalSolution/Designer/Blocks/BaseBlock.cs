using System;
using System.Windows.Forms;
using System.Drawing;

namespace Solution.Designer.Blocks {

	/// <summary>
	/// 
	/// </summary>
	public enum BasicBlockIds {

		/// <summary>
		/// An empty connection. Code generation will stop when it reaches a block with a NextBlockId of -1
		/// </summary>
		NoConnection = -1,
		
		/// <summary>
		/// The variable declaration block. Only one of these per project.
		/// </summary>
		Variable = 0,
		
		/// <summary>
		/// The starter block, where code generation starts. Only one of these per project
		/// </summary>
		Starter = 1,
		
		/// <summary>
		/// The first user added block
		/// </summary>
		First = 2

	}

	/// <inheritdoc />
	/// <summary>
	/// A class that can be used in the designer like a normal panel, but has its own explicit features
	/// </summary>
	public abstract class BaseBlock : Panel {

		/// <summary>
		/// Constructor for the block. 
		/// Sets the event handlers and double buffering for the block
		/// </summary>
		protected BaseBlock() {

			SetStyle(ControlStyles.OptimizedDoubleBuffer,
			         true); // Double buffering. Something the rest of my class are having issues with
			Resize += OnResized; // Good for the designer view when I'm working with the blocks
			Paint += DrawMe; // Allows me to use the graphics object without wasting system
			// Resources to create my own
			LocationChanged += OnResized; // Relocation also forces a redraw and reevaluation

			NextBlockId = (int) BasicBlockIds.NoConnection; // 

			OnResized(null, null); // Resize the component to match


		}

		/// <summary>
		/// Is called when the box is moved or resized for drawing  purposes
		/// </summary>
		/// <param name="sender">Needed for the EventHandler delegate</param>
		/// <param name="e">Needed for the EventHandler delegate</param>
		protected void OnResized(object sender, EventArgs e) {
			const int RectStartX = 5;
			const int RectStartY = 0;
			const int RectWidth = 15;
			const int RectHeight = 10;

			TopConnectorZone = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);

			var BottomRectStartY = Size.Height - 10;

			BottomConnectorZone = new Rectangle(RectStartX, BottomRectStartY, RectWidth, RectHeight);
			OutlineRectangle = new Rectangle(0, 7, DisplayRectangle.Width, DisplayRectangle.Height - 14);

			IconLocation = new Point(IconLocation.X , (Height / 2) - (IconSize.Height / 2));
			
		}



		/// <summary>
		/// The assigned Id of the block
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The block ID for the block that this block leads on to
		/// </summary>
		public int NextBlockId { get; protected set; }

		/// <summary>
		/// An area at the top of the panel which the user can click to connect to the previous block
		/// </summary>
		public Rectangle TopConnectorZone { get; protected set; }

		/// <summary>
		/// An area at the top of the panel which the user can click to connect to the next block
		/// </summary>
		public Rectangle BottomConnectorZone { get; protected set; }

		/// <summary>
		/// The rectangle the user can interact with to move the block
		/// </summary>
		public Rectangle OutlineRectangle { get; protected set; }

		/// <summary>
		/// Provides the ability to link 2 blocks together, sequentially.
		/// Code is executed in the order (this) => (BaseBlock.Id == this.NextBlockId) etc
		/// </summary>
		/// <param name="NextId">The block to link to</param>
		public void ConnectNext(int NextId) {
			NextBlockId = NextId;
		}

		/// <summary>
		/// Allows for the disconnection of this block and the one after it
		/// </summary>
		public void DisconnectNext() {
			NextBlockId = (int) BasicBlockIds.NoConnection;
		}

		/// <summary>
		/// Provides the draw method for the block
		/// </summary>
		/// <param name="sender">The object that called the function</param>
		/// <param name="e">The corresponding PaintEventArgs object</param>
		public virtual void DrawMe(object sender, PaintEventArgs e) {

			Graphics GFX = e.Graphics;
			using (var P = new Pen(Color.Black, 2)) {
				GFX.DrawRectangle(P, OutlineRectangle);
				P.Color = Color.DarkRed;
				GFX.DrawRectangle(P, TopConnectorZone);

				var MyParent = FindForm();
				if (MyParent is FrmDesigner FD) {
					foreach (var C in FD.SContainer_Workspace.Panel2.Controls) {
						if (!(C is BaseBlock B)) continue;
						if (B.NextBlockId == Id) {
							GFX.FillRectangle(Brushes.DarkRed, TopConnectorZone);
						}
					}
				}

				P.Color = Color.DarkBlue;
				GFX.DrawRectangle(P, BottomConnectorZone);

				if (NextBlockId != (int) BasicBlockIds.NoConnection) {
					GFX.FillRectangle(Brushes.DarkBlue, BottomConnectorZone);
				}

				if (ConnectorSelected == true) {
					// TopConnector
					GFX.FillRectangle(Brushes.BurlyWood, TopConnectorZone);
				} else if (ConnectorSelected == false) {
					// BottomConnector
					GFX.FillRectangle(Brushes.BurlyWood, BottomConnectorZone);
				}

			}

			if (!(Icon is null)) {
				// Draw the icon
				GFX.DrawImage(Icon,
				              IconLocation.X, IconLocation.Y,
				              IconSize.Width, IconSize.Height);
			}
		}

		/// <summary>
		/// <c>null</c>: Neither selected.
		/// <c>true</c>: TopConnector selected.
		/// <c>false</c>: BottomConnector Selected
		/// </summary>
		public bool? ConnectorSelected;

		/// <summary>
		/// The code that this block represents
		/// </summary>
		public string Code = "// BaseBlock. You shouldn't be able to see this bit :)";

		/// <summary>
		/// The icon for the block
		/// </summary>
		public Image Icon = null;
		
		/// <summary>
		/// Where the top left point of the icon will be drawn 
		/// </summary>
		public Point IconLocation = new Point(0, 0);
		
		/// <summary>
		/// How large the icon will be. Should be square
		/// </summary>
		public Size IconSize = new Size(40, 40);

	}
}
