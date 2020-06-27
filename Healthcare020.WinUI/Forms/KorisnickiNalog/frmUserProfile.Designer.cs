using Healthcare020.WinUI.Properties;

namespace Healthcare020.WinUI.Forms.KorisnickiNalog
{
    partial class frmUserProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserProfile));
            this.lblFirstLastName = new System.Windows.Forms.Label();
            this.tabUserProfile = new MaterialSkin.Controls.MaterialTabControl();
            this.tabLicniPodaci = new System.Windows.Forms.TabPage();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbDrzave = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.cmbPolovi = new System.Windows.Forms.ComboBox();
            this.cmbGradovi = new System.Windows.Forms.ComboBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.txtBrojTelefona = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtJmbg = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtAdresa = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPrezime = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtIme = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tabSigurnost = new System.Windows.Forms.TabPage();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.txtDateCreated = new System.Windows.Forms.Label();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.lblRole = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picProfilePicture = new Healthcare020.WinUI.Helpers.CustomElements.CircularPictureBox();
            this.pnlCopyright = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.ofcLoadPicture = new System.Windows.Forms.OpenFileDialog();
            this.tabUserProfile.SuspendLayout();
            this.tabLicniPodaci.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePicture)).BeginInit();
            this.pnlCopyright.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstLastName
            // 
            this.lblFirstLastName.AutoSize = true;
            this.lblFirstLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblFirstLastName.Location = new System.Drawing.Point(36, 229);
            this.lblFirstLastName.Name = "lblFirstLastName";
            this.lblFirstLastName.Padding = new System.Windows.Forms.Padding(2);
            this.lblFirstLastName.Size = new System.Drawing.Size(4, 41);
            this.lblFirstLastName.TabIndex = 1;
            // 
            // tabUserProfile
            // 
            this.tabUserProfile.Controls.Add(this.tabLicniPodaci);
            this.tabUserProfile.Controls.Add(this.tabSigurnost);
            this.tabUserProfile.Depth = 0;
            this.tabUserProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserProfile.Location = new System.Drawing.Point(0, 37);
            this.tabUserProfile.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabUserProfile.Name = "tabUserProfile";
            this.tabUserProfile.SelectedIndex = 0;
            this.tabUserProfile.Size = new System.Drawing.Size(891, 542);
            this.tabUserProfile.TabIndex = 3;
            // 
            // tabLicniPodaci
            // 
            this.tabLicniPodaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.tabLicniPodaci.Controls.Add(this.lblCountry);
            this.tabLicniPodaci.Controls.Add(this.cmbDrzave);
            this.tabLicniPodaci.Controls.Add(this.lblCity);
            this.tabLicniPodaci.Controls.Add(this.lblPhoneNumber);
            this.tabLicniPodaci.Controls.Add(this.lblJmbg);
            this.tabLicniPodaci.Controls.Add(this.lblPrezime);
            this.tabLicniPodaci.Controls.Add(this.lblEmail);
            this.tabLicniPodaci.Controls.Add(this.lblAddress);
            this.tabLicniPodaci.Controls.Add(this.lblGender);
            this.tabLicniPodaci.Controls.Add(this.lblIme);
            this.tabLicniPodaci.Controls.Add(this.cmbPolovi);
            this.tabLicniPodaci.Controls.Add(this.cmbGradovi);
            this.tabLicniPodaci.Controls.Add(this.txtEmail);
            this.tabLicniPodaci.Controls.Add(this.btnSave);
            this.tabLicniPodaci.Controls.Add(this.txtBrojTelefona);
            this.tabLicniPodaci.Controls.Add(this.txtJmbg);
            this.tabLicniPodaci.Controls.Add(this.txtAdresa);
            this.tabLicniPodaci.Controls.Add(this.txtPrezime);
            this.tabLicniPodaci.Controls.Add(this.txtIme);
            this.tabLicniPodaci.Location = new System.Drawing.Point(4, 22);
            this.tabLicniPodaci.Name = "tabLicniPodaci";
            this.tabLicniPodaci.Padding = new System.Windows.Forms.Padding(3);
            this.tabLicniPodaci.Size = new System.Drawing.Size(883, 516);
            this.tabLicniPodaci.TabIndex = 0;
            this.tabLicniPodaci.Text = global::Healthcare020.WinUI.Properties.Resources.LabelPersonalData;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(65, 273);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(69, 25);
            this.lblCountry.TabIndex = 47;
            this.lblCountry.Text = "Drzava";
            // 
            // cmbDrzave
            // 
            this.cmbDrzave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDrzave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbDrzave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrzave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDrzave.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbDrzave.FormattingEnabled = true;
            this.cmbDrzave.Location = new System.Drawing.Point(67, 318);
            this.cmbDrzave.Name = "cmbDrzave";
            this.cmbDrzave.Size = new System.Drawing.Size(250, 31);
            this.cmbDrzave.TabIndex = 46;
            this.cmbDrzave.SelectionChangeCommitted += new System.EventHandler(this.cmbDrzave_SelectionChangeCommitted);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(445, 279);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(52, 25);
            this.lblCity.TabIndex = 45;
            this.lblCity.Text = "Grad";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(445, 191);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(116, 25);
            this.lblPhoneNumber.TabIndex = 44;
            this.lblPhoneNumber.Tag = "";
            this.lblPhoneNumber.Text = "Broj telefona";
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJmbg.Location = new System.Drawing.Point(445, 94);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(58, 25);
            this.lblJmbg.TabIndex = 43;
            this.lblJmbg.Text = "JMBG";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezime.Location = new System.Drawing.Point(445, 16);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(77, 25);
            this.lblPrezime.TabIndex = 42;
            this.lblPrezime.Text = "Prezime";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(62, 378);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(64, 25);
            this.lblEmail.TabIndex = 41;
            this.lblEmail.Text = "E-mail";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(62, 191);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(69, 25);
            this.lblAddress.TabIndex = 40;
            this.lblAddress.Text = "Adresa";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(62, 94);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(36, 25);
            this.lblGender.TabIndex = 39;
            this.lblGender.Text = "Pol";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIme.Location = new System.Drawing.Point(62, 16);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(43, 25);
            this.lblIme.TabIndex = 38;
            this.lblIme.Text = "Ime";
            // 
            // cmbPolovi
            // 
            this.cmbPolovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPolovi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPolovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPolovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPolovi.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbPolovi.FormattingEnabled = true;
            this.cmbPolovi.Location = new System.Drawing.Point(67, 142);
            this.cmbPolovi.Name = "cmbPolovi";
            this.cmbPolovi.Size = new System.Drawing.Size(250, 31);
            this.cmbPolovi.TabIndex = 37;
            // 
            // cmbGradovi
            // 
            this.cmbGradovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbGradovi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbGradovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGradovi.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbGradovi.FormattingEnabled = true;
            this.cmbGradovi.Location = new System.Drawing.Point(447, 324);
            this.cmbGradovi.Name = "cmbGradovi";
            this.cmbGradovi.Size = new System.Drawing.Size(250, 31);
            this.cmbGradovi.TabIndex = 35;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtEmail.Hint = "";
            this.txtEmail.Location = new System.Drawing.Point(67, 423);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 34;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(279, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(101)))), ((int)(((byte)(112)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(296, 37);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBrojTelefona
            // 
            this.txtBrojTelefona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBrojTelefona.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBrojTelefona.Depth = 0;
            this.txtBrojTelefona.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtBrojTelefona.Hint = "";
            this.txtBrojTelefona.Location = new System.Drawing.Point(447, 229);
            this.txtBrojTelefona.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBrojTelefona.Name = "txtBrojTelefona";
            this.txtBrojTelefona.PasswordChar = '\0';
            this.txtBrojTelefona.SelectedText = "";
            this.txtBrojTelefona.SelectionLength = 0;
            this.txtBrojTelefona.SelectionStart = 0;
            this.txtBrojTelefona.Size = new System.Drawing.Size(203, 23);
            this.txtBrojTelefona.TabIndex = 31;
            this.txtBrojTelefona.UseSystemPasswordChar = false;
            // 
            // txtJmbg
            // 
            this.txtJmbg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtJmbg.Depth = 0;
            this.txtJmbg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJmbg.Hint = "";
            this.txtJmbg.Location = new System.Drawing.Point(447, 142);
            this.txtJmbg.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.PasswordChar = '\0';
            this.txtJmbg.SelectedText = "";
            this.txtJmbg.SelectionLength = 0;
            this.txtJmbg.SelectionStart = 0;
            this.txtJmbg.Size = new System.Drawing.Size(250, 23);
            this.txtJmbg.TabIndex = 27;
            this.txtJmbg.UseSystemPasswordChar = false;
            // 
            // txtAdresa
            // 
            this.txtAdresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAdresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAdresa.Depth = 0;
            this.txtAdresa.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtAdresa.Hint = "";
            this.txtAdresa.Location = new System.Drawing.Point(67, 229);
            this.txtAdresa.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.PasswordChar = '\0';
            this.txtAdresa.SelectedText = "";
            this.txtAdresa.SelectionLength = 0;
            this.txtAdresa.SelectionStart = 0;
            this.txtAdresa.Size = new System.Drawing.Size(250, 23);
            this.txtAdresa.TabIndex = 25;
            this.txtAdresa.UseSystemPasswordChar = false;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrezime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrezime.Depth = 0;
            this.txtPrezime.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtPrezime.Hint = "";
            this.txtPrezime.Location = new System.Drawing.Point(450, 51);
            this.txtPrezime.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.PasswordChar = '\0';
            this.txtPrezime.SelectedText = "";
            this.txtPrezime.SelectionLength = 0;
            this.txtPrezime.SelectionStart = 0;
            this.txtPrezime.Size = new System.Drawing.Size(250, 23);
            this.txtPrezime.TabIndex = 23;
            this.txtPrezime.UseSystemPasswordChar = false;
            // 
            // txtIme
            // 
            this.txtIme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtIme.Depth = 0;
            this.txtIme.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtIme.Hint = "";
            this.txtIme.Location = new System.Drawing.Point(67, 51);
            this.txtIme.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIme.Name = "txtIme";
            this.txtIme.PasswordChar = '\0';
            this.txtIme.SelectedText = "";
            this.txtIme.SelectionLength = 0;
            this.txtIme.SelectionStart = 0;
            this.txtIme.Size = new System.Drawing.Size(250, 23);
            this.txtIme.TabIndex = 21;
            this.txtIme.UseSystemPasswordChar = false;
            // 
            // tabSigurnost
            // 
            this.tabSigurnost.Location = new System.Drawing.Point(4, 22);
            this.tabSigurnost.Name = "tabSigurnost";
            this.tabSigurnost.Padding = new System.Windows.Forms.Padding(3);
            this.tabSigurnost.Size = new System.Drawing.Size(883, 516);
            this.tabSigurnost.TabIndex = 1;
            this.tabSigurnost.Text = global::Healthcare020.WinUI.Properties.Resources.LabelSecurity;
            this.tabSigurnost.UseVisualStyleBackColor = true;
            // 
            // tabSelector
            // 
            this.tabSelector.BackColor = System.Drawing.Color.DarkGray;
            this.tabSelector.BaseTabControl = this.tabUserProfile;
            this.tabSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabSelector.Depth = 0;
            this.tabSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSelector.Location = new System.Drawing.Point(0, 0);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(891, 37);
            this.tabSelector.TabIndex = 4;
            this.tabSelector.Text = "materialTabSelector1";
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.tabUserProfile);
            this.pnlTabs.Controls.Add(this.tabSelector);
            this.pnlTabs.Location = new System.Drawing.Point(282, 12);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(891, 579);
            this.pnlTabs.TabIndex = 5;
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblDateCreated.Location = new System.Drawing.Point(38, 411);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(151, 25);
            this.lblDateCreated.TabIndex = 11;
            this.lblDateCreated.Text = "Datum kreiranja";
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.AutoSize = true;
            this.txtDateCreated.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCreated.ForeColor = System.Drawing.Color.White;
            this.txtDateCreated.Location = new System.Drawing.Point(56, 446);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Padding = new System.Windows.Forms.Padding(2);
            this.txtDateCreated.Size = new System.Drawing.Size(4, 25);
            this.txtDateCreated.TabIndex = 10;
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(38, 294);
            this.horizontalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(200, 1);
            this.horizontalDivider.TabIndex = 12;
            this.horizontalDivider.Text = "materialDivider1";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblRole.Location = new System.Drawing.Point(38, 328);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(62, 25);
            this.lblRole.TabIndex = 14;
            this.lblRole.Text = "Uloga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(56, 362);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(4, 25);
            this.label2.TabIndex = 13;
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pnlSidebar.Controls.Add(this.picProfilePicture);
            this.pnlSidebar.Controls.Add(this.label2);
            this.pnlSidebar.Controls.Add(this.lblFirstLastName);
            this.pnlSidebar.Controls.Add(this.lblRole);
            this.pnlSidebar.Controls.Add(this.txtDateCreated);
            this.pnlSidebar.Controls.Add(this.lblDateCreated);
            this.pnlSidebar.Controls.Add(this.horizontalDivider);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(252, 630);
            this.pnlSidebar.TabIndex = 17;
            // 
            // picProfilePicture
            // 
            this.picProfilePicture.BackColor = System.Drawing.Color.White;
            this.picProfilePicture.Image = ((System.Drawing.Image)(resources.GetObject("picProfilePicture.Image")));
            this.picProfilePicture.Location = new System.Drawing.Point(28, 12);
            this.picProfilePicture.Name = "picProfilePicture";
            this.picProfilePicture.Size = new System.Drawing.Size(200, 200);
            this.picProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProfilePicture.TabIndex = 0;
            this.picProfilePicture.TabStop = false;
            this.picProfilePicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picProfilePicture_MouseClick);
            // 
            // pnlCopyright
            // 
            this.pnlCopyright.BackColor = System.Drawing.Color.Transparent;
            this.pnlCopyright.Controls.Add(this.lblCopyright);
            this.pnlCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCopyright.Location = new System.Drawing.Point(252, 607);
            this.pnlCopyright.Name = "pnlCopyright";
            this.pnlCopyright.Size = new System.Drawing.Size(956, 23);
            this.pnlCopyright.TabIndex = 18;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCopyright.Location = new System.Drawing.Point(361, 1);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(199, 13);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "© 2020. Fahir Mumdžić. All rights reserved.";
            // 
            // ofcLoadPicture
            // 
            this.ofcLoadPicture.FileName = "openFileDialog1";
            // 
            // frmUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 630);
            this.Controls.Add(this.pnlCopyright);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserProfile";
            this.Text = "Korisnički profil";
            this.Load += new System.EventHandler(this.frmUserProfile_Load);
            this.tabUserProfile.ResumeLayout(false);
            this.tabLicniPodaci.ResumeLayout(false);
            this.tabLicniPodaci.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePicture)).EndInit();
            this.pnlCopyright.ResumeLayout(false);
            this.pnlCopyright.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Helpers.CustomElements.CircularPictureBox picProfilePicture;
        private System.Windows.Forms.Label lblFirstLastName;
        private MaterialSkin.Controls.MaterialTabControl tabUserProfile;
        private System.Windows.Forms.TabPage tabLicniPodaci;
        private System.Windows.Forms.TabPage tabSigurnost;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private System.Windows.Forms.Panel pnlTabs;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrezime;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIme;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBrojTelefona;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtJmbg;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAdresa;
        private Helpers.CustomElements.Button_WOC btnSave;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label txtDateCreated;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGradovi;
        private System.Windows.Forms.ComboBox cmbPolovi;
        private System.Windows.Forms.ErrorProvider Errors;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlCopyright;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbDrzave;
        private System.Windows.Forms.OpenFileDialog ofcLoadPicture;
    }
}