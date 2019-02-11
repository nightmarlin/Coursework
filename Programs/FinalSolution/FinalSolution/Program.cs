using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Solution.Welcome;
using System.Threading.Tasks;

namespace Solution {

	/// <summary>
	/// The main program. Starts on load and sets up error handlers, cleaners and the welcome form. 
	/// </summary>
	public static class Program {

		private static CancellationTokenSource CTokenSource;
		private static CancellationToken CToken;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main() {

			var CurDom = AppDomain.CurrentDomain;
			
			// Prevent RAM 'hogging'
			CTokenSource = new CancellationTokenSource(); // Black magic trickery
			CToken = CTokenSource.Token; // Cross thread fun
			Task.Factory.StartNew(async () => {
				while (true) { // Collect disposed objects every 10 seconds
					if (CToken.IsCancellationRequested) return; // break on exit
					GC.Collect();// clean up
					await Task.Delay(10000, CToken); // wait 10s or on exit, whichever comes first
				}
			}, CToken);

			// Handler for unhandled exceptions.
			CurDom.UnhandledException += (S, E) => {
				var Ex = (Exception) E.ExceptionObject; // Get the exception
				var Text = "A serious error occurred: " + Ex.Message + Environment.NewLine +
				           Ex.StackTrace + Environment.NewLine + "The application will now exit.";
				MessageBox.Show(Text); // Display to user
				Debug.WriteLine(Text);
				Console.WriteLine(Text);
				Application.Exit(); // Die quietly
			};
			// Handler for exceptions in threads behind forms.
			Application.ThreadException += (S, E) => {
				var Ex = E.Exception; // Get the exception
				var Text = "A serious thread error occurred: " + Ex.Message + Environment.NewLine +
				           Ex.StackTrace + Environment.NewLine + "The application will now exit.";
				MessageBox.Show(Text); // Tell the user
				Debug.WriteLine(Text);
				Console.WriteLine(Text);
				Application.Exit(); // Die quietly
			};

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmWelcome());
			
		}


	}
}