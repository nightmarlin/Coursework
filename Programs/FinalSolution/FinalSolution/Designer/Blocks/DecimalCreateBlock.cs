using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    /// <inheritdoc />
    public class DecimalCreateBlock : VarCreateBlock {

        /// <inheritdoc />
        /// <summary>
        /// Allows for the declaration of a decimal type variable
        /// </summary>
        public DecimalCreateBlock() : base(typeof(decimal)) {
            Icon = Properties.Resources.Decimal;
            
            var TT = new ToolTip();
            TT.SetToolTip(this, TaH.DecimalCreateBlockTooltip);
        }

        /// <inheritdoc />
        protected override bool ValidateValue(out object Result) {
            
            var Success = decimal.TryParse(ValueBox.Text, out var NewResult);

            if (Success) {
                Result = NewResult;
                return true;
            }

            Result = null;
            return false;
        }

    }

}