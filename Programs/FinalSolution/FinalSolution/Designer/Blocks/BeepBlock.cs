using System;
using System.Drawing;

namespace Solution.Designer.Blocks {

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class BeepBlock : BaseBlock {

        /// <inheritdoc />
        public BeepBlock() {
            Code = "System.Console.Beep();" + Environment.NewLine;
            Icon = Properties.Resources.Beep;
            IconSize = new Size(100, 100);
            IconLocation = new Point(Width / 2 - IconSize.Width / 2, Height / 2 - IconSize.Height / 2);
        }

    }

}