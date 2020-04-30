using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.Gradovi;

namespace Healthcare020.WinUI.StartMenu
{
    public partial class frmStartMenu : Form
    {
        public frmStartMenu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmGradoviPrikaz = new frmGradoviPrikaz{MdiParent = MdiParent};
            frmGradoviPrikaz.Show();
            Close();
        }
    }
}
