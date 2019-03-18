using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Solution {

	/// <summary>
	/// Has all the useful tooltips and help pages
	/// </summary>
	public static class TaH {

		#region FrmDesigner

		/// <summary>
		/// The help text for the workspace
		/// </summary>
		public static string FrmDesignerWorkspaceHelpText = $"The workspace is where you can design and build your B# programs. {Environment.NewLine}" +
		                                         $"To add a block to the workspace either double click a block name or highlight it and press enter. {Environment.NewLine}" +
		                                         $"To connect action blocks together, click the red box on the first then the blue box on the second (It doesn't matter the order, just the colour).{Environment.NewLine}" +
		                                         $"To connect a variable block to an action block, click on the green box and the corresponding yellow box.{Environment.NewLine}" +
		                                         $"To delete a block, press the delete key and click the block you want to delete.{Environment.NewLine}" +
		                                         $"To copy a block, press Ctrl+C then click a block.{Environment.NewLine}" +
		                                         $"To paste a previously copied block, press Ctrl+V. {Environment.NewLine}" +
		                                         $"To run your code, press F5. To find your \"exe\" file press Ctrl+B.{Environment.NewLine}" +
		                                         $"Use Ctrl+Shift+H or Ctrl+Alt+H to get help.{Environment.NewLine}" +
		                                         $"Press Ctrl+P to open the Command Palette{Environment.NewLine}";

		/// <summary>
		/// The help text about blocks
		/// </summary>
		public static string FrmDesignerBlockHelpText = $"Blocks are how you build up your code.{Environment.NewLine}" +
		                                     $"You can connect them together.{Environment.NewLine}" +
		                                     $"-> Red: This block executes first{Environment.NewLine}" +
		                                     $"-> Blue: This block executes after the red block it connects to{Environment.NewLine}" +
		                                     $"-> Yellow: Connects to a variable reference block to allow the use of a variable{Environment.NewLine}" +
		                                     $"-> Green: The connector on a variable reference block{Environment.NewLine}" +
		                                     $"The code starts with the start block and runs until no more blocks are connected{Environment.NewLine}" +
		                                     $"--> Note that adding a loop will not allow your code to be compiled";

		/// <summary>
		/// Save button tooltip
		/// </summary>
		public static string FrmDesignerSaveButtonText = "Save your work";

		/// <summary>
		/// Show code tooltip
		/// </summary>
		public static string FrmDesignerShowInCSText = "Show your code in C-Sharp";

		/// <summary>
		/// Quit tooltip text
		/// </summary>
		public static string FrmDesignerQuitText = "Go back to the welcome screen";

		/// <summary>
		/// Select toolbox text
		/// </summary>
		public static string FrmDesignerSelectToolboxText = "Focus the toolbox";

		/// <summary>
		/// Delete block text
		/// </summary>
		public static string FrmDesignerDeleteText = "Delete the next block you click";

		/// <summary>
		/// Copy block text
		/// </summary>
		public static string FrmDesignerCopyText = "Copy the next block you click";

		/// <summary>
		/// Paste block text
		/// </summary>
		public static string FrmDesignerPasteText = "Paste the last block you copied";

		/// <summary>
		/// Cmd palette text
		/// </summary>
		public static string FrmDesignerCommandPaletteText = "Open the command palette";

		/// <summary>
		/// Debug tooltip text
		/// </summary>
		public static string FrmDesignerDebug = "Run your code";

		/// <summary>
		/// Get exe tooltip text
		/// </summary>
		public static string FrmDesignerGetExe = "Get your \"exe\" file path";
		
		#endregion

		#region FrmDebugger

		/// <summary>
		/// StandardOut tooltip
		/// </summary>
		public static string FrmDebuggerStandardOut = "The output of your program";

		/// <summary>
		/// Observed variables tooltip
		/// </summary>
		public static string FrmDebuggerObservedVars = "Variable data will be shown here when available";

		/// <summary>
		/// Error Out tooltip
		/// </summary>
		public static string FrmDebuggerErrorOut = "Errors will be shown here if they occur";

		/// <summary>
		/// Input Box tooltip
		/// </summary>
		public static string FrmDebuggerInputBox = "Type your input here. Press Enter or SUBMIT to send it.";

		/// <summary>
		/// Submit button tooltip
		/// </summary>
		public static string FrmDebuggerSubmitButton = "Send the input from the input box to the program. HotKey: Enter";

		/// <summary>
		/// Stop Button tooltip
		/// </summary>
		public static string FrmDebuggerStopButton = "Stop debugging and kill the application";

		/// <summary>
		/// Pause Button Tooltip
		/// </summary>
		public static string FrmDebuggerPauseButton = "Pause debugging until START is clicked";

		/// <summary>
		/// Exit button tooltip
		/// </summary>
		public static string FrmDebuggerExitButton = "Kill program and return to previous screen";

		/// <summary>
		/// Start button tooltip
		/// </summary>
		public static string FrmDebuggerStartButton = "Resume execution after pause";

		#endregion

		#region Block Tooltips

		/// <summary>
		/// Beep Block tooltip
		/// </summary>
		public static string BeepBlockTooltip = "Send an audible beep to the user";

		/// <summary>
		/// Decimal Create Block tooltip
		/// </summary>
		public static string DecimalCreateBlockTooltip = "Declare a decimal type variable. Must be placed in the declaration section";
		
		/// <summary>
		/// Boolean Create Block tooltip
		/// </summary>
		public static string BoolCreateBlockTooltip = "Declare a boolean type variable. Must be placed in the declaration section";
		
		/// <summary>
		/// Int Create Block tooltip
		/// </summary>
		public static string IntCreateBlockTooltip = "Declare a integer type variable. Must be placed in the declaration section";
		
		/// <summary>
		/// String Create Block tooltip
		/// </summary>
		public static string StringCreateBlockTooltip = "Declare a string type variable. Must be placed in the declaration section";
		
		/// <summary>
		/// Var Reference Block tooltip
		/// </summary>
		public static string VariableReferenceBlockTooltip = "Use a variable in your code. Select one from the list and connect it where needed";

		/// <summary>
		/// Starter Block tooltip
		/// </summary>
		public static string StarterBlockTooltip = "Where code execution begins. Cannot be created or deleted. " +
		                                           "Do not place declaration blocks beneath this block";

		/// <summary>
		/// VarDeclare Block tooltip
		/// </summary>
		public static string VarDeclareBlockTooltip = "Where variables are declared for use. " +
		                                              "Cannot be created or deleted. " +
		                                              "Do not place action blocks beneath this block";

		#endregion


	}
}
