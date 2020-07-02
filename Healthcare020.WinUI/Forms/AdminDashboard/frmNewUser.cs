using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdministratorDashboard
{
    public partial class frmNewUser : Form
    {
        private static frmNewUser _instance = null;
        private readonly APIService _apiService;
        private Dictionary<string, Point> FieldsDefaultLocations;

        private frmNewUser()
        {
            InitializeComponent();
            _apiService = new APIService(Routes.KorisniciRoute);
            lblNaucnaOblast.Visible = false;
            cmbNaucneOblasti.Visible = false;
            rbtnAdministrator.Click += naucneOblastiHide_Click;
            rbtnMedTehnicar.Click += naucneOblastiHide_Click;
            rbtnRadnikPrijem.Click += naucneOblastiHide_Click;
            FieldsDefaultLocations = new Dictionary<string, Point>();

            TopLevel = false;
            Text = Properties.Resources.frmNewUser;
            foreach (var control in Controls.OfType<MaterialSingleLineTextField>())
            {
                Errors.SetIconPadding(control, 10);
            }
            foreach (var control in Controls.OfType<ComboBox>())
            {
                Errors.SetIconPadding(control, 10);
            }
        }

        public static frmNewUser Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmNewUser();
                }

                return _instance;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmUsers.Instance.OpenAsChildOfControl(Parent);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {

                RoleType roleChecked = RoleType.Doktor;
                if (rbtnRadnikPrijem.Checked) 
                    roleChecked = RoleType.RadnikPrijem;
                else if (rbtnAdministrator.Checked) 
                    roleChecked = RoleType.Administrator;

                var korisnickiNalogUpsertDto = new KorisnickiNalogUpsertDto
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text,
                    RoleType = roleChecked.ToDescriptionString()
                };

                if (roleChecked == RoleType.Administrator)
                {
                    _apiService.ChangeRoute(Routes.KorisniciRoute);
                    var korisnickiNalogInsertResult =
                        await _apiService.Post<KorisnickiNalogDtoLL>(korisnickiNalogUpsertDto);
                    if(korisnickiNalogInsertResult.Succeeded)
                        dlgSuccess.ShowDialog();
                    return;
                }

                var licniPodaciUpsertDto = new LicniPodaciUpsertDto
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Adresa = txtAdresa.Text,
                    JMBG = txtJmbg.Text,
                    BrojTelefona = txtBrojTelefona.Text,
                    EmailAddress = txtEmail.Text,
                    GradId = int.Parse(cmbGradovi.SelectedValue.ToString()),
                    Pol = cmbPolovi.SelectedIndex == 1 ? 'Z' : 'M'
                };
                

                bool SuccededInsert = true;
                if (rbtnDoktor.Checked)
                {
                    _apiService.ChangeRoute(Routes.DoktoriRoute);
                    var doktorUpsertDto = new DoktorUpsertDto
                    {
                        KorisnickiNalog = korisnickiNalogUpsertDto,
                        LicniPodaci = licniPodaciUpsertDto,
                        NaucnaOblastId = int.Parse(cmbNaucneOblasti.SelectedValue.ToString()),
                        StacionarnoOdeljenjeId = int.Parse(cmbStacionarnaOdeljenja.SelectedValue.ToString())
                    };

                    var doktorInsertResult = await _apiService.Post<DoktorDtoLL>(doktorUpsertDto);
                    SuccededInsert = doktorInsertResult.Succeeded;
                }
                else if (rbtnRadnikPrijem.Checked)
                {
                    _apiService.ChangeRoute(Routes.RadniciPrijemRoute);
                    var radnikPrijemUpsertDto = new RadnikPrijemUpsertDto
                    {
                        KorisnickiNalog = korisnickiNalogUpsertDto,
                        LicniPodaci = licniPodaciUpsertDto,
                        StacionarnoOdeljenjeId = int.Parse(cmbStacionarnaOdeljenja.SelectedValue.ToString())
                    };
                    var radnikPrijemInsertResult = await _apiService.Post<RadnikPrijemDtoLL>(radnikPrijemUpsertDto);
                    SuccededInsert = radnikPrijemInsertResult.Succeeded;
                }

                if (SuccededInsert)
                    dlgSuccess.ShowDialog();
            }
        }

        private async void cmbDrzave_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selected = cmbDrzave.SelectedItem as DrzavaDto;
            if (selected == null)
                return;

            await LoadGradovi(selected.Id);
        }

        private void frmNewUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Errors.Clear();
        }

        private async void frmNewUser_Load(object sender, EventArgs e)
        {
            _apiService.ChangeRoute(Routes.NaucneOblastiRoute);
            var naucneOblastiResult =
                await _apiService.Get<TwoFieldsDto>(new TwoFieldsResourceParameters { PageSize = 100 });
            if (naucneOblastiResult.Succeeded && naucneOblastiResult.HasData)
            {
                cmbNaucneOblasti.DataSource = naucneOblastiResult.Data;
                cmbNaucneOblasti.ValueMember = nameof(TwoFieldsDto.Id);
                cmbNaucneOblasti.DisplayMember = nameof(TwoFieldsDto.Naziv);
            }

            _apiService.ChangeRoute(Routes.StacionarnaOdeljenjaRoute);
            var stacOdeljenjaResult =
                await _apiService.Get<TwoFieldsDto>(new TwoFieldsResourceParameters { PageSize = 100 });
            if (stacOdeljenjaResult.Succeeded && stacOdeljenjaResult.HasData)
            {
                cmbStacionarnaOdeljenja.DataSource = stacOdeljenjaResult.Data;
                cmbStacionarnaOdeljenja.DisplayMember = nameof(TwoFieldsDto.Naziv);
                cmbStacionarnaOdeljenja.ValueMember = nameof(TwoFieldsDto.Id);
            }

            _apiService.ChangeRoute(Routes.DrzaveRoute);
            var drzaveResult = await _apiService.Get<DrzavaDto>(new DrzavaResourceParameters { PageSize = 100 });
            if (drzaveResult.Succeeded)
            {
                var drzave = drzaveResult.Data;
                cmbDrzave.DataSource = drzave;
                cmbDrzave.DisplayMember = nameof(DrzavaDto.Naziv);
                cmbDrzave.ValueMember = nameof(DrzavaDto.Id);
            }

            cmbPolovi.DataSource = new List<ComboBoxItem>
            {
                new ComboBoxItem(Resources.GenderMale, 0),
                new ComboBoxItem(Resources.GenderFemale, 1)
            };

            cmbPolovi.ValueMember = nameof(ComboBoxItem.Value);
            cmbPolovi.DisplayMember = nameof(ComboBoxItem.Text);
        }

        private async Task LoadGradovi(int drzavaId)
        {
            _apiService.ChangeRoute(Routes.GradoviRoute);
            var gradoviResult = await _apiService.Get<GradDtoLL>(new GradResourceParameters
            { PageSize = 100, DrzavaId = drzavaId });
            if (gradoviResult.Succeeded)
            {
                var gradovi = gradoviResult.Data;
                cmbGradovi.DataSource = gradovi;
                cmbGradovi.DisplayMember = nameof(GradDtoLL.Naziv);
                cmbGradovi.ValueMember = nameof(GradDtoLL.Id);
            }
        }

        private void naucneOblastiHide_Click(object sender, EventArgs e)
        {
            if (lblNaucnaOblast.Visible)
            {
                lblNaucnaOblast.Visible = false;
                cmbNaucneOblasti.Visible = false;
            }
        }

        private void rbtnAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAdministrator.Checked)
            {
                var firstLabelPosition = lblIme.Location;
                var secondLabelPosition = lblJmbg.Location;
                var thirdLabelPosition = lblGender.Location;
                var firstTxtPosition = txtIme.Location;
                var secondTxtPosition = txtJmbg.Location;
                var thirdTxtPosition = cmbPolovi.Location;

                foreach (var control in pnlMain.Controls.OfType<Control>())
                {
                    if (control is MaterialSingleLineTextField c)
                        c.Visible = false;
                    else if (control is ComboBox cmb)
                        cmb.Visible = false;
                    else if (control is Label lbl)
                        lbl.Visible = false;
                }

                FieldsDefaultLocations.Add(lblUsername.Name, lblUsername.Location);
                lblUsername.Location = firstLabelPosition;
                FieldsDefaultLocations.Add(txtUsername.Name, txtUsername.Location);
                txtUsername.Location = firstTxtPosition;
                txtUsername.Visible = true;
                lblUsername.Visible = true;

                FieldsDefaultLocations.Add(lblPassword.Name, lblPassword.Location);
                lblPassword.Location = secondLabelPosition;
                FieldsDefaultLocations.Add(txtPassword.Name, txtPassword.Location);
                txtPassword.Location = secondTxtPosition;
                lblPassword.Visible = true;
                txtPassword.Visible = true;

                FieldsDefaultLocations.Add(txtConfirmPassword.Name, txtConfirmPassword.Location);
                txtConfirmPassword.Location = thirdTxtPosition;
                txtConfirmPassword.Visible = true;
                FieldsDefaultLocations.Add(lblConfirmPassword.Name, lblConfirmPassword.Location);
                lblConfirmPassword.Location = thirdLabelPosition;
                lblConfirmPassword.Visible = true;
            }
        }

        private void rbtnDoktor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDoktor.Checked)
            {
                RevertDefaultControlsLocations();
                lblNaucnaOblast.Visible = true;
                cmbNaucneOblasti.Visible = true;
            }
        }

        private void rbtnMedTehnicar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMedTehnicar.Checked)
            {
                RevertDefaultControlsLocations();
            }
        }

        private void rbtnRadnikPrijem_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRadnikPrijem.Checked)
            {
                RevertDefaultControlsLocations();
            }
        }

        private void RevertDefaultControlsLocations()
        {
            if (!FieldsDefaultLocations.Any())
                return;
            foreach (var control in pnlMain.Controls.OfType<Control>())
            {
                if (FieldsDefaultLocations.ContainsKey(control.Name))
                    control.Location = FieldsDefaultLocations.Single(x => x.Key == control.Name).Value;
                control.Visible = true;
            }
            FieldsDefaultLocations.Clear();
        }

        private bool ValidateInputs()
        {
            if (!txtPassword.ValidTextInput(Errors, Validation.TextInputType.Mixed))
                return false;

            if (!txtConfirmPassword.ValidTextInput(Errors, Validation.TextInputType.Mixed))
                return false;

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                Errors.SetError(txtConfirmPassword, Resources.InvalidPasswordConfirmation);
                return false;
            }

            if (!txtUsername.ValidTextInput(Errors,Validation.TextInputType.Mixed))
                return false;

            if (rbtnAdministrator.Checked)
            {
                Errors.Clear();
                return true;
            }

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

            if (!txtAdresa.ValidTextInput(Errors,Validation.TextInputType.Mixed))
                return false;

            if (!txtBrojTelefona.Text.ValidatePhoneNumber(true))
                return false;

            if (!txtEmail.ValidEmailAddressFormat(Errors))
                return false;

            if (!cmbStacionarnaOdeljenja.ValidComboBoxItemSelected(Errors))
                return false;

            if (rbtnDoktor.Checked && !cmbNaucneOblasti.ValidComboBoxItemSelected(Errors))
                return false;

            Errors.Clear();
            return true;
        }
    }
}