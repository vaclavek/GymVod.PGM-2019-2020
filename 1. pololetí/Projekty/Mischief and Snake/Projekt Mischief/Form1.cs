using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Projekt
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            
        }

        private void buttonLevel1_Click(object sender, EventArgs e)
        {
            Hide();
            Level_1 Level1Instance = new Level_1();
            Level1Instance.ShowDialog();
            Level1Instance = null;
            Show();
        }


        private void ButtonLevel2_Click(object sender, EventArgs e)
        {
            Hide();
            Level_2 Level2Instance = new Level_2();
            Level2Instance.ShowDialog();
            Level2Instance = null;
            Show();
        }

        private void ButtonLevel3_Click(object sender, EventArgs e)
        {
            Hide();
            Level_3 Level3Instance = new Level_3();
            Level3Instance.ShowDialog();
            Level3Instance = null;
            Show();
        }
    }
}
