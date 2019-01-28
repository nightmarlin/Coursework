using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Windows.Forms;

namespace Solution.Designer.Blocks {

    /// <inheritdoc cref="BaseBlock"/>
    /// <summary>
    /// A block representing a variable declaration
    /// </summary>
    public abstract class VarCreateBlock : BaseBlock {

	    private Type Represents;

        protected TextBox ValueBox;
		/// <summary>
		/// stores the name of the box
		/// </summary>
        public TextBox NameBox;

		/// <summary>
		/// Validate the content of the name and value blocks on click
		/// </summary>
		public Button ValidateButton;

        /// <inheritdoc />
        public VarCreateBlock(Type Represents) {
	        this.Represents = Represents;
	        SizeChanged += Resized;
            Value = 0;
            SuspendLayout();
            
            IconSize = new Size(45, 45);
            IconLocation = new Point(0, Height / 2 - IconSize.Height);

            ValueBox = new TextBox {
                Name = "ValueBox",
                Text = "0",
                BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark),
				ForeColor = Color.White,
                Multiline = false,
				Width = 145
            };

			NameBox = new TextBox {
				Name = "NameBox",
				Text = "NameBox",
				BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark),
				ForeColor = Color.White,
				Multiline = false,
				Width = 145
			};
			
			ValidateButton = new Button {
				Name = "ValidateButton",
				FlatAppearance = {
					BorderColor = Color.FromKnownColor(KnownColor.ControlDarkDark),
					BorderSize = 1
				},
				FlatStyle = FlatStyle.Flat,
				Size = new Size(35, 30),
				Visible = false,
				Text = "OK"
			};
			
			ValidateButton.Location = new Point(5, (Height / 2) - (ValidateButton.Height / 2));

            ValueBox.Location = new Point((Width / 2) - (ValueBox.Width / 2) + 15,
                                     (Height / 2) - (ValueBox.Height / 2) + 10);
            NameBox.Location = new Point((Width / 2) - (ValueBox.Width / 2) + 15,
                                          (Height / 2) - (ValueBox.Height / 2) - 10);

            NameBox.TextChanged += (S, E) => { ValidateButton.Show(); };
            ValueBox.TextChanged += (S, E) => { ValidateButton.Show(); };

            ValidateButton.Click += (S, E) => {
	            ValidateName();
	            if (ValidateValue(out var Result)) {
		            Value = Result;
	            }
	            ValueBox.Text = $"{Value}";
	            ValidateButton.Hide();
            };
            
			Controls.Add(ValueBox);
			Controls.Add(NameBox);
			Controls.Add(ValidateButton);
			
            ResumeLayout();
            Resized(null, null);
        }

        /// <summary>
        /// Checks that the value set by the user is a valid value
        /// </summary>
        /// <param name="Result">The resulting valid value. Or null if the function returns false</param>
        /// <returns>If the value is valid</returns>
        protected abstract bool ValidateValue(out object Result);


		private void ValidateName() {
			using (var Prov = CodeDomProvider.CreateProvider("C#")) {
				if (!Prov.IsValidIdentifier(NameBox.Text)) {
					MessageBox.Show("Invalid Name", "B#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					NameBox.Text = VarName;
					return;
				}

				if (Parent is Panel P) {

					foreach (var C in P.Controls) {
						if (!(C is VarCreateBlock V)) continue;
						if (V.VarName != NameBox.Text) continue;
						MessageBox.Show("Name Must Be Unique", "B#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						NameBox.Text = VarName;
						return;
					}

					VarName = NameBox.Text;
				}
			}
		}

		private void Resized(object S, EventArgs E) {
			ValueBox.Location = new Point((Width / 2) - (ValueBox.Width / 2) + 15,
			                              (Height / 2) - (ValueBox.Height / 2) + 10);
			NameBox.Location = new Point((Width / 2) - (ValueBox.Width / 2) + 15,
			                             (Height / 2) - (ValueBox.Height / 2) - 10);
			
			ValidateButton.Location = new Point(5, (Height / 2) - (ValidateButton.Height / 2));
		}

        private object _value;
        /// <summary>
        /// The starting value of the variable
        /// </summary>
        public object Value {
            get => _value;
            set => _value = value;

        }

        private string _varname;
		/// <summary>
		/// The name of the variable
		/// </summary>
        public string VarName {
	        get => _varname;
	        set {
		        _varname = value;
		        Code = $"public static {Represents.FullName} {value} = {Value};";
		        
	        }
        }

        // /// <summary></summary>
        // public new void DrawMe(object Sender, PaintEventArgs E) { }
        

    }

}