using Healthcare020.WinUI.Services;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Dialogs
{
    public partial class dlgAccountLock : Form
    {
        private readonly APIService _apiServiceKorisnici;
        private readonly KorisnickiNalogDtoLL _korisnik;
        public int NumberOfHours = 2;

        public dlgAccountLock(KorisnickiNalogDtoLL korisnik)
        {
            if (korisnik == null)
                return;

            _korisnik = korisnik;
            _apiServiceKorisnici = new APIService("korisnici");
            InitializeComponent();
            this.Opacity = 50;
            this.FormBorderStyle = FormBorderStyle.None;
            var size = MainForm.Instance.Size;
            cmbBrojSati.Items.Add("2");
            cmbBrojSati.Items.Add("6");
            cmbBrojSati.Items.Add("18");
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }

        private void dlgAccountLock_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.CenterToParent();
            this.BringToFront();
        }

        private void dlgAccountLock_Shown(object sender, EventArgs e)
        {
            dlgPrompt.PointToScreen(new Point(Width / 2, Height / 2));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private async void btnLockOk_Click(object sender, EventArgs e)
        {
            if (cmbBrojSati.SelectedIndex == -1)
            {
                this.DialogResult = DialogResult.No;
                return;
            }

            this.DialogResult = DialogResult.OK;
            NumberOfHours = int.Parse(cmbBrojSati.SelectedItem.ToString());
        }
    }
}