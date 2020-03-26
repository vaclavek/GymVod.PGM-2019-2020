using System;
using System.Configuration;
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
            if (!IsLoginValid())
            {
                MessageBox.Show("Neplatné přihlášení.", "Přihlášení", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Hide();

            var mainForm = new MainForm();
            mainForm.ShowDialog();

            Close();
        }

        private bool IsLoginValid()
        {
            string usernameSettings = ConfigurationManager.AppSettings["username"];
            string passwordSettings = ConfigurationManager.AppSettings["password"];

            string username = UsernameTB.Text;
            string password = PasswordTB.Text;

            if (username == usernameSettings && password == passwordSettings)
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
