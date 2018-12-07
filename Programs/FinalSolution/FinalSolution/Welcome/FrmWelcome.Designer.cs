namespace Solution.Welcome {
	partial class FrmWelcome {
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "TestProject1",
            ""}, -1, System.Drawing.SystemColors.Info, System.Drawing.Color.Empty, null);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "TestProject2"}, -1, System.Drawing.SystemColors.Info, System.Drawing.Color.Empty, null);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWelcome));
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.List_RecentItems = new System.Windows.Forms.ListView();
			this.Lbl_RecentItems_Header = new System.Windows.Forms.Label();
			this.BtnShowDebugger = new System.Windows.Forms.Button();
			this.BtnShowDesigner = new System.Windows.Forms.Button();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
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
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.BtnShowDebugger);
			this.splitContainer1.Panel2.Controls.Add(this.BtnShowDesigner);
			this.splitContainer1.Size = new System.Drawing.Size(800, 426);
			this.splitContainer1.SplitterDistance = 284;
			this.splitContainer1.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.List_RecentItems, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.Lbl_RecentItems_Header, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 426);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// List_RecentItems
			// 
			this.List_RecentItems.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.List_RecentItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.List_RecentItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.List_RecentItems.GridLines = true;
			this.List_RecentItems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.List_RecentItems.Location = new System.Drawing.Point(3, 45);
			this.List_RecentItems.Name = "List_RecentItems";
			this.List_RecentItems.Size = new System.Drawing.Size(278, 378);
			this.List_RecentItems.TabIndex = 1;
			this.List_RecentItems.UseCompatibleStateImageBehavior = false;
			this.List_RecentItems.View = System.Windows.Forms.View.Tile;
			this.List_RecentItems.VirtualListSize = 1;
			// 
			// Lbl_RecentItems_Header
			// 
			this.Lbl_RecentItems_Header.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Lbl_RecentItems_Header.Location = new System.Drawing.Point(3, 0);
			this.Lbl_RecentItems_Header.Name = "Lbl_RecentItems_Header";
			this.Lbl_RecentItems_Header.Size = new System.Drawing.Size(278, 42);
			this.Lbl_RecentItems_Header.TabIndex = 2;
			this.Lbl_RecentItems_Header.Text = "Recent Projects";
			this.Lbl_RecentItems_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BtnShowDebugger
			// 
			this.BtnShowDebugger.Location = new System.Drawing.Point(3, 3);
			this.BtnShowDebugger.Name = "BtnShowDebugger";
			this.BtnShowDebugger.Size = new System.Drawing.Size(221, 126);
			this.BtnShowDebugger.TabIndex = 9;
			this.BtnShowDebugger.Text = "Debug A Program";
			this.BtnShowDebugger.UseVisualStyleBackColor = true;
			this.BtnShowDebugger.Click += new System.EventHandler(this.BtnShowDebugger_Click);
			// 
			// BtnShowDesigner
			// 
			this.BtnShowDesigner.Location = new System.Drawing.Point(3, 135);
			this.BtnShowDesigner.Name = "BtnShowDesigner";
			this.BtnShowDesigner.Size = new System.Drawing.Size(221, 129);
			this.BtnShowDesigner.TabIndex = 10;
			this.BtnShowDesigner.Text = "Create A Program";
			this.BtnShowDesigner.UseVisualStyleBackColor = true;
			this.BtnShowDesigner.Click += new System.EventHandler(this.BtnShowDesigner_Click);
			// 
			// FrmWelcome
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.MainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmWelcome";
			this.Text = "Welcome";
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button BtnShowDebugger;
		private System.Windows.Forms.Button BtnShowDesigner;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListView List_RecentItems;
		private System.Windows.Forms.Label Lbl_RecentItems_Header;
	}
}

