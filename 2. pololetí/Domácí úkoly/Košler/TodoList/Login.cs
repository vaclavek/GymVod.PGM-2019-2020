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
            if (IsLoginValid())
            {
                this.Hide();
                MainForm form = new MainForm();
                form.ShowDialog();
                this.Close();
            }
            MessageBox.Show("Přihlášení není správné", "Přihlášení", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private bool IsLoginValid()
        {
            string defaultUsername = ConfigurationManager.AppSettings["username"];
            string defaultPassword = ConfigurationManager.AppSettings["password"];

            return UsernameTB.Text == defaultUsername && PasswordTB.Text == defaultPassword;
        }
    }
}
