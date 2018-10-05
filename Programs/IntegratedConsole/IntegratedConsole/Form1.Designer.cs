namespace IntegratedConsole {
	partial class Form1 {
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
			this.integratedConsoleWindow1 = new IntegratedConsole.IntegratedConsoleWindow();
			this.SuspendLayout();
			// 
			// integratedConsoleWindow1
			// 
			this.integratedConsoleWindow1.Location = new System.Drawing.Point(195, 144);
			this.integratedConsoleWindow1.Name = "integratedConsoleWindow1";
			this.integratedConsoleWindow1.Size = new System.Drawing.Size(200, 100);
			this.integratedConsoleWindow1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.integratedConsoleWindow1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private IntegratedConsoleWindow integratedConsoleWindow1;
	}
}

