using System;
using System.Linq;
using System.Windows;

namespace WpfVariantApp
{
    public partial class TaskTwoWindow : Window
    {
        public TaskTwoWindow()
        {
            InitializeComponent();
        }

        private void BtnFindLongestWord_Click(object sender, RoutedEventArgs e)
        {
            string inputSentence = txtInputSentence.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputSentence))
            {
                MessageBox.Show(
                    "Введите строку со словами.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtInputSentence.Focus();
                return;
            }

            string[] words = inputSentence.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            int longestWordLength = words.Max(word => word.Length);

            txtLongestWordLength.Text =
                $"Длина самого длинного слова: {longestWordLength}";
        }

        private void BtnClosePage_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}