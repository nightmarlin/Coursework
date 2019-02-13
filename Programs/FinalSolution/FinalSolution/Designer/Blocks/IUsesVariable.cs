using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Designer.Blocks {

	/// <summary>
	/// Denotes an action block that can take a variable reference
	/// </summary>
	public interface IUsesVariable {

		/// <summary>
		/// The rectangle area to draw the connector at
		/// </summary>
		Rectangle VarConnectorZone { get; set; }

		/// <summary>
		/// The id of the VarRefBlock we're connected to
		/// </summary>
		int VarBlockId { get; set; }

	}
}
