using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

// Replace this with the name of the user's program
namespace Solution.Build.Template {

	/// <summary>
	/// Template class for code construction. User code is laced in the User_Program class
	/// and is then wrapped 
	/// </summary>
	public class Main_Program {

		private static CancellationTokenSource CTokenSource;
		private static CancellationToken CToken;

		/// <summary>
		/// The name of the program being debugged.
		/// Is the namespace of the program.
		/// </summary>
		private static string Name;

		private static void Main(string[] Args) {

			CTokenSource = new CancellationTokenSource(); // Black magic
			CToken = CTokenSource.Token; // Witchcraft and wizardry

			Name = typeof(Main_Program).Namespace;

			try {
				if (Args?[0] == "DEBUG") {

					Task.Factory.StartNew(async () => {
						while (true) {

							if (CToken.IsCancellationRequested) return;

							Console.WriteLine(@"DAT|" + JsonConvert.SerializeObject(ObserveVariables()));

							await Task.Delay(250);

						}
					}, CToken);

					Console.WriteLine($@"Debugging of program ""{Name}"" in progress");

				}

			} catch (IndexOutOfRangeException) {
				Args = new[] {""};
			} // If no arguments are supplied, this might not have worked...

			// Run their code

			Program.Main(Args);

			// Finish up

			CTokenSource.Cancel();

		}

		#region Get variables

		private static List<string[]> ObserveVariables() {

			// Get a list of all the variables that are being observed and their contents
			//     using Reflection

			var ReflectionInfo = typeof(Program).GetFields(BindingFlags.NonPublic |
			                                                    BindingFlags.Public |
			                                                    BindingFlags.Static);

			var StringSet = new List<string[]>();

			foreach (var FI in ReflectionInfo) {

				StringSet.Add(new[] {FI.Name, (FI.GetValue(null) ?? "null").ToString(), FI.FieldType.Name});

			}

			return StringSet;

		}

		#endregion

	}

}