using System;
using System.Windows.Forms;

namespace TodoList
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (TextTB.Equals(null))
            {
                ListLB.Items.Add(DateDTP.Value.Date.ToString().Remove(10, 9) + " : " + TextTB.Text);
                //Snaha se zbavit času v listu. Plánuji zaměnit za vlastní třídu s hodnotou DateTime pokud to půjde. ListBox se sám uspořádává
            }
            else
            {
                MessageBox.Show("No input in text box", "Invalid input");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            ListLB.Items.RemoveAt(ListLB.SelectedIndex);
        }

        private void ListLB_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if(sender.Equals(Keys.Delete))
            {
                DeleteBtn_Click(sender,e);
            }
            Snažil jsem se rychle vytvořit možnost použít tlačítko delete pro odstranění objektu
            */
        }
    }
}
