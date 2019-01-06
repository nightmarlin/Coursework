using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		Starter = 1

	}

	/// <inheritdoc />
	/// <summary>
	/// A class that can be used in the designer like a normal panel, but has its own explicit features
	/// </summary>
	public abstract class BaseBlock : Panel {

		/// <summary>
		/// Constructor for the panel. 
		/// Sets the event handlers and double buffering for the panel
		/// </summary>
		protected BaseBlock() {

			SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // Double buffering. Something the rest of my class are having issues with
			Resize += OnResized;             // Good for the designer view when I'm working with the blocks
			Paint += DrawMe;       // Allows me to use the graphics object without wasting system
																	// Resources to create my own
			LocationChanged += OnResized;    // Relocation also forces a redraw and reevaluation
			
			NextBlockId = (int)BasicBlockIds.NoConnection;        // 

			OnResized(null, null);          // Resize the component to match

			// MoveTimer.Tick += new EventHandler(this.MoveTimer_Tick);

		}

		/// <summary>
		/// Is called when the box is moved or resized for drawing  purposes
		/// </summary>
		/// <param name="sender">Needed for the EventHandler delegate</param>
		/// <param name="e">Needed for the EventHandler delegate</param>
		protected void OnResized(object sender, EventArgs e) {
			var RectStartX = 5;
			var RectStartY = 0;
			var RectWidth = 15;
			var RectHeight = 10;

			TopConnectorZone = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);
			
			RectStartY = Size.Height - 10;

			BottomConnectorZone = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);
			OutlineRectangle = new Rectangle(0, 7, DisplayRectangle.Width, DisplayRectangle.Height - 14);
			
		}

		#region Movement Controls
		//bool IsMoving = false;
		/*
		/// <summary>
		/// Is called when the mouse presses down on the control.
		/// Note that this will be overidden to ensure that the block interacts correctly with other blocks
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void OnMouseDown(object sender, EventArgs e) {
			MoveTimer = new Timer {
				Enabled = true,
				Interval = 10
			};
			MoveTimer.Tick += new EventHandler(MoveTimer_Tick);
			MoveTimer.Start();
		}

		/// <summary>
		/// Is called when the mouse is released
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void OnMouseUp(object sender, EventArgs e) {
			MoveTimer.Stop();
		}

		private Point MousePointInControl;
		private Timer MoveTimer;
		/// <summary>
		/// Is called when the timer ticks. Allows the control to move to where the mouse is
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void MoveTimer_Tick(object sender, EventArgs e) {
			
		}
		*/
		#endregion
		
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
		public abstract void ConnectNext(int NextId);
		
		/// <summary>
		/// Allows for the disconnection of this block and the one after it
		/// </summary>
		public abstract void DisconnectNext();
		
		/// <summary>
		/// Provides the draw method for the block
		/// </summary>
		/// <param name="sender">The object that called the function</param>
		/// <param name="e">The corresponding PaintEventArgs object</param>
		public abstract void DrawMe(object sender, PaintEventArgs e);

		/// <summary>
		/// The code that this block represents
		/// </summary>
		public string Code = "// BaseBlock. You shouldn't be able to see this bit :)";

	}
}