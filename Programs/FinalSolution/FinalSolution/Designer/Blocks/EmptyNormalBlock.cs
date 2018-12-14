using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    class EmptyNormalBlock : BaseBlock {

        /// <summary>
        /// Constructor for the block
        /// </summary>
        public EmptyNormalBlock() : base() { }

        //
        public override void ConnectDownwards(BaseBlock ChildToAdd) { }

        //
        public override void DisconnectChild() { }

        //
        public override void DrawMe(object sender, PaintEventArgs e) {
            Graphics GFX = e.Graphics;
            using (var P = new Pen(Color.Black, 2)) {
                GFX.DrawRectangle(P, OutlineRectangle);
                P.Color = Color.Red;
                GFX.DrawRectangle(P, TopConnector);
                P.Color = Color.Blue;
                GFX.DrawRectangle(P, BottomConnector);
            }
        }

        //
        public override string GetCode() {
            return "// Empty block" + (ChildBlock is null ? "" : ChildBlock.GetCode()) + Environment.NewLine;
        }
    }
}
