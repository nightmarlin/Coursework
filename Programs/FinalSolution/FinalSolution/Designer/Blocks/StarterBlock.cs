using System;
using System.Drawing;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {
	/// <summary>
	/// Block that indicates the start of a main process, subroutine or function. 
	/// Does not possess a top connector, it is always the parent.
	/// </summary>
	public class StartBlock : BaseBlock {
		/// <summary>
		/// Constructor for the block
		/// </summary>
		public StartBlock() : base() {

		}
		
		/// <summary>
		/// Edits the OnResized function to allow me to ignore the TopConnector
		/// </summary>
		/// <param name="sender">EventHandler delegate required code</param>
		/// <param name="e">EventHandler delegate required code</param>
		protected new void OnResized(object sender, EventArgs e) {
			int RectStartX = 5;
			int RectStartY = (Height) - 10;
			int RectWidth = 15;
			int RectHeight = 10;

			this.BottomConnector = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);

			this.OutlineRectangle = new Rectangle(0, 7, DisplayRectangle.Width, DisplayRectangle.Height - 14);
		}

		//
		public override void ConnectDownwards(BaseBlock ChildToAdd) {

		}

		//
		public override void DisconnectChild() {

		}

		//
		public override void DrawMe(object sender, PaintEventArgs e) {
			Graphics GFX = e.Graphics;
			using (Pen P = new Pen(Color.Black, 2)) {
				GFX.DrawRectangle(P, this.OutlineRectangle);
				//P.Color = Color.Red;							// No top connector
				//GFX.DrawRectangle(P, this.TopConnector);
				P.Color = Color.Blue;
				GFX.DrawRectangle(P, this.BottomConnector);
			}
		}

		/// <summary>
		/// Gets the CS code for the Block
		/// </summary>
		/// <returns>"// Start \r\n"</returns>
		public override string GetCode() {
			return $"// Start {Environment.NewLine}"; 
		}
	}

}

