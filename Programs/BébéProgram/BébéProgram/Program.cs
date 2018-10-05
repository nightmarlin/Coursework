using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram {
	class Program {
		static void Main(string[] Args) {
			int Count = 1;
			while (true) {
				Console.WriteLine("Outputting to console - " + Count);
				var Reading = Console.ReadLine();
				Count += 1;
			}
		}
	}
}
