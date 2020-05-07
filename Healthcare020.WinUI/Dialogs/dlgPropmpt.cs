using Healthcare020.WinUI.Services;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Dialogs
{
    public partial class dlgPropmpt : Form
    {
        private readonly APIService _apiServiceKorisnici;
        private readonly KorisnickiNalogDtoLL _korisnik;

        public dlgPropmpt(KorisnickiNalogDtoLL korisnik)
        {
            if (korisnik == null)
                return;

            _korisnik = korisnik;
            _apiServiceKorisnici = new APIService("korisnici");

            InitializeComponent();
            this.Opacity = 50;
            this.FormBorderStyle = FormBorderStyle.None;
            pnlBody.BackColor = Color.FromArgb(
                245, 245, 245
            );
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 0, 0, 0)))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }

        private void dlgPropmpt_Load(object sender, System.EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.CenterToParent();
            this.BringToFront();
        }

        private void dlgPropmpt_Shown(object sender, System.EventArgs e)
        {
            pnlBody.PointToScreen(new Point(Width / 2, Height / 2));
        }

        private async void btnYes_Click(object sender, System.EventArgs e)
        {
            _korisnik.LockedOut = false;
            _korisnik.LockedOutUntil = null;

            var upsertDto = new KorisnickiNalogUpsertDto
            {
                Username = _korisnik.Username,
                Password = "testtest",
                ConfirmPassword = "testtest",
                LokedOutUntil = null,
                LockedOut = false
            };

            var result = await _apiServiceKorisnici.Update<KorisnickiNalogDtoLL>(_korisnik.Id, upsertDto);

            if (result.Success)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.No;
        }
    }
}