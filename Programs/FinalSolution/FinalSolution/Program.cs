using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Solution.Welcome;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Solution {

	static class Program {

		private static CancellationTokenSource CTokenSource;
		private static CancellationToken CToken;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main() {

			var currentDomain = AppDomain.CurrentDomain;
			
			// Prevent RAM 'hogging'
			CTokenSource = new CancellationTokenSource();
			CToken = CTokenSource.Token;
			Task.Factory.StartNew(async () => {
				while (true) {
					if (CToken.IsCancellationRequested) return;
					GC.Collect();
					await Task.Delay(10000, CToken);
				}
			}, CToken);

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