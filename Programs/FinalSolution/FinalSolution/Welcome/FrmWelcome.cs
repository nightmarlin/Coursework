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

			Settings.Default.SettingsSaving += (S, E) => { List_Welcome_Load(); };

		}
		

		private void BtnShowDesigner_Click(object S, EventArgs E) {
			
			var Designer = new FrmDesigner(this);
			Designer.VisibleChanged += (S2, E2) => { Show(); };
			Designer.Closed += (S2, E2) => { Show(); };

			Designer.Show();

			Hide();

		}

		private void FrmWelcome_Load(object sender, EventArgs e) {

			List_Welcome_Load();

		}

		private void List_Welcome_Load() {

			// DD/MM/YYYY HH:mm|C:\\File\Path\Project.bs

			List_RecentItems.Clear();

			List_RecentItems.View = View.Details;
			List_RecentItems.GridLines = false;

			List_RecentItems.Columns.Add("Name", List_RecentItems.Width / 3, HorizontalAlignment.Left);
			List_RecentItems.Columns.Add("Path", List_RecentItems.Width / 3, HorizontalAlignment.Left);
			List_RecentItems.Columns.Add("Date Last Accessed", List_RecentItems.Width / 3, HorizontalAlignment.Left);
			
			List_RecentItems.Activation = ItemActivation.TwoClick;



			foreach (var Item in Settings.Default.RecentItems) {
				var ToList = Item.Split('|');

				List_RecentItems.Items.Add(new ListViewItem(new [] {ToList[1].Split('\\')[Item.Split('\\').Length - 1], ToList[1], ToList[0]}));
			}

			List_RecentItems.Resize += (S, E) => {
				List_RecentItems.Columns[0].Width = List_RecentItems.Width / 3;
				List_RecentItems.Columns[1].Width = List_RecentItems.Width / 3;
				List_RecentItems.Columns[2].Width = List_RecentItems.Width / 3;
				List_RecentItems.Refresh();
			};

			List_RecentItems.Update();

		}
	}
}
