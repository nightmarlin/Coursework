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
			System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Declare Variables");
			System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Starter Block");
			System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Control", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27});
			System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Add");
			System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Divide");
			System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Empty Block");
			System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Multiply");
			System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Set");
			System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Subtract");
			System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Process", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34});
			System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Read Key");
			System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Read Line");
			System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Input", new System.Windows.Forms.TreeNode[] {
            treeNode36,
            treeNode37});
			System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Beep");
			System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Write");
			System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Write Line");
			System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Output", new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode40,
            treeNode41});
			System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Boolean");
			System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Decimal");
			System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Integer");
			System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("String");
			System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Declare Variables", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode44,
            treeNode45,
            treeNode46});
			System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Variable Selector");
			System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Use Variables", new System.Windows.Forms.TreeNode[] {
            treeNode48});
			System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Constants");
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showInCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectToolboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.commandPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutTheWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.editToolStripMenuItem,
            this.runToolStripMenuItem,
            this.helpToolStripMenuItem});
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
            this.saveToolStripMenuItem,
            this.showInCToolStripMenuItem,
            this.quitToolStripMenuItem1});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "File";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.ToolTipText = "Save your work";
			// 
			// showInCToolStripMenuItem
			// 
			this.showInCToolStripMenuItem.Name = "showInCToolStripMenuItem";
			this.showInCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.showInCToolStripMenuItem.Text = "Show in C#";
			this.showInCToolStripMenuItem.ToolTipText = "Show your code in C-Sharp";
			// 
			// quitToolStripMenuItem1
			// 
			this.quitToolStripMenuItem1.Name = "quitToolStripMenuItem1";
			this.quitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.quitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
			this.quitToolStripMenuItem1.Text = "Quit";
			this.quitToolStripMenuItem1.ToolTipText = "Go back to the welcome screen";
			this.quitToolStripMenuItem1.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolboxToolStripMenuItem,
            this.toolStripSeparator2,
            this.DeleteToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.commandPaletteToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// selectToolboxToolStripMenuItem
			// 
			this.selectToolboxToolStripMenuItem.Name = "selectToolboxToolStripMenuItem";
			this.selectToolboxToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
			this.selectToolboxToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.selectToolboxToolStripMenuItem.Text = "Select Toolbox";
			this.selectToolboxToolStripMenuItem.ToolTipText = "Focus the toolbox";
			this.selectToolboxToolStripMenuItem.Click += new System.EventHandler(this.selectToolboxToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
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
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.ToolTipText = "Copy the next block you click";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.ToolTipText = "Paste the last block you copied";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
			// 
			// commandPaletteToolStripMenuItem
			// 
			this.commandPaletteToolStripMenuItem.Name = "commandPaletteToolStripMenuItem";
			this.commandPaletteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.commandPaletteToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.commandPaletteToolStripMenuItem.Text = "Command Palette";
			this.commandPaletteToolStripMenuItem.ToolTipText = "Open the command palette";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.getexeToolStripMenuItem});
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.runToolStripMenuItem.Text = "Run";
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.debugToolStripMenuItem.Text = "Debug";
			this.debugToolStripMenuItem.ToolTipText = "Run your code";
			// 
			// getexeToolStripMenuItem
			// 
			this.getexeToolStripMenuItem.Name = "getexeToolStripMenuItem";
			this.getexeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.getexeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.getexeToolStripMenuItem.Text = "Get \"exe\"";
			this.getexeToolStripMenuItem.ToolTipText = "Get your \"exe\" file path";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutBlocksToolStripMenuItem,
            this.aboutTheWorkspaceToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutBlocksToolStripMenuItem
			// 
			this.aboutBlocksToolStripMenuItem.Name = "aboutBlocksToolStripMenuItem";
			this.aboutBlocksToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
			this.aboutBlocksToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
			this.aboutBlocksToolStripMenuItem.Text = "About Blocks";
			this.aboutBlocksToolStripMenuItem.ToolTipText = resources.GetString("aboutBlocksToolStripMenuItem.ToolTipText");
			this.aboutBlocksToolStripMenuItem.Click += new System.EventHandler(this.aboutBlocksToolStripMenuItem_Click);
			// 
			// aboutTheWorkspaceToolStripMenuItem
			// 
			this.aboutTheWorkspaceToolStripMenuItem.Name = "aboutTheWorkspaceToolStripMenuItem";
			this.aboutTheWorkspaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.H)));
			this.aboutTheWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
			this.aboutTheWorkspaceToolStripMenuItem.Text = "About the Workspace";
			this.aboutTheWorkspaceToolStripMenuItem.ToolTipText = resources.GetString("aboutTheWorkspaceToolStripMenuItem.ToolTipText");
			this.aboutTheWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.aboutTheWorkspaceToolStripMenuItem_Click);
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
			treeNode26.Name = "DeclareVarsBlock";
			treeNode26.Text = "Declare Variables";
			treeNode27.Name = "StarterBlock";
			treeNode27.Text = "Starter Block";
			treeNode28.Name = "ControlBlocks";
			treeNode28.Text = "Control";
			treeNode29.Name = "AddBlock";
			treeNode29.Text = "Add";
			treeNode30.Name = "DivideBlock";
			treeNode30.Text = "Divide";
			treeNode31.Name = "EmptyNormalBlock";
			treeNode31.Text = "Empty Block";
			treeNode32.Name = "MultiplyBlock";
			treeNode32.Text = "Multiply";
			treeNode33.Name = "SetBlock";
			treeNode33.Text = "Set";
			treeNode34.Name = "SubtractBlock";
			treeNode34.Text = "Subtract";
			treeNode35.Name = "ProcessBlocks";
			treeNode35.Text = "Process";
			treeNode36.Name = "ReadKeyBlock";
			treeNode36.Text = "Read Key";
			treeNode37.Name = "ReadLineBlock";
			treeNode37.Text = "Read Line";
			treeNode38.Name = "InputBlocks";
			treeNode38.Text = "Input";
			treeNode39.Name = "BeepBlock";
			treeNode39.Text = "Beep";
			treeNode40.Name = "WriteBlock";
			treeNode40.Text = "Write";
			treeNode41.Name = "WriteLineBlock";
			treeNode41.Text = "Write Line";
			treeNode42.Name = "Output Blocks";
			treeNode42.Text = "Output";
			treeNode43.Name = "BoolSetBlock";
			treeNode43.Text = "Boolean";
			treeNode44.Name = "DecimalSetBlock";
			treeNode44.Text = "Decimal";
			treeNode45.Name = "IntegerSetBlock";
			treeNode45.Text = "Integer";
			treeNode46.Name = "StringSetBlock";
			treeNode46.Text = "String";
			treeNode47.Name = "VariableDeclareBlocks";
			treeNode47.Text = "Declare Variables";
			treeNode47.ToolTipText = "Place these blocks under the declaration block";
			treeNode48.Name = "VariableRefBlock";
			treeNode48.Text = "Variable Selector";
			treeNode49.Name = "VariableRefBlocks";
			treeNode49.Text = "Use Variables";
			treeNode49.ToolTipText = "Place these blocks in your program to reference the variable";
			treeNode50.Name = "ConstantBlocks";
			treeNode50.Text = "Constants";
			this.BlockTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode35,
            treeNode38,
            treeNode42,
            treeNode47,
            treeNode49,
            treeNode50});
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
		private ToolStripMenuItem quitToolStripMenuItem1;
		private ToolStripMenuItem editToolStripMenuItem;
		private ToolStripMenuItem runToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem DeleteToolStripMenuItem;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripMenuItem showInCToolStripMenuItem;
		private ToolStripMenuItem copyToolStripMenuItem;
		private ToolStripMenuItem pasteToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem commandPaletteToolStripMenuItem;
		private ToolStripMenuItem debugToolStripMenuItem;
		private ToolStripMenuItem getexeToolStripMenuItem;
		private ToolStripMenuItem aboutBlocksToolStripMenuItem;
		private ToolStripMenuItem aboutTheWorkspaceToolStripMenuItem;
		private ToolStripMenuItem selectToolboxToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator2;
	}
}