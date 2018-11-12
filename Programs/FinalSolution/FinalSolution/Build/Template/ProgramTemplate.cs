﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

// Replace this with the name of the user's program
namespace Solution.Build.Template {

	/// <summary>
	/// Template class for code construction. User code is placed in the <see cref="T:Solution.Build.Template.Program"/> class
	/// and is then wrapped by this class
	/// </summary>
	public class Main_Program {

		private static CancellationTokenSource CTokenSource;
		private static CancellationToken CToken;

		/// <summary>
		/// The name of the program being debugged.
		/// Is the namespace of the program.
		/// </summary>
		private static string Name;

		// 
		
		private static void Main(string[] Args) {
			CTokenSource = new CancellationTokenSource(); // B̶l̶a̶c̶k-̶m̶a̶g̶i̶c  Generates a CancellationToken that can be 
			CToken = CTokenSource.Token; // ̶W̶i̶t̶c̶h̶c̶r̶a̶f̶t-̶a̶n̶d-̶w̶i̶z̶a̶r̶d̶r̶y         used to kill a Task

			Name = typeof(Main_Program).Namespace; // Software saves the namespace as the name assigned to the program

			try {
				if (Args?[0] == "DEBUG") { // Check if DEBUG was passed. If it wasn't then an IndexOutOfRangeException
										    //   may occur.  

					Task.Factory.StartNew(async () => { // ̶A̶s̶y̶n̶c̶h̶r̶o̶n̶o̶u̶s-̶m̶a̶g̶i̶c̶k
						while (true) { // Do it forever

							if (CToken.IsCancellationRequested) return; // Quit if we have been asked to

							Console.WriteLine(@"DAT|" + JsonConvert.SerializeObject(ObserveVariables()));
								// Do the really cool thing and send it to the console

							await Task.Delay(250); // Delay 0.25s

						}
					}, CToken); // Pass the CancellationToken to the Task

					Console.WriteLine($@"Debugging of program ""{Name}"" in progress"); // Let the world know
                                                                         // we're debugging

				}

			} catch (IndexOutOfRangeException) {
				Args = new[] {""};
			} // If no arguments were supplied, this catches the IndexOutOfRangeException that would occur

			// Run their code

			Program.Main(Args);

			// Finish up

			CTokenSource.Cancel();

		}

		#region Get variables

		private static List<string[]> ObserveVariables() {

			// Get a list of all the variables that are being observed and their contents using Reflection

			var ReflectionInfo = typeof(Program).GetFields(BindingFlags.NonPublic |
			                                               BindingFlags.Public |
			                                               BindingFlags.Static);
				// Returns a list of all the static variables in the Program class
				// This is useful because it allows me to dynamically read the class' contents at runtime

			var StringSet = new List<string[]>();
			
			foreach (var FI in ReflectionInfo) {
				// for every static variable in the class, return its Name, Type and Value 
				StringSet.Add(new[] {FI.Name, (FI.GetValue(null) ?? "null").ToString(), FI.FieldType.Name});
					// Using null coalescence is a good way to stop errors because of null values
			}

			return StringSet;

		}

		#endregion

	}

}