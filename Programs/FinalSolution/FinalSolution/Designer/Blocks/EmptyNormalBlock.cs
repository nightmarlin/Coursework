using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    /// <summary>
    /// An empty block, for testing purposes
    /// </summary>
    class EmptyNormalBlock : BaseBlock {

        /// <inheritdoc />
        public EmptyNormalBlock() : base() {
            Code = "// Empty Block";
        }

        /// <inheritdoc />
        public override void ConnectNext(int NextId) { }

        /// <inheritdoc />
        public override void DisconnectNext() { }

        /// <inheritdoc />
        public override void DrawMe(object sender, PaintEventArgs e) {
            Graphics GFX = e.Graphics;
            using (var P = new Pen(Color.Black, 2)) {
                GFX.DrawRectangle(P, OutlineRectangle);
                P.Color = Color.Red;
                GFX.DrawRectangle(P, TopConnectorZone);
                P.Color = Color.Blue;
                GFX.DrawRectangle(P, BottomConnectorZone);
            }
        }

    }
}
