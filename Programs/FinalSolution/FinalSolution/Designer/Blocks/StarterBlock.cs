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
			Icon = Properties.Resources.StartButton;
			IconSize = new Size(100, 100);
			IconLocation = new Point(Width / 2 - IconSize.Width, Height / 2 - IconSize.Height);
		}
		
		/// <summary>
		/// Edits the OnResized function to allow me to ignore the TopConnectorZone
		/// </summary>
		/// <param name="sender">EventHandler delegate required code</param>
		/// <param name="e">EventHandler delegate required code</param>
		protected new void OnResized(object sender, EventArgs e) {
			const int RectStartX = 5;
			const int RectWidth = 15;
			const int RectHeight = 10;
			var RectStartY = Height - 10;

			BottomConnectorZone = new Rectangle(RectStartX, RectStartY, RectWidth, RectHeight);

			OutlineRectangle = new Rectangle(0, 7, DisplayRectangle.Width, DisplayRectangle.Height - 14);
		}

		/// <inheritdoc />
		/// <summary>Doesn't draw the TopConnector</summary>
		public override void DrawMe(object S, PaintEventArgs E) {
			TopConnectorZone = new Rectangle(0, 0, 0, 0);
			
			var GFX = E.Graphics;
			using (var P = new Pen(Color.Black, 2)) {
				GFX.DrawRectangle(P, OutlineRectangle);
				//P.Color = Color.Red;							// No top connector
				//GFX.DrawRectangle(P, this.TopConnectorZone);
				P.Color = Color.DarkBlue;
				GFX.DrawRectangle(P, BottomConnectorZone);
				if (NextBlockId != (int) BasicBlockIds.NoConnection) {
					GFX.FillRectangle(Brushes.DarkBlue, BottomConnectorZone);
				}

				if (ConnectorSelected == false) {
					GFX.FillRectangle(Brushes.BurlyWood, BottomConnectorZone);
				}
			}

			if (!(Icon is null)) {
				// Draw the icon
				GFX.DrawImage(Icon, IconLocation.X, IconLocation.Y, IconSize.Width, IconSize.Height);
			}
			
		}

	}

}

