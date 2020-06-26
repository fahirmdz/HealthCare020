namespace Healthcare020.WinUI.Forms.RadnikDashboard
{
    partial class frmMainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainDashboard));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlCopyright = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnZakazaniPregledi = new FontAwesome.Sharp.IconButton();
            this.btnPreglediNaCekanju = new FontAwesome.Sharp.IconButton();
            this.btnSviPregledi = new FontAwesome.Sharp.IconButton();
            this.btnLekarskaUverenja = new FontAwesome.Sharp.IconButton();
            this.btnUputnice = new FontAwesome.Sharp.IconButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.lblPregledi = new System.Windows.Forms.Label();
            this.lblOstalo = new System.Windows.Forms.Label();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.pnlUserMenuDropdown = new Healthcare020.WinUI.Helpers.CustomElements.UserMenuDropdownPanel();
            this.btnUserMenu = new Healthcare020.WinUI.Helpers.CustomElements.UserMenuButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlCopyright.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserMenu)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(490, 6);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(216, 216);
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pnlTop.Controls.Add(this.btnUserMenu);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1208, 42);
            this.pnlTop.TabIndex = 11;
            // 
            // pnlCopyright
            // 
            this.pnlCopyright.BackColor = System.Drawing.Color.Transparent;
            this.pnlCopyright.Controls.Add(this.lblCopyright);
            this.pnlCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCopyright.Location = new System.Drawing.Point(0, 607);
            this.pnlCopyright.Name = "pnlCopyright";
            this.pnlCopyright.Size = new System.Drawing.Size(1208, 23);
            this.pnlCopyright.TabIndex = 17;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCopyright.Location = new System.Drawing.Point(487, 1);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(199, 13);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "© 2020. Fahir Mumdžić. All rights reserved.";
            // 
            // btnZakazaniPregledi
            // 
            this.btnZakazaniPregledi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnZakazaniPregledi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZakazaniPregledi.FlatAppearance.BorderSize = 0;
            this.btnZakazaniPregledi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZakazaniPregledi.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnZakazaniPregledi.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakazaniPregledi.ForeColor = System.Drawing.Color.White;
            this.btnZakazaniPregledi.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnZakazaniPregledi.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnZakazaniPregledi.IconSize = 45;
            this.btnZakazaniPregledi.Location = new System.Drawing.Point(476, 272);
            this.btnZakazaniPregledi.Name = "btnZakazaniPregledi";
            this.btnZakazaniPregledi.Rotation = 0D;
            this.btnZakazaniPregledi.Size = new System.Drawing.Size(230, 74);
            this.btnZakazaniPregledi.TabIndex = 24;
            this.btnZakazaniPregledi.Text = "Zakazani pregledi";
            this.btnZakazaniPregledi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZakazaniPregledi.UseVisualStyleBackColor = false;
            // 
            // btnPreglediNaCekanju
            // 
            this.btnPreglediNaCekanju.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnPreglediNaCekanju.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreglediNaCekanju.FlatAppearance.BorderSize = 0;
            this.btnPreglediNaCekanju.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreglediNaCekanju.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPreglediNaCekanju.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreglediNaCekanju.ForeColor = System.Drawing.Color.White;
            this.btnPreglediNaCekanju.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.btnPreglediNaCekanju.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnPreglediNaCekanju.IconSize = 45;
            this.btnPreglediNaCekanju.Location = new System.Drawing.Point(750, 272);
            this.btnPreglediNaCekanju.Name = "btnPreglediNaCekanju";
            this.btnPreglediNaCekanju.Rotation = 0D;
            this.btnPreglediNaCekanju.Size = new System.Drawing.Size(230, 74);
            this.btnPreglediNaCekanju.TabIndex = 25;
            this.btnPreglediNaCekanju.Text = "Pregledi na čekanju";
            this.btnPreglediNaCekanju.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreglediNaCekanju.UseVisualStyleBackColor = false;
            // 
            // btnSviPregledi
            // 
            this.btnSviPregledi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnSviPregledi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSviPregledi.FlatAppearance.BorderSize = 0;
            this.btnSviPregledi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSviPregledi.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSviPregledi.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSviPregledi.ForeColor = System.Drawing.Color.White;
            this.btnSviPregledi.IconChar = FontAwesome.Sharp.IconChar.Stethoscope;
            this.btnSviPregledi.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnSviPregledi.IconSize = 45;
            this.btnSviPregledi.Location = new System.Drawing.Point(173, 272);
            this.btnSviPregledi.Name = "btnSviPregledi";
            this.btnSviPregledi.Rotation = 0D;
            this.btnSviPregledi.Size = new System.Drawing.Size(230, 74);
            this.btnSviPregledi.TabIndex = 26;
            this.btnSviPregledi.Text = "Svi pregledi";
            this.btnSviPregledi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSviPregledi.UseVisualStyleBackColor = false;
            // 
            // btnLekarskaUverenja
            // 
            this.btnLekarskaUverenja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnLekarskaUverenja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLekarskaUverenja.FlatAppearance.BorderSize = 0;
            this.btnLekarskaUverenja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLekarskaUverenja.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnLekarskaUverenja.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLekarskaUverenja.ForeColor = System.Drawing.Color.White;
            this.btnLekarskaUverenja.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.btnLekarskaUverenja.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnLekarskaUverenja.IconSize = 45;
            this.btnLekarskaUverenja.Location = new System.Drawing.Point(183, 435);
            this.btnLekarskaUverenja.Name = "btnLekarskaUverenja";
            this.btnLekarskaUverenja.Rotation = 0D;
            this.btnLekarskaUverenja.Size = new System.Drawing.Size(230, 74);
            this.btnLekarskaUverenja.TabIndex = 30;
            this.btnLekarskaUverenja.Text = "Sva lekarska uverenja";
            this.btnLekarskaUverenja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLekarskaUverenja.UseVisualStyleBackColor = false;
            // 
            // btnUputnice
            // 
            this.btnUputnice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnUputnice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUputnice.FlatAppearance.BorderSize = 0;
            this.btnUputnice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUputnice.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUputnice.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUputnice.ForeColor = System.Drawing.Color.White;
            this.btnUputnice.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.btnUputnice.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnUputnice.IconSize = 45;
            this.btnUputnice.Location = new System.Drawing.Point(486, 435);
            this.btnUputnice.Name = "btnUputnice";
            this.btnUputnice.Rotation = 0D;
            this.btnUputnice.Size = new System.Drawing.Size(230, 74);
            this.btnUputnice.TabIndex = 28;
            this.btnUputnice.Text = "Sve uputnice";
            this.btnUputnice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUputnice.UseVisualStyleBackColor = false;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.Gainsboro;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(154, 254);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(332, 1);
            this.materialDivider1.TabIndex = 32;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // lblPregledi
            // 
            this.lblPregledi.AutoSize = true;
            this.lblPregledi.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregledi.Location = new System.Drawing.Point(168, 216);
            this.lblPregledi.Name = "lblPregledi";
            this.lblPregledi.Size = new System.Drawing.Size(78, 25);
            this.lblPregledi.TabIndex = 33;
            this.lblPregledi.Text = "Pregledi";
            // 
            // lblOstalo
            // 
            this.lblOstalo.AutoSize = true;
            this.lblOstalo.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOstalo.Location = new System.Drawing.Point(179, 379);
            this.lblOstalo.Name = "lblOstalo";
            this.lblOstalo.Size = new System.Drawing.Size(65, 25);
            this.lblOstalo.TabIndex = 35;
            this.lblOstalo.Text = "Ostalo";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.Gainsboro;
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(154, 416);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(332, 1);
            this.materialDivider2.TabIndex = 34;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // pnlUserMenuDropdown
            // 
            this.pnlUserMenuDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserMenuDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pnlUserMenuDropdown.Location = new System.Drawing.Point(1006, 0);
            this.pnlUserMenuDropdown.Name = "pnlUserMenuDropdown";
            this.pnlUserMenuDropdown.Size = new System.Drawing.Size(202, 105);
            this.pnlUserMenuDropdown.TabIndex = 10;
            this.pnlUserMenuDropdown.Visible = false;
            // 
            // btnUserMenu
            // 
            this.btnUserMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnUserMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.btnUserMenu.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnUserMenu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.btnUserMenu.IconSize = 45;
            this.btnUserMenu.Location = new System.Drawing.Point(1143, 0);
            this.btnUserMenu.Name = "btnUserMenu";
            this.btnUserMenu.Size = new System.Drawing.Size(65, 45);
            this.btnUserMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnUserMenu.TabIndex = 9;
            this.btnUserMenu.TabStop = false;
            this.btnUserMenu.Click += new System.EventHandler(this.btnUserMenu_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.picLogo);
            this.pnlMain.Controls.Add(this.pnlUserMenuDropdown);
            this.pnlMain.Controls.Add(this.lblOstalo);
            this.pnlMain.Controls.Add(this.btnSviPregledi);
            this.pnlMain.Controls.Add(this.materialDivider2);
            this.pnlMain.Controls.Add(this.btnZakazaniPregledi);
            this.pnlMain.Controls.Add(this.btnLekarskaUverenja);
            this.pnlMain.Controls.Add(this.lblPregledi);
            this.pnlMain.Controls.Add(this.btnUputnice);
            this.pnlMain.Controls.Add(this.btnPreglediNaCekanju);
            this.pnlMain.Controls.Add(this.materialDivider1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 42);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1208, 565);
            this.pnlMain.TabIndex = 36;
            // 
            // frmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 630);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlCopyright);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainDashboard";
            this.Text = "x";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlCopyright.ResumeLayout(false);
            this.pnlCopyright.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserMenu)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private Helpers.CustomElements.UserMenuButton btnUserMenu;
        private Helpers.CustomElements.UserMenuDropdownPanel pnlUserMenuDropdown;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCopyright;
        private System.Windows.Forms.Label lblCopyright;
        private FontAwesome.Sharp.IconButton btnZakazaniPregledi;
        private FontAwesome.Sharp.IconButton btnPreglediNaCekanju;
        private FontAwesome.Sharp.IconButton btnSviPregledi;
        private FontAwesome.Sharp.IconButton btnLekarskaUverenja;
        private FontAwesome.Sharp.IconButton btnUputnice;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Label lblPregledi;
        private System.Windows.Forms.Label lblOstalo;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private System.Windows.Forms.Panel pnlMain;
    }
}