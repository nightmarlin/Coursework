using System;
using System.Drawing;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {
	
	/// <inheritdoc />
	/// <summary>
	/// Block that indicates the start of a main process, subroutine or function. 
	/// Does not possess a top connector, it is always the parent.
	/// </summary>
	public class StartBlock : BaseBlock {

		/// <inheritdoc />
		public StartBlock() {
			Code = "// Start block";
			Paint -= base.DrawMe;
			Paint += this.DrawMe;
		}
		
		/// <summary>
		/// Edits the OnResized function to allow me to ignore the TopConnectorZone
		/// </summary>
		/// <param name="sender">EventHandler delegate required code</param>
		/// <param name="e">EventHandler delegate required code</param>
		protected new void OnResized(object sender, EventArgs e) {
			var RectStartX = 5;
			var RectStartY = Height - 10;
			var RectWidth = 15;
			var RectHeight = 10;

			BottomConnectorZone = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);

			OutlineRectangle = new Rectangle(0, 7, DisplayRectangle.Width, DisplayRectangle.Height - 14);
		}

		/// <summary>Doesn't draw the TopConnector</summary>
		public new void DrawMe(object S, PaintEventArgs E) {
			var GFX = E.Graphics;
			using (var P = new Pen(Color.Black, 2)) {
				GFX.DrawRectangle(P, OutlineRectangle);
				//P.Color = Color.Red;							// No top connector
				//GFX.DrawRectangle(P, this.TopConnectorZone);
				P.Color = Color.Blue;
				GFX.DrawRectangle(P, BottomConnectorZone);
				if (NextBlockId != (int) BasicBlockIds.NoConnection) {
					GFX.FillRectangle(Brushes.Blue, BottomConnectorZone);
				}

				if (ConnectorSelected == false) {
					GFX.FillRectangle(Brushes.Goldenrod, BottomConnectorZone);
				}
			}
		}

	}

}

