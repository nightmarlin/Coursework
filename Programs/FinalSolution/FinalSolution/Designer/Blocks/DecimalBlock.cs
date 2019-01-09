using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    /// <inheritdoc cref="BaseBlock"/>
    /// <summary>
    /// A block representing a number 
    /// </summary>
    public class DecimalBlock : BaseBlock {

        /// <inheritdoc />
        public DecimalBlock() {
            Value = 0;
        }

        private decimal _value;
        /// <summary>
        /// The value of the decimal
        /// </summary>
        public decimal Value {
            get => _value;
            set {
                Code = $"{value}";
                _value = value;
            }
        }

        /// <summary></summary>
        public new void DrawMe(object Sender, PaintEventArgs E) { }
        

    }

}