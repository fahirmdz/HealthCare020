namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmDoktorMainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoktorMainDashboard));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlCopyright = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnZakazaniPregledi = new FontAwesome.Sharp.IconButton();
            this.btnZahteviZaPregled = new FontAwesome.Sharp.IconButton();
            this.btnSviPregledi = new FontAwesome.Sharp.IconButton();
            this.btnLekarskaUverenja = new FontAwesome.Sharp.IconButton();
            this.btnUputnice = new FontAwesome.Sharp.IconButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.lblPregledi = new System.Windows.Forms.Label();
            this.lblLekarskaUverenja = new System.Windows.Forms.Label();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnUputniceNamenjene = new FontAwesome.Sharp.IconButton();
            this.lblUputnice = new System.Windows.Forms.Label();
            this.materialDivider3 = new MaterialSkin.Controls.MaterialDivider();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCopyright.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(514, 32);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(216, 216);
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
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
            this.lblCopyright.Location = new System.Drawing.Point(531, 3);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(199, 13);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "© 2020. Fahir Mumdžić. All rights reserved.";
            // 
            // btnZakazaniPregledi
            // 
            this.btnZakazaniPregledi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZakazaniPregledi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnZakazaniPregledi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZakazaniPregledi.FlatAppearance.BorderSize = 0;
            this.btnZakazaniPregledi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZakazaniPregledi.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnZakazaniPregledi.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakazaniPregledi.ForeColor = System.Drawing.Color.White;
            this.btnZakazaniPregledi.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            this.btnZakazaniPregledi.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnZakazaniPregledi.IconSize = 45;
            this.btnZakazaniPregledi.Location = new System.Drawing.Point(534, 331);
            this.btnZakazaniPregledi.Name = "btnZakazaniPregledi";
            this.btnZakazaniPregledi.Rotation = 0D;
            this.btnZakazaniPregledi.Size = new System.Drawing.Size(230, 74);
            this.btnZakazaniPregledi.TabIndex = 24;
            this.btnZakazaniPregledi.Text = "Zakazani pregledi";
            this.btnZakazaniPregledi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZakazaniPregledi.UseVisualStyleBackColor = false;
            this.btnZakazaniPregledi.Click += new System.EventHandler(this.btnZakazaniPregledi_Click);
            // 
            // btnZahteviZaPregled
            // 
            this.btnZahteviZaPregled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZahteviZaPregled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnZahteviZaPregled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZahteviZaPregled.FlatAppearance.BorderSize = 0;
            this.btnZahteviZaPregled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZahteviZaPregled.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnZahteviZaPregled.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZahteviZaPregled.ForeColor = System.Drawing.Color.White;
            this.btnZahteviZaPregled.IconChar = FontAwesome.Sharp.IconChar.Question;
            this.btnZahteviZaPregled.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnZahteviZaPregled.IconSize = 43;
            this.btnZahteviZaPregled.Location = new System.Drawing.Point(810, 331);
            this.btnZahteviZaPregled.Name = "btnZahteviZaPregled";
            this.btnZahteviZaPregled.Rotation = 0D;
            this.btnZahteviZaPregled.Size = new System.Drawing.Size(230, 74);
            this.btnZahteviZaPregled.TabIndex = 25;
            this.btnZahteviZaPregled.Text = "Zahtevi za pregled";
            this.btnZahteviZaPregled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZahteviZaPregled.UseVisualStyleBackColor = false;
            this.btnZahteviZaPregled.Click += new System.EventHandler(this.btnPreglediNaCekanju_Click);
            // 
            // btnSviPregledi
            // 
            this.btnSviPregledi.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnSviPregledi.Location = new System.Drawing.Point(239, 331);
            this.btnSviPregledi.Name = "btnSviPregledi";
            this.btnSviPregledi.Rotation = 0D;
            this.btnSviPregledi.Size = new System.Drawing.Size(230, 74);
            this.btnSviPregledi.TabIndex = 26;
            this.btnSviPregledi.Text = "Svi pregledi";
            this.btnSviPregledi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSviPregledi.UseVisualStyleBackColor = false;
            this.btnSviPregledi.Click += new System.EventHandler(this.btnSviPregledi_Click);
            // 
            // btnLekarskaUverenja
            // 
            this.btnLekarskaUverenja.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnLekarskaUverenja.Location = new System.Drawing.Point(810, 494);
            this.btnLekarskaUverenja.Name = "btnLekarskaUverenja";
            this.btnLekarskaUverenja.Rotation = 0D;
            this.btnLekarskaUverenja.Size = new System.Drawing.Size(230, 74);
            this.btnLekarskaUverenja.TabIndex = 30;
            this.btnLekarskaUverenja.Text = "Sva lekarska uverenja";
            this.btnLekarskaUverenja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLekarskaUverenja.UseVisualStyleBackColor = false;
            this.btnLekarskaUverenja.Click += new System.EventHandler(this.btnLekarskaUverenja_Click);
            // 
            // btnUputnice
            // 
            this.btnUputnice.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnUputnice.Location = new System.Drawing.Point(239, 494);
            this.btnUputnice.Name = "btnUputnice";
            this.btnUputnice.Rotation = 0D;
            this.btnUputnice.Size = new System.Drawing.Size(230, 74);
            this.btnUputnice.TabIndex = 28;
            this.btnUputnice.Text = "Kreirane uputnice";
            this.btnUputnice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUputnice.UseVisualStyleBackColor = false;
            this.btnUputnice.Click += new System.EventHandler(this.btnUputnice_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialDivider1.BackColor = System.Drawing.Color.Gainsboro;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(201, 295);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(857, 1);
            this.materialDivider1.TabIndex = 32;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // lblPregledi
            // 
            this.lblPregledi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPregledi.AutoSize = true;
            this.lblPregledi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregledi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblPregledi.Location = new System.Drawing.Point(215, 262);
            this.lblPregledi.Name = "lblPregledi";
            this.lblPregledi.Size = new System.Drawing.Size(91, 30);
            this.lblPregledi.TabIndex = 33;
            this.lblPregledi.Text = "Pregledi";
            // 
            // lblLekarskaUverenja
            // 
            this.lblLekarskaUverenja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLekarskaUverenja.AutoSize = true;
            this.lblLekarskaUverenja.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLekarskaUverenja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblLekarskaUverenja.Location = new System.Drawing.Point(792, 423);
            this.lblLekarskaUverenja.Name = "lblLekarskaUverenja";
            this.lblLekarskaUverenja.Size = new System.Drawing.Size(182, 30);
            this.lblLekarskaUverenja.TabIndex = 35;
            this.lblLekarskaUverenja.Text = "Lekarska uverenja";
            // 
            // materialDivider2
            // 
            this.materialDivider2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialDivider2.BackColor = System.Drawing.Color.Gainsboro;
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(797, 457);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(280, 1);
            this.materialDivider2.TabIndex = 34;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblUputnice);
            this.pnlMain.Controls.Add(this.materialDivider3);
            this.pnlMain.Controls.Add(this.btnUputniceNamenjene);
            this.pnlMain.Controls.Add(this.picLogo);
            this.pnlMain.Controls.Add(this.lblLekarskaUverenja);
            this.pnlMain.Controls.Add(this.btnSviPregledi);
            this.pnlMain.Controls.Add(this.materialDivider2);
            this.pnlMain.Controls.Add(this.btnZakazaniPregledi);
            this.pnlMain.Controls.Add(this.btnLekarskaUverenja);
            this.pnlMain.Controls.Add(this.lblPregledi);
            this.pnlMain.Controls.Add(this.btnUputnice);
            this.pnlMain.Controls.Add(this.btnZahteviZaPregled);
            this.pnlMain.Controls.Add(this.materialDivider1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1208, 607);
            this.pnlMain.TabIndex = 36;
            // 
            // btnUputniceNamenjene
            // 
            this.btnUputniceNamenjene.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUputniceNamenjene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnUputniceNamenjene.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUputniceNamenjene.FlatAppearance.BorderSize = 0;
            this.btnUputniceNamenjene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUputniceNamenjene.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUputniceNamenjene.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUputniceNamenjene.ForeColor = System.Drawing.Color.White;
            this.btnUputniceNamenjene.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            this.btnUputniceNamenjene.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnUputniceNamenjene.IconSize = 45;
            this.btnUputniceNamenjene.Location = new System.Drawing.Point(534, 494);
            this.btnUputniceNamenjene.Name = "btnUputniceNamenjene";
            this.btnUputniceNamenjene.Rotation = 0D;
            this.btnUputniceNamenjene.Size = new System.Drawing.Size(230, 74);
            this.btnUputniceNamenjene.TabIndex = 36;
            this.btnUputniceNamenjene.Text = "Namenjene uputnice";
            this.btnUputniceNamenjene.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUputniceNamenjene.UseVisualStyleBackColor = false;
            this.btnUputniceNamenjene.Click += new System.EventHandler(this.btnUputniceNamenjene_Click);
            // 
            // lblUputnice
            // 
            this.lblUputnice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUputnice.AutoSize = true;
            this.lblUputnice.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUputnice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblUputnice.Location = new System.Drawing.Point(215, 423);
            this.lblUputnice.Name = "lblUputnice";
            this.lblUputnice.Size = new System.Drawing.Size(99, 30);
            this.lblUputnice.TabIndex = 38;
            this.lblUputnice.Text = "Uputnice";
            // 
            // materialDivider3
            // 
            this.materialDivider3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialDivider3.BackColor = System.Drawing.Color.Gainsboro;
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Location = new System.Drawing.Point(203, 456);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Size = new System.Drawing.Size(561, 1);
            this.materialDivider3.TabIndex = 37;
            this.materialDivider3.Text = "materialDivider3";
            // 
            // frmDoktorMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 630);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoktorMainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCopyright.ResumeLayout(false);
            this.pnlCopyright.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlCopyright;
        private System.Windows.Forms.Label lblCopyright;
        private FontAwesome.Sharp.IconButton btnZakazaniPregledi;
        private FontAwesome.Sharp.IconButton btnZahteviZaPregled;
        private FontAwesome.Sharp.IconButton btnSviPregledi;
        private FontAwesome.Sharp.IconButton btnLekarskaUverenja;
        private FontAwesome.Sharp.IconButton btnUputnice;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Label lblPregledi;
        private System.Windows.Forms.Label lblLekarskaUverenja;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private System.Windows.Forms.Panel pnlMain;
        private FontAwesome.Sharp.IconButton btnUputniceNamenjene;
        private System.Windows.Forms.Label lblUputnice;
        private MaterialSkin.Controls.MaterialDivider materialDivider3;
    }
}