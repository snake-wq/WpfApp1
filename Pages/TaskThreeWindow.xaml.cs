using System;
using System.Globalization;
using System.Windows;

namespace WpfVariantApp
{
    public partial class TaskThreeWindow : Window
    {
        public TaskThreeWindow()
        {
            InitializeComponent();
        }

        private void BtnFindMinimumDistance_Click(object sender, RoutedEventArgs e)
        {
            string inputCoordinates = txtPointCoordinates.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputCoordinates))
            {
                MessageBox.Show(
                    "Введите координаты точек.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtPointCoordinates.Focus();
                return;
            }

            string[] coordinateParts = inputCoordinates.Split(
                new[] { ' ', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            if (coordinateParts.Length < 2)
            {
                MessageBox.Show(
                    "Введите не менее двух координат.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                txtPointCoordinates.Focus();
                return;
            }

            double[] pointCoordinates = new double[coordinateParts.Length];

            for (int coordinateIndex = 0;
                 coordinateIndex < coordinateParts.Length;
                 coordinateIndex++)
            {
                bool isCorrectCoordinate = double.TryParse(
                    coordinateParts[coordinateIndex],
                    NumberStyles.Float,
                    CultureInfo.CurrentCulture,
                    out double pointCoordinate);

                if (!isCorrectCoordinate)
                {
                    MessageBox.Show(
                        $"Значение «{coordinateParts[coordinateIndex]}» не является числом.",
                        "Ошибка ввода",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    txtPointCoordinates.Focus();
                    return;
                }

                pointCoordinates[coordinateIndex] = pointCoordinate;
            }

            double pointWithMinimumDistance = pointCoordinates[0];
            double minimumDistanceSum = double.MaxValue;

            foreach (double currentPoint in pointCoordinates)
            {
                double currentDistanceSum = 0;

                foreach (double otherPoint in pointCoordinates)
                {
                    currentDistanceSum += Math.Abs(currentPoint - otherPoint);
                }

                if (currentDistanceSum < minimumDistanceSum)
                {
                    minimumDistanceSum = currentDistanceSum;
                    pointWithMinimumDistance = currentPoint;
                }
            }

            txtMinimumDistanceResult.Text =
                $"Точка с минимальной суммой расстояний: {pointWithMinimumDistance}\n" +
                $"Минимальная сумма расстояний: {minimumDistanceSum}";
        }

        private void BtnClosePage_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}