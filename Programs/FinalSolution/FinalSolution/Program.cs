using System;
using System.Windows.Forms;

using Solution.Welcome;

namespace Solution {

	static class Program {

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main() {
			try {
				
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new FrmWelcome());
				
				
			} catch (Exception Ex) { // If an unhandled error bubbles up to the top, log the details and exit for safety

				Console.WriteLine($@"A serious error occurred: {Environment.NewLine}" +
				                  $@"{Ex.GetType()}{Environment.NewLine}{Ex.Data}{Environment.NewLine}" +
				                  @"Mission failed. We'll get 'em next time");
				Console.ReadLine();
				return 1;
			}

			return 0;
		}
	}
}
