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
            if (IsLoginValid())
            {
                OpenMainForm();
            }
            else
            {
                ShowAlert();
            }
        }

        private bool IsLoginValid()
        {
            var username = System.Configuration.ConfigurationManager.AppSettings["username"].ToLower();
            var password = System.Configuration.ConfigurationManager.AppSettings["password"];
            return UsernameTB.Text.ToLower() == username && PasswordTB.Text == password;
        }

        private void OpenMainForm()
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void ShowAlert()
        {
            MessageBox.Show("Jsi blbej", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
