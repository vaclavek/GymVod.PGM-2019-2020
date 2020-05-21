using System;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.todoTableAdapter.Update(this.gymvodDataSet.Todo);
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.todoTableAdapter.Fill(this.gymvodDataSet.Todo);
        }
    }
}
