using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Solution.Build;
using Solution.Debugger;
using Solution.Designer.Blocks;
using Solution.Welcome;

namespace Solution.Designer {

	/// <inheritdoc />
	/// <summary>
	/// The form upon which designmentination occurs 
	/// </summary>
	public partial class FrmDesigner : Form {

		/// <summary>
		/// DD/MM/YYYY HH:mm|Disk:\File\Path\Project.bs
		/// </summary>
		public string FileInfo = "";

		/// <summary>
		/// The parent form
		/// </summary>
		public FrmWelcome _ParentFrmWelcome;

		#region Startup
		
		/// <inheritdoc />
		public FrmDesigner(FrmWelcome ParentFrmWelcome = null) {
			InitializeComponent();
			//Connections = new Dictionary<BaseBlock, BaseBlock>();

			PnlCommandPalette.Hide();
			
			SContainer_Workspace.Panel2.Paint += DrawLinks;
			SContainer_Workspace.Panel2.Refresh();
			
			MovementTicker = new Timer {
				Interval = 10,
				Enabled = false
			};
			MovementTicker.Tick += DoMove;

			_ParentFrmWelcome = ParentFrmWelcome;

			BlockTree.NodeMouseDoubleClick += AddBlock;
			BlockTree.KeyPress += BlockTree_KeyPress;

			TxtCommandPaletteSearch.TextChanged += (S, E) => {
				DoSearch();
			};
			BtnHideCommandPalette.Click += (S, E) => {
				TxtCommandPaletteSearch.Text = "";
				PnlCommandPalette.Hide();
			};
			KeyUp += OnKeyRelease;
			LViewSearchResults.ItemActivate += LViewSearchResults_Activated;

			SContainer_Workspace.Panel2.SuspendLayout();
			/*{
				var VarBlock = new DeclareVarBlock {
					Location = new Point(300, 10),
					Id = (int) BasicBlockIds.Starter,
					Size = new Size(200, 100),
					TabIndex = (int) BasicBlockIds.Starter
				};
				
				VarBlock.MouseDown += Block_OnMouseDown;
				VarBlock.MouseUp += Block_OnMouseUp;

				SContainer_Workspace.Panel2.Controls.Add(VarBlock);
			}*/
			
			{
				var StartBlock = new StartBlock {
					Location = new Point(10, 10),
					Id = (int) BasicBlockIds.Starter,
					Size = new Size(100, 100),
					TabIndex = (int) BasicBlockIds.Starter
				};
				StartBlock.Name = StartBlock.GetType().Name + StartBlock.Id;

				StartBlock.MouseDown += Block_OnMouseDown;
				StartBlock.MouseUp += Block_OnMouseUp;

				SContainer_Workspace.Panel2.Controls.Add(StartBlock);
			}

			{
				var DeclarationBlock = new VarDeclareBlock {
					Location = new Point(SContainer_Workspace.Panel2.Width - 210, 10),
					Id = (int) BasicBlockIds.Variable,
					Size = new Size(100, 100),
					TabIndex = (int) BasicBlockIds.Variable
				};
				DeclarationBlock.Name = DeclarationBlock.GetType().Name + DeclarationBlock.Id;

				DeclarationBlock.MouseDown += Block_OnMouseDown;
				DeclarationBlock.MouseUp += Block_OnMouseUp;

				SContainer_Workspace.Panel2.Controls.Add(DeclarationBlock);
			}
			

			SContainer_Workspace.Panel2.ResumeLayout(true);

		}

		private void BtnExit_Click(object Sender, EventArgs E) {

			_ParentFrmWelcome?.Show(); // Show parent form
			

			Hide(); // Become invisible
			Dispose(); // Clean up
			
		}

		#endregion

		#region Block Tree
		
		private int NextId = (int) BasicBlockIds.First; 

		private void BlockTree_KeyPress(object sender, KeyPressEventArgs e) {

			if (BlockTree.SelectedNode == null) return; // Do nothing

			if ((char)Keys.Return == e.KeyChar) { // If it's enter, select that block
				AddBlock(null, new TreeNodeMouseClickEventArgs(BlockTree.SelectedNode, MouseButtons.Left, 2, 0, 0));
			}
		}

		private void AddBlock(object S, TreeNodeMouseClickEventArgs E) { // Add a block from the blockTree

			if (E.Node.Nodes.Count != 0) return; // If the node has children, do nothing
			
				
			/* var NewBlock = new EmptyNormalBlock {
			 *     // Add New Block
			 *	   Id = NextId,
			 *     Size = new Size(200, 100),
			 *     TabIndex = NextId
			 * };
			 * NewBlock.Name = NewBlock.GetType().Name + NextId;
			 */

			BaseBlock NewBlock;

			switch (E.Node.Name) { // Create a block based on the user's selection
				case "DecimalSetBlock": {
					NewBlock = GenericBlockConstructor<DecimalCreateBlock>();
					break;
				}

				case "VariableRefBlock": {
					NewBlock = GenericBlockConstructor<VarRefBlock>();
					break;
				}

				case "ConstantBlocks": {
					NewBlock = GenericBlockConstructor<EmptyNormalBlock>();
					break;
				}

				case "BeepBlock": {
					NewBlock = GenericBlockConstructor<BeepBlock>();
					break;
				}

				default: {
					MessageBox.Show($@"Could not spawn a block of type {E.Node.Text}");
					return;
				}
			}
			
			AddBlock(NewBlock); // Add it

		}

		private BaseBlock GenericBlockConstructor<T>() where T : BaseBlock, new() { // Generic constructor

			while (true) {
				var AnotherHasThisId = false;

				foreach (var Panel2Control in SContainer_Workspace.Panel2.Controls) {
					if (!(Panel2Control is BaseBlock B)) continue;

					if (B.Id != NextId) continue;

					AnotherHasThisId = true;
					break;

				}

				if (AnotherHasThisId) {
					NextId++;
				} else {
					break;
				}
			}
			
			var NewName = typeof(T).Name + NextId;

			var ToAdd = new T {
				// Add New Block
				Name = NewName,
				Id = NextId,
				Size = new Size(200, 100),
				TabIndex = NextId
			};
			
			ToAdd.MouseDown += Block_OnMouseDown;
			ToAdd.MouseUp += Block_OnMouseUp;

			NextId++;

			if (ToAdd is VarCreateBlock VC) { // Make it small
				VC.Height = 60;
				VC.NameBox.Text = ToAdd.Name;
				VC.ValidateButton.Hide();
			}

			if (ToAdd is VarCreateBlock VCB) {
				VCB.OnVarNameChanged += UpdateVarNameList;
			}

			return ToAdd;
		}

		// ReSharper disable once SuggestBaseTypeForParameter
		private void AddBlock(BaseBlock ToAdd) { // Add block to panel

			var X = SContainer_Workspace.Panel2.Width / 2 - ToAdd.Width / 2; // Add in the middle
			var Y = SContainer_Workspace.Panel2.Height / 2 - ToAdd.Height / 2;

			ToAdd.Location = new Point(X, Y);

			SContainer_Workspace.Panel2.SuspendLayout(); // Stop layout
			SContainer_Workspace.Panel2.Controls.Add(ToAdd); // Add the block
			SContainer_Workspace.Panel2.ResumeLayout(true); // Continue

			ToAdd.Refresh(); // Redraw

		}

		#endregion

		#region Block Movement

		private readonly Timer MovementTicker; // Move block to mouse each tick
		private Point Offset; // Point mouse clicked on
		private BaseBlock ToMove; // Block to move

		/// <summary>
		/// Start Movement
		/// </summary>
		/// <param name="S"></param>
		/// <param name="E"></param>
		public void Block_OnMouseDown(object S, MouseEventArgs E) {
			if (!(S is BaseBlock Block)) return; // Do nothing if it isn't a baseBlock
			//Debug.WriteLine("Mouse Down");

			Block.BringToFront(); // Layering

			if (Deleting) { // Delete
				DeleteBlock(Block);
				return;
			} else if (Copying) { // Copy
				CopyBlock(Block);
				return;
			}

			if (Block.RectangleToScreen(Block.TopConnectorZone).Contains(MousePosition)) { // Top connector
				TopConnector_Clicked(Block);
				return;
			}
			if (Block.RectangleToScreen(Block.BottomConnectorZone).Contains(MousePosition)) { // Bottom Connector
				BottomConnector_Clicked(Block);
				return;
			}

			var RTS = Block.RectangleToScreen(Block.DisplayRectangle); // Get the RTS to keep things relative to the screen

			Offset = new Point(MousePosition.X - RTS.Left,
			                   MousePosition.Y - RTS.Top); // New mouse offset
			
			ToMove = Block; // Pick up the block
			MovementTicker.Start(); // Start moving
			SContainer_Workspace.Panel2.Refresh(); // Redraw
		}

		/// <summary>
		/// Finish movement
		/// </summary>
		/// <param name="S"></param>
		/// <param name="E"></param>
		public void Block_OnMouseUp(object S, MouseEventArgs E) { // Stop moving
			if (!(S is BaseBlock)) return; // PatternMatchingIsAUsefulTool
			//Debug.WriteLine("Mouse Up");

			MovementTicker.Stop();
			ToMove = null; // Drop the block

			SContainer_Workspace.Panel2.Refresh(); // Redraw
		}

		private void DoMove(object S, EventArgs E) { // Go to mouse
			
			var MousePos = SContainer_Workspace.Panel2.PointToClient(MousePosition); // Get mouse position

			ToMove.Left = MousePos.X - Offset.X; // Move block there and adjust by offset
			ToMove.Top = MousePos.Y - Offset.Y;

		}

		#endregion

		#region Connection Management

		//private Dictionary<BaseBlock, BaseBlock> Connections; // Store the links
		
		private BaseBlock First; // The blocksss
		private BaseBlock Second;

		private void TopConnector_Clicked(BaseBlock Block) { // Top connector

			if (!(Second is null) | Block is StartBlock) { // If there is already a second block, don't override it
				
				if (Block == Second) { // Click the same connector to deselect it
					// Debug.WriteLine($"Second: {Second.Name}");
					Block.ConnectorSelected = null;
					Block.Refresh();
					Second = null;
				}

				return;
			}

			Block.ConnectorSelected = true; // top connector selected
			Block.Refresh(); // redraw

			if (First is null) { // wait for the next connection
				Second = Block;
				
			} else { // we're ready. let's go
				Second = Block;
				MakeConnection();
			}
		}

		private void BottomConnector_Clicked(BaseBlock Block) { // Like top connectors, but for bottoms
			
			if (!(First is null)) {
				if (Block == First) {
					Block.ConnectorSelected = null;
					Block.Refresh();
					First = null;
				}
				return;
			}

			Block.ConnectorSelected = false;
			Block.Refresh();
			
			if (Second is null) {
				First = Block;
			} else {
				First = Block;
				MakeConnection();
			}
		}

		private void VariableConnectorClicked() { // TODO
			
		}
		
		[SuppressMessage("ReSharper", "LocalVariableHidesMember")] // ReSharper annoyed me
		private void MakeConnection() { // Everything is in place. Create the link
		
			this.First.ConnectorSelected = null; // No more illuminated connectors
			this.Second.ConnectorSelected = null;

			var First = this.First; // Localise variables
			var Second = this.Second;

			this.First = null; // Empty "this." vars
			this.Second = null;
			
			if (First == Second) { // Bad self-connection. Bad
				First.Refresh();
				Second.Refresh();
				MessageBox.Show("You can't do that!", "B#", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if ((Second is VarCreateBlock) && !(First is VarDeclareBlock || First is VarCreateBlock)
			    || (!(Second is VarCreateBlock) && (First is VarDeclareBlock || First is VarCreateBlock))) {
				/*
				 * We can't allow declaration blocks and action blocks to be connected, so don't
				 */

				First.Refresh();
				Second.Refresh();
				MessageBox.Show("You can't declare a variable where you would run code, and you cant run code where you would declare a variable!",
				                "B#", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			//Connections.Add(First, Second); // Make the link
			First.ConnectNext(Second.Id); // Setup for the next block

			SContainer_Workspace.Panel2.Refresh(); // redraw
			
			First.Invalidate(); // redraw
			Second.Invalidate(); // redraw

		}

		private bool Deleting;
		private void DeleteToolStripMenuItem_Click(object S = null, EventArgs E = null) {
			Deleting = !Deleting;
			DeleteToolStripMenuItem.BackColor = Deleting
				? Color.BurlyWood
				: Color.FromKnownColor(KnownColor.ControlDark);
			DeleteToolStripMenuItem.Text = Deleting
				? "< Deleting >"
				: "Delete";
			
		}

		private void DeleteBlock(BaseBlock Block) { // TODO
			
			DeleteToolStripMenuItem_Click();

			if (Block is StartBlock) {
				MessageBox.Show("Cannot delete this type of block", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			Block.DisconnectNext();

			//var FeaturedConnections = Connections.Select(C => C.Key == Block);
			
			//foreach (var FC in FeaturedConnections) {
			//	Debug.WriteLine(FC);
			//}
			//Debug.WriteLine("");


		}

		private bool Copying;
		private void CopyBlock(BaseBlock ToCopy) { // TODO
			
		}


		#endregion

		#region Drawing

		private void DrawLinks(object S, PaintEventArgs E) { // Draw the connections
			var GFX = E.Graphics; // Better name

			foreach (var C in SContainer_Workspace.Panel2.Controls) {
				if (!(C is BaseBlock Block)) continue;
				if (Block.NextBlockId == (int) BasicBlockIds.NoConnection) continue;

				var Next = GetBlockById(Block.NextBlockId);

				if (Next is null || Next == ToMove || Block == ToMove) continue;

				
				var BBCZ = Block.BottomConnectorZone.Location;

				var P1 = SContainer_Workspace.Panel2 // First point on First Line
				                             .PointToClient(Block.PointToScreen(new Point(BBCZ.X,
				                                                                       BBCZ.Y +
				                                                                       Block.BottomConnectorZone.Height)
				                                                            )
				                                           );

				var P2 =
					SContainer_Workspace.Panel2.PointToClient(Next.PointToScreen(Next.TopConnectorZone
					                                                                 .Location)); // Second point on First Line

				GFX.DrawLine(Pens.Black, P1, P2);

				P1.X = P1.X + Block.BottomConnectorZone.Width; // First point on Second Line
				P2.X = P2.X + Next.TopConnectorZone.Width; // Second point on Second Line

				GFX.DrawLine(Pens.Black, P1, P2);

				if (!(Block is IUsesVariable VBlock)) continue;

				if (VBlock.VarBlockId == (int) BasicBlockIds.NoConnection) continue;

				Next = GetBlockById(VBlock.VarBlockId);

				if (Next is null || Next == ToMove) continue;
				if (!(Next is VarRefBlock VNext)) continue;


				var VBVZ = VBlock.VarConnectorZone.Location;

				P1 = SContainer_Workspace.Panel2 // First point on First Line
				                         .PointToClient(Block.PointToScreen(new Point(VBVZ.X +
				                                                                      VBlock.VarConnectorZone.Width,
				                                                                      VBVZ.Y)
				                                                           )
				                                       );
				P2 =
#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
					SContainer_Workspace.Panel2.PointToClient(VNext.PointToScreen(VNext.InputConnector // TODO
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
					                                                                 .Location)); // Second point on First Line

			}

			//foreach (var Connection in Connections) {

			//	if (Connection.Key == ToMove || Connection.Value == ToMove) continue;

			//	var CK = Connection.Key; // Compactness
			//	var CV = Connection.Value;
			//	var CR = Connection.Key.BottomConnectorZone.Location;
				
			//	var P1 = SContainer_Workspace.Panel2 // First point on First Line
			//	                             .PointToClient(CK.PointToScreen(new Point(CR.X,
			//	                                                                       CR.Y +
			//	                                                                       CK.BottomConnectorZone.Height)
			//	                                                             )
			//	                                            );
				
			//	var P2 = SContainer_Workspace.Panel2.PointToClient(CV.PointToScreen(CV.TopConnectorZone.Location)); // Second point on First Line
				
			//	GFX.DrawLine(Pens.Black, P1, P2);

			//	P1.X = P1.X + CK.BottomConnectorZone.Width; // First point on Second Line
			//	P2.X = P2.X + CV.TopConnectorZone.Width; // Second point on Second Line

			//	GFX.DrawLine(Pens.Black, P1, P2);

			//}
		}


		#endregion

		#region Save, Build and Generic Functions

		private void SelectToolboxToolStripMenuItem_Click(object sender, EventArgs e) {
			BlockTree.Focus(); // CTRL + {SPACE} = Focus blockTree
		}

		private void AboutBlocksToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show(TaH.FrmDesignerBlockHelpText, "B#", MessageBoxButtons.OK, MessageBoxIcon.Information);
			// Show MessageBox
		}

		private void AboutTheWorkspaceToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show(TaH.FrmDesignerWorkspaceHelpText, "B#", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
			Save(); // Save it
		}

		private bool Save() { // TODO
			return GetSaveFilePath() && Saving.Save.SaveProject(this);
		}

		private bool GetSaveFilePath() {
			if (FileInfo == "") {
				if (!UpdateSavePath()) { // get new save path
					return false;
				}
			}

			FileInfo = $"{DateTime.Now:g}|" + FileInfo.Split('|')[1]; // update the date

			if (!Properties.Settings.Default.RecentItems.Contains(FileInfo)) {// If it's not already in there
				Properties.Settings.Default.RecentItems.Add(FileInfo); // Add it
			} else {
				Properties.Settings.Default.RecentItems.Remove(FileInfo); // otherwise remove it
				Properties.Settings.Default.RecentItems.Add(FileInfo); // and add it again
			}

			if (Properties.Settings.Default.RecentItems.Count > 5) {
				Properties.Settings.Default.RecentItems.RemoveAt(0); // Remove any items that would make the list longer than 5 items
			}

			Properties.Settings.Default.Save(); // SAVE

			return true; // success
		}

		private bool UpdateSavePath() {
			using (var SFD = new SaveFileDialog() { // Get the file name and path
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), // Start in docs
				Filter = "BSharp Files (*.bs)|*.bs", // Only show .bs files
				DefaultExt = "bs", // Save as a .bs file
				FileName = "My Project.bs" // Default file name
			}) {
				var Complete = SFD.ShowDialog();

				if (Complete != DialogResult.OK) { // No path was specified
					MessageBox.Show("No location specified. Cannot save.", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false; // failure
				}
				
				FileInfo = $"{DateTime.Now:g}|"; // Set the date last saved
				FileInfo += SFD.FileName; // Add the filepath

				Name = FileInfo.Split('|')[1].Split('\\')[FileInfo.Split('|')[1].Split('\\').Length - 1];
				return true; // success
			}
		}

		private void DebugToolStripMenuItem_Click(object sender, EventArgs e) {
			// Save

			if (!Save()) {
				MessageBox.Show("You have to save your work in order to run it");
				return;
			}

			// Get Code

			var CS = BuildToCompiledStruct();

			if (!CS.HasValue) return;

			// Build			

			var Program = Properties.Resources.ProjectTemplate;

			Builder BDR;

			using (var CDP = CodeDomProvider.CreateProvider("C#")) {
				BDR = CDP.IsValidIdentifier(Name) 
					? new Builder(Name) 
					: new Builder("YourProject");
			}


			Program = Program.Replace("//<VariableSet>", CS.Value.Vars) // Insert code
			                 .Replace("//<Program>", CS.Value.Actions);

			/*
			 * 1) Pass generated code to builder
			 * 2) Builder does the buildy thing
			 * 3) Receive exe path
			 */

			var FilePath = FileInfo.Split('|')[1];

			var Path = System.IO.Path.GetDirectoryName(FilePath); // 3

			var Success = BDR.Build(Program, Path); // 1 // 2

			if (Success) {
				MessageBox.Show("Compilation was successful", "B#", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} else {
				MessageBox.Show("Compilation was unsuccessful", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			// Run

			/*
			 * Open FrmDebugger with the exe output from earlier
			 */
			
			var EXEPath = $"{Path}\\{Name}.exe";

			if (!File.Exists(EXEPath)) EXEPath = $"{Path}\\YourProject.exe";

			var Debugger = new FrmDebugger(EXEPath, this);

			Debugger.VisibleChanged += (S, E) => {
				if (S is FrmDebugger D && D.Visible) return;
				Show();
			};

			Debugger.Closed += (S, E) => Show();
			
			Debugger.Show();

			Hide();

		}

		private struct CompiledStruct {

			/// <summary>
			/// The variable
			/// </summary>
			public string Vars;

			public string Actions;

		}

		private CompiledStruct? BuildToCompiledStruct() {
			var CS = new CompiledStruct();

			
			// Generate code

			/* 1) Find the StartBlock
			 * 2) Iterate through the connections and build up the code
			 * 3) Find the VarDeclareBlock
			 * 4) Iterate through those connections and build up variable declarations
			 */

			// 1
			var Actions = new StringBuilder("");
			var HasNext = true;
			var CurrentBlock = GetBlockById((int) BasicBlockIds.Starter);

			var IteratedThrough = new List<BaseBlock>();

			while (HasNext) { // 2

				if (IteratedThrough.Contains(CurrentBlock)) {
					MessageBox.Show("There is a circular reference in your code. " +
					                "This would cause the compiler to enter an infinite loop. " +
					                "Please remove the loop and try again", "B#", MessageBoxButtons.OK,
					                MessageBoxIcon.Error);
					return null;
				}

				Actions.AppendLine(CurrentBlock.Code + Environment.NewLine);
				IteratedThrough.Add(CurrentBlock);

				if (CurrentBlock.NextBlockId == (int) BasicBlockIds.NoConnection) {
					HasNext = false;
				} else {
					CurrentBlock = GetBlockById(CurrentBlock.NextBlockId);
				}

			}

			// 3
			var Vars = new StringBuilder("");
			HasNext = true;
			CurrentBlock = GetBlockById((int) BasicBlockIds.Variable);

			while (HasNext) { // 4

				if (IteratedThrough.Contains(CurrentBlock)) {
					MessageBox.Show("There is a circular reference in your code. " +
					                "This would cause the compiler to enter an infinite loop. " +
					                "Please remove the loop and try again", "B#", MessageBoxButtons.OK,
					                MessageBoxIcon.Error);
					return null;
				}

				Actions.AppendLine(CurrentBlock.Code + Environment.NewLine);
				IteratedThrough.Add(CurrentBlock);
				
				if (CurrentBlock.NextBlockId == (int) BasicBlockIds.NoConnection) {
					HasNext = false;
				} else {
					CurrentBlock = GetBlockById(CurrentBlock.NextBlockId);
				}

			}

			CS.Actions = Actions.ToString();
			CS.Vars = Vars.ToString();

			return CS;
		}

		private BaseBlock GetBlockById(int Id) {

			if (Id == -1) return null;

			foreach (var Control in SContainer_Workspace.Panel2.Controls) {
				if (!(Control is BaseBlock Block)) continue;
				if (Block.Id == Id) {
					return Block;
				}
			}

			return null;
		}

		

		private void CommandPaletteToolStripMenuItem_Click(object sender, EventArgs e) { // Show the command palette
			PnlCommandPalette.Show();
			TxtCommandPaletteSearch.Focus();
		}

		private void DoSearch() { // Search on text update

			if (TxtCommandPaletteSearch.Text == "") { // Don't search if empty
				LViewSearchResults.Clear();
				return;
			}

			var Results = new List<ToolStripItem>(); // Scoping
			
			foreach (var TSI in MainMenu.Items) { // Iterate through the main menu items
				if (!(TSI is ToolStripMenuItem Item)) continue; // PATTERN MATCHING

				foreach (var I in Item.DropDownItems) { // Iterate through the dropdowns
					if (!(I is ToolStripMenuItem Option)) continue; // PATTERN MATCHING

					if (Option.Text.ToLower().Contains(TxtCommandPaletteSearch.Text.ToLower())) {
						Results.Add(Option); // Fuzzy search for results
					}
				}
			}

			// show results on list box

			LViewSearchResults.Clear(); // Empty box

			foreach (var Result in Results) {
				// Fill box
				LViewSearchResults.Items.Add(new ListViewItem(new [] {Result.Text, Result.Name}));
			}


		}

		private void LViewSearchResults_Activated(object S, EventArgs E) { // On selection of a result
			var NameToFind = LViewSearchResults.SelectedItems[0].SubItems[1].Text;

			var Results = MainMenu.Items.Find(NameToFind, true); // Quick search
			
			PnlCommandPalette.Hide();
			TxtCommandPaletteSearch.Text = "";

			Results[0].PerformClick(); // No need to null check cos we know it's there
		}

		private void OnKeyRelease(object S, KeyEventArgs E) { 
			if (E.KeyData == Keys.Escape) { 
				PnlCommandPalette.Hide(); // Hide on {ESCAPE} keypress
				TxtCommandPaletteSearch.Text = "";
			}
		}

		private List<string> VarNamesList = new List<string>();

		/// <summary>
		/// Updates the 
		/// </summary>
		public void UpdateVarNameList(object S, EventArgs E) {
			VarNamesList = new List<string>();

			foreach (var Panel2Control in SContainer_Workspace.Panel2.Controls) {
				if (!(Panel2Control is VarCreateBlock VCB)) continue;

				VarNamesList.Add(VCB.VarName);

			}

			foreach (var Panel2Control in SContainer_Workspace.Panel2.Controls) {
				if (!(Panel2Control is VarRefBlock VRB)) continue;

				VRB.UpdateVarNames(VarNamesList);

			}

		}
		#endregion

		
	}
}
