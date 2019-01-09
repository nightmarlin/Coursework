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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Starter Block");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Control", new System.Windows.Forms.TreeNode[] {
            treeNode1});
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Empty Block");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Process", new System.Windows.Forms.TreeNode[] {
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Output");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Integer");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Variables", new System.Windows.Forms.TreeNode[] {
            treeNode6});
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.QuitToolStripMenuItem = new ToolStripMenuItem();
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
			this.MainMenu.BackColor = System.Drawing.SystemColors.ControlDark;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem, this.QuitToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.MainMenu.Size = new System.Drawing.Size(800, 24);
			this.MainMenu.TabIndex = 1;
			this.MainMenu.Text = "Main Menu";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "File";
			// 
			// OpenToolStripMenuItem
			// 
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.OpenToolStripMenuItem.Text = "Open";
			//
			// QuitToolStripMenuItem;
			//
			this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
			this.QuitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.QuitToolStripMenuItem.Text = "Quit";
			// 
			// SContainer_Workspace
			// 
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
			this.SContainer_Workspace.Size = new System.Drawing.Size(800, 426);
			this.SContainer_Workspace.SplitterDistance = 266;
			this.SContainer_Workspace.TabIndex = 2;
			// 
			// BlockTree
			// 
			this.BlockTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BlockTree.Location = new System.Drawing.Point(0, 0);
			this.BlockTree.Name = "BlockTree";
			treeNode1.Name = "StarterBlock";
			treeNode1.Text = "Starter Block";
			treeNode2.Name = "ControlBlocks";
			treeNode2.Text = "Control";
			treeNode3.Name = "EmptyNormalBlock";
			treeNode3.Text = "Empty Block";
			treeNode4.Name = "ProcessBlocks";
			treeNode4.Text = "Process";
			treeNode5.Name = "Output Blocks";
			treeNode5.Text = "Output";
			treeNode6.Name = "IntegerBlock";
			treeNode6.Text = "Integer";
			treeNode7.Name = "VariableBlocks";
			treeNode7.Text = "Variables";
			this.BlockTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode5,
            treeNode7});
			this.BlockTree.Size = new System.Drawing.Size(264, 424);
			this.BlockTree.TabIndex = 1;
			// 
			// FrmDesigner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.SContainer_Workspace);
			this.Controls.Add(this.MainMenu);
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
		private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		/// <summary>
		/// The SplitContainer containing the block tree and active editor panels
		/// </summary>
		public System.Windows.Forms.SplitContainer SContainer_Workspace;
		private System.Windows.Forms.TreeView BlockTree;
	}
}