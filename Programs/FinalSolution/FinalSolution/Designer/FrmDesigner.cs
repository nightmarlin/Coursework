using System;
using System.Windows.Forms;

using Solution.Debugger;

namespace Solution.Designer {
	
	/// <summary>
	/// The form upon which designing occurs
	/// </summary>
	/// <inheritdoc />
	public partial class FrmDesigner : Form {

		/// <summary>
		/// Initializes and instantiates the component
		/// </summary>
		/// <inheritdoc />
		public FrmDesigner() {
			InitializeComponent();
			Shown += FrmDesigner_Shown;
		}

		/// <summary>
		/// When the form is shown, call the GarbageCollector for discarded resources
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void FrmDesigner_Shown(object Sender, EventArgs E) {
			GC.Collect();
		}

		/// <summary>
		/// Shows the Welcome Panel and hides the Workspace Panel
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void FrmDesigner_Load(object Sender, EventArgs E) {

			PnlWelcomePage.Visible = true;
			PnlWorkspace.Visible = false;

		}

		/// <summary>
		/// When clicked, shows the designer form with the TestProgram running
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void BtnShowDebugger_Click(object Sender, EventArgs E) {

			const string MyProcess = @".\\BébéProgramMK2.exe";

			var MyDebugger = new FrmDebugger(MyProcess, this);
			//var MyDebugger = new FrmDebugger();
			MyDebugger.Show();

			MyDebugger.VisibleChanged += (S, EArgs) => { this.Show(); };
			MyDebugger.Closed += (S, EArgs) => { this.Show(); };

		}


	}
}
