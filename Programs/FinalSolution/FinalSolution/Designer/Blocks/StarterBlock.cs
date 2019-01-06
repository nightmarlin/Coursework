using System;
using System.Drawing;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {
	/// <summary>
	/// Block that indicates the start of a main process, subroutine or function. 
	/// Does not possess a top connector, it is always the parent.
	/// </summary>
	public class StartBlock : BaseBlock {

		/// <inheritdoc />
		public StartBlock() {
			Code = "// Start block";
		}
		
		/// <summary>
		/// Edits the OnResized function to allow me to ignore the TopConnectorZone
		/// </summary>
		/// <param name="sender">EventHandler delegate required code</param>
		/// <param name="e">EventHandler delegate required code</param>
		protected new void OnResized(object sender, EventArgs e) {
			int RectStartX = 5;
			int RectStartY = Height - 10;
			int RectWidth = 15;
			int RectHeight = 10;

			BottomConnectorZone = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);

			OutlineRectangle = new Rectangle(0, 7, DisplayRectangle.Width, DisplayRectangle.Height - 14);
		}

		/// <inheritdoc />
		public override void ConnectNext(int NextId) {

		}

		/// <inheritdoc />
		public override void DisconnectNext() {

		}

		/// <inheritdoc />
		public override void DrawMe(object sender, PaintEventArgs e) {
			Graphics GFX = e.Graphics;
			using (Pen P = new Pen(Color.Black, 2)) {
				GFX.DrawRectangle(P, this.OutlineRectangle);
				//P.Color = Color.Red;							// No top connector
				//GFX.DrawRectangle(P, this.TopConnectorZone);
				P.Color = Color.Blue;
				GFX.DrawRectangle(P, this.BottomConnectorZone);
			}
		}

	}

}

