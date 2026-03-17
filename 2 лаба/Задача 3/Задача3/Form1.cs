using System;
using System.Windows.Forms;

namespace TemperatureConverterApp
{
    public partial class Form1 : Form
    {
        private TextBox temperatureTextBox;
        private ComboBox conversionTypeComboBox;
        private Button convertButton;
        private Label resultLabel;
        private Label inputLabel;
        private Label outputLabel;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Label titleLabel = new Label();
            titleLabel.Text = "Конвертер температуры";
            titleLabel.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(100, 20);
            titleLabel.Size = new System.Drawing.Size(220, 30);

            inputLabel = new Label();
            inputLabel.Text = "Введите температуру:";
            inputLabel.Location = new System.Drawing.Point(50, 70);
            inputLabel.Size = new System.Drawing.Size(120, 20);

            temperatureTextBox = new TextBox();
            temperatureTextBox.Location = new System.Drawing.Point(180, 70);
            temperatureTextBox.Size = new System.Drawing.Size(100, 20);

            Label conversionLabel = new Label();
            conversionLabel.Text = "Выберите конверсию:";
            conversionLabel.Location = new System.Drawing.Point(50, 110);
            conversionLabel.Size = new System.Drawing.Size(120, 20);

            conversionTypeComboBox = new ComboBox();
            conversionTypeComboBox.Location = new System.Drawing.Point(180, 110);
            conversionTypeComboBox.Size = new System.Drawing.Size(150, 20);
            conversionTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            conversionTypeComboBox.Items.Add("Цельсий -> Фаренгейт");
            conversionTypeComboBox.Items.Add("Фаренгейт -> Цельсий");
            conversionTypeComboBox.SelectedIndex = 0;

            convertButton = new Button();
            convertButton.Text = "Конвертировать";
            convertButton.Location = new System.Drawing.Point(120, 160);
            convertButton.Size = new System.Drawing.Size(150, 40);
            convertButton.Click += ConvertTemperature;

            outputLabel = new Label();
            outputLabel.Text = "Результат:";
            outputLabel.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            outputLabel.Location = new System.Drawing.Point(50, 220);
            outputLabel.Size = new System.Drawing.Size(80, 20);

            resultLabel = new Label();
            resultLabel.Text = "";
            resultLabel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            resultLabel.Location = new System.Drawing.Point(130, 220);
            resultLabel.Size = new System.Drawing.Size(200, 30);
            resultLabel.ForeColor = System.Drawing.Color.Blue;

            this.Controls.Add(titleLabel);
            this.Controls.Add(inputLabel);
            this.Controls.Add(temperatureTextBox);
            this.Controls.Add(conversionLabel);
            this.Controls.Add(conversionTypeComboBox);
            this.Controls.Add(convertButton);
            this.Controls.Add(outputLabel);
            this.Controls.Add(resultLabel);
        }

        private void ConvertTemperature(object sender, EventArgs e)
        {
            if (double.TryParse(temperatureTextBox.Text, out double temperature))
            {
                double result = 0;
                string fromUnit = "";
                string toUnit = "";

                if (conversionTypeComboBox.SelectedIndex == 0)
                {
                    result = CelsiusToFahrenheit(temperature);
                    fromUnit = "°C";
                    toUnit = "°F";
                }
                else
                {
                    result = FahrenheitToCelsius(temperature);
                    fromUnit = "°F";
                    toUnit = "°C";
                }

                resultLabel.Text = temperature.ToString("F1") + fromUnit + " = " + result.ToString("F1") + toUnit;
            }
            else
            {
                MessageBox.Show("Введите корректное число");
            }
        }

        private double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        private double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}