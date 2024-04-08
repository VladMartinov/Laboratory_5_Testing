using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Laboratory_5;

namespace UnitTestProjectMatrix
{
    [TestClass]
    public class UnitTest
    {
        // Удачный кейс. Возврат матрицы
        [TestMethod]
        public void TestDataGridViewToMatrixSuccess()
        {
            var dataGridView = new DataGridView()
                { 
                    RowCount = 2,
                    ColumnCount = 3,
                };

            dataGridView[0, 0].Value = 1;
            dataGridView[1, 0].Value = 2;
            dataGridView[2, 0].Value = 3;
            dataGridView[0, 1].Value = 4;
            dataGridView[1, 1].Value = 5;
            dataGridView[2, 1].Value = 6;

            double[,] expected = { { 1, 2, 3 }, { 4, 5, 6 } };

            double[,] result = MatrixOperations.DataGridViewToMatrix(dataGridView);

            CollectionAssert.AreEqual(expected, result);
        }

        // Не удачный кейс. Одно из значений оказалось пустым.
        [TestMethod]
        public void TestDataGridViewToMatrixEmptyCells()
        {
            DataGridView dataGridView = new DataGridView()
                {
                    RowCount = 2,
                    ColumnCount = 3,
                };

            dataGridView[0, 0].Value = 1;
            dataGridView[1, 0].Value = null;
            dataGridView[2, 0].Value = 3;
            dataGridView[0, 1].Value = 4;
            dataGridView[1, 1].Value = 5;
            dataGridView[2, 1].Value = 6;

            double[,] result = MatrixOperations.DataGridViewToMatrix(dataGridView);

            Assert.IsNull(result);
        }

        // Удачный кейс. Успешное перемножение обоих матриц.
        [TestMethod]
        public void TestMultiplyMatricesSuccess()
        {
            double[,] matrixA = { { 1, 2 }, { 3, 4 } };
            double[,] matrixB = { { 4, 3 }, { 2, 1 } };

            double[,] expected = { { 8, 5 }, { 20, 13 } };

            double[,] result = MatrixOperations.MultiplyMatrices(matrixA, matrixB);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
