using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace MSBuildTesting {

	internal static class Program {

		#region TestProgram

		public static string TestProgram = @"
using System;
using System.Threading;
namespace Template {
	public static class Program {

		public static string TestVariable = ""The test is working"";

		public static void Main(string[] Args) {
			Console.WriteLine(""Test Program Functional"");
			System.Threading.Thread.Sleep(1500);
			Console.WriteLine(""Thread Sleep Complete"");
			Console.ReadKey();
		}
	}
}";
		#endregion
		
		static Program() {
			CurDir = Environment.CurrentDirectory;
			using (var WrapperReader =
				new
					StreamReader(@"D:\HDD Documents\Computing\Coursework\Programs\FinalSolution\FinalSolution\Build\Template\Wrapper.cs")
			) {
				Wrapper = WrapperReader.ReadToEnd();
				WrapperReader.Close();
			}
		}

		public static string Wrapper;
		public static string CurDir;

		public static void Main(string[] Args) {
			Console.WriteLine("Saving Files");
			
			var Name = "Test";
			
			SaveTextFile(Name);
			
			Console.WriteLine("Running builder");
			
			CompileFromStrings(Name);
			
		}

		private static void SaveTextFile(string Name) {
			
			if (!Directory.Exists($".\\{Name}")) {
				Directory.CreateDirectory($".\\{Name}");
			}
			

			if (!File.Exists($".\\{Name}\\Wrapper.cs")) {
				File.Create($".\\{Name}\\Wrapper.cs").Close();
				using (var SW = new StreamWriter($".\\{Name}\\Wrapper.cs")) {
					SW.Write(Wrapper);
				}
			}

			if (!File.Exists($".\\{Name}\\{Name}.cs")) {
				File.Create($".\\{Name}\\{Name}.cs").Close();
			}

			using (var SW = new StreamWriter($".\\{Name}\\{Name}.cs")) {
				SW.Write(TestProgram);
			}
		}

		private static void CompileFromStrings(string Name) {
			CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
			var OutputLocation = $".\\{Name}\\{Name}.exe";

			CompilerParameters parameters = new CompilerParameters {
				GenerateExecutable = true,
				OutputAssembly = OutputLocation,
				CompilerOptions = "/main:Template.Main_Program"
			};
			parameters.ReferencedAssemblies.Add("Newtonsoft.Json.dll");
			
			//Make sure we generate an EXE, not a DLL
			CompilerResults Results = codeProvider.CompileAssemblyFromSource(parameters, Wrapper, TestProgram);

			if (Results.Errors.Count > 0) {
				Console.WriteLine($"{Results.Errors.Count} error{(Results.Errors.Count == 1 ? "" : "s")} occurred: ");
				foreach (CompilerError CompErr in Results.Errors) {
					Console.WriteLine("(" + CompErr.Line + ", " + CompErr.Column + ") " +
					                  ", Error Number: " + CompErr.ErrorNumber +
					                  ", '" + CompErr.ErrorText + ";" + 
					                  ", Is Warning: " + CompErr.IsWarning +
					                  Environment.NewLine + Environment.NewLine);
				}
			} else {
				//Successful Compile
				Console.Write("Success!. Press '>' to run the program ");
				//If we clicked run then launch our EXE
				if (Console.ReadKey().KeyChar.ToString() == ">") Process.Start(OutputLocation);
			}
		}

	}

}