using System;
using System.Windows.Forms;

namespace DiscountCalculatorApp
{
    public partial class Form1 : Form
    {
        private TextBox purchaseAmountTextBox;
        private Button calculateButton;
        private Label originalAmountLabel;
        private Label discountLabel;
        private Label finalAmountLabel;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Label titleLabel = new Label();
            titleLabel.Text = "Калькулятор скидок";
            titleLabel.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(120, 20);
            titleLabel.Size = new System.Drawing.Size(180, 30);

            Label purchaseLabel = new Label();
            purchaseLabel.Text = "Введите сумму покупки:";
            purchaseLabel.Location = new System.Drawing.Point(50, 70);
            purchaseLabel.Size = new System.Drawing.Size(150, 20);

            purchaseAmountTextBox = new TextBox();
            purchaseAmountTextBox.Location = new System.Drawing.Point(210, 70);
            purchaseAmountTextBox.Size = new System.Drawing.Size(100, 20);

            calculateButton = new Button();
            calculateButton.Text = "Рассчитать скидку";
            calculateButton.Location = new System.Drawing.Point(120, 120);
            calculateButton.Size = new System.Drawing.Size(150, 40);
            calculateButton.Click += CalculateDiscount;

            originalAmountLabel = new Label();
            originalAmountLabel.Text = "Сумма покупки:";
            originalAmountLabel.Location = new System.Drawing.Point(50, 180);
            originalAmountLabel.Size = new System.Drawing.Size(300, 20);

            discountLabel = new Label();
            discountLabel.Text = "Скидка:";
            discountLabel.Location = new System.Drawing.Point(50, 210);
            discountLabel.Size = new System.Drawing.Size(300, 20);

            finalAmountLabel = new Label();
            finalAmountLabel.Text = "Итоговая сумма:";
            finalAmountLabel.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            finalAmountLabel.Location = new System.Drawing.Point(50, 240);
            finalAmountLabel.Size = new System.Drawing.Size(300, 30);

            this.Controls.Add(titleLabel);
            this.Controls.Add(purchaseLabel);
            this.Controls.Add(purchaseAmountTextBox);
            this.Controls.Add(calculateButton);
            this.Controls.Add(originalAmountLabel);
            this.Controls.Add(discountLabel);
            this.Controls.Add(finalAmountLabel);
        }

        private void CalculateDiscount(object sender, EventArgs e)
        {
            if (double.TryParse(purchaseAmountTextBox.Text, out double purchaseAmount) && purchaseAmount > 0)
            {
                double discount = CalculateDiscountRate(purchaseAmount);
                double discountAmount = purchaseAmount * discount / 100;
                double finalAmount = purchaseAmount - discountAmount;

                originalAmountLabel.Text = "Сумма покупки: " + purchaseAmount.ToString("F2") + " руб.";
                discountLabel.Text = "Скидка: " + discount.ToString("F0") + "% (" + discountAmount.ToString("F2") + " руб.)";
                finalAmountLabel.Text = "Итоговая сумма: " + finalAmount.ToString("F2") + " руб.";
            }
            else
            {
                MessageBox.Show("Введите корректную сумму покупки");
            }
        }

        private double CalculateDiscountRate(double amount)
        {
            if (amount < 1000)
            {
                return 0;
            }
            else if (amount >= 1000 && amount <= 5000)
            {
                return 5;
            }
            else
            {
                return 10;
            }
        }
    }
}