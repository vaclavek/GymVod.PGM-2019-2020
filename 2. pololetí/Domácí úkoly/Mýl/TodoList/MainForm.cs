using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList_muj_
{
    public partial class MainForm : Form
    {
        BindingList<Polozka> Data = new BindingList<Polozka>();

        public MainForm()
        {
            InitializeComponent();
            LBList.ValueMember = nameof(Polozka.ID);
            LBList.DisplayMember = nameof(Polozka.DisplayName);
            LBList.DataSource = Data;
        }

        private void BPridat_Click(object sender, EventArgs e)
        {
            var polozka = new Polozka();
            polozka.Name = TBPolozka.Text;
            polozka.Datum = DTPPolozka.Value; 
            Data.Add(polozka);
        }

        private void BOdebrat_Click(object sender, EventArgs e)
        {
            var odstranit = LBList.SelectedItem as Polozka;

            if (odstranit!= null)
            {
                Data.Remove(odstranit);
            }

           
        }
    }
}
