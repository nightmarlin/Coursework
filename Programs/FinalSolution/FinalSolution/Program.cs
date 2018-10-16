using System;
using System.Windows.Forms;

using Solution.Designer;

namespace Solution {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new FrmDesigner());
			} catch (Exception Ex) {
				Console.WriteLine($@"A serious error occurred: {Environment.NewLine}" +
				                  $@"{Ex.GetType()}{Environment.NewLine}{Ex.Data}");
				Console.ReadLine();
			}
		}
	}
}
