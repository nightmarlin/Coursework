
using System;
using System.IO;
using System.Windows.Forms;

using Solution.Designer;

using Newtonsoft.Json;

namespace Solution.Saving {

    /// <summary>
    /// Provides static methods for saving ".BSharp" projects
    /// </summary>
    public static class Save {

        /// <summary>
		/// Saves the project at the file location specified by the user
		/// </summary>
		/// <param name="Designer">The FrmDesigner to save</param>
		/// <returns>true: Save was successful, False: Save went bad</returns>
        public static bool SaveProject(FrmDesigner Designer) {

	        try {
		        var Path = Designer.FileInfo.Split('|')[1];
		        var DesignerAsJson = JsonConvert.SerializeObject(Designer.SContainer_Workspace.Panel2, new JsonSerializerSettings {
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		        });

		        if (File.Exists(Path)) {
			        File.WriteAllText(Path, "");
		        } else {
			        var F = File.Create(Path);
			        F.Close();
		        }

		        using (var SW = new StreamWriter(Path)) {

			        SW.Write(DesignerAsJson);

		        }

	        } catch (UnauthorizedAccessException Ex) { // Error handling
		        MessageBox.Show($"You did not have permission to access the file. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;
	        } catch (ArgumentException Ex) { // I probably did a bad thing
		        MessageBox.Show($"Something broke but it wasn't your fault. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (DirectoryNotFoundException Ex) { // FAKE
		        MessageBox.Show($"We couldn't find that directory. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (PathTooLongException Ex) { // File path too long
		        MessageBox.Show($"The file path was too long. Windows is mad at you. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (IOException Ex) { // IO Disagrees with my decisions
		        MessageBox.Show($"Something broke but it wasn't your fault. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (NotSupportedException Ex) { // Windows hates me
		        MessageBox.Show($"Something broke but it wasn't your fault. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (System.Security.SecurityException Ex) { // Get your permissions sorted
		        MessageBox.Show($"Security settings stopped us from saving your work. Please contact your local sysadmin." +
		                        $"Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;
	        }

	        return true;
        }

		/// <summary>
		/// Saves the code file for the user
		/// </summary>
		/// <param name="CS">The code</param>
		/// <param name="Path">The filepath</param>
		/// <returns>True: success, False: failure</returns>
        public static bool SaveCSFile(string CS, string Path) {

			if (File.Exists(Path)) {
				var Result = MessageBox.Show("A CS file with this name already exists. Overwrite it?", "B#",
				                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (Result != DialogResult.Yes) {
					MessageBox.Show("Could not overwrite file. Aborting", "B#", MessageBoxButtons.OK,
					                MessageBoxIcon.Exclamation);
					return false;
				}
			}

			try {
				File.WriteAllText(Path, CS);
			} catch (UnauthorizedAccessException Ex) { // Error handling
		        MessageBox.Show($"You did not have permission to access the file. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;
	        } catch (ArgumentException Ex) { // I probably did a bad thing
		        MessageBox.Show($"Something broke but it wasn't your fault. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (DirectoryNotFoundException Ex) { // FAKE
		        MessageBox.Show($"We couldn't find that directory. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (PathTooLongException Ex) { // File path too long
		        MessageBox.Show($"The file path was too long. Windows is mad at you. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (IOException Ex) { // IO Disagrees with my decisions
		        MessageBox.Show($"Something broke but it wasn't your fault. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (NotSupportedException Ex) { // Windows hates me
		        MessageBox.Show($"Something broke but it wasn't your fault. Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;

	        } catch (System.Security.SecurityException Ex) { // Get your permissions sorted
		        MessageBox.Show($"Security settings stopped us from saving your work. Please contact your local sysadmin." +
		                        $"Details follow: {Environment.NewLine}{Ex.Message}",
		                        "B#", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;
	        }


			return true;
		}

    }

}