using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private TextBox txtPassword;
        private Button btnCheck;
        private Label lblResult;

        public Form1()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Create and setup controls
            txtPassword = new TextBox();
            btnCheck = new Button();
            lblResult = new Label();

            // TextBox settings
            txtPassword.Location = new Point(12, 12);
            txtPassword.Size = new Size(200, 20);
            txtPassword.PasswordChar = '*';

            // Button settings
            btnCheck.Location = new Point(12, 38);
            btnCheck.Size = new Size(75, 23);
            btnCheck.Text = "Check";
            btnCheck.Click += BtnCheck_Click;

            // Label settings
            lblResult.Location = new Point(12, 64);
            lblResult.AutoSize = true;

            // Form settings
            this.Text = "Password Checker";
            this.Size = new Size(300, 150);

            // Add controls to form
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnCheck);
            this.Controls.Add(lblResult);
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            CheckPassword(password);
        }

        private void CheckPassword(string password)
        {
            lblResult.Text = "";
            int score = 0;

            // Check length
            if (password.Length >= 8)
            {
                AddColoredText("✓ Good length\n", Color.Green);
                score++;
            }
            else
            {
                AddColoredText("✗ Password should be at least 8 characters\n", Color.Red);
            }

            // Check for numbers
            if (password.Any(char.IsDigit))
            {
                AddColoredText("✓ Contains numbers\n", Color.Green);
                score++;
            }
            else
            {
                AddColoredText("✗ Should contain numbers\n", Color.Red);
            }

            // Check for uppercase
            if (password.Any(char.IsUpper))
            {
                AddColoredText("✓ Contains uppercase\n", Color.Green);
                score++;
            }
            else
            {
                AddColoredText("✗ Should contain uppercase letters\n", Color.Red);
            }

            AddColoredText($"\nStrength Score: {score}/3", Color.Black);
        }

        private void AddColoredText(string text, Color color)
        {
            Label newLabel = new Label();
            newLabel.Text = text;
            newLabel.ForeColor = color;
            newLabel.AutoSize = true;
            newLabel.Location = new Point(lblResult.Location.X,
                lblResult.Location.Y + lblResult.Height);
            this.Controls.Add(newLabel);
            lblResult = newLabel;
        }
    }
}