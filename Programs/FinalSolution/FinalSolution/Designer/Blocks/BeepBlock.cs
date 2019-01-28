using System;

namespace Solution.Designer.Blocks {

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class BeepBlock : BaseBlock {

        /// <inheritdoc />
        public BeepBlock() {
            Code = "System.Console.Beep();" + Environment.NewLine;
        }

    }

}