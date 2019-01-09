using System;
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
			currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
			// Handler for exceptions in threads behind forms.
			Application.ThreadException += GlobalThreadExceptionHandler;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmWelcome());
			
		}

		private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e) {
			var ex = (Exception) e.ExceptionObject;
			Console.Error.WriteLine("A serious error occurred: " + ex.Message + Environment.NewLine + ex.StackTrace);
		}

		private static void GlobalThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e) {
			var ex = e.Exception;
			Console.Error.WriteLine("A serious error occurred: " + ex.Message + Environment.NewLine + ex.StackTrace);
		}

	}
}