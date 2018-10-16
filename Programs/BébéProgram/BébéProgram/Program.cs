using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestProgram {

	/// <summary>
	/// Template class for code construction
	/// (c) - Lewis W. Miller 2018
	/// Feel free to take a look at how this works!
	/// </summary>
	internal class Program {

		private static CancellationTokenSource CTokenSource;
		private static CancellationToken CToken;

		private const string Name = @"Bébé program MKII";

		private static void Main(string[] Args) {

			CTokenSource = new CancellationTokenSource();
			CToken = CTokenSource.Token;

			try {
				if (Args?[0] == "DEBUG") {

					Task.Factory.StartNew(async () => {
						while (true) {

							if (CToken.IsCancellationRequested) return;

							Console.WriteLine("DAT|" + JsonConvert.SerializeObject(ObserveVariables()));

							await Task.Delay(500);

						}
					}, CToken);

					Console.WriteLine($"Debugging of program \"{Name}\" in progress");

				}

			} catch (IndexOutOfRangeException) { }

			User_Program.Do_Program();

			CTokenSource.Cancel();

		}

		#region Get variables

		private static List<string[]> ObserveVariables() {

			// Get a list of all the variables that are being observed and their contents

			var ReflectionTest = typeof(User_Program).GetFields(BindingFlags.NonPublic |
			                                                    BindingFlags.Public |
			                                                    BindingFlags.Static);

			var Stringses = new List<string[]>();

			foreach (var FI in ReflectionTest) {

				Stringses.Add(new[] {FI.Name, (FI.GetValue(null) ?? "null").ToString(), FI.FieldType.Name});

			}

			return Stringses;

		}

		#endregion

	}

	public static class User_Program {

		// public static T FieldName;

		#region Internal Variables

		private static string Input;
		private static int Count = 1;

		#endregion

		public static void Do_Program() {
			#region Programmed Logic

			while (true) {

				Console.WriteLine("Outputting to console - " + Count);

				Input = Console.ReadLine(); // Wait for ENTER to be pressed

				if (Input is null || Input.ToLower() == "" || Input.ToLower() == "exit") break;

				Count += 1;
			}

			#endregion Program Logic
		}

	}

}