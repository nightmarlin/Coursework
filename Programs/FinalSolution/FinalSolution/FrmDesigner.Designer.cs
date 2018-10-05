using System.Drawing;

namespace Solution {
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
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PnlWelcomePage = new System.Windows.Forms.Panel();
			this.BtnShowDebugger = new System.Windows.Forms.Button();
			this.PnlWorkspace = new System.Windows.Forms.Panel();
			this.MainMenu.SuspendLayout();
			this.PnlWelcomePage.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.BackColor = System.Drawing.SystemColors.Control;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.MainMenu.Size = new System.Drawing.Size(800, 24);
			this.MainMenu.TabIndex = 0;
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
			// PnlWelcomePage
			// 
			this.PnlWelcomePage.BackColor = System.Drawing.SystemColors.Control;
			this.PnlWelcomePage.Controls.Add(this.BtnShowDebugger);
			this.PnlWelcomePage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PnlWelcomePage.Location = new System.Drawing.Point(0, 0);
			this.PnlWelcomePage.Name = "PnlWelcomePage";
			this.PnlWelcomePage.Size = new System.Drawing.Size(800, 450);
			this.PnlWelcomePage.TabIndex = 1;
			this.PnlWelcomePage.Visible = false;
			// 
			// BtnShowDebugger
			// 
			this.BtnShowDebugger.Location = new System.Drawing.Point(238, 136);
			this.BtnShowDebugger.Name = "BtnShowDebugger";
			this.BtnShowDebugger.Size = new System.Drawing.Size(257, 123);
			this.BtnShowDebugger.TabIndex = 0;
			this.BtnShowDebugger.Text = "ShowDebugger";
			this.BtnShowDebugger.UseVisualStyleBackColor = true;
			this.BtnShowDebugger.Click += new System.EventHandler(this.BtnShowDebugger_Click);
			// 
			// PnlWorkspace
			// 
			this.PnlWorkspace.BackColor = System.Drawing.SystemColors.Control;
			this.PnlWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PnlWorkspace.Location = new System.Drawing.Point(0, 0);
			this.PnlWorkspace.Name = "PnlWorkspace";
			this.PnlWorkspace.Size = new System.Drawing.Size(800, 450);
			this.PnlWorkspace.TabIndex = 2;
			this.PnlWorkspace.Visible = false;
			// 
			// FrmDesigner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.MainMenu);
			this.Controls.Add(this.PnlWelcomePage);
			this.Controls.Add(this.PnlWorkspace);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmDesigner";
			this.Text = "Designer";
			this.Load += new System.EventHandler(this.FrmDesigner_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.PnlWelcomePage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.Panel PnlWelcomePage;
		private System.Windows.Forms.Panel PnlWorkspace;
		private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
		private System.Windows.Forms.Button BtnShowDebugger;
	}
}

