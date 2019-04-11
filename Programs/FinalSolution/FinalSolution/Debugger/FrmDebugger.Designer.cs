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
			this.components = new System.ComponentModel.Container();
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
			this.TTGeneral = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// TxtStandardOutput
			// 
			this.TxtStandardOutput.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.TxtStandardOutput, "TxtStandardOutput");
			this.TxtStandardOutput.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.TxtStandardOutput.Name = "TxtStandardOutput";
			this.TxtStandardOutput.ReadOnly = true;
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.TxtInputToProgram, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.BtnSubmitInput, 1, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// TxtInputToProgram
			// 
			this.TxtInputToProgram.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.TxtInputToProgram.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			resources.ApplyResources(this.TxtInputToProgram, "TxtInputToProgram");
			this.TxtInputToProgram.Name = "TxtInputToProgram";
			this.TxtInputToProgram.TextChanged += new System.EventHandler(this.TxtInputToProgram_TextChanged);
			// 
			// BtnSubmitInput
			// 
			this.BtnSubmitInput.BackColor = System.Drawing.SystemColors.ScrollBar;
			resources.ApplyResources(this.BtnSubmitInput, "BtnSubmitInput");
			this.BtnSubmitInput.Name = "BtnSubmitInput";
			this.BtnSubmitInput.UseVisualStyleBackColor = false;
			this.BtnSubmitInput.Click += new System.EventHandler(this.BtnSubmitInput_Click);
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.TxtStandardOutput, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// tableLayoutPanel3
			// 
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.BtnExitDebugging, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.BtnStartExecution, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.BtnStopExecution, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.BtnPauseExecution, 1, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			// 
			// BtnExitDebugging
			// 
			this.BtnExitDebugging.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.BtnExitDebugging.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.BtnExitDebugging, "BtnExitDebugging");
			this.BtnExitDebugging.Name = "BtnExitDebugging";
			this.BtnExitDebugging.UseVisualStyleBackColor = false;
			this.BtnExitDebugging.Click += new System.EventHandler(this.BtnExitDebugging_Click);
			// 
			// BtnStartExecution
			// 
			this.BtnStartExecution.BackColor = System.Drawing.SystemColors.ScrollBar;
			resources.ApplyResources(this.BtnStartExecution, "BtnStartExecution");
			this.BtnStartExecution.Name = "BtnStartExecution";
			this.BtnStartExecution.UseVisualStyleBackColor = false;
			this.BtnStartExecution.Click += new System.EventHandler(this.BtnStartExecution_Click);
			// 
			// BtnStopExecution
			// 
			this.BtnStopExecution.BackColor = System.Drawing.SystemColors.ScrollBar;
			resources.ApplyResources(this.BtnStopExecution, "BtnStopExecution");
			this.BtnStopExecution.Name = "BtnStopExecution";
			this.BtnStopExecution.UseVisualStyleBackColor = false;
			this.BtnStopExecution.Click += new System.EventHandler(this.BtnStopExecution_Click);
			// 
			// BtnPauseExecution
			// 
			this.BtnPauseExecution.BackColor = System.Drawing.SystemColors.ScrollBar;
			resources.ApplyResources(this.BtnPauseExecution, "BtnPauseExecution");
			this.BtnPauseExecution.Name = "BtnPauseExecution";
			this.BtnPauseExecution.UseVisualStyleBackColor = false;
			this.BtnPauseExecution.Click += new System.EventHandler(this.BtnPauseExecution_Click);
			// 
			// tableLayoutPanel4
			// 
			resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
			this.tableLayoutPanel4.Controls.Add(this.TxtErrorOutput, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.TxtVariableOutput, 0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			// 
			// TxtErrorOutput
			// 
			this.TxtErrorOutput.AcceptsReturn = true;
			this.TxtErrorOutput.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.TxtErrorOutput, "TxtErrorOutput");
			this.TxtErrorOutput.ForeColor = System.Drawing.Color.DarkRed;
			this.TxtErrorOutput.Name = "TxtErrorOutput";
			this.TxtErrorOutput.ReadOnly = true;
			// 
			// TxtVariableOutput
			// 
			this.TxtVariableOutput.AcceptsReturn = true;
			this.TxtVariableOutput.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.TxtVariableOutput, "TxtVariableOutput");
			this.TxtVariableOutput.ForeColor = System.Drawing.Color.MediumSeaGreen;
			this.TxtVariableOutput.Name = "TxtVariableOutput";
			this.TxtVariableOutput.ReadOnly = true;
			// 
			// FrmDebugger
			// 
			this.AcceptButton = this.BtnSubmitInput;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.CancelButton = this.BtnExitDebugging;
			this.Controls.Add(this.tableLayoutPanel2);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "FrmDebugger";
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
		private System.Windows.Forms.ToolTip TTGeneral;
	}
}