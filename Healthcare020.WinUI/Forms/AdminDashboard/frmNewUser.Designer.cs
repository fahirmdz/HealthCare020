namespace Healthcare020.WinUI.Forms.AdminDashboard
{
    sealed partial class frmNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewUser));
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblPassword = new MaterialSkin.Controls.MaterialLabel();
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtConfirmPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblConfirmPassword = new MaterialSkin.Controls.MaterialLabel();
            this.lblRoles = new MaterialSkin.Controls.MaterialLabel();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUsername = new MaterialSkin.Controls.MaterialLabel();
            this.rbtnAdministrator = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnDoktor = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnMedTehnicar = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnRadnikPrijem = new MaterialSkin.Controls.MaterialRadioButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblNaucnaOblast = new System.Windows.Forms.Label();
            this.cmbPolovi = new System.Windows.Forms.ComboBox();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbNaucneOblasti = new System.Windows.Forms.ComboBox();
            this.lblStacionarnoOdeljenje = new System.Windows.Forms.Label();
            this.cmbStacionarnaOdeljenja = new System.Windows.Forms.ComboBox();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbDrzave = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.cmbGradovi = new System.Windows.Forms.ComboBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBrojTelefona = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtJmbg = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtAdresa = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPrezime = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtIme = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnBack.IconSize = 25;
            this.btnBack.Location = new System.Drawing.Point(14, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Rotation = 0D;
            this.btnBack.Size = new System.Drawing.Size(88, 34);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Hint = "";
            this.txtUsername.Location = new System.Drawing.Point(412, 372);
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(239, 23);
            this.txtUsername.TabIndex = 10;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Depth = 0;
            this.lblPassword.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPassword.Location = new System.Drawing.Point(68, 424);
            this.lblPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 19);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Lozinka";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Hint = "";
            this.txtPassword.Location = new System.Drawing.Point(71, 456);
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(203, 23);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.UseSystemPasswordChar = false;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPassword.Depth = 0;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Hint = "";
            this.txtConfirmPassword.Location = new System.Drawing.Point(412, 456);
            this.txtConfirmPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.SelectionLength = 0;
            this.txtConfirmPassword.SelectionStart = 0;
            this.txtConfirmPassword.Size = new System.Drawing.Size(239, 23);
            this.txtConfirmPassword.TabIndex = 12;
            this.txtConfirmPassword.UseSystemPasswordChar = false;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Depth = 0;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(409, 424);
            this.lblConfirmPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(112, 19);
            this.lblConfirmPassword.TabIndex = 9;
            this.lblConfirmPassword.Text = "Potvrda lozinke";
            // 
            // lblRoles
            // 
            this.lblRoles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRoles.AutoSize = true;
            this.lblRoles.Depth = 0;
            this.lblRoles.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRoles.Location = new System.Drawing.Point(741, 5);
            this.lblRoles.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(39, 19);
            this.lblRoles.TabIndex = 12;
            this.lblRoles.Text = "Role";
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Depth = 0;
            this.lblUsername.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsername.Location = new System.Drawing.Point(409, 341);
            this.lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 19);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username";
            // 
            // rbtnAdministrator
            // 
            this.rbtnAdministrator.AccessibleName = "Administratoristrator";
            this.rbtnAdministrator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnAdministrator.AutoSize = true;
            this.rbtnAdministrator.Depth = 0;
            this.rbtnAdministrator.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnAdministrator.Location = new System.Drawing.Point(735, 42);
            this.rbtnAdministrator.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnAdministrator.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnAdministrator.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnAdministrator.Name = "rbtnAdministrator";
            this.rbtnAdministrator.Ripple = true;
            this.rbtnAdministrator.Size = new System.Drawing.Size(158, 30);
            this.rbtnAdministrator.TabIndex = 18;
            this.rbtnAdministrator.Text = "Administratoristrator";
            this.rbtnAdministrator.UseVisualStyleBackColor = true;
            this.rbtnAdministrator.CheckedChanged += new System.EventHandler(this.rbtnAdministrator_CheckedChanged);
            // 
            // rbtnDoktor
            // 
            this.rbtnDoktor.AccessibleName = "Doktor";
            this.rbtnDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnDoktor.AutoSize = true;
            this.rbtnDoktor.Depth = 0;
            this.rbtnDoktor.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnDoktor.Location = new System.Drawing.Point(735, 77);
            this.rbtnDoktor.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnDoktor.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnDoktor.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnDoktor.Name = "rbtnDoktor";
            this.rbtnDoktor.Ripple = true;
            this.rbtnDoktor.Size = new System.Drawing.Size(70, 30);
            this.rbtnDoktor.TabIndex = 19;
            this.rbtnDoktor.Text = "Doktor";
            this.rbtnDoktor.UseVisualStyleBackColor = true;
            this.rbtnDoktor.CheckedChanged += new System.EventHandler(this.rbtnDoktor_CheckedChanged);
            // 
            // rbtnMedTehnicar
            // 
            this.rbtnMedTehnicar.AccessibleName = "MedicinskiTehnicar";
            this.rbtnMedTehnicar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnMedTehnicar.AutoSize = true;
            this.rbtnMedTehnicar.Depth = 0;
            this.rbtnMedTehnicar.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnMedTehnicar.Location = new System.Drawing.Point(735, 113);
            this.rbtnMedTehnicar.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnMedTehnicar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnMedTehnicar.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnMedTehnicar.Name = "rbtnMedTehnicar";
            this.rbtnMedTehnicar.Ripple = true;
            this.rbtnMedTehnicar.Size = new System.Drawing.Size(149, 30);
            this.rbtnMedTehnicar.TabIndex = 20;
            this.rbtnMedTehnicar.Text = "Medicinski tehničar";
            this.rbtnMedTehnicar.UseVisualStyleBackColor = true;
            this.rbtnMedTehnicar.CheckedChanged += new System.EventHandler(this.rbtnMedTehnicar_CheckedChanged);
            // 
            // rbtnRadnikPrijem
            // 
            this.rbtnRadnikPrijem.AccessibleName = "RadnikPrijem";
            this.rbtnRadnikPrijem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbtnRadnikPrijem.AutoSize = true;
            this.rbtnRadnikPrijem.Checked = true;
            this.rbtnRadnikPrijem.Depth = 0;
            this.rbtnRadnikPrijem.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnRadnikPrijem.Location = new System.Drawing.Point(735, 152);
            this.rbtnRadnikPrijem.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnRadnikPrijem.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnRadnikPrijem.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnRadnikPrijem.Name = "rbtnRadnikPrijem";
            this.rbtnRadnikPrijem.Ripple = true;
            this.rbtnRadnikPrijem.Size = new System.Drawing.Size(139, 30);
            this.rbtnRadnikPrijem.TabIndex = 21;
            this.rbtnRadnikPrijem.TabStop = true;
            this.rbtnRadnikPrijem.Text = "Radnik na prijemu";
            this.rbtnRadnikPrijem.UseVisualStyleBackColor = true;
            this.rbtnRadnikPrijem.CheckedChanged += new System.EventHandler(this.rbtnRadnikPrijem_CheckedChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnBack);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1004, 70);
            this.pnlTop.TabIndex = 22;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMain.Controls.Add(this.lblNaucnaOblast);
            this.pnlMain.Controls.Add(this.cmbPolovi);
            this.pnlMain.Controls.Add(this.lblJmbg);
            this.pnlMain.Controls.Add(this.lblGender);
            this.pnlMain.Controls.Add(this.cmbNaucneOblasti);
            this.pnlMain.Controls.Add(this.lblStacionarnoOdeljenje);
            this.pnlMain.Controls.Add(this.cmbStacionarnaOdeljenja);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.lblCountry);
            this.pnlMain.Controls.Add(this.cmbDrzave);
            this.pnlMain.Controls.Add(this.lblCity);
            this.pnlMain.Controls.Add(this.lblPhoneNumber);
            this.pnlMain.Controls.Add(this.lblPrezime);
            this.pnlMain.Controls.Add(this.lblEmail);
            this.pnlMain.Controls.Add(this.lblAddress);
            this.pnlMain.Controls.Add(this.lblIme);
            this.pnlMain.Controls.Add(this.cmbGradovi);
            this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.txtBrojTelefona);
            this.pnlMain.Controls.Add(this.txtJmbg);
            this.pnlMain.Controls.Add(this.txtAdresa);
            this.pnlMain.Controls.Add(this.txtPrezime);
            this.pnlMain.Controls.Add(this.txtIme);
            this.pnlMain.Controls.Add(this.txtUsername);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.rbtnRadnikPrijem);
            this.pnlMain.Controls.Add(this.lblPassword);
            this.pnlMain.Controls.Add(this.lblConfirmPassword);
            this.pnlMain.Controls.Add(this.rbtnMedTehnicar);
            this.pnlMain.Controls.Add(this.lblUsername);
            this.pnlMain.Controls.Add(this.txtConfirmPassword);
            this.pnlMain.Controls.Add(this.rbtnAdministrator);
            this.pnlMain.Controls.Add(this.rbtnDoktor);
            this.pnlMain.Controls.Add(this.lblRoles);
            this.pnlMain.Location = new System.Drawing.Point(0, 67);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1004, 517);
            this.pnlMain.TabIndex = 23;
            // 
            // lblNaucnaOblast
            // 
            this.lblNaucnaOblast.AutoSize = true;
            this.lblNaucnaOblast.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaucnaOblast.Location = new System.Drawing.Point(732, 322);
            this.lblNaucnaOblast.Name = "lblNaucnaOblast";
            this.lblNaucnaOblast.Size = new System.Drawing.Size(109, 21);
            this.lblNaucnaOblast.TabIndex = 70;
            this.lblNaucnaOblast.Text = "Naučna oblast";
            // 
            // cmbPolovi
            // 
            this.cmbPolovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPolovi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPolovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPolovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPolovi.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbPolovi.FormattingEnabled = true;
            this.cmbPolovi.Location = new System.Drawing.Point(412, 113);
            this.cmbPolovi.Name = "cmbPolovi";
            this.cmbPolovi.Size = new System.Drawing.Size(239, 31);
            this.cmbPolovi.TabIndex = 4;
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJmbg.Location = new System.Drawing.Point(67, 83);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(50, 21);
            this.lblJmbg.TabIndex = 61;
            this.lblJmbg.Text = "JMBG";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(408, 83);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(31, 21);
            this.lblGender.TabIndex = 57;
            this.lblGender.Text = "Pol";
            // 
            // cmbNaucneOblasti
            // 
            this.cmbNaucneOblasti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbNaucneOblasti.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbNaucneOblasti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNaucneOblasti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNaucneOblasti.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbNaucneOblasti.FormattingEnabled = true;
            this.cmbNaucneOblasti.Location = new System.Drawing.Point(735, 364);
            this.cmbNaucneOblasti.Name = "cmbNaucneOblasti";
            this.cmbNaucneOblasti.Size = new System.Drawing.Size(207, 31);
            this.cmbNaucneOblasti.TabIndex = 14;
            // 
            // lblStacionarnoOdeljenje
            // 
            this.lblStacionarnoOdeljenje.AutoSize = true;
            this.lblStacionarnoOdeljenje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStacionarnoOdeljenje.Location = new System.Drawing.Point(731, 240);
            this.lblStacionarnoOdeljenje.Name = "lblStacionarnoOdeljenje";
            this.lblStacionarnoOdeljenje.Size = new System.Drawing.Size(159, 21);
            this.lblStacionarnoOdeljenje.TabIndex = 68;
            this.lblStacionarnoOdeljenje.Text = "Stacionarno odeljenje";
            // 
            // cmbStacionarnaOdeljenja
            // 
            this.cmbStacionarnaOdeljenja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbStacionarnaOdeljenja.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbStacionarnaOdeljenja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStacionarnaOdeljenja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStacionarnaOdeljenja.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbStacionarnaOdeljenja.FormattingEnabled = true;
            this.cmbStacionarnaOdeljenja.Location = new System.Drawing.Point(735, 266);
            this.cmbStacionarnaOdeljenja.Name = "cmbStacionarnaOdeljenja";
            this.cmbStacionarnaOdeljenja.Size = new System.Drawing.Size(207, 31);
            this.cmbStacionarnaOdeljenja.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(744, 424);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(198, 55);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(67, 246);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(58, 21);
            this.lblCountry.TabIndex = 65;
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
            this.cmbDrzave.Location = new System.Drawing.Point(71, 272);
            this.cmbDrzave.Name = "cmbDrzave";
            this.cmbDrzave.Size = new System.Drawing.Size(250, 31);
            this.cmbDrzave.TabIndex = 7;
            this.cmbDrzave.SelectionChangeCommitted += new System.EventHandler(this.cmbDrzave_SelectionChangeCommitted);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(408, 246);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(44, 21);
            this.lblCity.TabIndex = 63;
            this.lblCity.Text = "Grad";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(408, 170);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(98, 21);
            this.lblPhoneNumber.TabIndex = 62;
            this.lblPhoneNumber.Tag = "";
            this.lblPhoneNumber.Text = "Broj telefona";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezime.Location = new System.Drawing.Point(408, 8);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(66, 21);
            this.lblPrezime.TabIndex = 60;
            this.lblPrezime.Text = "Prezime";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(67, 338);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 21);
            this.lblEmail.TabIndex = 59;
            this.lblEmail.Text = "E-mail";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(67, 170);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 21);
            this.lblAddress.TabIndex = 58;
            this.lblAddress.Text = "Adresa";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIme.Location = new System.Drawing.Point(67, 8);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(36, 21);
            this.lblIme.TabIndex = 56;
            this.lblIme.Text = "Ime";
            // 
            // cmbGradovi
            // 
            this.cmbGradovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbGradovi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbGradovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGradovi.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbGradovi.FormattingEnabled = true;
            this.cmbGradovi.Location = new System.Drawing.Point(412, 272);
            this.cmbGradovi.Name = "cmbGradovi";
            this.cmbGradovi.Size = new System.Drawing.Size(239, 31);
            this.cmbGradovi.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtEmail.Hint = "";
            this.txtEmail.Location = new System.Drawing.Point(71, 372);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtBrojTelefona
            // 
            this.txtBrojTelefona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBrojTelefona.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBrojTelefona.Depth = 0;
            this.txtBrojTelefona.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtBrojTelefona.Hint = "";
            this.txtBrojTelefona.Location = new System.Drawing.Point(412, 206);
            this.txtBrojTelefona.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBrojTelefona.Name = "txtBrojTelefona";
            this.txtBrojTelefona.PasswordChar = '\0';
            this.txtBrojTelefona.SelectedText = "";
            this.txtBrojTelefona.SelectionLength = 0;
            this.txtBrojTelefona.SelectionStart = 0;
            this.txtBrojTelefona.Size = new System.Drawing.Size(239, 23);
            this.txtBrojTelefona.TabIndex = 6;
            this.txtBrojTelefona.UseSystemPasswordChar = false;
            // 
            // txtJmbg
            // 
            this.txtJmbg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtJmbg.Depth = 0;
            this.txtJmbg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJmbg.Hint = "";
            this.txtJmbg.Location = new System.Drawing.Point(71, 120);
            this.txtJmbg.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.PasswordChar = '\0';
            this.txtJmbg.SelectedText = "";
            this.txtJmbg.SelectionLength = 0;
            this.txtJmbg.SelectionStart = 0;
            this.txtJmbg.Size = new System.Drawing.Size(250, 23);
            this.txtJmbg.TabIndex = 3;
            this.txtJmbg.UseSystemPasswordChar = false;
            // 
            // txtAdresa
            // 
            this.txtAdresa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAdresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAdresa.Depth = 0;
            this.txtAdresa.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtAdresa.Hint = "";
            this.txtAdresa.Location = new System.Drawing.Point(71, 206);
            this.txtAdresa.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.PasswordChar = '\0';
            this.txtAdresa.SelectedText = "";
            this.txtAdresa.SelectionLength = 0;
            this.txtAdresa.SelectionStart = 0;
            this.txtAdresa.Size = new System.Drawing.Size(250, 23);
            this.txtAdresa.TabIndex = 5;
            this.txtAdresa.UseSystemPasswordChar = false;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrezime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrezime.Depth = 0;
            this.txtPrezime.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtPrezime.Hint = "";
            this.txtPrezime.Location = new System.Drawing.Point(412, 43);
            this.txtPrezime.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.PasswordChar = '\0';
            this.txtPrezime.SelectedText = "";
            this.txtPrezime.SelectionLength = 0;
            this.txtPrezime.SelectionStart = 0;
            this.txtPrezime.Size = new System.Drawing.Size(239, 23);
            this.txtPrezime.TabIndex = 2;
            this.txtPrezime.UseSystemPasswordChar = false;
            // 
            // txtIme
            // 
            this.txtIme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtIme.Depth = 0;
            this.txtIme.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtIme.Hint = "";
            this.txtIme.Location = new System.Drawing.Point(71, 43);
            this.txtIme.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIme.Name = "txtIme";
            this.txtIme.PasswordChar = '\0';
            this.txtIme.SelectedText = "";
            this.txtIme.SelectionLength = 0;
            this.txtIme.SelectionStart = 0;
            this.txtIme.Size = new System.Drawing.Size(250, 23);
            this.txtIme.TabIndex = 1;
            this.txtIme.UseSystemPasswordChar = false;
            // 
            // frmNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 584);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewUser";
            this.Text = "frmNewUser";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNewUser_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBack;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtConfirmPassword;
        private MaterialSkin.Controls.MaterialLabel lblConfirmPassword;
        private MaterialSkin.Controls.MaterialLabel lblRoles;
        private System.Windows.Forms.ErrorProvider Errors;
        private MaterialSkin.Controls.MaterialRadioButton rbtnRadnikPrijem;
        private MaterialSkin.Controls.MaterialRadioButton rbtnMedTehnicar;
        private MaterialSkin.Controls.MaterialRadioButton rbtnDoktor;
        private MaterialSkin.Controls.MaterialRadioButton rbtnAdministrator;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbDrzave;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.ComboBox cmbPolovi;
        private System.Windows.Forms.ComboBox cmbGradovi;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBrojTelefona;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtJmbg;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAdresa;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrezime;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIme;
        private Helpers.CustomElements.Button_WOC btnSave;
        private System.Windows.Forms.Label lblStacionarnoOdeljenje;
        private System.Windows.Forms.ComboBox cmbStacionarnaOdeljenja;
        private System.Windows.Forms.Label lblNaucnaOblast;
        private System.Windows.Forms.ComboBox cmbNaucneOblasti;
    }
}