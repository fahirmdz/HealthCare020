using FontAwesome.Sharp;
using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.Dialogs;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    public partial class frmStartMenuAdmin : Form
    {
        private static frmStartMenuAdmin _instance;

        //Fields
        private IconButton currentBtn;

        private Panel leftBorderBtn;
        private Form currentChildForm;

        private APIService _apiService;

        //PREDEFINED DATA COUNTS
        public int DrzavaCount { get; set; }

        public int GradoviCount { get; set; }
        public int NaucneOblastiCount { get; set; }
        public int ZdravstvenaStanjaCount { get; set; }
        public int RolesCount { get; set; }

        public static frmStartMenuAdmin Instance
        {
            get
            {
                //if (!Auth.IsAuthenticated())
                //    return null;

                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new frmStartMenuAdmin();
                }

                return _instance;
            }
        }

        private frmStartMenuAdmin()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
        }

        private async void frmStartMenuAdmin_Load(object sender, EventArgs e)
        {
            if (!Auth.IsAuthenticated())
            {
                Close();
                Dispose();
            }
            await LoadPredefinedDataCounts();
            SetClickEventToCloseUserMenu(Controls);
            SetClickEventToCloseUserMenu(panelMenu.Controls);
            SetClickEventToCloseUserMenu(pnlTop.Controls);
        }

        public async Task LoadPredefinedDataCounts()
        {
            _apiService = new APIService(Routes.DrzaveRoute);
            DrzavaCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.GradoviRoute);
            GradoviCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.ZdravstvenaStanjaRoute);
            ZdravstvenaStanjaCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.NaucneOblastiRoute);
            NaucneOblastiCount = (await _apiService.Count())?.Data.First() ?? 0;
            _apiService.ChangeRoute(Routes.RolesRoute);
            RolesCount = (await _apiService.Count())?.Data.First() ?? 0;
        }

        public async Task LoadPredefinedDataCount(string route)
        {
            switch (route)
            {
                case Routes.DrzaveRoute:
                    _apiService = new APIService(Routes.DrzaveRoute);
                    DrzavaCount = (await _apiService.Count())?.Data.First() ?? 0;
                    break;

                case Routes.GradoviRoute:
                    _apiService.ChangeRoute(Routes.GradoviRoute);
                    GradoviCount = (await _apiService.Count())?.Data.First() ?? 0;
                    break;

                case Routes.ZdravstvenaStanjaRoute:
                    _apiService.ChangeRoute(Routes.ZdravstvenaStanjaRoute);
                    ZdravstvenaStanjaCount = (await _apiService.Count())?.Data.First() ?? 0;
                    break;

                case Routes.NaucneOblastiRoute:
                    _apiService.ChangeRoute(Routes.NaucneOblastiRoute);
                    NaucneOblastiCount = (await _apiService.Count())?.Data.First() ?? 0;
                    break;

                case Routes.RolesRoute:
                    _apiService.ChangeRoute(Routes.RolesRoute);
                    RolesCount = (await _apiService.Count())?.Data.First() ?? 0;
                    break;

                default:
                    return;
            }
        }

        /// <summary>
        /// Add event for closing User dropdown menu on every click
        /// </summary>
        public void SetClickEventToCloseUserMenu(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Name != "btnUserMenu")
                    control.MouseClick += new MouseEventHandler(control_Click);
            }
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(0, 31, 61);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(15, 200, 200);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 190, 190);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(73, 96, 117);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var frmUsers = AdminDashboard.frmUsers.Instance;
            if (frmUsers != null)
            {
                frmUsers.OpenAsChildOfControl(pnlBody);
            }
            else
            {
                MessageBox.Show(Properties.Resources.NotLoggedIn);
            }
        }

        private void btnPredefinedData_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            var frmPredefinedData = frmPredefinedDataMenu.Instance;
            if (frmPredefinedData != null)
            {
                frmPredefinedData.OpenAsChildOfControl(pnlBody);
            }
            else
            {
                dlgError.ShowDialog(Properties.Resources.NotLoggedIn);
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            var frmStatisticsMenu = AdminDashboard.frmStatisticsMenu.Instance;
            if (frmStatisticsMenu != null)
            {
                frmStatisticsMenu.OpenAsChildOfControl(pnlBody);
            }
            else
            {
                dlgError.ShowDialog(Properties.Resources.NotLoggedIn);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (var form in pnlBody.Controls.OfType<Form>())
            {
                form.Dispose();
                form.Close();
            }

            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = RGBColors.color5;
            lblTitleChildForm.Text = "Home";
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CloseUserDropdownMenu()
        {
            if (pnlUserMenuDropdown.Visible)
                pnlUserMenuDropdown.Hide();
        }

        public void control_Click(object sender, EventArgs e)
        {
            CloseUserDropdownMenu();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            currentChildForm.Dispose();
        }

        private void pnlBody_ControlAdded(object sender, ControlEventArgs e)
        {
            currentChildForm = pnlBody.Controls.OfType<Form>().First();
            if(currentChildForm==null)
                return;

            lblTitleChildForm.Text = currentChildForm.Text;
            SetClickEventToCloseUserMenu(currentChildForm.Controls);
        }
    }
}