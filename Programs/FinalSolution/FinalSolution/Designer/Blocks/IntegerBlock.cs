using System.Drawing;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    public class DecimalBlock : BaseBlock {

        public DecimalBlock() : base() { }

        public decimal Value = 0;

        public override void ConnectUpwards(BaseBlock Block) {
            
        }

        public override void ConnectDownwards(BaseBlock Block) {
            
        }
        
        public override void DisconnectParent() {}

        public override void DisconnectChild(BaseBlock ChildToRemove) { }
        
        public override void DrawMe(object Sender, PaintEventArgs E) { }

        public override string GetCode() {
            return $"{Value:F3}";
        }
        
        
        

    }

}