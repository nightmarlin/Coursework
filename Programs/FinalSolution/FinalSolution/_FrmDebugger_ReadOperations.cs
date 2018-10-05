using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Solution {
	partial class FrmDebugger {
				#region Read operations

		delegate void OutputDelegate(object S, DataReceivedEventArgs E);

		/// <summary>
		/// https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
		/// </summary>
		/// <param name="S">the object that sent the event</param>
		/// <param name="E">the data attached to the event</param>
		private void ReadOutput(object S, DataReceivedEventArgs E) {

			if (this.TxtStandardOutput.InvokeRequired) {

				var OutputDelegate = new OutputDelegate(ReadOutput);
				this.Invoke(OutputDelegate, new object [] {S, E});

			} else {

				TxtStandardOutput.Text += $@"> {E.Data}{Environment.NewLine}";

				Console.WriteLine(@"Output: " + E.Data);
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
				this.Invoke(OutputDelegate, new object[] {S, E});

			} else {
				// We're on the thread so do what I need to do
				if (E.Data != "") {
					TxtErrorOutput.Text = $@"Error detected:{Environment.NewLine}{E.Data}";
				}

				Console.WriteLine(@"Error: " + E.Data);

				try {
					_DebugProcess.CancelErrorRead();
				} catch (InvalidOperationException) { }

				try {
					_DebugProcess.CancelOutputRead();
				} catch (InvalidOperationException) { }

				_DebugProcess.EnableRaisingEvents = false;
				try {
					if (!_DebugProcess.HasExited) {
						_DebugProcess.Kill();
						_DebugProcess.WaitForExit();
					}
				} catch (InvalidOperationException) { }

				StopDebuggingInterfaceChanges();
			}

		}

		#endregion
	}
}
