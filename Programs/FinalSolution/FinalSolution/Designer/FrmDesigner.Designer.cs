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
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SContainer_Workspace = new System.Windows.Forms.SplitContainer();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SContainer_Workspace)).BeginInit();
			this.SContainer_Workspace.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.BackColor = System.Drawing.SystemColors.ControlDark;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
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
			// SContainer_Workspace
			// 
			this.SContainer_Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SContainer_Workspace.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SContainer_Workspace.Location = new System.Drawing.Point(0, 24);
			this.SContainer_Workspace.Name = "SContainer_Workspace";
			// 
			// SContainer_Workspace.Panel2
			// 
			this.SContainer_Workspace.Panel2.AllowDrop = true;
			this.SContainer_Workspace.Size = new System.Drawing.Size(800, 426);
			this.SContainer_Workspace.SplitterDistance = 266;
			this.SContainer_Workspace.TabIndex = 2;
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
			((System.ComponentModel.ISupportInitialize)(this.SContainer_Workspace)).EndInit();
			this.SContainer_Workspace.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
		private System.Windows.Forms.SplitContainer SContainer_Workspace;
	}
}