using System;
using System.Threading;
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
				Console.Error.WriteLine("A serious error occurred: " + Ex.Message + Environment.NewLine +
				                        Ex.StackTrace);
			};
			// Handler for exceptions in threads behind forms.
			Application.ThreadException += (S, E) => {
				var Ex = E.Exception;
				Console.Error.WriteLine("A serious error occurred: " + Ex.Message + Environment.NewLine +
				                        Ex.StackTrace);
			};

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmWelcome());
			
		}


	}
}