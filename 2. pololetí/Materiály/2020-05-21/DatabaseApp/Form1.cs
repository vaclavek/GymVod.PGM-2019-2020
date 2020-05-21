using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DatabaseApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

            // ADO.NET
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // SELECT * FROM Login WHERE Username = 'admin' AND Password = 'admin'";

            // útočník
            // SELECT * FROM Login WHERE Username = 'admin' OR 1 = 1 -- AND Password = 'admin'";

            string query = "SELECT * FROM Login WHERE Username = '" + txtUsername.Text + "' AND Password = '" + txtPasswrod.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                MessageBox.Show("Přihlašovací údaje nejsou správné.", "Přihlášení", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = reader["name"].ToString();
            connection.Close();

            Hide();
            MessageBox.Show("Vítejte " + name);

            TableForm tableForm = new TableForm();
            tableForm.ShowDialog();

            Close();
        }


    }
}
