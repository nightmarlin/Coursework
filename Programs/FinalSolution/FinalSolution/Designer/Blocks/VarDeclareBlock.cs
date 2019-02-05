using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    /// <inheritdoc />
    /// <summary>
    /// The root node to which all variable declarations are to be affixed
    /// </summary>
    public class VarDeclareBlock : StartBlock {

        /// <inheritdoc />
        public VarDeclareBlock() {
            Code = "// Variables ";
            Icon = Properties.Resources.Variable;
            
            var TT = new ToolTip();
            TT.SetToolTip(this, TaH.VarDeclareBlockTooltip);
        }

    }

}