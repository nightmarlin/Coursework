namespace Solution.Debugger {
	partial class FrmDebugger {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDebugger));
			this.TxtStandardOutput = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.TxtInputToProgram = new System.Windows.Forms.TextBox();
			this.BtnSubmitInput = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.BtnExitDebugging = new System.Windows.Forms.Button();
			this.BtnStartExecution = new System.Windows.Forms.Button();
			this.BtnStopExecution = new System.Windows.Forms.Button();
			this.BtnPauseExecution = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.TxtErrorOutput = new System.Windows.Forms.TextBox();
			this.TxtVariableOutput = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// TxtStandardOutput
			// 
			this.TxtStandardOutput.BackColor = System.Drawing.Color.Black;
			this.TxtStandardOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtStandardOutput.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.TxtStandardOutput.Location = new System.Drawing.Point(3, 3);
			this.TxtStandardOutput.MaxLength = 1073741824;
			this.TxtStandardOutput.Multiline = true;
			this.TxtStandardOutput.Name = "TxtStandardOutput";
			this.TxtStandardOutput.ReadOnly = true;
			this.TxtStandardOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtStandardOutput.Size = new System.Drawing.Size(456, 422);
			this.TxtStandardOutput.TabIndex = 7;
			this.TxtStandardOutput.Text = "Standard Output.";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.TxtInputToProgram, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.BtnSubmitInput, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 431);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 34);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// TxtInputToProgram
			// 
			this.TxtInputToProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.TxtInputToProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.TxtInputToProgram.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtInputToProgram.Location = new System.Drawing.Point(3, 3);
			this.TxtInputToProgram.MaxLength = 1073741824;
			this.TxtInputToProgram.Name = "TxtInputToProgram";
			this.TxtInputToProgram.Size = new System.Drawing.Size(336, 20);
			this.TxtInputToProgram.TabIndex = 1;
			this.TxtInputToProgram.TextChanged += new System.EventHandler(this.TxtInputToProgram_TextChanged);
			// 
			// BtnSubmitInput
			// 
			this.BtnSubmitInput.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.BtnSubmitInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnSubmitInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSubmitInput.Location = new System.Drawing.Point(345, 3);
			this.BtnSubmitInput.Name = "BtnSubmitInput";
			this.BtnSubmitInput.Size = new System.Drawing.Size(108, 28);
			this.BtnSubmitInput.TabIndex = 2;
			this.BtnSubmitInput.Text = "SUBMIT";
			this.BtnSubmitInput.UseVisualStyleBackColor = false;
			this.BtnSubmitInput.Click += new System.EventHandler(this.BtnSubmitInput_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
			this.tableLayoutPanel2.Controls.Add(this.TxtStandardOutput, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(762, 468);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel3.Controls.Add(this.BtnExitDebugging, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.BtnStartExecution, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.BtnStopExecution, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.BtnPauseExecution, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(465, 431);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(294, 34);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// BtnExitDebugging
			// 
			this.BtnExitDebugging.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.BtnExitDebugging.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnExitDebugging.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnExitDebugging.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnExitDebugging.Location = new System.Drawing.Point(222, 3);
			this.BtnExitDebugging.Name = "BtnExitDebugging";
			this.BtnExitDebugging.Size = new System.Drawing.Size(69, 28);
			this.BtnExitDebugging.TabIndex = 6;
			this.BtnExitDebugging.Text = "EXIT";
			this.BtnExitDebugging.UseVisualStyleBackColor = false;
			this.BtnExitDebugging.Click += new System.EventHandler(this.BtnExitDebugging_Click);
			// 
			// BtnStartExecution
			// 
			this.BtnStartExecution.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.BtnStartExecution.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnStartExecution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnStartExecution.Location = new System.Drawing.Point(149, 3);
			this.BtnStartExecution.Name = "BtnStartExecution";
			this.BtnStartExecution.Size = new System.Drawing.Size(67, 28);
			this.BtnStartExecution.TabIndex = 5;
			this.BtnStartExecution.Text = "START";
			this.BtnStartExecution.UseVisualStyleBackColor = false;
			this.BtnStartExecution.Click += new System.EventHandler(this.BtnStartExecution_Click);
			// 
			// BtnStopExecution
			// 
			this.BtnStopExecution.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.BtnStopExecution.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnStopExecution.Enabled = false;
			this.BtnStopExecution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnStopExecution.Location = new System.Drawing.Point(3, 3);
			this.BtnStopExecution.Name = "BtnStopExecution";
			this.BtnStopExecution.Size = new System.Drawing.Size(67, 28);
			this.BtnStopExecution.TabIndex = 3;
			this.BtnStopExecution.Text = "STOP";
			this.BtnStopExecution.UseVisualStyleBackColor = false;
			this.BtnStopExecution.Click += new System.EventHandler(this.BtnStopExecution_Click);
			// 
			// BtnPauseExecution
			// 
			this.BtnPauseExecution.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.BtnPauseExecution.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnPauseExecution.Enabled = false;
			this.BtnPauseExecution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnPauseExecution.Location = new System.Drawing.Point(76, 3);
			this.BtnPauseExecution.Name = "BtnPauseExecution";
			this.BtnPauseExecution.Size = new System.Drawing.Size(67, 28);
			this.BtnPauseExecution.TabIndex = 4;
			this.BtnPauseExecution.Text = "PAUSE";
			this.BtnPauseExecution.UseVisualStyleBackColor = false;
			this.BtnPauseExecution.Click += new System.EventHandler(this.BtnPauseExecution_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Controls.Add(this.TxtErrorOutput, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.TxtVariableOutput, 0, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(465, 3);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(294, 422);
			this.tableLayoutPanel4.TabIndex = 4;
			// 
			// TxtErrorOutput
			// 
			this.TxtErrorOutput.BackColor = System.Drawing.Color.Black;
			this.TxtErrorOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtErrorOutput.ForeColor = System.Drawing.Color.DarkRed;
			this.TxtErrorOutput.Location = new System.Drawing.Point(3, 214);
			this.TxtErrorOutput.MaxLength = 1073741824;
			this.TxtErrorOutput.Multiline = true;
			this.TxtErrorOutput.Name = "TxtErrorOutput";
			this.TxtErrorOutput.ReadOnly = true;
			this.TxtErrorOutput.Size = new System.Drawing.Size(288, 205);
			this.TxtErrorOutput.TabIndex = 9;
			this.TxtErrorOutput.Text = "Error Output. Nothing\'s gone wrong yet";
			// 
			// TxtVariableOutput
			// 
			this.TxtVariableOutput.BackColor = System.Drawing.Color.Black;
			this.TxtVariableOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxtVariableOutput.ForeColor = System.Drawing.Color.MediumSeaGreen;
			this.TxtVariableOutput.Location = new System.Drawing.Point(3, 3);
			this.TxtVariableOutput.MaxLength = 1073741824;
			this.TxtVariableOutput.Multiline = true;
			this.TxtVariableOutput.Name = "TxtVariableOutput";
			this.TxtVariableOutput.ReadOnly = true;
			this.TxtVariableOutput.Size = new System.Drawing.Size(288, 205);
			this.TxtVariableOutput.TabIndex = 8;
			this.TxtVariableOutput.Text = "Observed Variables";
			// 
			// FrmDebugger
			// 
			this.AcceptButton = this.BtnSubmitInput;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.CancelButton = this.BtnExitDebugging;
			this.ClientSize = new System.Drawing.Size(786, 492);
			this.Controls.Add(this.tableLayoutPanel2);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(621, 273);
			this.Name = "FrmDebugger";
			this.Text = "Debugging";
			this.Load += new System.EventHandler(this.FrmDebugger_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox TxtStandardOutput;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox TxtInputToProgram;
		private System.Windows.Forms.Button BtnSubmitInput;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button BtnStopExecution;
		private System.Windows.Forms.Button BtnExitDebugging;
		private System.Windows.Forms.Button BtnStartExecution;
		private System.Windows.Forms.Button BtnPauseExecution;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TextBox TxtErrorOutput;
		private System.Windows.Forms.TextBox TxtVariableOutput;
	}
}