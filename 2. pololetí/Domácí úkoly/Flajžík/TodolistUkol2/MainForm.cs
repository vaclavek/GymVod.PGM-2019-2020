using System;
using System.ComponentModel;
using System.Windows.Forms;
using TodoList.Data;
using System.Collections.Generic;

namespace TodoList
{
    public partial class MainForm : Form
    {
        private BindingList<TodoItem> _data = new BindingList<TodoItem>();

        // List<TodoItem> _data = new List<TodoItem>() => nezobrazuje eventy v listboxu
        public MainForm()
        {
            InitializeComponent();
            //zobrazí události z listu v listboxu
           
            ListLB.ValueMember = nameof(TodoItem.DisplayName);
            
            ListLB.DataSource = _data;

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var happen = new TodoItem();
            happen.Name = TextTB.Text;
            happen.Date = DateDTP.Value;

            _data.Add(happen);

            MessageBox.Show("Přidal jste novou událost: " + happen.Name + "\n číslo:  " + happen.Id.ToString());


        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var item = ListLB.SelectedItem as TodoItem;
            if(item != null)
            {
                if (MessageBox.Show
            ("Opravdu chcete smazat událost?", "Odstranění",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
            == DialogResult.Yes)
                {
                    _data.Remove(item);
                }



            }


        }
    }
}
