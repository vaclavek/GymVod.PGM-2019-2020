using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoListReichl1903
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            logins.Add("jmeno", new byte[] { 0x56, 0xB1, 0xDB, 0x81, 0x33, 0xD9, 0xEB, 0x39, 0x8A, 0xAB, 0xD3, 0x76, 0xF0, 0x7B, 0xF8, 0xAB, 0x5F, 0xC5, 0x84, 0xEA, 0x0B, 0x8B, 0xD6, 0xA1, 0x77, 0x02, 0x00, 0xCB, 0x61, 0x3C, 0xA0, 0x05 });
        }

        /* přihlašovací údaje:
         * "jmeno"
         * "heslo"
         * heslo ve formě SHA256 hashe (aby to bylo trochu realističtější)
         */
        private Dictionary<string, byte[]> logins = new Dictionary<string, byte[]>();

        private SHA256 sha = SHA256.Create();


        private void butSignin_Click(object sender, EventArgs e)
        {
            
            // debug kód
            Console.WriteLine(tbUsername.Text);
            Console.WriteLine(tbPassword.Text);
            Console.WriteLine("0x"+BitConverter.ToString(sha.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(tbPassword.Text)))).Replace("-", ",0x"));
            Console.WriteLine();

            if (logins.ContainsKey(tbUsername.Text))
            {
                if (logins[tbUsername.Text].SequenceEqual(sha.ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(tbPassword.Text)))))
                {
                    this.Hide();
                    new MainForm().ShowDialog();
                    this.Close();
                }
                else
                    tsslSigninError.Text = "Špatné heslo";
            }
            else
                tsslSigninError.Text = "Zadané uživatelské jméno neexistuje";
        }
    }
}
