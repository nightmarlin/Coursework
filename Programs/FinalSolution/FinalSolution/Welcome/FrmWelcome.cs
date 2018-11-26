using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Solution.Debugger;
using Solution.Designer;

namespace Solution.Welcome {
	
	/// <summary>
	/// The form upon which we welcome our users
	/// </summary>
	/// <inheritdoc />
	public partial class FrmWelcome : Form {

		/// <summary>
		/// Initializes and instantiates the component
		/// </summary>
		/// <inheritdoc />
		public FrmWelcome() {
			InitializeComponent();
			Shown += FrmWelcome_Shown;
			var x = new List<RecentItem>();
		}

		/// <summary>
		/// When the form is shown, call the <see cref="T:System.GC"/> for discarded resources
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void FrmWelcome_Shown(object Sender, EventArgs E) {
			GC.Collect();
		}

		/// <summary>
		/// When clicked, shows the <see cref="T:Solution.Debugger.FrmDebugger"/> with the <see cref="T:Solution.Build.Template.Program"/> running
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void BtnShowDebugger_Click(object Sender, EventArgs E) {

			var MyProcessName = TxtFilePath.Text;

			if (!File.Exists(MyProcessName)) {
				MessageBox.Show("Cannot run a file that doesn't exist", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!MyProcessName.EndsWith(".exe")) {
				MessageBox.Show("Cannot run a non 'exe' file", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var MyDebugger = new FrmDebugger(MyProcessName, this);
			//var MyDebugger = new FrmDebugger();
			
			
			MyDebugger.Show();

			MyDebugger.VisibleChanged += (S, EArgs) => { this.Show(); };
			MyDebugger.Closed += (S, EArgs) => { this.Show(); };

		}

		private void BtnShowDesigner_Click(object sender, EventArgs e) {
			var Designer = new FrmDesigner();

			Designer.Show();

			
			Designer.VisibleChanged += (S, EArgs) => { this.Show(); };
			Designer.Closed += (S, EArgs) => { this.Show(); };

		}
	}
}
