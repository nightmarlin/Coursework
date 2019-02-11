using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using Newtonsoft.Json;

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

			Settings.Default.SettingsSaving += (S, E) => { List_RecentItems_Update(); };

			List_RecentItems.ItemActivate += ListRecentItemsItemSelected;

		}
		

		private void BtnShowDesigner_Click(object S, EventArgs E) {
			
			var Designer = new FrmDesigner(this); // Set up a new FrmDesigner with a reference to this
			Designer.VisibleChanged += (S2, E2) => { Show(); }; // Add event handlers
			Designer.Closed += (S2, E2) => { Show(); };

			Designer.Show(); // Show designer

			Hide();

		}

		private void FrmWelcome_Load(object sender, EventArgs e) {

			List_RecentItems_Update(); // reload the list

		}

		private void List_RecentItems_Update() {

			// DD/MM/YYYY HH:mm|C:\\File\Path\Project.bs

			List_RecentItems.Clear(); // empty the list

			List_RecentItems.View = View.Details;

			List_RecentItems.Columns.Add("Name", List_RecentItems.Width / 3, HorizontalAlignment.Left);
			List_RecentItems.Columns.Add("Path", List_RecentItems.Width / 3, HorizontalAlignment.Left);
			List_RecentItems.Columns.Add("Date Last Accessed", List_RecentItems.Width / 3, HorizontalAlignment.Left);
			
			List_RecentItems.Activation = ItemActivation.TwoClick;

			for (var Index = Settings.Default.RecentItems.Count - 1; Index >= 0; Index--) { // Iterate backwards through the list
				var Item = Settings.Default.RecentItems[Index]; // Get the current item

				var ToList = Item.Split('|'); // Split on pipe character

				// Details time
				List_RecentItems.Items.Add(new ListViewItem(new [] {ToList[1].Split('\\')[Item.Split('\\').Length - 1], ToList[1], ToList[0]}));
			}
			
			// allow resizing evenly
			List_RecentItems.Resize += (S, E) => {
				List_RecentItems.Columns[0].Width = List_RecentItems.Width / 3;
				List_RecentItems.Columns[1].Width = List_RecentItems.Width / 3;
				List_RecentItems.Columns[2].Width = List_RecentItems.Width / 3;
				List_RecentItems.Refresh();
			};

			List_RecentItems.Update();

		}

		private void ClearRecentItemsToolStripMenuItem_Click(object sender, EventArgs e) {
			Settings.Default.RecentItems = new StringCollection(); // Empty the list
			Settings.Default.Save(); // Save the empty list
			List_RecentItems_Update(); // Update the recent items list
		}

		private void QuitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit(); // Quit
		}

		private void BtnOpenFile_Click(object sender, EventArgs e) { // Open from file
			string OpenPath;
			using (var OFD = new OpenFileDialog {
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				CheckFileExists = true,
				Filter = "BSharp Files (*.bs)|*.bs", // Only show .bs files
				DefaultExt = "bs", // Only open .bs files
				
			}) {
				var Complete = OFD.ShowDialog(); // get the path

				if (Complete != DialogResult.OK || !File.Exists(OFD.FileName)) {
					MessageBox.Show("You need to give a valid file path", "B#", MessageBoxButtons.OK,
					                MessageBoxIcon.Warning);
					return;
				}

				OpenPath = OFD.FileName;

			}

			OpenDesigner(OpenPath);
		}

		private void OpenDesigner(string Path) { // Open from a path

			var DesignerAsJSON = File.ReadAllText(Path);

			FrmDesigner Designer = null;

			try {
				Designer = (FrmDesigner) JsonConvert.DeserializeObject(DesignerAsJSON, typeof(FrmDesigner)); // open the designer

				if (Designer is null) throw new Exception("Something went wrong"); // it broke

			} catch (Exception Ex) { // it broke
				MessageBox.Show("Unable to deserialise the file. It may have been corrupted.", "B#",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Designer._ParentFrmWelcome = this; // Show the designer

			Designer.VisibleChanged += (S2, E2) => { Show(); };
			Designer.Closed += (S2, E2) => { Show(); };

			Designer.Show();

			Hide();


		}

		private void ListRecentItemsItemSelected(object S, EventArgs E) { // Open from the list
			var Item = List_RecentItems.SelectedItems[0];
			var SelectedPath = Item.SubItems[1].Text;
			

			if (!File.Exists(SelectedPath)) {
				MessageBox.Show("That item no longer exists or has been moved. Removing from the list", "B#",
				                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				var Index = Settings.Default.RecentItems.IndexOf(Item.SubItems[2].Text + "|" + Item.SubItems[1].Text);

				if (Index != -1) {
					Settings.Default.RecentItems.RemoveAt(Index);
				}

				Settings.Default.Save();

				List_RecentItems_Update();
			}

		}
	}
}
