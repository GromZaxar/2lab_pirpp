using System;
using System.Windows.Forms;

namespace PasswordCheckerApp
{
    public partial class Form1 : Form
    {
        private TextBox passwordTextBox;
        private Button checkButton;
        private Label lengthCheckLabel;
        private Label digitCheckLabel;
        private Label strengthLabel;
        private Label passwordLabel;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Label titleLabel = new Label();
            titleLabel.Text = "Проверка надежности пароля";
            titleLabel.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(100, 20);
            titleLabel.Size = new System.Drawing.Size(250, 30);

            passwordLabel = new Label();
            passwordLabel.Text = "Введите пароль:";
            passwordLabel.Location = new System.Drawing.Point(50, 70);
            passwordLabel.Size = new System.Drawing.Size(100, 20);

            passwordTextBox = new TextBox();
            passwordTextBox.Location = new System.Drawing.Point(160, 70);
            passwordTextBox.Size = new System.Drawing.Size(200, 20);
            passwordTextBox.UseSystemPasswordChar = false;

            checkButton = new Button();
            checkButton.Text = "Проверить пароль";
            checkButton.Location = new System.Drawing.Point(150, 110);
            checkButton.Size = new System.Drawing.Size(150, 40);
            checkButton.Click += CheckPassword;

            lengthCheckLabel = new Label();
            lengthCheckLabel.Text = "Длина пароля: ";
            lengthCheckLabel.Location = new System.Drawing.Point(50, 170);
            lengthCheckLabel.Size = new System.Drawing.Size(350, 20);

            digitCheckLabel = new Label();
            digitCheckLabel.Text = "Наличие цифр: ";
            digitCheckLabel.Location = new System.Drawing.Point(50, 200);
            digitCheckLabel.Size = new System.Drawing.Size(350, 20);

            strengthLabel = new Label();
            strengthLabel.Text = "Надежность: ";
            strengthLabel.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            strengthLabel.Location = new System.Drawing.Point(50, 240);
            strengthLabel.Size = new System.Drawing.Size(350, 30);

            this.Controls.Add(titleLabel);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(passwordTextBox);
            this.Controls.Add(checkButton);
            this.Controls.Add(lengthCheckLabel);
            this.Controls.Add(digitCheckLabel);
            this.Controls.Add(strengthLabel);
        }

        private void CheckPassword(object sender, EventArgs e)
        {
            string password = passwordTextBox.Text;

            bool lengthOk = CheckPasswordLength(password);
            bool digitsOk = CheckPasswordDigits(password);

            UpdateCheckLabels(lengthOk, digitsOk);
            ShowPasswordStrength(lengthOk, digitsOk);
        }

        private bool CheckPasswordLength(string password)
        {
            return password.Length >= 8;
        }

        private bool CheckPasswordDigits(string password)
        {
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateCheckLabels(bool lengthOk, bool digitsOk)
        {
            if (lengthOk)
            {
                lengthCheckLabel.Text = "Длина пароля: (8+ символов)";
                lengthCheckLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lengthCheckLabel.Text = "Длина пароля: (минимум 8 символов)";
                lengthCheckLabel.ForeColor = System.Drawing.Color.Red;
            }

            if (digitsOk)
            {
                digitCheckLabel.Text = "Наличие цифр: (есть цифры)";
                digitCheckLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                digitCheckLabel.Text = "Наличие цифр: (нужна хотя бы одна цифра)";
                digitCheckLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowPasswordStrength(bool lengthOk, bool digitsOk)
        {
            if (lengthOk && digitsOk)
            {
                strengthLabel.Text = "Надежность: НАДЕЖНЫЙ";
                strengthLabel.ForeColor = System.Drawing.Color.Green;
            }
            else if (lengthOk || digitsOk)
            {
                strengthLabel.Text = "Надежность: СРЕДНИЙ";
                strengthLabel.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                strengthLabel.Text = "Надежность: СЛАБЫЙ";
                strengthLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}