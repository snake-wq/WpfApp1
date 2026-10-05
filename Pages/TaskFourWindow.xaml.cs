using System;
using System.Windows;

namespace WpfVariantApp
{
    public partial class TaskFourWindow : Window
    {
        public TaskFourWindow()
        {
            InitializeComponent();
        }

        private void BtnSwapArrayElements_Click(object sender, RoutedEventArgs e)
        {
            string inputArrayElements = txtArrayElements.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputArrayElements))
            {
                MessageBox.Show(
                    "Введите элементы массива.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtArrayElements.Focus();
                return;
            }

            string[] arrayElementParts = inputArrayElements.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            int[] arrayElements = new int[arrayElementParts.Length];

            for (int elementIndex = 0;
                 elementIndex < arrayElementParts.Length;
                 elementIndex++)
            {
                bool isCorrectElement = int.TryParse(
                    arrayElementParts[elementIndex],
                    out int arrayElement);

                if (!isCorrectElement)
                {
                    MessageBox.Show(
                        $"Значение «{arrayElementParts[elementIndex]}» не является целым числом.",
                        "Ошибка ввода",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    txtArrayElements.Focus();
                    return;
                }

                arrayElements[elementIndex] = arrayElement;
            }

            int firstEvenElementIndex = -1;
            int lastNegativeElementIndex = -1;

            for (int elementIndex = 0;
                 elementIndex < arrayElements.Length;
                 elementIndex++)
            {
                if (arrayElements[elementIndex] % 2 == 0 &&
                    firstEvenElementIndex == -1)
                {
                    firstEvenElementIndex = elementIndex;
                }

                if (arrayElements[elementIndex] < 0)
                {
                    lastNegativeElementIndex = elementIndex;
                }
            }

            if (firstEvenElementIndex == -1)
            {
                MessageBox.Show(
                    "В массиве отсутствуют чётные элементы.",
                    "Результат",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            if (lastNegativeElementIndex == -1)
            {
                MessageBox.Show(
                    "В массиве отсутствуют отрицательные элементы.",
                    "Результат",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            int firstEvenElement = arrayElements[firstEvenElementIndex];
            int lastNegativeElement = arrayElements[lastNegativeElementIndex];

            arrayElements[firstEvenElementIndex] = lastNegativeElement;
            arrayElements[lastNegativeElementIndex] = firstEvenElement;

            txtChangedArray.Text =
                $"Первый чётный элемент: {firstEvenElement}\n" +
                $"Последний отрицательный элемент: {lastNegativeElement}\n" +
                $"Массив после обмена: {string.Join(" ", arrayElements)}";
        }

        private void BtnClosePage_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}