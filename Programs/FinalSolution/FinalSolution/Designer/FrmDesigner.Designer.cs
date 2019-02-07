using System;
using System.Windows.Forms;

namespace Solution.Designer {
	partial class FrmDesigner {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDesigner));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Declare Variables");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Starter Block");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Control", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Add");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Divide");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Empty Block");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Multiply");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Set");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Subtract");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Process", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Read Key");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Read Line");
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Input", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
			System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Beep");
			System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Write");
			System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Write Line");
			System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Output", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16});
			System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Boolean");
			System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Decimal");
			System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Integer");
			System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("String");
			System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Declare Variables", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
			System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Variable Selector");
			System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Use Variables", new System.Windows.Forms.TreeNode[] {
            treeNode23});
			System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Constants");
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ShowInCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.QuitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SelectToolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.CommandPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GetexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutTheWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SContainer_Workspace = new System.Windows.Forms.SplitContainer();
			this.BlockTree = new System.Windows.Forms.TreeView();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SContainer_Workspace)).BeginInit();
			this.SContainer_Workspace.Panel1.SuspendLayout();
			this.SContainer_Workspace.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.RunToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.MainMenu.Size = new System.Drawing.Size(784, 24);
			this.MainMenu.TabIndex = 1;
			this.MainMenu.Text = "Main Menu";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.ShowInCSToolStripMenuItem,
            this.QuitToolStripMenuItem1});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "File";
			// 
			// SaveToolStripMenuItem
			// 
			this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
			this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.SaveToolStripMenuItem.Text = "Save";
			this.SaveToolStripMenuItem.ToolTipText = "Save your work";
			this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// ShowInCSToolStripMenuItem
			// 
			this.ShowInCSToolStripMenuItem.Name = "ShowInCSToolStripMenuItem";
			this.ShowInCSToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.ShowInCSToolStripMenuItem.Text = "Show in C#";
			this.ShowInCSToolStripMenuItem.ToolTipText = "Show your code in C-Sharp";
			// 
			// QuitToolStripMenuItem1
			// 
			this.QuitToolStripMenuItem1.Name = "QuitToolStripMenuItem1";
			this.QuitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.QuitToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
			this.QuitToolStripMenuItem1.Text = "Quit";
			this.QuitToolStripMenuItem1.ToolTipText = "Go back to the welcome screen";
			this.QuitToolStripMenuItem1.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// EditToolStripMenuItem
			// 
			this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectToolboxToolStripMenuItem,
            this.ToolStripSeparator2,
            this.DeleteToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.ToolStripSeparator1,
            this.CommandPaletteToolStripMenuItem});
			this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
			this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.EditToolStripMenuItem.Text = "Edit";
			// 
			// SelectToolboxToolStripMenuItem
			// 
			this.SelectToolboxToolStripMenuItem.Name = "SelectToolboxToolStripMenuItem";
			this.SelectToolboxToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
			this.SelectToolboxToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.SelectToolboxToolStripMenuItem.Text = "Select Toolbox";
			this.SelectToolboxToolStripMenuItem.ToolTipText = "Focus the toolbox";
			this.SelectToolboxToolStripMenuItem.Click += new System.EventHandler(this.SelectToolboxToolStripMenuItem_Click);
			// 
			// ToolStripSeparator2
			// 
			this.ToolStripSeparator2.Name = "ToolStripSeparator2";
			this.ToolStripSeparator2.Size = new System.Drawing.Size(212, 6);
			// 
			// DeleteToolStripMenuItem
			// 
			this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
			this.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.DeleteToolStripMenuItem.Text = "Delete";
			this.DeleteToolStripMenuItem.ToolTipText = "Delete the next block you click";
			this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// CopyToolStripMenuItem
			// 
			this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
			this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.CopyToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.CopyToolStripMenuItem.Text = "Copy";
			this.CopyToolStripMenuItem.ToolTipText = "Copy the next block you click";
			// 
			// PasteToolStripMenuItem
			// 
			this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
			this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.PasteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.PasteToolStripMenuItem.Text = "Paste";
			this.PasteToolStripMenuItem.ToolTipText = "Paste the last block you copied";
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(212, 6);
			// 
			// CommandPaletteToolStripMenuItem
			// 
			this.CommandPaletteToolStripMenuItem.Name = "CommandPaletteToolStripMenuItem";
			this.CommandPaletteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.CommandPaletteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.CommandPaletteToolStripMenuItem.Text = "Command Palette";
			this.CommandPaletteToolStripMenuItem.ToolTipText = "Open the command palette";
			// 
			// RunToolStripMenuItem
			// 
			this.RunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DebugToolStripMenuItem,
            this.GetexeToolStripMenuItem});
			this.RunToolStripMenuItem.Name = "RunToolStripMenuItem";
			this.RunToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.RunToolStripMenuItem.Text = "Run";
			// 
			// DebugToolStripMenuItem
			// 
			this.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem";
			this.DebugToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.DebugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.DebugToolStripMenuItem.Text = "Debug";
			this.DebugToolStripMenuItem.ToolTipText = "Run your code";
			this.DebugToolStripMenuItem.Click += new System.EventHandler(this.DebugToolStripMenuItem_Click);
			// 
			// GetexeToolStripMenuItem
			// 
			this.GetexeToolStripMenuItem.Name = "GetexeToolStripMenuItem";
			this.GetexeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.GetexeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.GetexeToolStripMenuItem.Text = "Get \"exe\"";
			this.GetexeToolStripMenuItem.ToolTipText = "Get your \"exe\" file path";
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutBlocksToolStripMenuItem,
            this.AboutTheWorkspaceToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.HelpToolStripMenuItem.Text = "Help";
			// 
			// AboutBlocksToolStripMenuItem
			// 
			this.AboutBlocksToolStripMenuItem.Name = "AboutBlocksToolStripMenuItem";
			this.AboutBlocksToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
			this.AboutBlocksToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
			this.AboutBlocksToolStripMenuItem.Text = "About Blocks";
			this.AboutBlocksToolStripMenuItem.ToolTipText = resources.GetString("AboutBlocksToolStripMenuItem.ToolTipText");
			this.AboutBlocksToolStripMenuItem.Click += new System.EventHandler(this.AboutBlocksToolStripMenuItem_Click);
			// 
			// AboutTheWorkspaceToolStripMenuItem
			// 
			this.AboutTheWorkspaceToolStripMenuItem.Name = "AboutTheWorkspaceToolStripMenuItem";
			this.AboutTheWorkspaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.H)));
			this.AboutTheWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
			this.AboutTheWorkspaceToolStripMenuItem.Text = "About the Workspace";
			this.AboutTheWorkspaceToolStripMenuItem.ToolTipText = resources.GetString("AboutTheWorkspaceToolStripMenuItem.ToolTipText");
			this.AboutTheWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.AboutTheWorkspaceToolStripMenuItem_Click);
			// 
			// SContainer_Workspace
			// 
			this.SContainer_Workspace.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.SContainer_Workspace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SContainer_Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SContainer_Workspace.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SContainer_Workspace.Location = new System.Drawing.Point(0, 24);
			this.SContainer_Workspace.Name = "SContainer_Workspace";
			// 
			// SContainer_Workspace.Panel1
			// 
			this.SContainer_Workspace.Panel1.Controls.Add(this.BlockTree);
			// 
			// SContainer_Workspace.Panel2
			// 
			this.SContainer_Workspace.Panel2.AllowDrop = true;
			this.SContainer_Workspace.Panel2.AutoScroll = true;
			this.SContainer_Workspace.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.SContainer_Workspace.Size = new System.Drawing.Size(784, 437);
			this.SContainer_Workspace.SplitterDistance = 180;
			this.SContainer_Workspace.TabIndex = 2;
			// 
			// BlockTree
			// 
			this.BlockTree.BackColor = System.Drawing.SystemColors.ControlDark;
			this.BlockTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BlockTree.Location = new System.Drawing.Point(0, 0);
			this.BlockTree.Name = "BlockTree";
			treeNode1.Name = "DeclareVarsBlock";
			treeNode1.Text = "Declare Variables";
			treeNode2.Name = "StarterBlock";
			treeNode2.Text = "Starter Block";
			treeNode3.Name = "ControlBlocks";
			treeNode3.Text = "Control";
			treeNode4.Name = "AddBlock";
			treeNode4.Text = "Add";
			treeNode5.Name = "DivideBlock";
			treeNode5.Text = "Divide";
			treeNode6.Name = "EmptyNormalBlock";
			treeNode6.Text = "Empty Block";
			treeNode7.Name = "MultiplyBlock";
			treeNode7.Text = "Multiply";
			treeNode8.Name = "SetBlock";
			treeNode8.Text = "Set";
			treeNode9.Name = "SubtractBlock";
			treeNode9.Text = "Subtract";
			treeNode10.Name = "ProcessBlocks";
			treeNode10.Text = "Process";
			treeNode11.Name = "ReadKeyBlock";
			treeNode11.Text = "Read Key";
			treeNode12.Name = "ReadLineBlock";
			treeNode12.Text = "Read Line";
			treeNode13.Name = "InputBlocks";
			treeNode13.Text = "Input";
			treeNode14.Name = "BeepBlock";
			treeNode14.Text = "Beep";
			treeNode15.Name = "WriteBlock";
			treeNode15.Text = "Write";
			treeNode16.Name = "WriteLineBlock";
			treeNode16.Text = "Write Line";
			treeNode17.Name = "Output Blocks";
			treeNode17.Text = "Output";
			treeNode18.Name = "BoolSetBlock";
			treeNode18.Text = "Boolean";
			treeNode19.Name = "DecimalSetBlock";
			treeNode19.Text = "Decimal";
			treeNode20.Name = "IntegerSetBlock";
			treeNode20.Text = "Integer";
			treeNode21.Name = "StringSetBlock";
			treeNode21.Text = "String";
			treeNode22.Name = "VariableDeclareBlocks";
			treeNode22.Text = "Declare Variables";
			treeNode22.ToolTipText = "Place these blocks under the declaration block";
			treeNode23.Name = "VariableRefBlock";
			treeNode23.Text = "Variable Selector";
			treeNode24.Name = "VariableRefBlocks";
			treeNode24.Text = "Use Variables";
			treeNode24.ToolTipText = "Place these blocks in your program to reference the variable";
			treeNode25.Name = "ConstantBlocks";
			treeNode25.Text = "Constants";
			this.BlockTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode10,
            treeNode13,
            treeNode17,
            treeNode22,
            treeNode24,
            treeNode25});
			this.BlockTree.Size = new System.Drawing.Size(178, 435);
			this.BlockTree.TabIndex = 1;
			// 
			// FrmDesigner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(784, 461);
			this.Controls.Add(this.SContainer_Workspace);
			this.Controls.Add(this.MainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(575, 250);
			this.Name = "FrmDesigner";
			this.Text = "FrmDesigner";
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.SContainer_Workspace.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SContainer_Workspace)).EndInit();
			this.SContainer_Workspace.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		/// <summary>
		/// The SplitContainer containing the block tree and active editor panels
		/// </summary>
		public System.Windows.Forms.SplitContainer SContainer_Workspace;
		private TreeView BlockTree;
		private ToolStripMenuItem QuitToolStripMenuItem1;
		private ToolStripMenuItem EditToolStripMenuItem;
		private ToolStripMenuItem RunToolStripMenuItem;
		private ToolStripMenuItem HelpToolStripMenuItem;
		private ToolStripMenuItem DeleteToolStripMenuItem;
		private ToolStripMenuItem SaveToolStripMenuItem;
		private ToolStripMenuItem ShowInCSToolStripMenuItem;
		private ToolStripMenuItem CopyToolStripMenuItem;
		private ToolStripMenuItem PasteToolStripMenuItem;
		private ToolStripSeparator ToolStripSeparator1;
		private ToolStripMenuItem CommandPaletteToolStripMenuItem;
		private ToolStripMenuItem DebugToolStripMenuItem;
		private ToolStripMenuItem GetexeToolStripMenuItem;
		private ToolStripMenuItem AboutBlocksToolStripMenuItem;
		private ToolStripMenuItem AboutTheWorkspaceToolStripMenuItem;
		private ToolStripMenuItem SelectToolboxToolStripMenuItem;
		private ToolStripSeparator ToolStripSeparator2;
	}
}