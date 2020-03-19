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
            if (ValidateLogin())
            {
                Hide();
                var mainForm = new MainForm();
                mainForm.ShowDialog();
                Close();
            }
            MessageBox.Show("neplatné přihlášení", "Cože", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool ValidateLogin()
        {
            return ConfigurationManager.AppSettings["username"] == UsernameTB.Text && ConfigurationManager.AppSettings["password"] == PasswordTB.Text;
        }
    }
}
