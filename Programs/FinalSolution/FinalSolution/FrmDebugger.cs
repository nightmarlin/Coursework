using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/* - SRC: https://stackoverflow.com/questions/355724/embedding-a-dos-console-in-a-windows-form -
   var processStartInfo = new ProcessStartInfo("SomeOldApp.exe", "-p SomeParameters");
   
   processStartInfo.UseShellExecute = false;
   processStartInfo.ErrorDialog = false;
   
   processStartInfo.RedirectStandardError = true;
   processStartInfo.RedirectStandardInput = true;
   processStartInfo.RedirectStandardOutput = true;
   processStartInfo.CreateNoWindow = true;
   
   Process process = new Process();
   process.StartInfo = processStartInfo;
   bool processStarted = process.Start();
   
   StreamWriter inputWriter = process.StandardInput;
   StreamReader outputReader = process.StandardOutput;
   StreamReader errorReader = process.StandardError;
   process.WaitForExit();
 */

namespace Solution {

	/// <summary>
	///     The form upon which all debugging will occur
	/// </summary>
	public partial class FrmDebugger : Form {
	
		private readonly Process _DebugProcess;
		private readonly FrmDesigner _ParentFrmDesigner;
		private bool _IsDebugging;

		/// <summary>
		///     Parameter-less initialization. Disables all buttons except Exit so nothing breaks
		/// </summary>
		public FrmDebugger() {
			InitializeComponent();
			StopDebuggingInterfaceChanges();
			TxtStandardOutput.Text = @"No program was loaded, debugging will not occur";
			TxtVariableOutput.Text = @"No variables can be observed";
			TxtErrorOutput.Text = @"No errors will be recorded";
		}

		/// <summary>
		///     Initialization with parameters. Allows debugging to begin
		/// </summary>
		/// <param name="FileToDebug">The path of the "*.exe" file to be debugged</param>
		/// <param name="MyParent">The FrmDesigner that instantiated the FrmDebugger</param>
		public FrmDebugger(string FileToDebug, FrmDesigner MyParent) {
			InitializeComponent();
			StopDebuggingInterfaceChanges();


			Application.ApplicationExit += (S, E) => {
				_DebugProcess?.Kill();
			};


			if (FileToDebug == null || MyParent == null) {
				TxtStandardOutput.Text = @"No program was loaded, debugging will not occur";
				TxtVariableOutput.Text = @"No variables can be observed";
				TxtErrorOutput.Text = @"No errors will be recorded";

				return;
			}


			_DebugProcess = new Process {
				StartInfo = new ProcessStartInfo {
					FileName = FileToDebug,

					CreateNoWindow = true, // No new window
					UseShellExecute = false, // Don't run it in the system shell

					//Arguments = "DEBUG"

					RedirectStandardError = true, // Allows me to read the error output
					RedirectStandardOutput = true, // Allows me to read normal output
					RedirectStandardInput = true // Allows me to send my own inputs to the program
				},

				EnableRaisingEvents = true // Allows me to hook on to the "Exited" event
			};

			_ParentFrmDesigner = MyParent;

			_ParentFrmDesigner.Hide(); // Hide the parent form

			_IsDebugging = _DebugProcess.Start(); // Start the process


			if (!_IsDebugging) { // Did something break?
				MessageBox.Show(@"Something went wrong and the process couldn't start, sorry.",
				                @"Unable to start process", MessageBoxButtons.OK);

				KillDebugProcess(); // Kill everything just in case

				_ParentFrmDesigner.Show(); // Show the main form

				Hide(); // Disappear
				Dispose(); // Clean up
			}

			TxtStandardOutput.Text = $@"Process started at {_DebugProcess.StartTime:f} {Environment.NewLine}";
				// Feedback to user

			Console.WriteLine($@"Process is called: {_DebugProcess.ProcessName} {Environment.NewLine}" +
			                $@"Process was started at {_DebugProcess.StartTime:f} {Environment.NewLine}" +
			                $@"Process has {(_DebugProcess.HasExited ? "" : "not ")}exited");
				// Feedback to me (plus string interpolation, yay)

			_DebugProcess.ErrorDataReceived += new DataReceivedEventHandler(ReadError);

			_DebugProcess.OutputDataReceived += new DataReceivedEventHandler(ReadOutput);

			_DebugProcess.Exited += (Sender, E) => { StopDebuggingInterfaceChanges(); };

			StartDebuggingInterfaceChanges(); // Enable buttons

			TxtInputToProgram.Text = ""; // Empty the input
			TxtInputToProgram_TextChanged(null, null); // Disable the SUBMIT button

			_DebugProcess.BeginOutputReadLine();
			_DebugProcess.BeginErrorReadLine();

			TxtInputToProgram.Focus(); // Give focus to TxtInputToProgram
		}

		#region Process related methods

		/// <summary>
		///	Closes all open streams and then kills the process if it's still alive
		/// </summary>
		private void KillDebugProcess() {

			try {
				_DebugProcess?.Kill();
				_DebugProcess?.Close();
				_DebugProcess?.Dispose();
			} catch (InvalidOperationException) { }
		}

		#endregion


		#region Interface appearance methods

		/// <summary>
		/// Enables / Disables the SUBMIT button based on if there's text in the input box
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void TxtInputToProgram_TextChanged(object Sender, EventArgs E) {
			if (TxtInputToProgram.Text == "" || _IsDebugging == false)
				BtnSubmitInput.Enabled = false;
			else
				BtnSubmitInput.Enabled = true;
		}

		/// <summary>
		/// There used to be something here, but removing this snippet breaks the WYSIWYG editor so...
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void FrmDebugger_Load(object Sender, EventArgs E) { }

		/// <summary>
		/// Disable all the buttons
		/// </summary>
		private void StopDebuggingInterfaceChanges() {
			BtnExitDebugging.Enabled = true;

			BtnPauseExecution.Enabled = false;
			BtnStartExecution.Enabled = false;
			BtnStopExecution.Enabled = false;
			BtnSubmitInput.Enabled = false;

			_IsDebugging = false;
			TxtInputToProgram.Enabled = false;
		}

		/// <summary>
		/// Enable the buttons (Except START cos we've already started)
		/// </summary>
		private void StartDebuggingInterfaceChanges() {
			BtnExitDebugging.Enabled = true;
			BtnPauseExecution.Enabled = true;
			BtnStartExecution.Enabled = false;
			BtnStopExecution.Enabled = true;
			BtnSubmitInput.Enabled = true;

			_IsDebugging = true;
			TxtInputToProgram.Enabled = true;
		}

		#endregion

		#region Control Flow Buttons

		private async void BtnSubmitInput_Click(object Sender, EventArgs E) {

			var ToSubmit = Regex.Replace(TxtInputToProgram.Text, @"\p{C}+", string.Empty);
				// Remove unreadable characters (Thanks Regex)

			if (ToSubmit == string.Empty) return; // Don't send an empty string
			
			Console.WriteLine(@"Sent: " + ToSubmit);

			TxtStandardOutput.Text += $@": {ToSubmit}{Environment.NewLine}";

			await _DebugProcess.StandardInput.WriteLineAsync(ToSubmit); // Send input to the program
			

			TxtInputToProgram.Text = ""; // Empty the text box

			TxtInputToProgram.Focus(); // Give focus to TxtInputToProgram
		}

		/// <summary>
		/// Doesn't do anything to the program, just prevents the user sending inputs
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void BtnPauseExecution_Click(object Sender, EventArgs E) {
			StopDebuggingInterfaceChanges();
			BtnStartExecution.Enabled = true;
		}

		/// <summary>
		/// Kills the process and any affiliated readers. Disables some buttons
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void BtnStopExecution_Click(object Sender, EventArgs E) {
			StopDebuggingInterfaceChanges();
			KillDebugProcess();
		}

		/// <summary>
		/// Doesn't do anything to the program, just enables the user to send inputs
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void BtnStartExecution_Click(object Sender, EventArgs E) {
			StartDebuggingInterfaceChanges();
		}

		/// <summary>
		/// Kills the program and any affiliated readers, then shows the parent form and cleans up
		/// </summary>
		/// <param name="Sender">Reqd. for events</param>
		/// <param name="E">Reqd. for events</param>
		private void BtnExitDebugging_Click(object Sender, EventArgs E) {
			StopDebuggingInterfaceChanges();
			KillDebugProcess();

			_ParentFrmDesigner?.Show(); // Show parent form

			Hide(); // Become invisible
			Dispose(); // Clean up
		}

		private async void StartOutputRead() {
			TxtStandardOutput.Text += await _DebugProcess.StandardOutput.ReadToEndAsync();
		}

		#endregion

	}

}