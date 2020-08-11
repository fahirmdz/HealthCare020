using System;
using System.Drawing;
using System.Windows.Forms;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Services;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public partial class frmNewNaucnaOblast : Form
    {
        private static frmNewNaucnaOblast _instance = null;
        private APIService _apiService;
        private TwoFieldsDto NaucnaOblast;

        public new static frmNewNaucnaOblast ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmNewNaucnaOblast();
            }
            ((Form)_instance).ShowDialog();
            return _instance;
        }

        public static frmNewNaucnaOblast ShowDialogWithData(TwoFieldsDto naucnaOblast = null)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewNaucnaOblast(naucnaOblast);
            else
                _instance.NaucnaOblast = naucnaOblast;

            ((Form)_instance).ShowDialog();
            return _instance;
        }

        private frmNewNaucnaOblast(TwoFieldsDto naucnaOblast = null)
        {
            InitializeComponent();
            NaucnaOblast = naucnaOblast;

            if (NaucnaOblast != null)
            {
                txtNaziv.Text = NaucnaOblast.Naziv;
            }

            _apiService = new APIService(Routes.NaucneOblastiRoute);
            Text = NaucnaOblast == null ? Properties.Resources.frmNewNaucnaOblastAdd : Properties.Resources.frmNewNaucnaOblastUpdate;

            var mainFormSize = MainForm.Instance.Size;
            this.Size = new Size(mainFormSize.Width - 16, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;
            this.FormBorderStyle = FormBorderStyle.None;

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = Color.Transparent;
            pnlMain.BackColor = Color.FromArgb(125, 0, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //IGNORE
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtNaziv.ValidTextInput(Errors))
            {
                APIServiceResult<TwoFieldsDto> result;
                var upsertDto = new NaucnaOblastUpsertDto { Naziv = txtNaziv.Text };

                if (NaucnaOblast == null)
                {
                    result = await _apiService.Post<TwoFieldsDto>(upsertDto);
                }
                else
                {
                    result = await _apiService.Update<TwoFieldsDto>(NaucnaOblast.Id, upsertDto);
                }

                if (result.Succeeded)
                {
                    if (NaucnaOblast == null)
                        await frmPredefinedDataMenu.Instance.LoadPredefinedDataCount(Routes.NaucneOblastiRoute);

                    dlgSuccess.ShowDialog();
                    await frmNaucneOblasti.Instance.RefreshData();
                }
            }
            Close();
            Dispose();
        }
    }
}