using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PraceSTextem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileNameTB.Text = openFileDialog.FileName;
                contentTB.Text = ReadFile(openFileDialog.FileName);
            }
        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileNameTB.Text))
            {
                MessageBox.Show("Zadej název souboru!");
                return;
            }

            SaveFile(fileNameTB.Text, contentTB.Text);
        }

        private string ReadFile(string fileName)
        {
            // 1. způsob
            // return File.ReadAllText(fileName);

            // 2. způsob
            //using(StreamReader sr = new StreamReader(fileName))
            //{
            //return sr.ReadToEnd();
            //}

            // 3. způsob
            using (StreamReader sr = new StreamReader(fileName))
            {
                StringBuilder content = new StringBuilder();
                while (true)
                {
                    var line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    content.AppendLine(line);
                }

                return content.ToString();
            }
        }

        private void SaveFile(string fileName, string content)
        {
            try
            {
                File.WriteAllText(fileName, content);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Adresář neexistuje!");
            }

            // TODO: Domácí úkol - naimplementovat metodu se StreamWriter
        }
    }
}
