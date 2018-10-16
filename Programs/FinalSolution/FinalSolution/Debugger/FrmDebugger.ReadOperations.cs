using System;
using System.Collections.Generic;
using System.Diagnostics;

using Newtonsoft.Json;

namespace Solution.Debugger {
	partial class FrmDebugger {

		#region Read operations

		private delegate void OutputDelegate(object S, DataReceivedEventArgs E);

		/// <summary>
		/// https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
		/// </summary>
		/// <param name="S">the object that sent the event</param>
		/// <param name="E">the data attached to the event</param>
		private void ReadOutput(object S, DataReceivedEventArgs E) {

			// Check if correct thread
			if (TxtStandardOutput.InvokeRequired) {
				
				// Exit if disposed (it's caused some errors due to the nature of Async)
				if (this.IsDisposed) return;

				var OutputDelegate = new OutputDelegate(ReadOutput);
				try {
					// Invoke on UI thread
					this.Invoke(OutputDelegate, new object[] {S, E});
				} catch (ObjectDisposedException) {
					// Don't break.
					// Normally breaks because of Async operations trying to operate on the disposed program
					return;
				}

			} else {
				// This is the correct thread

				if (IsVariables(E.Data)) {
					// Yay variable data!
					OutputVariables(E.Data); 
					return;
				}

				// Show the user the output
				TxtStandardOutput.Text += $@"{E.Data}{Environment.NewLine}";

				//Console.WriteLine(@"Output: " + E.Data);
			}
		}
		
		/// <summary>
		/// https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
		/// </summary>
		/// <param name="S">the object that sent the event</param>
		/// <param name="E">the data attached to the event</param>
		private void ReadError(object S, DataReceivedEventArgs E) {
			if (this.TxtErrorOutput.InvokeRequired) {
				// Invoke if needed
				var OutputDelegate = new OutputDelegate(ReadError);
				if (this.IsDisposed) return;
				try {
					this.Invoke(OutputDelegate, new object[] {S, E});
				} catch (ObjectDisposedException) {
					return;
				}

			} else {
				// We're on the thread so do what I need to do
				if (E.Data != "") {
					TxtErrorOutput.Text = $@"Error detected:{Environment.NewLine}{E.Data}";
				}

				Console.WriteLine(@"Error: " + E.Data);

				try {
					_DebugProcess.CancelErrorRead(); 
					// Stop Async error reading
				} catch (InvalidOperationException) { }

				try {
					_DebugProcess.CancelOutputRead();
					// Stop Async output reading
				} catch (InvalidOperationException) { }

				_DebugProcess.EnableRaisingEvents = false;
				// No more events

				try {
					if (!_DebugProcess.HasExited) {
						_DebugProcess.Kill();
						_DebugProcess.WaitForExit();
						// End the process
					}
				} catch (InvalidOperationException) { }

				StopDebuggingInterfaceChanges();
			}

		}

		#endregion

		#region Observe Variables

		private static bool IsVariables(string Line) {
			// Is it null? It could be
			// Does it start with "DAT|", the variable data identifier
			return !(Line is null) && Line.StartsWith(@"DAT|");
		}

		private void OutputVariablesOld(string Data) {

			// Remove `DAT|[`
			Data = Data.Remove(0, 5);

			//Console.WriteLine(Data);
			
			// Remove last `]`
			var VariableOut = Data.Remove(Data.Length - 1);

			// Remove `["` instances
			VariableOut = VariableOut.Replace("[\"", "");
			// Remove `"]` instances
			VariableOut = VariableOut.Replace("\"]", "");
			// Replace `","` with ` = `
			VariableOut = VariableOut.Replace("\",\"", " = ");
			// Replace `,` instances with a new line
			VariableOut = VariableOut.Replace(",", Environment.NewLine);

			VariableOut = "Variables:" + Environment.NewLine + Environment.NewLine + VariableOut;

			/* For the input `DAT|[["Name1","Value1"],["Name2","Value2"]]`, you get
			 *
			 * `Variables:
			 *
			 * Name1 = Value1
			 * Name2 = Value2`
			 *
			 */

			TxtVariableOutput.Text = VariableOut;

		}

		private void OutputVariables(string Data) {

			// Remove `DAT|`
			Data = Data.Remove(0, 4);

			//Console.WriteLine(Data);
			
			// Remove last `]`
			var ListOut = JsonConvert.DeserializeObject<List<string[]>>(Data);

			var VariableOut = "Variables:" + Environment.NewLine;

			foreach (var Stringse in ListOut) {
				VariableOut += $"{Stringse[0]} <{Stringse[2]}> = {Stringse[1]}{Environment.NewLine}{Environment.NewLine}";
			}

			/* For the input `DAT|[["Name1","Value1"],["Name2","Value2"]]`, you get
			 *
			 * `Variables:
			 *
			 * Name1 = Value1
			 * Name2 = Value2`
			 *
			 */

			TxtVariableOutput.Text = VariableOut;

		}

		#endregion
	}
}
