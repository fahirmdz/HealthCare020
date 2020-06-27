using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ComboBoxItem = Healthcare020.WinUI.Models.ComboBoxItem;
using Image = System.Drawing.Image;
using Validation = Healthcare020.WinUI.Helpers.Validation;

namespace Healthcare020.WinUI.Forms.KorisnickiNalog
{
    public partial class frmUserProfile : Form
    {
        private static frmUserProfile _instance = null;

        private readonly APIService _apiService;
        private LicniPodaciDto LicniPodaci;

        public frmUserProfile()
        {
            InitializeComponent();
            tabSelector.BackColor = Color.Black;

            _apiService = new APIService(Routes.LicniPodaciRoute);
        }

        public static frmUserProfile Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new frmUserProfile();
                return _instance;
            }
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
                await UpdateLicniPodaci();
        }

        private async void frmUserProfile_Load(object sender, System.EventArgs e)
        {
            _apiService.ChangeRoute(Routes.DrzaveRoute);
            var drzaveResult = await _apiService.Get<DrzavaDto>(new DrzavaResourceParameters {PageSize = 100});
            if (drzaveResult.Succeeded)
            {
                var drzave = drzaveResult.Data;
                cmbDrzave.DataSource = drzave;
                cmbDrzave.DisplayMember = "Naziv";
                cmbDrzave.ValueMember = "Id";
            }


            cmbPolovi.DataSource = new List<ComboBoxItem>
            {
                new ComboBoxItem(Resources.GenderMale, 0),
                new ComboBoxItem(Resources.GenderFemale, 1)
            };

            cmbPolovi.ValueMember = nameof(ComboBoxItem.Value);
            cmbPolovi.DisplayMember = nameof(ComboBoxItem.Text);

            int licniPodaciId = 0;

            if (Auth.Role == RoleType.Doktor)
            {
                _apiService.ChangeRoute(Routes.DoktoriRoute);

                var result = await _apiService.Get<DoktorDtoEL>(new DoktorResourceParameters
                    {KorisnickiNalogId = Auth.KorisnickiNalog.Id, EagerLoaded = true});

                if (!result.Succeeded || result.Data == null)
                {
                    dlgError.ShowDialog("Unable to load profile data");
                    return;
                }

                var doktor = result.Data.First();
                licniPodaciId = doktor.Radnik?.LicniPodaciId ?? 0;
            }
            else if (Auth.Role == RoleType.MedicinskiTehnicar)
            {
                _apiService.ChangeRoute(Routes.MedicinskiTehnicariRoute);

                var result = await _apiService.Get<MedicinskiTehnicarDtoEL>(new MedicinskiTehnicarResourceParameters
                    {KorisnickiNalogId = Auth.KorisnickiNalog.Id, EagerLoaded = true});

                if (!result.Succeeded || result?.Data == null)
                {
                    dlgError.ShowDialog("Unable to load profile data");
                    return;
                }

                var medTehnicar = result.Data.First();
                licniPodaciId = medTehnicar.LicniPodaciId;
            }
            else if (Auth.Role == RoleType.RadnikPrijem)
            {
                _apiService.ChangeRoute(Routes.RadniciPrijemRoute);

                var result = await _apiService.Get<RadnikDtoEL>(new RadnikPrijemResourceParameters()
                    {KorisnickiNalogId = Auth.KorisnickiNalog.Id, EagerLoaded = true});

                if (!result.Succeeded || result?.Data == null)
                {
                    dlgError.ShowDialog("Unable to load profile data");
                    return;
                }

                var radnikPrijem = result.Data.First();
                licniPodaciId = radnikPrijem.LicniPodaciId;
            }

            if (licniPodaciId == 0)
            {
                dlgError.ShowDialog("Nismo pronasli licne podatke povezane sa ovim korisnickim nalogom");
                return;
            }

            _apiService.ChangeRoute(Routes.LicniPodaciRoute);

            var licniPodaciResult = await _apiService.GetById<LicniPodaciDto>(licniPodaciId, eagerLoaded: true);
            if (!licniPodaciResult.Succeeded && !licniPodaciResult.HasData)
            {
                dlgError.ShowDialog("Unable to laod profile data");
                return;
            }

            LicniPodaci = licniPodaciResult.Data;
            await LoadGradovi(LicniPodaci.Grad.DrzavaId);

            txtIme.Text = LicniPodaci.Ime;
            txtPrezime.Text = LicniPodaci.Prezime;
            lblFirstLastName.Text = $"{LicniPodaci.Ime} {LicniPodaci.Prezime}";
            txtJmbg.Text = LicniPodaci.JMBG;
            txtEmail.Text = LicniPodaci.EmailAddress;
            txtAdresa.Text = LicniPodaci.Adresa;
            txtDateCreated.Text = Auth.KorisnickiNalog.DateCreated;
            txtBrojTelefona.Text = LicniPodaci.BrojTelefona;

            if (LicniPodaci.ProfilePicture.Length > 0)
            {
                var imageFromStream= Image.FromStream(new MemoryStream(LicniPodaci.ProfilePicture));
                picProfilePicture.Image = imageFromStream;
            }

            cmbPolovi.SelectedIndex = char.ToLower(LicniPodaci.Pol) == 'm' ? 0 : 1;
            cmbDrzave.SelectedValue = LicniPodaci.Grad?.DrzavaId ?? 0;
            cmbGradovi.SelectedValue = LicniPodaci.Grad.Id;
        }

        private bool ValidateInputs()
        {
            if (!txtIme.ValidTextInput(Errors))
                return false;

            if (!txtPrezime.ValidTextInput(Errors))
                return false;

            if (!txtJmbg.ValidTextInput(Errors, Validation.TextInputType.Digits))
                return false;

            if (!cmbPolovi.ValidComboBoxItemSelected(Errors))
                return false;

            if (!cmbGradovi.ValidComboBoxItemSelected(Errors))
                return false;

            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                Errors.SetError(txtAdresa, Properties.Resources.RequiredField);
                return false;
            }

            if (!txtBrojTelefona.Text.ValidatePhoneNumber(true))
                return false;

            if (!txtEmail.ValidEmailAddressFormat(Errors))
                return false;

            Errors.Clear();
            return true;
        }

        private async void cmbDrzave_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            var selected = cmbDrzave.SelectedItem as DrzavaDto;
            if (selected == null)
                return;

            await LoadGradovi(selected.Id);
        }

        private async Task LoadGradovi(int drzavaId)
        {
            _apiService.ChangeRoute(Routes.GradoviRoute);
            var gradoviResult = await _apiService.Get<GradDtoLL>(new GradResourceParameters
                {PageSize = 100, DrzavaId = drzavaId});
            if (gradoviResult.Succeeded)
            {
                var gradovi = gradoviResult.Data;
                cmbGradovi.DataSource = gradovi;
                cmbGradovi.DisplayMember = nameof(GradDtoLL.Naziv);
                cmbGradovi.ValueMember = nameof(GradDtoLL.Id);
            }
        }

        private async void picProfilePicture_MouseClick(object sender, MouseEventArgs e)
        {
            if (ofcLoadPicture.ShowDialog() == DialogResult.OK)
            {
                var path = ofcLoadPicture.FileName;
                var picture = Image.FromFile(path);
                picProfilePicture.Image = picture;

                await UpdateLicniPodaci();
            }
        }

        private async Task UpdateLicniPodaci()
        {
            if (ValidateInputs())
            {
                byte[] ProfilePic;
                using (var ms = new MemoryStream())
                {
                    picProfilePicture.Image.Save(ms,picProfilePicture.Image.RawFormat);
                    ProfilePic = ms.ToArray();
                }
                var upsertDto = new LicniPodaciUpsertDto
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Adresa = txtAdresa.Text,
                    JMBG = txtJmbg.Text,
                    BrojTelefona = txtBrojTelefona.Text,
                    EmailAddress = txtEmail.Text,
                    GradId = int.Parse(cmbGradovi.SelectedValue.ToString()),
                    Pol = cmbPolovi.SelectedIndex == 1 ? 'Z' : 'M',
                    ProfilePicture = ProfilePic
                };

                _apiService.ChangeRoute(Routes.LicniPodaciRoute);
                var result = await _apiService.Update<LicniPodaciDto>(LicniPodaci.Id, upsertDto);
                if (result.Succeeded)
                    dlgSuccess.ShowDialog();
            }
        }
    }
}