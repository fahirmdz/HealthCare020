using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare020.WinUI.KorisnickiNalog;

namespace Healthcare020.WinUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            frmLogin child = new frmLogin();
            child.MdiParent = this;
            child.Show();
        }
    }
}
