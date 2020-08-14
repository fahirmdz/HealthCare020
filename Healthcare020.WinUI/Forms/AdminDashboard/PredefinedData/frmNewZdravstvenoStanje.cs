using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Models;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    public sealed partial class frmNewZdravstvenoStanje : Form
    {
        private static frmNewZdravstvenoStanje _instance;
        private readonly APIService _apiService;
        private ZdravstvenoStanjeDto ZdravstvenoStanje;

        public new static frmNewZdravstvenoStanje ShowDialog()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new frmNewZdravstvenoStanje();
            }
            ((Form)_instance).ShowDialog();
            return _instance;
        }

        public static frmNewZdravstvenoStanje ShowDialogWithData(ZdravstvenoStanjeDto zdravstvenoStanje = null)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmNewZdravstvenoStanje(zdravstvenoStanje);
            else
                _instance.ZdravstvenoStanje = zdravstvenoStanje;

            ((Form)_instance).ShowDialog();
            return _instance;
        }

        private frmNewZdravstvenoStanje(ZdravstvenoStanjeDto zdravstvenoStanje = null)
        {
            InitializeComponent();
            ZdravstvenoStanje = zdravstvenoStanje;

            if (ZdravstvenoStanje != null)
            {
                txtOpis.Text = ZdravstvenoStanje.Opis;
            }

            _apiService = new APIService(Routes.ZdravstvenaStanjaRoute);
            Text = ZdravstvenoStanje == null ? Properties.Resources.frmNewZdravstvenoStanjeAdd : Properties.Resources.frmNewZdravstvenoStanjeUpdate;

            var mainFormSize = MainForm.Instance.Size;
            Size = new Size(mainFormSize.Width - 16, mainFormSize.Height - 14);
            pnlMain.MinimumSize = Size;
            FormBorderStyle = FormBorderStyle.None;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            TransparencyKey = Color.Transparent;
            pnlMain.BackColor = Color.FromArgb(125, 0, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //IGNORE
        }

        private void frmNewZdravstvenoStanje_Shown(object sender, System.EventArgs e)
        {
            pnlDialog.PointToScreen(new Point(Width / 2, Height / 2));
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
            Dispose();
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (ValidateInput())
            {
                APIServiceResult<ZdravstvenoStanjeDto> result;
                var upsertDto = new ZdravstvenoStanjeUpsertDto
                { Opis = txtOpis.Text };

                if (ZdravstvenoStanje == null)
                    result = await _apiService.Post<ZdravstvenoStanjeDto>(upsertDto);
                else
                    result = await _apiService.Update<ZdravstvenoStanjeDto>(ZdravstvenoStanje.Id, upsertDto);

                if (result.Succeeded)
                {
                    if (ZdravstvenoStanje == null)
                        await frmPredefinedDataMenu.Instance.LoadPredefinedDataCount(Routes.ZdravstvenaStanjaRoute);

                    dlgSuccess.ShowDialog();
                    Close();
                    await frmZdravstvenaStanja.Instance.RefreshData();
                }
            }

            Close();
            Dispose();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                Errors.SetError(txtOpis, Properties.Resources.RequiredField);
                return false;
            }

            if (txtOpis.Text.Any(char.IsDigit))
            {
                Errors.SetError(txtOpis, Properties.Resources.InvalidFormat);
                return false;
            }

            Errors.Clear();
            return true;
        }
    }
}