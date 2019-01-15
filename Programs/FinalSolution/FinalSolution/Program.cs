using System;
using System.Diagnostics;
using System.Windows.Forms;
using Solution.Welcome;

namespace Solution {

	static class Program {

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main() {
			
			var currentDomain = AppDomain.CurrentDomain;
			// Handler for unhandled exceptions.
			currentDomain.UnhandledException += (S, E) => {
				var Ex = (Exception) E.ExceptionObject;
				var Text = "A serious error occurred: " + Ex.Message + Environment.NewLine +
				           Ex.StackTrace + Environment.NewLine + "The application will now exit.";
				MessageBox.Show(Text);
				Debug.WriteLine(Text);
				Application.Exit();
			};
			// Handler for exceptions in threads behind forms.
			Application.ThreadException += (S, E) => {
				var Ex = E.Exception;
				var Text = "A serious thread error occurred: " + Ex.Message + Environment.NewLine +
				           Ex.StackTrace + Environment.NewLine + "The application will now exit.";
				MessageBox.Show(Text);
				Debug.WriteLine(Text);
				Application.Exit();
			};

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmWelcome());
			
		}


	}
}