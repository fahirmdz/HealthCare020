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
            this.cmbPolovi = new System.Windows.Forms.ComboBox();
            this.lblGrad = new MaterialSkin.Controls.MaterialLabel();
            this.cmbGradovi = new System.Windows.Forms.ComboBox();
            this.lblEmailAddress = new MaterialSkin.Controls.MaterialLabel();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.lblBrojTelefona = new MaterialSkin.Controls.MaterialLabel();
            this.txtBrojTelefona = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblPol = new MaterialSkin.Controls.MaterialLabel();
            this.lblJmbg = new MaterialSkin.Controls.MaterialLabel();
            this.txtJmbg = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblAdresa = new MaterialSkin.Controls.MaterialLabel();
            this.txtAdresa = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblPrezime = new MaterialSkin.Controls.MaterialLabel();
            this.txtPrezime = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblIme = new MaterialSkin.Controls.MaterialLabel();
            this.txtIme = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tabSigurnost = new System.Windows.Forms.TabPage();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.verticalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.txtDateCreated = new System.Windows.Forms.Label();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.lblRole = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserProfile = new System.Windows.Forms.Label();
            this.topDivider = new MaterialSkin.Controls.MaterialDivider();
            this.circularPictureBox1 = new Healthcare020.WinUI.Helpers.CustomElements.CircularPictureBox();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabUserProfile.SuspendLayout();
            this.tabLicniPodaci.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstLastName
            // 
            this.lblFirstLastName.AutoSize = true;
            this.lblFirstLastName.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstLastName.Location = new System.Drawing.Point(62, 308);
            this.lblFirstLastName.Name = "lblFirstLastName";
            this.lblFirstLastName.Padding = new System.Windows.Forms.Padding(2);
            this.lblFirstLastName.Size = new System.Drawing.Size(185, 41);
            this.lblFirstLastName.TabIndex = 1;
            this.lblFirstLastName.Text = "Fahir Mumdžić";
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
            this.tabUserProfile.Size = new System.Drawing.Size(837, 464);
            this.tabUserProfile.TabIndex = 3;
            // 
            // tabLicniPodaci
            // 
            this.tabLicniPodaci.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.tabLicniPodaci.Controls.Add(this.cmbPolovi);
            this.tabLicniPodaci.Controls.Add(this.lblGrad);
            this.tabLicniPodaci.Controls.Add(this.cmbGradovi);
            this.tabLicniPodaci.Controls.Add(this.lblEmailAddress);
            this.tabLicniPodaci.Controls.Add(this.txtEmail);
            this.tabLicniPodaci.Controls.Add(this.btnSave);
            this.tabLicniPodaci.Controls.Add(this.lblBrojTelefona);
            this.tabLicniPodaci.Controls.Add(this.txtBrojTelefona);
            this.tabLicniPodaci.Controls.Add(this.lblPol);
            this.tabLicniPodaci.Controls.Add(this.lblJmbg);
            this.tabLicniPodaci.Controls.Add(this.txtJmbg);
            this.tabLicniPodaci.Controls.Add(this.lblAdresa);
            this.tabLicniPodaci.Controls.Add(this.txtAdresa);
            this.tabLicniPodaci.Controls.Add(this.lblPrezime);
            this.tabLicniPodaci.Controls.Add(this.txtPrezime);
            this.tabLicniPodaci.Controls.Add(this.lblIme);
            this.tabLicniPodaci.Controls.Add(this.txtIme);
            this.tabLicniPodaci.Location = new System.Drawing.Point(4, 22);
            this.tabLicniPodaci.Name = "tabLicniPodaci";
            this.tabLicniPodaci.Padding = new System.Windows.Forms.Padding(3);
            this.tabLicniPodaci.Size = new System.Drawing.Size(829, 438);
            this.tabLicniPodaci.TabIndex = 0;
            this.tabLicniPodaci.Text = global::Healthcare020.WinUI.Properties.Resources.LabelPersonalData;
            // 
            // cmbPolovi
            // 
            this.cmbPolovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPolovi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPolovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPolovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPolovi.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cmbPolovi.FormattingEnabled = true;
            this.cmbPolovi.Location = new System.Drawing.Point(178, 148);
            this.cmbPolovi.Name = "cmbPolovi";
            this.cmbPolovi.Size = new System.Drawing.Size(203, 28);
            this.cmbPolovi.TabIndex = 37;
            // 
            // lblGrad
            // 
            this.lblGrad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGrad.AutoSize = true;
            this.lblGrad.Depth = 0;
            this.lblGrad.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblGrad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGrad.Location = new System.Drawing.Point(474, 289);
            this.lblGrad.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGrad.Name = "lblGrad";
            this.lblGrad.Size = new System.Drawing.Size(40, 19);
            this.lblGrad.TabIndex = 36;
            this.lblGrad.Text = "Grad";
            // 
            // cmbGradovi
            // 
            this.cmbGradovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbGradovi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbGradovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGradovi.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cmbGradovi.FormattingEnabled = true;
            this.cmbGradovi.Location = new System.Drawing.Point(465, 327);
            this.cmbGradovi.Name = "cmbGradovi";
            this.cmbGradovi.Size = new System.Drawing.Size(203, 28);
            this.cmbGradovi.TabIndex = 35;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Depth = 0;
            this.lblEmailAddress.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEmailAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmailAddress.Location = new System.Drawing.Point(187, 289);
            this.lblEmailAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(51, 19);
            this.lblEmailAddress.TabIndex = 33;
            this.lblEmailAddress.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Hint = "";
            this.txtEmail.Location = new System.Drawing.Point(178, 332);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(203, 23);
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
            this.btnSave.Location = new System.Drawing.Point(298, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(101)))), ((int)(((byte)(112)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(254, 39);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblBrojTelefona
            // 
            this.lblBrojTelefona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBrojTelefona.AutoSize = true;
            this.lblBrojTelefona.Depth = 0;
            this.lblBrojTelefona.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblBrojTelefona.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBrojTelefona.Location = new System.Drawing.Point(474, 202);
            this.lblBrojTelefona.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBrojTelefona.Name = "lblBrojTelefona";
            this.lblBrojTelefona.Size = new System.Drawing.Size(95, 19);
            this.lblBrojTelefona.TabIndex = 30;
            this.lblBrojTelefona.Text = "Broj telefona";
            // 
            // txtBrojTelefona
            // 
            this.txtBrojTelefona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBrojTelefona.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBrojTelefona.Depth = 0;
            this.txtBrojTelefona.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrojTelefona.Hint = "";
            this.txtBrojTelefona.Location = new System.Drawing.Point(465, 236);
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
            // lblPol
            // 
            this.lblPol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPol.AutoSize = true;
            this.lblPol.Depth = 0;
            this.lblPol.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPol.Location = new System.Drawing.Point(187, 114);
            this.lblPol.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(31, 19);
            this.lblPol.TabIndex = 28;
            this.lblPol.Text = "Pol";
            // 
            // lblJmbg
            // 
            this.lblJmbg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Depth = 0;
            this.lblJmbg.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblJmbg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblJmbg.Location = new System.Drawing.Point(474, 114);
            this.lblJmbg.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(49, 19);
            this.lblJmbg.TabIndex = 26;
            this.lblJmbg.Text = "JMBG";
            // 
            // txtJmbg
            // 
            this.txtJmbg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtJmbg.Depth = 0;
            this.txtJmbg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJmbg.Hint = "";
            this.txtJmbg.Location = new System.Drawing.Point(465, 148);
            this.txtJmbg.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.PasswordChar = '\0';
            this.txtJmbg.SelectedText = "";
            this.txtJmbg.SelectionLength = 0;
            this.txtJmbg.SelectionStart = 0;
            this.txtJmbg.Size = new System.Drawing.Size(203, 23);
            this.txtJmbg.TabIndex = 27;
            this.txtJmbg.UseSystemPasswordChar = false;
            // 
            // lblAdresa
            // 
            this.lblAdresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Depth = 0;
            this.lblAdresa.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAdresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAdresa.Location = new System.Drawing.Point(187, 202);
            this.lblAdresa.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(56, 19);
            this.lblAdresa.TabIndex = 24;
            this.lblAdresa.Text = "Adresa";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAdresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAdresa.Depth = 0;
            this.txtAdresa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdresa.Hint = "";
            this.txtAdresa.Location = new System.Drawing.Point(178, 236);
            this.txtAdresa.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.PasswordChar = '\0';
            this.txtAdresa.SelectedText = "";
            this.txtAdresa.SelectionLength = 0;
            this.txtAdresa.SelectionStart = 0;
            this.txtAdresa.Size = new System.Drawing.Size(203, 23);
            this.txtAdresa.TabIndex = 25;
            this.txtAdresa.UseSystemPasswordChar = false;
            // 
            // lblPrezime
            // 
            this.lblPrezime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Depth = 0;
            this.lblPrezime.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPrezime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPrezime.Location = new System.Drawing.Point(474, 25);
            this.lblPrezime.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(63, 19);
            this.lblPrezime.TabIndex = 22;
            this.lblPrezime.Text = "Prezime";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrezime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrezime.Depth = 0;
            this.txtPrezime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrezime.Hint = "";
            this.txtPrezime.Location = new System.Drawing.Point(465, 59);
            this.txtPrezime.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.PasswordChar = '\0';
            this.txtPrezime.SelectedText = "";
            this.txtPrezime.SelectionLength = 0;
            this.txtPrezime.SelectionStart = 0;
            this.txtPrezime.Size = new System.Drawing.Size(203, 23);
            this.txtPrezime.TabIndex = 23;
            this.txtPrezime.UseSystemPasswordChar = false;
            // 
            // lblIme
            // 
            this.lblIme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIme.AutoSize = true;
            this.lblIme.Depth = 0;
            this.lblIme.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblIme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblIme.Location = new System.Drawing.Point(187, 25);
            this.lblIme.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(34, 19);
            this.lblIme.TabIndex = 18;
            this.lblIme.Text = "Ime";
            // 
            // txtIme
            // 
            this.txtIme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtIme.Depth = 0;
            this.txtIme.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIme.Hint = "";
            this.txtIme.Location = new System.Drawing.Point(178, 59);
            this.txtIme.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIme.Name = "txtIme";
            this.txtIme.PasswordChar = '\0';
            this.txtIme.SelectedText = "";
            this.txtIme.SelectionLength = 0;
            this.txtIme.SelectionStart = 0;
            this.txtIme.Size = new System.Drawing.Size(203, 23);
            this.txtIme.TabIndex = 21;
            this.txtIme.UseSystemPasswordChar = false;
            // 
            // tabSigurnost
            // 
            this.tabSigurnost.Location = new System.Drawing.Point(4, 22);
            this.tabSigurnost.Name = "tabSigurnost";
            this.tabSigurnost.Padding = new System.Windows.Forms.Padding(3);
            this.tabSigurnost.Size = new System.Drawing.Size(829, 438);
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
            this.tabSelector.Size = new System.Drawing.Size(837, 37);
            this.tabSelector.TabIndex = 4;
            this.tabSelector.Text = "materialTabSelector1";
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.tabUserProfile);
            this.pnlTabs.Controls.Add(this.tabSelector);
            this.pnlTabs.Location = new System.Drawing.Point(322, 81);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(837, 501);
            this.pnlTabs.TabIndex = 5;
            // 
            // verticalDivider
            // 
            this.verticalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.verticalDivider.Depth = 0;
            this.verticalDivider.Location = new System.Drawing.Point(284, 153);
            this.verticalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.verticalDivider.Name = "verticalDivider";
            this.verticalDivider.Size = new System.Drawing.Size(1, 425);
            this.verticalDivider.TabIndex = 7;
            this.verticalDivider.Text = "materialDivider1";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreated.Location = new System.Drawing.Point(74, 478);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(104, 21);
            this.lblDateCreated.TabIndex = 11;
            this.lblDateCreated.Text = "Date created";
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.AutoSize = true;
            this.txtDateCreated.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateCreated.Location = new System.Drawing.Point(93, 511);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Padding = new System.Windows.Forms.Padding(2);
            this.txtDateCreated.Size = new System.Drawing.Size(86, 25);
            this.txtDateCreated.TabIndex = 10;
            this.txtDateCreated.Text = "01/01/2009";
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(60, 362);
            this.horizontalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(200, 1);
            this.horizontalDivider.TabIndex = 12;
            this.horizontalDivider.Text = "materialDivider1";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(74, 383);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(53, 21);
            this.lblRole.TabIndex = 14;
            this.lblRole.Text = "Uloga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 416);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Doktor";
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.AutoSize = true;
            this.lblUserProfile.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblUserProfile.Location = new System.Drawing.Point(49, 5);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Padding = new System.Windows.Forms.Padding(2);
            this.lblUserProfile.Size = new System.Drawing.Size(243, 49);
            this.lblUserProfile.TabIndex = 15;
            this.lblUserProfile.Text = "Korisnički profil";
            // 
            // topDivider
            // 
            this.topDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.topDivider.Depth = 0;
            this.topDivider.Location = new System.Drawing.Point(32, 59);
            this.topDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.topDivider.Name = "topDivider";
            this.topDivider.Size = new System.Drawing.Size(1144, 1);
            this.topDivider.TabIndex = 16;
            this.topDivider.Text = "materialDivider1";
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("circularPictureBox1.Image")));
            this.circularPictureBox1.Location = new System.Drawing.Point(60, 81);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(200, 200);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circularPictureBox1.TabIndex = 0;
            this.circularPictureBox1.TabStop = false;
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // frmUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 630);
            this.Controls.Add(this.topDivider);
            this.Controls.Add(this.lblUserProfile);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.txtDateCreated);
            this.Controls.Add(this.verticalDivider);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.lblFirstLastName);
            this.Controls.Add(this.circularPictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserProfile";
            this.Text = "Korisnički profil";
            this.Load += new System.EventHandler(this.frmUserProfile_Load);
            this.tabUserProfile.ResumeLayout(false);
            this.tabLicniPodaci.ResumeLayout(false);
            this.tabLicniPodaci.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Helpers.CustomElements.CircularPictureBox circularPictureBox1;
        private System.Windows.Forms.Label lblFirstLastName;
        private MaterialSkin.Controls.MaterialTabControl tabUserProfile;
        private System.Windows.Forms.TabPage tabLicniPodaci;
        private System.Windows.Forms.TabPage tabSigurnost;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private System.Windows.Forms.Panel pnlTabs;
        private MaterialSkin.Controls.MaterialDivider verticalDivider;
        private MaterialSkin.Controls.MaterialLabel lblPrezime;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrezime;
        private MaterialSkin.Controls.MaterialLabel lblIme;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIme;
        private MaterialSkin.Controls.MaterialLabel lblBrojTelefona;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBrojTelefona;
        private MaterialSkin.Controls.MaterialLabel lblPol;
        private MaterialSkin.Controls.MaterialLabel lblJmbg;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtJmbg;
        private MaterialSkin.Controls.MaterialLabel lblAdresa;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAdresa;
        private Helpers.CustomElements.Button_WOC btnSave;
        private MaterialSkin.Controls.MaterialLabel lblEmailAddress;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label txtDateCreated;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserProfile;
        private MaterialSkin.Controls.MaterialDivider topDivider;
        private System.Windows.Forms.ComboBox cmbGradovi;
        private System.Windows.Forms.ComboBox cmbPolovi;
        private MaterialSkin.Controls.MaterialLabel lblGrad;
        private System.Windows.Forms.ErrorProvider Errors;
    }
}