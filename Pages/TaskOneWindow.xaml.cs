using System;
using System.Windows;

namespace WpfVariantApp
{
    public partial class TaskOneWindow : Window
    {
        public TaskOneWindow()
        {
            InitializeComponent();
        }

        private void BtnDescribeNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtInputNumber.Text, out int inputNumber))
            {
                MessageBox.Show(
                    "Введите целое число.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtInputNumber.Focus();
                return;
            }

            if (inputNumber < -999 || inputNumber > 999)
            {
                MessageBox.Show(
                    "Число должно находиться в диапазоне от -999 до 999.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtInputNumber.Focus();
                return;
            }

            if (inputNumber == 0)
            {
                txtNumberDescription.Text = "нулевое число";
                return;
            }

            string numberSign = inputNumber > 0
                ? "положительное"
                : "отрицательное";

            int absoluteNumber = Math.Abs(inputNumber);

            string digitCountDescription;

            if (absoluteNumber < 10)
            {
                digitCountDescription = "однозначное";
            }
            else if (absoluteNumber < 100)
            {
                digitCountDescription = "двузначное";
            }
            else
            {
                digitCountDescription = "трехзначное";
            }

            txtNumberDescription.Text =
                $"{numberSign} {digitCountDescription} число";
        }

        private void BtnClosePage_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}