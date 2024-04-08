using System;
using System.Windows.Forms;

namespace Laboratory_5
{
    public class MatrixOperations
    {
        public static double[,] DataGridViewToMatrix(DataGridView dataGridView)
        {
            int rows = dataGridView.RowCount;
            int columns = dataGridView.ColumnCount;

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    if (dataGridView[j, i].Value == null || !double.TryParse(dataGridView[j, i].Value.ToString(), out _))
                    {
                        MessageBox.Show("Пожалуйста, заполните все ячейки матрицы A числами.");
                        return null;
                    }
                }
            }

            double[,] matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = Convert.ToDouble(dataGridView[j, i].Value);
                }
            }

            return matrix;
        }

        public static void DataGridViewFromMatrix(DataGridView dataGridView, double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.ColumnCount = columns;
            dataGridView.RowCount = rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridView[j, i].Value = matrix[i, j];
                }
            }
        }

        public static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0),
                columnsA = matrixA.GetLength(1),
                rowsB = matrixB.GetLength(0),
                columnsB = matrixB.GetLength(1);

            if (columnsA != rowsB)
            {
                MessageBox.Show("Невозможно выполнить умножение матриц. Количество столбцов в матрице A должно быть равно количеству строк в матрице B.");
                return null;
            }

            if (columnsA <= 0 || rowsB <= 0 || columnsB <= 0)
            {
                MessageBox.Show("Невозможно выполнить умножение матриц с данными размерами.");
                return null;
            }

            double[,] result = new double[rowsA, columnsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsB; j++)
                {
                    for (int k = 0; k < columnsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }
    }
}
