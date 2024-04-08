using System.Windows.Forms;

namespace Laboratory_5
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonMatrixA_Click(object sender, System.EventArgs e)
        {
            if (!int.TryParse(textBoxXA.Text, out int rows) || rows <= 0)
            {
                MessageBox.Show("Введите корректное количество строк");
                return;
            }

            if (!int.TryParse(textBoxYA.Text, out int cols) || cols <= 0)
            {
                MessageBox.Show("Введите корректное количество столбцов");
                return;
            }

            dataGridViewA.Rows.Clear();
            dataGridViewA.Columns.Clear();

            dataGridViewA.ColumnCount = cols;
            dataGridViewA.RowCount = rows;
        }

        private void ButtonMatrixB_Click(object sender, System.EventArgs e)
        {
            if (!int.TryParse(textBoxXB.Text, out int rows) || rows <= 0)
            {
                MessageBox.Show("Введите корректное количество строк");
                return;
            }

            if (!int.TryParse(textBoxYB.Text, out int cols) || cols <= 0)
            {
                MessageBox.Show("Введите корректное количество столбцов");
                return;
            }

            dataGridViewB.Rows.Clear();
            dataGridViewB.Columns.Clear();

            dataGridViewB.ColumnCount = cols;
            dataGridViewB.RowCount = rows;
        }

        private void ButtonMultiMatrix_Click(object sender, System.EventArgs e)
        {
            double[,] matrixA = MatrixOperations.DataGridViewToMatrix(dataGridViewA);
            double[,] matrixB = MatrixOperations.DataGridViewToMatrix(dataGridViewB);

            if (matrixA is null || matrixB is null) return;

            double[,] result = MatrixOperations.MultiplyMatrices(matrixA, matrixB);

            if (result is null) return;

            var formResult = new FormResult(result);
            formResult.ShowDialog();
        }
    }
}
