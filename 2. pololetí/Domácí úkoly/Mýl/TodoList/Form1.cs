using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ToDoList_muj_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!PrihlaseniPlatne())
            {
                MessageBox.Show("Heslo nebo uživatelské jméno je neplatné");
            }
            else
            {
            Hide();
            var mainForm = new MainForm();
            mainForm.ShowDialog();
            Close();
            }
                
         
        }

        public bool PrihlaseniPlatne()
        {
            string heslo = ConfigurationManager.AppSettings["password"];
            string uzivatelskeJmeno = ConfigurationManager.AppSettings["username"];
            
            string zadaneHeslo = TBHeslo.Text;
            string zadaneJmeno = TBJmeno.Text;

            if (heslo == zadaneHeslo && uzivatelskeJmeno == zadaneJmeno)
            {
                return true;
            }
            else return false;
        }
    }
}
