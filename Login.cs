using System;
using System.Windows.Forms;
using System.Configuration;

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
            string usernameValue = ConfigurationManager.AppSettings["userInput"];
            string passwordValue = ConfigurationManager.AppSettings["passInput"];


            string username = UsernameTB.Text;
            string password = PasswordTB.Text;

            if(username != usernameValue || password != passwordValue)
            {
                MessageBox.Show("Uživatelské jméno nebo heslo jsou chybné","Reeeee", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                this.Hide();
                MainForm x = new MainForm();
                x.Show();
            }
            
           

        }
        





    }
}
