using System;
using System.Windows.Forms;

namespace TodoList
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (LoginValidity()== false)
            {
                MessageBox.Show("Either the username, or the password is wrong", caption:"Invalid Login");
                return;
            }
            else
            {
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.ShowDialog();
                this.Close();
            }

        }
        private bool LoginValidity()
        {
            string correctUsername = "GymVod";
            string correctPassword = "666.666";

            if(correctUsername==UsernameTB.Text && correctPassword==PasswordTB.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
