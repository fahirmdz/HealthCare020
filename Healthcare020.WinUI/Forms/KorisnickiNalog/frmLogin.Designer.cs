using Healthcare020.WinUI.Helpers.CustomElements;
using Healthcare020.WinUI.Properties;

namespace Healthcare020.WinUI.Forms.KorisnickiNalog
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnLogin = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cbxRememberMe = new MaterialSkin.Controls.MaterialCheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlCopyright = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCopyright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.btnLogin);
            this.pnlBody.Controls.Add(this.picLogo);
            this.pnlBody.Controls.Add(this.lblUsername);
            this.pnlBody.Controls.Add(this.cbxRememberMe);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.txtUsername);
            this.pnlBody.Location = new System.Drawing.Point(264, 25);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(516, 494);
            this.pnlBody.TabIndex = 19;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(121, 414);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnLogin.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogin.Size = new System.Drawing.Size(267, 37);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "Log In";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(148, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 187);
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.DimGray;
            this.lblUsername.Location = new System.Drawing.Point(118, 268);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(69, 17);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Username";
            // 
            // cbxRememberMe
            // 
            this.cbxRememberMe.AutoSize = true;
            this.cbxRememberMe.Depth = 0;
            this.cbxRememberMe.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbxRememberMe.Location = new System.Drawing.Point(121, 356);
            this.cbxRememberMe.Margin = new System.Windows.Forms.Padding(0);
            this.cbxRememberMe.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbxRememberMe.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbxRememberMe.Name = "cbxRememberMe";
            this.cbxRememberMe.Ripple = true;
            this.cbxRememberMe.Size = new System.Drawing.Size(104, 30);
            this.cbxRememberMe.TabIndex = 18;
            this.cbxRememberMe.Text = "Zapamti me";
            this.cbxRememberMe.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.DimGray;
            this.lblPassword.Location = new System.Drawing.Point(120, 317);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 17);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Depth = 0;
            this.txtPassword.Hint = "";
            this.txtPassword.Location = new System.Drawing.Point(205, 317);
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(156, 23);
            this.txtPassword.TabIndex = 17;
            this.txtPassword.UseSystemPasswordChar = false;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress_1);
            // 
            // txtUsername
            // 
            this.txtUsername.Depth = 0;
            this.txtUsername.Hint = "";
            this.txtUsername.Location = new System.Drawing.Point(205, 268);
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(156, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(996, 298);
            this.pnlTop.TabIndex = 20;
            // 
            // pnlCopyright
            // 
            this.pnlCopyright.BackColor = System.Drawing.Color.Transparent;
            this.pnlCopyright.Controls.Add(this.lblCopyright);
            this.pnlCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCopyright.Location = new System.Drawing.Point(0, 523);
            this.pnlCopyright.Name = "pnlCopyright";
            this.pnlCopyright.Size = new System.Drawing.Size(996, 23);
            this.pnlCopyright.TabIndex = 21;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCopyright.Location = new System.Drawing.Point(398, 1);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(195, 13);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text=Resources.CopyrightText;
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(996, 546);
            this.ControlBox = false;
            this.Controls.Add(this.pnlCopyright);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.Resize += new System.EventHandler(this.frmLogin_Resize);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCopyright.ResumeLayout(false);
            this.pnlCopyright.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblUsername;
        private MaterialSkin.Controls.MaterialCheckBox cbxRememberMe;
        private System.Windows.Forms.Label lblPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCopyright;
        private System.Windows.Forms.Label lblCopyright;
        private Button_WOC btnLogin;
        private System.Windows.Forms.ErrorProvider Errors;
    }
}