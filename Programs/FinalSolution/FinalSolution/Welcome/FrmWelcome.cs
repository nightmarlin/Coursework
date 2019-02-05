using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Solution.Debugger;
using Solution.Designer;
using Solution.Properties;

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

			if (Settings.Default.RecentItems is null) {
				Settings.Default.RecentItems = new StringCollection();
				MessageBox.Show("The program has not been loaded before for this user. Building Settings file",
				                "B#", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Settings.Default.Save();
			}

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

		private void FrmWelcome_Load(object sender, EventArgs e) {
			
			
			List_RecentItems.Clear();

			List_RecentItems.View = View.Details;
			List_RecentItems.GridLines = false;

			List_RecentItems.Columns.Add("Path", List_RecentItems.Width / 2, HorizontalAlignment.Left);
			List_RecentItems.Columns.Add("Name", List_RecentItems.Width / 2, HorizontalAlignment.Left);

			List_RecentItems.Activation = ItemActivation.TwoClick;

			List_RecentItems.Items.Add(new ListViewItem(new[] {"Path1", "Name1"}));
			List_RecentItems.Items.Add(new ListViewItem(new[] {"Path1", "Name1"}));

			foreach (var Item in Settings.Default.RecentItems) {
				List_RecentItems.Items.Add(new ListViewItem(new [] {Item, Item.Split('\\')[Item.Split('\\').Length - 1]}));
			}

			List_RecentItems.Resize += (S, E) => {
				List_RecentItems.Columns[0].Width = List_RecentItems.Width / 2;
				List_RecentItems.Columns[1].Width = List_RecentItems.Width / 2;
				List_RecentItems.Refresh();
			};

			List_RecentItems.Update();

		}
	}
}
