using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TodoList
{
    public partial class MainForm : Form
    {
        public class TodoItem
        {
            public Guid Id { get; } = Guid.NewGuid();
            public string Name { get; set; }
            public DateTime Date { get; set; }

            public string DisplayName => $"{Date.ToShortDateString()} - {Name}";
        }
        private BindingList<TodoItem> Data = new BindingList<TodoItem>();
        public MainForm()
        {
            InitializeComponent();
            ListLB.ValueMember = nameof(TodoItem.Id);
            ListLB.DisplayMember = nameof(TodoItem.DisplayName);
            ListLB.DataSource = Data;
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            var item = new TodoItem();
            item.Name = TextTB.Text;
            item.Date = DateDTP.Value;

            Data.Add(item);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var item = ListLB.SelectedItem as TodoItem;
            if (item != null)
            {
                Data.Remove(item);
            }
        }
    }
}
