using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TodoList
{
    public partial class MainForm : Form
    {
        private BindingList<TodoItem> listData = new BindingList<TodoItem>();
        public MainForm()
        {
            InitializeComponent();
            ListLB.ValueMember = nameof(TodoItem.Id);
            ListLB.DisplayMember = nameof(TodoItem.DisplayName);
            ListLB.DataSource = listData;
        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            listData.Add(
                new TodoItem { 
                    Name = TextTB.Text, 
                    Date = DateDTP.Value 
            });
            TextTB.Text = "";
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            listData.Remove((TodoItem)ListLB.SelectedItem);
        }
    }

    public class TodoItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string DisplayName => $"{Date.ToShortDateString()} - {Name}";
    }
}
