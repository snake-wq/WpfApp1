using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfVariantApp
{
    public partial class TaskFiveWindow : Window
    {
        private readonly Random _randomGenerator = new Random();

        public TaskFiveWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            bool isCorrectRowsCount = int.TryParse(
                txtRowsCount.Text,
                out int rowsCount);

            bool isCorrectColumnsCount = int.TryParse(
                txtColumnsCount.Text,
                out int columnsCount);

            if (!isCorrectRowsCount || !isCorrectColumnsCount)
            {
                MessageBox.Show(
                    "Введите целое количество строк и столбцов.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            if (rowsCount < 1 || rowsCount > 20 ||
                columnsCount < 1 || columnsCount > 20)
            {
                MessageBox.Show(
                    "Количество строк и столбцов должно быть в диапазоне от 1 до 20.",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            int[,] originalMatrix = new int[rowsCount, columnsCount];
            List<int> matrixValues = new List<int>();

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                for (int columnIndex = 0;
                     columnIndex < columnsCount;
                     columnIndex++)
                {
                    int randomValue = _randomGenerator.Next(-10, 11);

                    originalMatrix[rowIndex, columnIndex] = randomValue;
                    matrixValues.Add(randomValue);
                }
            }

            int[] ascendingValues = matrixValues.ToArray();
            Array.Sort(ascendingValues);

            int[] descendingValues = ascendingValues
                .Reverse()
                .ToArray();

            int[,] ascendingMatrix = CreateMatrixFromValues(
                ascendingValues,
                rowsCount,
                columnsCount);

            int[,] descendingMatrix = CreateMatrixFromValues(
                descendingValues,
                rowsCount,
                columnsCount);

            dgOriginalMatrix.ItemsSource = CreateDataTable(
                originalMatrix,
                rowsCount,
                columnsCount).DefaultView;

            dgAscendingMatrix.ItemsSource = CreateDataTable(
                ascendingMatrix,
                rowsCount,
                columnsCount).DefaultView;

            dgDescendingMatrix.ItemsSource = CreateDataTable(
                descendingMatrix,
                rowsCount,
                columnsCount).DefaultView;

            int minimumValue = matrixValues.Min();
            int maximumValue = matrixValues.Max();

            txtMinimumMaximum.Text =
                $"Минимальный элемент: {minimumValue}. " +
                $"Максимальный элемент: {maximumValue}.";
        }

        private int[,] CreateMatrixFromValues(
            int[] sortedValues,
            int rowsCount,
            int columnsCount)
        {
            int[,] resultMatrix = new int[rowsCount, columnsCount];
            int currentValueIndex = 0;

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                for (int columnIndex = 0;
                     columnIndex < columnsCount;
                     columnIndex++)
                {
                    resultMatrix[rowIndex, columnIndex] =
                        sortedValues[currentValueIndex];

                    currentValueIndex++;
                }
            }

            return resultMatrix;
        }

        private DataTable CreateDataTable(
            int[,] matrix,
            int rowsCount,
            int columnsCount)
        {
            DataTable matrixDataTable = new DataTable();

            for (int columnIndex = 0;
                 columnIndex < columnsCount;
                 columnIndex++)
            {
                matrixDataTable.Columns.Add(
                    $"Столбец {columnIndex + 1}");
            }

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                DataRow matrixDataRow = matrixDataTable.NewRow();

                for (int columnIndex = 0;
                     columnIndex < columnsCount;
                     columnIndex++)
                {
                    matrixDataRow[columnIndex] =
                        matrix[rowIndex, columnIndex];
                }

                matrixDataTable.Rows.Add(matrixDataRow);
            }

            return matrixDataTable;
        }

        private void BtnClosePage_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}