using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestProgram {

	internal class Program {

		private static CancellationTokenSource CTokenSource;
		private static CancellationToken CToken;

		private const string Name = @"Bébé program MKII";

		#region Internal Variables

		private static int Count = 1;

		#endregion

		private static void Main(string[] Args) {

			CTokenSource = new CancellationTokenSource();
			CToken = CTokenSource.Token;

			try {
				if (Args?[0] == "DEBUG") {

					Task.Factory.StartNew(async () => {
						while (true) {

							if (CToken.IsCancellationRequested) {
								return;
							}

							Console.WriteLine("DAT|" + JsonConvert.SerializeObject(ObserveVariables()));
							await Task.Delay(500);
						}
					}, CToken);

					Console.WriteLine($"Debugging of program \"{Name}\" in progress");

				}

			} catch (IndexOutOfRangeException) {
				//Console.WriteLine("No arguments");
			}

			#region Programmed Logic

			while (true) {

				Console.WriteLine("Outputting to console - " + Count);


				var input = Console.ReadLine(); // Wait for ENTER to be pressed


				if (input is null || input.ToLower() == "" || input.ToLower() == "exit") {
					break;
				}

				Count += 1;
			}

			#endregion Program Logic

			CTokenSource.Cancel();

		}

		private static List<object[]> ObserveVariables() {

			// Get a list of all the variables that are being observed and their contents

			return new List<object[]> {

				#region Variable List

				new object[] {nameof(Count), Count.ToString()}

				#endregion

			};
		}

	}

}