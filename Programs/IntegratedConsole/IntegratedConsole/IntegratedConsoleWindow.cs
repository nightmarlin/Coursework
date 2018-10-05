using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;	

namespace IntegratedConsole {
	class IntegratedConsoleWindow : Panel {
	
		public IntegratedConsoleWindow() : base() {
			
		}

		public bool Init() {
			try {
				
				
				
				return true;
			} catch (Exception ex) {
				MessageBox.Show($"Failed to Init because of the following error: {Environment.NewLine} {ex.ToString()}");
				return false;
			}
		}
	}
}
