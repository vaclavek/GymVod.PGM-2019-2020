using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TodoList
{
    public partial class MainForm : Form
    {
        private BindingList<ListItem> Data = new System.ComponentModel.BindingList<ListItem>();
        public MainForm()
        {
            InitializeComponent();
            ListLB.ValueMember = "Id";
            ListLB.DisplayMember = "DisplayName";
            ListLB.DataSource = Data;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var item = new ListItem();
            item.TodoText = TextTB.Text;
            item.Date = DateDTP.Value;

            Data.Add(item);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var item = ListLB.SelectedItem as ListItem;
            if (item != null)
            {
                Data.Remove(item);
            }
        }
    }
}
