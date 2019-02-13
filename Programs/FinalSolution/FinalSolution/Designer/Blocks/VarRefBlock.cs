using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    /// <inheritdoc />
    /// <summary>
    /// Allows for the referencing of variables available in the user's program
    /// </summary>
    public class VarRefBlock : BaseBlock {

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public VarRefBlock() {
            TopConnectorZone = Rectangle.Empty;
            BottomConnectorZone = Rectangle.Empty;
            Icon = Properties.Resources.Variable;
            IconSize = new Size(60, 60);
            IconLocation.X += 15;
            InputConnector = new Rectangle(0, Height / 2 - 10, 10, 20);

            SuspendLayout();

            VarNames = new ComboBox {
                Size = new Size(100, 20),
                
            };

            VarNames.Location = new Point(IconLocation.X + IconSize.Width + 10, Height / 2 - VarNames.Height / 2);
            VarNames.SelectedIndexChanged += VarNames_ItemSelectedChanged;

            Controls.Add(VarNames);

            ResumeLayout();
            
            var TT = new ToolTip();
            TT.SetToolTip(this, TaH.VariableReferenceBlockTooltip);
        }

        /// <inheritdoc />
        /// <summary>Fires the event indicating that the panel has been resized. Inheriting controls should use this in favor of actually listening to the event, but should still call <see langword="base.onResize" /> to ensure that the event is fired for external listeners.</summary>
        /// <param name="E">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnResize(EventArgs E) {

            InputConnector = new Rectangle(0, Height / 2 - 10, 10, 20);

            VarNames.Location = new Point(IconLocation.X + IconSize.Width + 10, Height / 2 - VarNames.Height / 2);
            
            IconLocation = new Point(IconLocation.X , (Height / 2) - (IconSize.Height / 2));
        }

        /// <inheritdoc />
        /// <summary>
        /// Draws the block and the side connector
        /// </summary>
        public override void DrawMe(object S, PaintEventArgs e) {
            var GFX = e.Graphics;
            using (var P = new Pen(Color.Black, 2)) {
                GFX.DrawRectangle(P, OutlineRectangle);

                P.Color = Color.Chartreuse;

                GFX.DrawRectangle(P, InputConnector);

            }

            if (!(Icon is null)) {
                // Draw the icon
                GFX.DrawImage(Icon,
                              IconLocation.X, IconLocation.Y,
                              IconSize.Width, IconSize.Height);
            }
        }

        /// <summary>
		/// The connector that allows for variable usage
		/// </summary>
        public Rectangle InputConnector;

        /// <summary>
		/// The list of all variables in project
		/// </summary>
        public ComboBox VarNames;

        /// <summary>
		/// The chosen variable name
		/// </summary>
        public string VarName { get; set; }

        /// <summary>
		/// 
		/// </summary>
		/// <param name="Names"></param>
        public void UpdateVarNames(List<string> Names) {

            if (!Names.Contains(VarName)) {
                VarName = "";
            }

            Names.ForEach(N => {
                VarNames.Items.Add(N);

            });

            VarNames.Refresh();
        }

        private void VarNames_ItemSelectedChanged(object S, EventArgs E) {
            VarName = (string) VarNames.SelectedItem;
            MessageBox.Show(VarName);
        }

    }

    

}