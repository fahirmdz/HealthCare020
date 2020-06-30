namespace Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem
{
    partial class frmRadnikPrijemMainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadnikPrijemMainDashboard));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnAutoSchedulePosete = new FontAwesome.Sharp.IconButton();
            this.btnOdobreniZahtevi = new FontAwesome.Sharp.IconButton();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnPosete = new FontAwesome.Sharp.IconButton();
            this.btnZahteviZaPosetuNaCekanju = new FontAwesome.Sharp.IconButton();
            this.lblPoseta = new System.Windows.Forms.Label();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.pnlCopyright = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCopyright.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnAutoSchedulePosete);
            this.pnlMain.Controls.Add(this.btnOdobreniZahtevi);
            this.pnlMain.Controls.Add(this.picLogo);
            this.pnlMain.Controls.Add(this.btnPosete);
            this.pnlMain.Controls.Add(this.btnZahteviZaPosetuNaCekanju);
            this.pnlMain.Controls.Add(this.lblPoseta);
            this.pnlMain.Controls.Add(this.materialDivider1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1192, 568);
            this.pnlMain.TabIndex = 38;
            // 
            // btnAutoSchedulePosete
            // 
            this.btnAutoSchedulePosete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutoSchedulePosete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnAutoSchedulePosete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoSchedulePosete.FlatAppearance.BorderSize = 0;
            this.btnAutoSchedulePosete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSchedulePosete.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAutoSchedulePosete.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSchedulePosete.ForeColor = System.Drawing.Color.White;
            this.btnAutoSchedulePosete.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnAutoSchedulePosete.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnAutoSchedulePosete.IconSize = 45;
            this.btnAutoSchedulePosete.Location = new System.Drawing.Point(427, 450);
            this.btnAutoSchedulePosete.Name = "btnAutoSchedulePosete";
            this.btnAutoSchedulePosete.Rotation = 0D;
            this.btnAutoSchedulePosete.Size = new System.Drawing.Size(351, 97);
            this.btnAutoSchedulePosete.TabIndex = 35;
            this.btnAutoSchedulePosete.Text = "Automatski rasporedi posete";
            this.btnAutoSchedulePosete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAutoSchedulePosete.UseVisualStyleBackColor = false;
            this.btnAutoSchedulePosete.Click += new System.EventHandler(this.btnAutoSchedulePosete_Click);
            // 
            // btnOdobreniZahtevi
            // 
            this.btnOdobreniZahtevi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOdobreniZahtevi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnOdobreniZahtevi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdobreniZahtevi.FlatAppearance.BorderSize = 0;
            this.btnOdobreniZahtevi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdobreniZahtevi.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnOdobreniZahtevi.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdobreniZahtevi.ForeColor = System.Drawing.Color.White;
            this.btnOdobreniZahtevi.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnOdobreniZahtevi.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnOdobreniZahtevi.IconSize = 45;
            this.btnOdobreniZahtevi.Location = new System.Drawing.Point(494, 333);
            this.btnOdobreniZahtevi.Name = "btnOdobreniZahtevi";
            this.btnOdobreniZahtevi.Rotation = 0D;
            this.btnOdobreniZahtevi.Size = new System.Drawing.Size(230, 74);
            this.btnOdobreniZahtevi.TabIndex = 34;
            this.btnOdobreniZahtevi.Text = "Odobreni zahtevi";
            this.btnOdobreniZahtevi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOdobreniZahtevi.UseVisualStyleBackColor = false;
            this.btnOdobreniZahtevi.Click += new System.EventHandler(this.btnOdobreniZahtevi_Click);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(504, 27);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(216, 216);
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            // 
            // btnPosete
            // 
            this.btnPosete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPosete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnPosete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosete.FlatAppearance.BorderSize = 0;
            this.btnPosete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosete.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPosete.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosete.ForeColor = System.Drawing.Color.White;
            this.btnPosete.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnPosete.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnPosete.IconSize = 45;
            this.btnPosete.Location = new System.Drawing.Point(197, 333);
            this.btnPosete.Name = "btnPosete";
            this.btnPosete.Rotation = 0D;
            this.btnPosete.Size = new System.Drawing.Size(230, 74);
            this.btnPosete.TabIndex = 26;
            this.btnPosete.Text = "Sve posete";
            this.btnPosete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPosete.UseVisualStyleBackColor = false;
            this.btnPosete.Click += new System.EventHandler(this.btnPosete_Click);
            // 
            // btnZahteviZaPosetuNaCekanju
            // 
            this.btnZahteviZaPosetuNaCekanju.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnZahteviZaPosetuNaCekanju.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnZahteviZaPosetuNaCekanju.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZahteviZaPosetuNaCekanju.FlatAppearance.BorderSize = 0;
            this.btnZahteviZaPosetuNaCekanju.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZahteviZaPosetuNaCekanju.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnZahteviZaPosetuNaCekanju.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZahteviZaPosetuNaCekanju.ForeColor = System.Drawing.Color.White;
            this.btnZahteviZaPosetuNaCekanju.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.btnZahteviZaPosetuNaCekanju.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnZahteviZaPosetuNaCekanju.IconSize = 45;
            this.btnZahteviZaPosetuNaCekanju.Location = new System.Drawing.Point(785, 333);
            this.btnZahteviZaPosetuNaCekanju.Name = "btnZahteviZaPosetuNaCekanju";
            this.btnZahteviZaPosetuNaCekanju.Rotation = 0D;
            this.btnZahteviZaPosetuNaCekanju.Size = new System.Drawing.Size(230, 74);
            this.btnZahteviZaPosetuNaCekanju.TabIndex = 24;
            this.btnZahteviZaPosetuNaCekanju.Text = "Zahtevi na čekanju";
            this.btnZahteviZaPosetuNaCekanju.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZahteviZaPosetuNaCekanju.UseVisualStyleBackColor = false;
            this.btnZahteviZaPosetuNaCekanju.Click += new System.EventHandler(this.btnZahteviZaPosetuNaCekanju_Click);
            // 
            // lblPoseta
            // 
            this.lblPoseta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPoseta.AutoSize = true;
            this.lblPoseta.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoseta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblPoseta.Location = new System.Drawing.Point(192, 271);
            this.lblPoseta.Name = "lblPoseta";
            this.lblPoseta.Size = new System.Drawing.Size(76, 30);
            this.lblPoseta.TabIndex = 33;
            this.lblPoseta.Text = "Posete";
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialDivider1.BackColor = System.Drawing.Color.Gainsboro;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(178, 304);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(857, 1);
            this.materialDivider1.TabIndex = 32;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // pnlCopyright
            // 
            this.pnlCopyright.BackColor = System.Drawing.Color.Transparent;
            this.pnlCopyright.Controls.Add(this.lblCopyright);
            this.pnlCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCopyright.Location = new System.Drawing.Point(0, 568);
            this.pnlCopyright.Name = "pnlCopyright";
            this.pnlCopyright.Size = new System.Drawing.Size(1192, 23);
            this.pnlCopyright.TabIndex = 37;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCopyright.Location = new System.Drawing.Point(523, 3);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(199, 13);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "© 2020. Fahir Mumdžić. All rights reserved.";
            // 
            // frmRadnikPrijemMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1192, 591);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRadnikPrijemMainDashboard";
            this.Text = "frmRadnikPrijemMainDashboard";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCopyright.ResumeLayout(false);
            this.pnlCopyright.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconButton btnPosete;
        private FontAwesome.Sharp.IconButton btnZahteviZaPosetuNaCekanju;
        private System.Windows.Forms.Label lblPoseta;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Panel pnlCopyright;
        private System.Windows.Forms.Label lblCopyright;
        private FontAwesome.Sharp.IconButton btnOdobreniZahtevi;
        private FontAwesome.Sharp.IconButton btnAutoSchedulePosete;
    }
}