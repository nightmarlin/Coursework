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

        /// <summary>
        /// Makes a connection to the parent block
        /// </summary>
        /// <param name="NewParent">Gives a reference to the parent block</param>
        public override void ConnectUpwards(BaseBlock NewParent) { }

        //
        public override void ConnectDownwards(BaseBlock ChildToAdd) { }

        //
        public override void DisconnectParent() { }

        //
        public override void DisconnectChild(BaseBlock ChildToRemove) { }

        //
        public override void DrawMe(object sender, PaintEventArgs e) {
            Graphics GFX = e.Graphics;
            using (Pen P = new Pen(Color.Black, 2)) {
                GFX.DrawRectangle(P, this.OutlineRectangle);
                P.Color = Color.Red;
                GFX.DrawRectangle(P, this.TopConnector);
                P.Color = Color.Blue;
                GFX.DrawRectangle(P, this.BottomConnector);
            }
        }

        //
        public override string GetCode() {
            return "";
        }

    }

}
