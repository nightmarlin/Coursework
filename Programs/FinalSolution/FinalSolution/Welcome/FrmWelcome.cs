using System;
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
			Shown += (S, E) => GC.Collect();
		}

		/// <summary>
		/// When clicked, shows the <see cref="T:Solution.Debugger.FrmDebugger"/> with the <see cref="T:Solution.Build.Template.Program"/> running
		/// </summary>
		/// <param name="S">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void BtnShowDebugger_Click(object S, EventArgs E) {

			var MyProcessName = Microsoft.VisualBasic.Interaction.InputBox("What's the file path?", "B#", ".\\BébéProgramMK2.exe");
			
			if (!File.Exists(MyProcessName)) {
				MessageBox.Show("Cannot run a file that doesn't exist", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!MyProcessName.EndsWith(".exe")) {
				MessageBox.Show("Cannot run a non 'exe' file", "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var MyDebugger = new FrmDebugger(MyProcessName, this);

			MyDebugger.VisibleChanged += (S2, E2) => { Show(); };
			MyDebugger.Closed += (S2, E2) => { Show(); };

			MyDebugger.Show();

			Hide();
		}

		private void BtnShowDesigner_Click(object S, EventArgs E) {
			
			var Designer = new FrmDesigner(this);
			Designer.VisibleChanged += (S2, E2) => { Show(); };
			Designer.Closed += (S2, E2) => { Show(); };

			Designer.Show();

			Hide();

		}
		
		

	}
}
