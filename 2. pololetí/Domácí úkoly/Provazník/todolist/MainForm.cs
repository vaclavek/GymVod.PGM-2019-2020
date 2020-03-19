using System;
using System.ComponentModel;
using System.Windows.Forms;
using TodoList.Data;

namespace TodoList
{
    public partial class MainForm : Form
    {
        private BindingList<TodoItem> _data = new BindingList<TodoItem>();
        public MainForm()
        {
            InitializeComponent();
            ListLB.ValueMember = nameof(TodoItem.Id);
            ListLB.DisplayMember = nameof(TodoItem.DisplayName);
            ListLB.DataSource = _data;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var item = new TodoItem
            {
                Name = TextTB.Text,
                Date = DateDTP.Value,
            };
            _data.Add(item);
            TextTB.Text = "";
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var item = ListLB.SelectedItem as TodoItem;
            _data.Remove(item);
        }
    }
}
