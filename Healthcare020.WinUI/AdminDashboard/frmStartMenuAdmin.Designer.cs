namespace Healthcare020.WinUI.AdminDashboard
{
    partial class frmStartMenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartMenuAdmin));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnStatistics = new FontAwesome.Sharp.IconButton();
            this.btnPredefinedData = new FontAwesome.Sharp.IconButton();
            this.btnSecurity = new FontAwesome.Sharp.IconButton();
            this.btnUsers = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnUserMenu = new Healthcare020.WinUI.CustomElements.UserMenuButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlUserMenuDropdown = new Healthcare020.WinUI.CustomElements.UserMenuDropdownPanel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.panelMenu.Controls.Add(this.btnStatistics);
            this.panelMenu.Controls.Add(this.btnPredefinedData);
            this.panelMenu.Controls.Add(this.btnSecurity);
            this.panelMenu.Controls.Add(this.btnUsers);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 546);
            this.panelMenu.TabIndex = 0;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnStatistics.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.White;
            this.btnStatistics.IconChar = FontAwesome.Sharp.IconChar.ChartPie;
            this.btnStatistics.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnStatistics.IconSize = 32;
            this.btnStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.Location = new System.Drawing.Point(0, 379);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnStatistics.Rotation = 0D;
            this.btnStatistics.Size = new System.Drawing.Size(220, 60);
            this.btnStatistics.TabIndex = 4;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnPredefinedData
            // 
            this.btnPredefinedData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPredefinedData.FlatAppearance.BorderSize = 0;
            this.btnPredefinedData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPredefinedData.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPredefinedData.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPredefinedData.ForeColor = System.Drawing.Color.White;
            this.btnPredefinedData.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnPredefinedData.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnPredefinedData.IconSize = 32;
            this.btnPredefinedData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPredefinedData.Location = new System.Drawing.Point(0, 319);
            this.btnPredefinedData.Name = "btnPredefinedData";
            this.btnPredefinedData.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnPredefinedData.Rotation = 0D;
            this.btnPredefinedData.Size = new System.Drawing.Size(220, 60);
            this.btnPredefinedData.TabIndex = 3;
            this.btnPredefinedData.Text = "Predefined data";
            this.btnPredefinedData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPredefinedData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPredefinedData.UseVisualStyleBackColor = true;
            this.btnPredefinedData.Click += new System.EventHandler(this.btnPredefinedData_Click);
            // 
            // btnSecurity
            // 
            this.btnSecurity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSecurity.FlatAppearance.BorderSize = 0;
            this.btnSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecurity.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSecurity.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecurity.ForeColor = System.Drawing.Color.White;
            this.btnSecurity.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.btnSecurity.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnSecurity.IconSize = 32;
            this.btnSecurity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecurity.Location = new System.Drawing.Point(0, 259);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnSecurity.Rotation = 0D;
            this.btnSecurity.Size = new System.Drawing.Size(220, 60);
            this.btnSecurity.TabIndex = 2;
            this.btnSecurity.Text = "Security";
            this.btnSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecurity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSecurity.UseVisualStyleBackColor = true;
            this.btnSecurity.Click += new System.EventHandler(this.btnSecurity_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUsers.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnUsers.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnUsers.IconSize = 32;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(0, 199);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnUsers.Rotation = 0D;
            this.btnUsers.Size = new System.Drawing.Size(220, 60);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 199);
            this.panelLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(23, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(168, 180);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pnlTop.Controls.Add(this.btnUserMenu);
            this.pnlTop.Controls.Add(this.lblTitleChildForm);
            this.pnlTop.Controls.Add(this.iconCurrentChildForm);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(220, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(776, 60);
            this.pnlTop.TabIndex = 2;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // btnUserMenu
            // 
            this.btnUserMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnUserMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.btnUserMenu.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnUserMenu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.btnUserMenu.IconSize = 44;
            this.btnUserMenu.Location = new System.Drawing.Point(720, 9);
            this.btnUserMenu.Name = "btnUserMenu";
            this.btnUserMenu.Size = new System.Drawing.Size(44, 45);
            this.btnUserMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnUserMenu.TabIndex = 2;
            this.btnUserMenu.TabStop = false;
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitleChildForm.Location = new System.Drawing.Point(55, 26);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(45, 18);
            this.lblTitleChildForm.TabIndex = 3;
            this.lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.iconCurrentChildForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(103)))), ((int)(((byte)(105)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(103)))), ((int)(((byte)(105)))));
            this.iconCurrentChildForm.IconSize = 37;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(17, 12);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.pnlUserMenuDropdown);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(220, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(776, 486);
            this.pnlBody.TabIndex = 3;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // pnlUserMenuDropdown
            // 
            this.pnlUserMenuDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserMenuDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pnlUserMenuDropdown.Location = new System.Drawing.Point(576, 0);
            this.pnlUserMenuDropdown.Name = "pnlUserMenuDropdown";
            this.pnlUserMenuDropdown.Size = new System.Drawing.Size(200, 100);
            this.pnlUserMenuDropdown.TabIndex = 0;
            this.pnlUserMenuDropdown.Toggler = this.btnUserMenu;
            this.pnlUserMenuDropdown.Visible = false;
            // 
            // frmStartMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(996, 546);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.panelMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStartMenuAdmin";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmStartMenuAdmin_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnStatistics;
        private FontAwesome.Sharp.IconButton btnPredefinedData;
        private FontAwesome.Sharp.IconButton btnSecurity;
        private FontAwesome.Sharp.IconButton btnUsers;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel pnlTop;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel pnlBody;
        private CustomElements.UserMenuButton btnUserMenu;
        private CustomElements.UserMenuDropdownPanel pnlUserMenuDropdown;
    }
}