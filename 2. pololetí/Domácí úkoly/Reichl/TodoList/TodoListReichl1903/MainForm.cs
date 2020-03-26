using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoListReichl1903
{
    public partial class MainForm : Form
    {
        private BindingList<TodoItem> todoItems = new BindingList<TodoItem>();

        public MainForm()
        {
            InitializeComponent();
            lbTodos.ValueMember = nameof(TodoItem.Id);
            lbTodos.DisplayMember = nameof(TodoItem.DisplayName);
            lbTodos.DataSource = todoItems;
        }

        private void butAdd_Click(object sender, EventArgs e) => todoItems.Add(new TodoItem { Date = dtpDate.Value, Name = tbNote.Text });
       

        private void butDel_Click(object sender, EventArgs e) => todoItems.Remove((TodoItem)lbTodos.SelectedItem);
        
    }
}
