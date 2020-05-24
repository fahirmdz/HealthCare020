namespace Healthcare020.WinUI.AdminDashboard
{
    partial class frmNewUser
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
            this.cmbVrstaRadnika = new System.Windows.Forms.ComboBox();
            this.lblVrstaRadnika = new MaterialSkin.Controls.MaterialLabel();
            this.lblImePrezimeOdeljenje = new MaterialSkin.Controls.MaterialLabel();
            this.cmbImePrezime = new System.Windows.Forms.ComboBox();
            this.lblUsername = new MaterialSkin.Controls.MaterialLabel();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblPassword = new MaterialSkin.Controls.MaterialLabel();
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtConfirmPassword = new MaterialSkin.Controls.MaterialLabel();
            this.ckbxAdmin = new MaterialSkin.Controls.MaterialCheckBox();
            this.lblRoles = new MaterialSkin.Controls.MaterialLabel();
            this.ckbxDoktor = new MaterialSkin.Controls.MaterialCheckBox();
            this.ckbxMedicinskiTehnicar = new MaterialSkin.Controls.MaterialCheckBox();
            this.ckbxRadnikPrijem = new MaterialSkin.Controls.MaterialCheckBox();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errors)).BeginInit();
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
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Rotation = 0D;
            this.btnBack.Size = new System.Drawing.Size(88, 34);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cmbVrstaRadnika
            // 
            this.cmbVrstaRadnika.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVrstaRadnika.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVrstaRadnika.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbVrstaRadnika.FormattingEnabled = true;
            this.cmbVrstaRadnika.Location = new System.Drawing.Point(168, 91);
            this.cmbVrstaRadnika.Name = "cmbVrstaRadnika";
            this.cmbVrstaRadnika.Size = new System.Drawing.Size(178, 26);
            this.cmbVrstaRadnika.TabIndex = 1;
            this.cmbVrstaRadnika.SelectedIndexChanged += new System.EventHandler(this.cmbVrstaRadnika_SelectedIndexChanged);
            // 
            // lblVrstaRadnika
            // 
            this.lblVrstaRadnika.AutoSize = true;
            this.lblVrstaRadnika.Depth = 0;
            this.lblVrstaRadnika.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblVrstaRadnika.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVrstaRadnika.Location = new System.Drawing.Point(154, 60);
            this.lblVrstaRadnika.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblVrstaRadnika.Name = "lblVrstaRadnika";
            this.lblVrstaRadnika.Size = new System.Drawing.Size(98, 19);
            this.lblVrstaRadnika.TabIndex = 2;
            this.lblVrstaRadnika.Text = "Vrsta radnika";
            // 
            // lblImePrezimeOdeljenje
            // 
            this.lblImePrezimeOdeljenje.AutoSize = true;
            this.lblImePrezimeOdeljenje.Depth = 0;
            this.lblImePrezimeOdeljenje.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblImePrezimeOdeljenje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblImePrezimeOdeljenje.Location = new System.Drawing.Point(424, 56);
            this.lblImePrezimeOdeljenje.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblImePrezimeOdeljenje.Name = "lblImePrezimeOdeljenje";
            this.lblImePrezimeOdeljenje.Size = new System.Drawing.Size(103, 19);
            this.lblImePrezimeOdeljenje.TabIndex = 3;
            this.lblImePrezimeOdeljenje.Text = "Ime i prezime ";
            // 
            // cmbImePrezime
            // 
            this.cmbImePrezime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbImePrezime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbImePrezime.FormattingEnabled = true;
            this.cmbImePrezime.Location = new System.Drawing.Point(438, 91);
            this.cmbImePrezime.Name = "cmbImePrezime";
            this.cmbImePrezime.Size = new System.Drawing.Size(253, 26);
            this.cmbImePrezime.TabIndex = 4;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Depth = 0;
            this.lblUsername.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsername.Location = new System.Drawing.Point(154, 136);
            this.lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 19);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Hint = "";
            this.txtUsername.Location = new System.Drawing.Point(168, 170);
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(203, 23);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Depth = 0;
            this.lblPassword.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPassword.Location = new System.Drawing.Point(154, 209);
            this.lblPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 19);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Lozinka";
            // 
            // txtPassword
            // 
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Hint = "";
            this.txtPassword.Location = new System.Drawing.Point(168, 241);
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(203, 23);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(168, 312);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(203, 23);
            this.materialSingleLineTextField1.TabIndex = 10;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AutoSize = true;
            this.txtConfirmPassword.Depth = 0;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(154, 276);
            this.txtConfirmPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(112, 19);
            this.txtConfirmPassword.TabIndex = 9;
            this.txtConfirmPassword.Text = "Potvrda lozinke";
            // 
            // ckbxAdmin
            // 
            this.ckbxAdmin.AutoSize = true;
            this.ckbxAdmin.Depth = 0;
            this.ckbxAdmin.Font = new System.Drawing.Font("Roboto", 10F);
            this.ckbxAdmin.Location = new System.Drawing.Point(438, 170);
            this.ckbxAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.ckbxAdmin.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ckbxAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.ckbxAdmin.Name = "ckbxAdmin";
            this.ckbxAdmin.Ripple = true;
            this.ckbxAdmin.Size = new System.Drawing.Size(115, 30);
            this.ckbxAdmin.TabIndex = 11;
            this.ckbxAdmin.Text = "Administrator";
            this.ckbxAdmin.UseVisualStyleBackColor = true;
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Depth = 0;
            this.lblRoles.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRoles.Location = new System.Drawing.Point(424, 139);
            this.lblRoles.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(47, 19);
            this.lblRoles.TabIndex = 12;
            this.lblRoles.Text = "Roles";
            // 
            // ckbxDoktor
            // 
            this.ckbxDoktor.AutoSize = true;
            this.ckbxDoktor.Depth = 0;
            this.ckbxDoktor.Font = new System.Drawing.Font("Roboto", 10F);
            this.ckbxDoktor.Location = new System.Drawing.Point(438, 204);
            this.ckbxDoktor.Margin = new System.Windows.Forms.Padding(0);
            this.ckbxDoktor.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ckbxDoktor.MouseState = MaterialSkin.MouseState.HOVER;
            this.ckbxDoktor.Name = "ckbxDoktor";
            this.ckbxDoktor.Ripple = true;
            this.ckbxDoktor.Size = new System.Drawing.Size(71, 30);
            this.ckbxDoktor.TabIndex = 13;
            this.ckbxDoktor.Text = "Doktor";
            this.ckbxDoktor.UseVisualStyleBackColor = true;
            // 
            // ckbxMedicinskiTehnicar
            // 
            this.ckbxMedicinskiTehnicar.AutoSize = true;
            this.ckbxMedicinskiTehnicar.Depth = 0;
            this.ckbxMedicinskiTehnicar.Font = new System.Drawing.Font("Roboto", 10F);
            this.ckbxMedicinskiTehnicar.Location = new System.Drawing.Point(438, 240);
            this.ckbxMedicinskiTehnicar.Margin = new System.Windows.Forms.Padding(0);
            this.ckbxMedicinskiTehnicar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ckbxMedicinskiTehnicar.MouseState = MaterialSkin.MouseState.HOVER;
            this.ckbxMedicinskiTehnicar.Name = "ckbxMedicinskiTehnicar";
            this.ckbxMedicinskiTehnicar.Ripple = true;
            this.ckbxMedicinskiTehnicar.Size = new System.Drawing.Size(150, 30);
            this.ckbxMedicinskiTehnicar.TabIndex = 14;
            this.ckbxMedicinskiTehnicar.Text = "Medicinski tehničar";
            this.ckbxMedicinskiTehnicar.UseVisualStyleBackColor = true;
            // 
            // ckbxRadnikPrijem
            // 
            this.ckbxRadnikPrijem.AutoSize = true;
            this.ckbxRadnikPrijem.Depth = 0;
            this.ckbxRadnikPrijem.Font = new System.Drawing.Font("Roboto", 10F);
            this.ckbxRadnikPrijem.Location = new System.Drawing.Point(438, 275);
            this.ckbxRadnikPrijem.Margin = new System.Windows.Forms.Padding(0);
            this.ckbxRadnikPrijem.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ckbxRadnikPrijem.MouseState = MaterialSkin.MouseState.HOVER;
            this.ckbxRadnikPrijem.Name = "ckbxRadnikPrijem";
            this.ckbxRadnikPrijem.Ripple = true;
            this.ckbxRadnikPrijem.Size = new System.Drawing.Size(114, 30);
            this.ckbxRadnikPrijem.TabIndex = 15;
            this.ckbxRadnikPrijem.Text = "Radnik prijem";
            this.ckbxRadnikPrijem.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(286, 388);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.btnSave.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnSave.Size = new System.Drawing.Size(212, 30);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errors
            // 
            this.errors.ContainerControl = this;
            this.errors.Icon = ((System.Drawing.Icon)(resources.GetObject("errors.Icon")));
            // 
            // frmNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 486);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ckbxRadnikPrijem);
            this.Controls.Add(this.ckbxMedicinskiTehnicar);
            this.Controls.Add(this.ckbxDoktor);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.ckbxAdmin);
            this.Controls.Add(this.materialSingleLineTextField1);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cmbImePrezime);
            this.Controls.Add(this.lblImePrezimeOdeljenje);
            this.Controls.Add(this.lblVrstaRadnika);
            this.Controls.Add(this.cmbVrstaRadnika);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewUser";
            this.Text = "frmNewUser";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBack;
        private System.Windows.Forms.ComboBox cmbVrstaRadnika;
        private MaterialSkin.Controls.MaterialLabel lblVrstaRadnika;
        private MaterialSkin.Controls.MaterialLabel lblImePrezimeOdeljenje;
        private System.Windows.Forms.ComboBox cmbImePrezime;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private MaterialSkin.Controls.MaterialLabel txtConfirmPassword;
        private MaterialSkin.Controls.MaterialCheckBox ckbxAdmin;
        private MaterialSkin.Controls.MaterialLabel lblRoles;
        private MaterialSkin.Controls.MaterialCheckBox ckbxDoktor;
        private MaterialSkin.Controls.MaterialCheckBox ckbxMedicinskiTehnicar;
        private MaterialSkin.Controls.MaterialCheckBox ckbxRadnikPrijem;
        private Helpers.CustomElements.Button_WOC btnSave;
        private System.Windows.Forms.ErrorProvider errors;
    }
}