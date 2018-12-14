
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
				
				// Exit if disposed (it's caused some errors due to the nature of async code)
				if (this.IsDisposed) return;

				var OutputDelegate = new OutputDelegate(ReadOutput);
				try {
					// Invoke on UI thread (AKA: The correct thread)
					this.Invoke(OutputDelegate, new object[] {S, E});
				} catch (ObjectDisposedException) {
					// Don't break.
					// Normally breaks because of async operations trying to operate on the disposed program
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

				Console.WriteLine(@"Debug Process Error: " + E.Data);

				try {
					_DebugProcess.CancelOutputRead();
					_DebugProcess.CancelErrorRead(); 
					_DebugProcess.EnableRaisingEvents = false;
					// Stop Async error and output reading
					// Prevent further events from firing

					if (!_DebugProcess.HasExited) {
						_DebugProcess.Kill();
						_DebugProcess.WaitForExit();
						// End the process
					}
				} catch (InvalidOperationException) { }


				StopDebuggingInterfaceChanges();
				
				// Because of the speed at which the process is killed, InvalidOperationExceptions could pop up in
				// any of the operations. This statement just prevents instant crashes
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
			 * However for the input `DAT|[["Name1","A string with '["' or '"]' or '","' or ','"],["Name2","Value2"]]`
			 *
			 * `Variables:
			 *
			 * Name1 = A string with '' or '' or ' = ' or '
			 * '
			 * Name2 = Value2`
			 *
			 * Note the loss of '["' and '"]', alongside the replacement of ('","' with ' = ') and (',' with a new line)  
			 */

			TxtVariableOutput.Text = VariableOut;

		}

		private void OutputVariables(string Data) {

			try {

				// Remove "DAT|". Note that `string.Remove` is used instead of `string.Replace`. This is because
				//   variable data may contain the "DAT|" string, so the method should not delete that
				Data = Data.Remove(0, 4);

				//Console.WriteLine(Data);

				// Deserialize JSON object with NewtonSoft.Json
				var ListOut = JsonConvert.DeserializeObject<List<string[]>>(Data);

				var VariableOut = "Variables:" + Environment.NewLine;


				foreach (var Strings in ListOut) {
					VariableOut +=
						$"{Strings[0]} <{Strings[2]}> = {Strings[1]}{Environment.NewLine}{Environment.NewLine}";
				}

				/* For the input `DAT|[["Name1","Value1"],["Name2","Value2"]]`, you get
				 *
				 * `Variables:
				 *
				 * Name1 <Type1> = Value1
				 * Name2 <T2> = Value2`
				 *
				 */

				TxtVariableOutput.Text = VariableOut;
			} catch (Exception) {
				var x = "";
				// Show the user the output
				TxtStandardOutput.Text += $@"Unable to deserialize variable data:{Environment.NewLine}" +
				                          $@"--> {Data}{Environment.NewLine}";
			}
		
		}

		#endregion
	}
}
