using System.Windows.Forms;

namespace Laboratory_5
{
    public partial class FormResult : Form
    {
        public FormResult()
        {
            InitializeComponent();
        }

        public FormResult(double[,] matrix)
        {
            InitializeComponent();

            MatrixOperations.DataGridViewFromMatrix(dataGridViewResult, matrix);
        }
    }
}
