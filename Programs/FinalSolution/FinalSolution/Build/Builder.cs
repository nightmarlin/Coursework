using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace Solution.Build {

	/// <summary>
	/// Provides a method to compile a functioning program.
	/// </summary>
	public class Builder {

		/// <summary>
		/// The name of the project, and therefore the name of the resulting EXE
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Constructor. 
		/// </summary>
		/// <param name="Name">The name of the project</param>
		public Builder(string Name) {
			this.Name = Name;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Program">The program as text</param>
		/// <param name="Path">The folder path that the EXE will be stored in IE "C:\\Docs\\Projects\\MyProject"</param>
		/// <returns>whether or not the build succeeded</returns>
		public bool Build(string Program, string Path = "") {

			// Check a path has been assigned
			if (Path == "") {
				Path = GetPath();
			}

			// Get the wrapper file
			var ResManager = new ResourceManager("Solution.Properties.Resources",
			                                     Assembly.GetExecutingAssembly());
			var Wrapper = ResManager.GetString("Wrapper");

			// Build the program
			var Output = CompileFromStrings(Path, Wrapper, Program);

			MessageBox.Show(Output);

			if (Output.StartsWith("!: ")) {// errors

				return false;
				
			}

			return true;

		}

		/// <summary>
        /// Asks the user where they want to save the executable if no path was specified
        /// </summary>
        /// <returns>The fully qualified folder path to the EXE</returns>
        public static string GetPath() {
            string Result;
            using (var FBD = new FolderBrowserDialog {
                ShowNewFolderButton = true,
                Description = @"A folder was not specified. Please select one now"
            }) {
                var DR = FBD.ShowDialog();
                Result = DR == DialogResult.OK ? FBD.SelectedPath : Environment.CurrentDirectory;
            }
            return Result;
        }

	    private string CompileFromStrings(string FilePath, string WrapperTxt, string ProgramTxt) {

		    var codeProvider = CodeDomProvider.CreateProvider("CSharp");
		    var OutputLocation = $"{FilePath}\\{Name}.exe";

		    var parameters = new CompilerParameters {
			    GenerateExecutable = true,
			    OutputAssembly = OutputLocation,
			    CompilerOptions = "/main:YourProject.Main_Program" // There is a Main method in both the wrapper
																// and the user program. By adding this switch
																// MSBuild is told to execute the program from
																// the Main method in the Wrapper
		    };
		    parameters.ReferencedAssemblies.Add("Newtonsoft.Json.dll");
			
		    //Make sure we generate an EXE, not a DLL
		    var Results = codeProvider.CompileAssemblyFromSource(parameters, WrapperTxt, ProgramTxt);

		    var OutputText = new StringBuilder();
		    
		    if (Results.Errors.Count > 0) {
			    // Errors Happened
			    OutputText.Append($@"!: {Results.Errors.Count} error{(Results.Errors.Count == 1 ? "" : "s")} occurred: ");
			    foreach (CompilerError CompErr in Results.Errors) {
				    OutputText.Append("(" + CompErr.Line + ", " + CompErr.Column + ") " +
				                      ", Error Number: " + CompErr.ErrorNumber +
				                      ", '" + CompErr.ErrorText + ";" + 
				                      Environment.NewLine + Environment.NewLine);
			    }
		    } else {
			    //Successful Compile
			    OutputText.Append($"Compilation was successful. EXE path is '{Results.PathToAssembly}'");
		    }

		    return OutputText.ToString();
		    
	    }

    }

}