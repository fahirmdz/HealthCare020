namespace Healthcare020.WinUI.Forms.AdminDashboard
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
            this.lblImePrezimeOdeljenje = new MaterialSkin.Controls.MaterialLabel();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblPassword = new MaterialSkin.Controls.MaterialLabel();
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtConfirmPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblConfirmPassword = new MaterialSkin.Controls.MaterialLabel();
            this.lblRoles = new MaterialSkin.Controls.MaterialLabel();
            this.errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUsername = new MaterialSkin.Controls.MaterialLabel();
            this.txtImePrezime = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rbtnAdmin = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnDoktor = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnMedTehnicar = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbtnRadnikPrijem = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.pnlBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errors)).BeginInit();
            this.pnlBody.SuspendLayout();
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
            this.btnBack.Location = new System.Drawing.Point(17, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Rotation = 0D;
            this.btnBack.Size = new System.Drawing.Size(88, 34);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblImePrezimeOdeljenje
            // 
            this.lblImePrezimeOdeljenje.AutoSize = true;
            this.lblImePrezimeOdeljenje.Depth = 0;
            this.lblImePrezimeOdeljenje.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblImePrezimeOdeljenje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblImePrezimeOdeljenje.Location = new System.Drawing.Point(458, 102);
            this.lblImePrezimeOdeljenje.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblImePrezimeOdeljenje.Name = "lblImePrezimeOdeljenje";
            this.lblImePrezimeOdeljenje.Size = new System.Drawing.Size(103, 19);
            this.lblImePrezimeOdeljenje.TabIndex = 3;
            this.lblImePrezimeOdeljenje.Text = "Ime i prezime ";
            // 
            // txtUsername
            // 
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Hint = "";
            this.txtUsername.Location = new System.Drawing.Point(169, 136);
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
            this.lblPassword.Location = new System.Drawing.Point(155, 177);
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
            this.txtPassword.Location = new System.Drawing.Point(169, 209);
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(203, 23);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = false;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Depth = 0;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Hint = "";
            this.txtConfirmPassword.Location = new System.Drawing.Point(169, 280);
            this.txtConfirmPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.SelectionLength = 0;
            this.txtConfirmPassword.SelectionStart = 0;
            this.txtConfirmPassword.Size = new System.Drawing.Size(203, 23);
            this.txtConfirmPassword.TabIndex = 10;
            this.txtConfirmPassword.UseSystemPasswordChar = false;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Depth = 0;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(155, 244);
            this.lblConfirmPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(112, 19);
            this.lblConfirmPassword.TabIndex = 9;
            this.lblConfirmPassword.Text = "Potvrda lozinke";
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Depth = 0;
            this.lblRoles.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRoles.Location = new System.Drawing.Point(459, 172);
            this.lblRoles.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.Size = new System.Drawing.Size(47, 19);
            this.lblRoles.TabIndex = 12;
            this.lblRoles.Text = "Roles";
            // 
            // errors
            // 
            this.errors.ContainerControl = this;
            this.errors.Icon = ((System.Drawing.Icon)(resources.GetObject("errors.Icon")));
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Depth = 0;
            this.lblUsername.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsername.Location = new System.Drawing.Point(155, 102);
            this.lblUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 19);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username";
            // 
            // txtImePrezime
            // 
            this.txtImePrezime.Depth = 0;
            this.txtImePrezime.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImePrezime.Hint = "";
            this.txtImePrezime.Location = new System.Drawing.Point(449, 136);
            this.txtImePrezime.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtImePrezime.Name = "txtImePrezime";
            this.txtImePrezime.PasswordChar = '\0';
            this.txtImePrezime.SelectedText = "";
            this.txtImePrezime.SelectionLength = 0;
            this.txtImePrezime.SelectionStart = 0;
            this.txtImePrezime.Size = new System.Drawing.Size(203, 23);
            this.txtImePrezime.TabIndex = 17;
            this.txtImePrezime.UseSystemPasswordChar = false;
            // 
            // rbtnAdmin
            // 
            this.rbtnAdmin.AccessibleName = "Administrator";
            this.rbtnAdmin.AutoSize = true;
            this.rbtnAdmin.Depth = 0;
            this.rbtnAdmin.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnAdmin.Location = new System.Drawing.Point(473, 209);
            this.rbtnAdmin.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnAdmin.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnAdmin.Name = "rbtnAdmin";
            this.rbtnAdmin.Ripple = true;
            this.rbtnAdmin.Size = new System.Drawing.Size(114, 30);
            this.rbtnAdmin.TabIndex = 18;
            this.rbtnAdmin.Text = "Administrator";
            this.rbtnAdmin.UseVisualStyleBackColor = true;
            // 
            // rbtnDoktor
            // 
            this.rbtnDoktor.AccessibleName = "Doktor";
            this.rbtnDoktor.AutoSize = true;
            this.rbtnDoktor.Depth = 0;
            this.rbtnDoktor.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnDoktor.Location = new System.Drawing.Point(473, 244);
            this.rbtnDoktor.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnDoktor.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnDoktor.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnDoktor.Name = "rbtnDoktor";
            this.rbtnDoktor.Ripple = true;
            this.rbtnDoktor.Size = new System.Drawing.Size(70, 30);
            this.rbtnDoktor.TabIndex = 19;
            this.rbtnDoktor.Text = "Doktor";
            this.rbtnDoktor.UseVisualStyleBackColor = true;
            // 
            // rbtnMedTehnicar
            // 
            this.rbtnMedTehnicar.AccessibleName = "MedicinskiTehnicar";
            this.rbtnMedTehnicar.AutoSize = true;
            this.rbtnMedTehnicar.Depth = 0;
            this.rbtnMedTehnicar.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnMedTehnicar.Location = new System.Drawing.Point(473, 280);
            this.rbtnMedTehnicar.Margin = new System.Windows.Forms.Padding(0);
            this.rbtnMedTehnicar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbtnMedTehnicar.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbtnMedTehnicar.Name = "rbtnMedTehnicar";
            this.rbtnMedTehnicar.Ripple = true;
            this.rbtnMedTehnicar.Size = new System.Drawing.Size(149, 30);
            this.rbtnMedTehnicar.TabIndex = 20;
            this.rbtnMedTehnicar.Text = "Medicinski tehničar";
            this.rbtnMedTehnicar.UseVisualStyleBackColor = true;
            // 
            // rbtnRadnikPrijem
            // 
            this.rbtnRadnikPrijem.AccessibleName = "RadnikPrijem";
            this.rbtnRadnikPrijem.AutoSize = true;
            this.rbtnRadnikPrijem.Checked = true;
            this.rbtnRadnikPrijem.Depth = 0;
            this.rbtnRadnikPrijem.Font = new System.Drawing.Font("Roboto", 10F);
            this.rbtnRadnikPrijem.Location = new System.Drawing.Point(473, 319);
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
            // 
            // btnSave
            // 
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(291, 398);
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
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.txtUsername);
            this.pnlBody.Controls.Add(this.rbtnRadnikPrijem);
            this.pnlBody.Controls.Add(this.btnBack);
            this.pnlBody.Controls.Add(this.rbtnMedTehnicar);
            this.pnlBody.Controls.Add(this.lblImePrezimeOdeljenje);
            this.pnlBody.Controls.Add(this.rbtnDoktor);
            this.pnlBody.Controls.Add(this.lblUsername);
            this.pnlBody.Controls.Add(this.rbtnAdmin);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.txtImePrezime);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.btnSave);
            this.pnlBody.Controls.Add(this.lblConfirmPassword);
            this.pnlBody.Controls.Add(this.lblRoles);
            this.pnlBody.Controls.Add(this.txtConfirmPassword);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(776, 522);
            this.pnlBody.TabIndex = 22;
            // 
            // frmNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 522);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewUser";
            this.Text = "frmNewUser";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmNewUser_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.errors)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBack;
        private MaterialSkin.Controls.MaterialLabel lblImePrezimeOdeljenje;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private MaterialSkin.Controls.MaterialLabel lblPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtConfirmPassword;
        private MaterialSkin.Controls.MaterialLabel lblConfirmPassword;
        private MaterialSkin.Controls.MaterialLabel lblRoles;
        private Helpers.CustomElements.Button_WOC btnSave;
        private System.Windows.Forms.ErrorProvider errors;
        private MaterialSkin.Controls.MaterialRadioButton rbtnRadnikPrijem;
        private MaterialSkin.Controls.MaterialRadioButton rbtnMedTehnicar;
        private MaterialSkin.Controls.MaterialRadioButton rbtnDoktor;
        private MaterialSkin.Controls.MaterialRadioButton rbtnAdmin;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtImePrezime;
        private MaterialSkin.Controls.MaterialLabel lblUsername;
        private System.Windows.Forms.Panel pnlBody;
    }
}