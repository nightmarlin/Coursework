using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Solution.Designer.Blocks {

	/// <inheritdoc />
	/// <summary>
	/// A class that can be used in the designer like a normal panel, but has its own explicit features
	/// </summary>
	public abstract class BaseBlock : Panel {

		/// <summary>
		/// Constructor for the panel. 
		/// Sets the event handlers and double buffering for the panel
		/// </summary>
		protected BaseBlock() : base() {

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // Double buffering. Something the rest of my class are having issues with
			this.Resize += new EventHandler(this.OnResized);             // Good for the designer view when I'm working with the blocks
			this.Paint += new PaintEventHandler(this.DrawMe);       // Allows me to use the graphics object without wasting system
																	// Resources to create my own
			this.LocationChanged += new EventHandler(OnResized);    // Relocation also forces a redraw and reevaluation

			this.ParentBlock = null;        // Empty the connections
			this.ChildBlocks = null;        // 

			OnResized(null, null);          // Resize the component to match

			// MoveTimer.Tick += new EventHandler(this.MoveTimer_Tick);

		}

		/// <summary>
		/// Is called when the box is moved or resized for drawing  purposes
		/// </summary>
		/// <param name="sender">Needed for the EventHandler delegate</param>
		/// <param name="e">Needed for the EventHandler delegate</param>
		protected void OnResized(object sender, EventArgs e) {
			int RectStartX = 5;
			int RectStartY = 0;
			int RectWidth = 15;
			int RectHeight = 10;

			this.TopConnector = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);

			RectStartY = (Size.Height) - 10;

			this.BottomConnector = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);
			this.OutlineRectangle = new Rectangle(0, 7, DisplayRectangle.Width, DisplayRectangle.Height - 14);

		}

		#region Movement Controls
		bool IsMoving = false;
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

		// Some variable encapsulation :)

		/// <summary>
		/// 
		/// </summary>
		public BaseBlock ParentBlock { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public List<BaseBlock> ChildBlocks { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public Rectangle TopConnector { get; protected set; }
		public Rectangle BottomConnector { get; protected set; }
		public Rectangle OutlineRectangle { get; protected set; }

		// VB MustOverride equivalents
		public abstract void ConnectUpwards(BaseBlock NewParent);
		public abstract void ConnectDownwards(BaseBlock ChildToAdd);
		public abstract void DisconnectParent();
		public abstract void DisconnectChild(BaseBlock ChildToRemove);
		public abstract void DrawMe(object sender, PaintEventArgs e);

		public abstract string GetCode();

	}
}