using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Newtonsoft.Json;

using Solution.Designer;
using Solution.Designer.Blocks;

namespace Solution.Saving {

	/// <summary>
	/// oad a bs save from the fie system
	/// </summary>
	public static class Load {

		private static readonly char[] Digits = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

		/// <summary>
		/// Load a FrmDesigner with blocks stored in the .bs file
		/// </summary>
		/// <param name="Path">The path to the .bs file</param>
		/// <returns>A reconstructed FrmDesigner</returns>
		public static FrmDesigner LoadFromFile(string Path) {

			if (!File.Exists(Path) || !Path.EndsWith(".bs")) {
				MessageBox.Show("An invalid path was provided.", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}


			var Contents = ReadText(Path);


			var BlockSet = Contents.Select(JsonConvert.DeserializeObject<DeserializedProps>)
			                       .Select(RebuildBlock)
			                       .Where(Rebuilt => !(Rebuilt is null))
			                       .ToList();

			var Designer = new FrmDesigner();

			Designer.SContainer_Workspace.Panel2.Controls.RemoveByKey("StartBlock1");
			Designer.SContainer_Workspace.Panel2.Controls.RemoveByKey("VarDeclareBlock0");

			foreach (var Block in BlockSet) {

				

				if (Block is VarCreateBlock VCB) {
					VCB.OnVarNameChanged += Designer.UpdateVarNameList;
				}
				
				Block.MouseDown += Designer.Block_OnMouseDown;
				Block.MouseUp += Designer.Block_OnMouseUp;

				Designer.SContainer_Workspace.Panel2.SuspendLayout();
				Designer.SContainer_Workspace.Panel2.Controls.Add(Block);
				Designer.SContainer_Workspace.Panel2.ResumeLayout();
			}

			Designer.FileInfo = $"{DateTime.Now:g}|{Path}";
			Designer.UpdateVarNameList(null, null);


			return Designer;
		}

		private static IEnumerable<string> ReadText(string Path) {
			return File.ReadAllLines(Path);
		}

		private static BaseBlock RebuildBlock(DeserializedProps Props) {

			var TypeName = Props.Name.Trim(Digits);

			BaseBlock BlockToReturn = null;

			switch (TypeName) {

				case "StartBlock": {
					BlockToReturn = new StartBlock();
					break;
				}

				case "VarDeclareBlock": {
					BlockToReturn = new VarDeclareBlock();
					break;
				}

				case "BeepBlock": {
					BlockToReturn = new BeepBlock();
					break;
				}

				case "EmptyNormalBlock": {
					BlockToReturn = new EmptyNormalBlock();
					break;
				}

				case "DecimalCreateBlock": {
					BlockToReturn = new DecimalCreateBlock {
						Value = Props.Value,
						VarName = Props.VarName,
					};
					break;
				}

				case "VarRefBlock": {
					BlockToReturn = new VarRefBlock {
						VarName = Props.VarName,
					};
					break;
				}

				default: {
					MessageBox.Show("Unable to build the following Block Type - Definition Missing:" +
					                $"{Environment.NewLine}{TypeName}", "B#", MessageBoxButtons.OK,
					                MessageBoxIcon.Error);
					return null;
				}
			}

			BlockToReturn.Location = Props.Location;
			BlockToReturn.Code = Props.Code;
			BlockToReturn.Name = Props.Name;
			BlockToReturn.ConnectorSelected = Props.ConnectorSelected;
			BlockToReturn.TopConnectorZone = Props.TopConnectorZone;
			BlockToReturn.BottomConnectorZone = Props.BottomConnectorZone;
			BlockToReturn.OutlineRectangle = Props.OutlineRectangle;
			BlockToReturn.Size = Props.Size;
			BlockToReturn.Id = Props.Id;
			BlockToReturn.NextBlockId = Props.NextBlockId;

			return BlockToReturn;
		}

	}

	/// <summary>
	/// Provides a frame for all the properties to be stored after deserialization
	/// </summary>
	[SuppressMessage("ReSharper", "UnassignedField.Global")]
	public struct DeserializedProps {
		

		/// <summary>
		/// The code
		/// </summary>
		public string Code;

		/// <summary>
		/// The Name
		/// </summary>
		public string Name;

		/// <summary>
		/// Whether the connector was selected or not
		/// </summary>
		public bool? ConnectorSelected;

		/// <summary>
		/// The TopConnector
		/// </summary>
		public Rectangle TopConnectorZone;

		/// <summary>
		/// The BottomConnector
		/// </summary>
		public Rectangle BottomConnectorZone;

		/// <summary>
		/// The Outline
		/// </summary>
		public Rectangle OutlineRectangle;

		/// <summary>
		/// Var connector zone
		/// </summary>
		public Rectangle VarConnectorZone;

		/// <summary>
		/// The Block's UID
		/// </summary>
		public int Id;

		/// <summary>
		/// Next Block's UID
		/// </summary>
		public int NextBlockId;

		/// <summary>
		/// Variable Block Id
		/// </summary>
		public int VarBlockId;

		/// <summary>
		/// Size of the block
		/// </summary>
		public Size Size;

		/// <summary>
		/// Location
		/// </summary>
		public Point Location;

		/// <summary>
		/// Stored value
		/// </summary>
		public object Value;

		/// <summary>
		/// Variable name
		/// </summary>
		public string VarName;


	}

}
