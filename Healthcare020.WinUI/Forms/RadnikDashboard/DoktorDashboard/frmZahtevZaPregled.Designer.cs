namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmZahtevZaPregled
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZahtevZaPregled));
            this.lblDatumVremeZahteva = new System.Windows.Forms.Label();
            this.lblDoktor = new System.Windows.Forms.Label();
            this.lblNapomena = new System.Windows.Forms.Label();
            this.lblPacijent = new System.Windows.Forms.Label();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtDatumZahteva = new System.Windows.Forms.Label();
            this.txtDoktor = new System.Windows.Forms.Label();
            this.txtPacijent = new System.Windows.Forms.Label();
            this.btnZakazi = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.txtIsObradjen = new System.Windows.Forms.Label();
            this.lblIsObradjen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDatumVremeZahteva
            // 
            this.lblDatumVremeZahteva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatumVremeZahteva.AutoSize = true;
            this.lblDatumVremeZahteva.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumVremeZahteva.Location = new System.Drawing.Point(45, 170);
            this.lblDatumVremeZahteva.Name = "lblDatumVremeZahteva";
            this.lblDatumVremeZahteva.Size = new System.Drawing.Size(245, 21);
            this.lblDatumVremeZahteva.TabIndex = 51;
            this.lblDatumVremeZahteva.Text = "Datum i vreme kreiranja zahteva:";
            // 
            // lblDoktor
            // 
            this.lblDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDoktor.AutoSize = true;
            this.lblDoktor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoktor.Location = new System.Drawing.Point(224, 129);
            this.lblDoktor.Name = "lblDoktor";
            this.lblDoktor.Size = new System.Drawing.Size(66, 21);
            this.lblDoktor.TabIndex = 50;
            this.lblDoktor.Text = "Doktor:";
            // 
            // lblNapomena
            // 
            this.lblNapomena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNapomena.AutoSize = true;
            this.lblNapomena.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNapomena.Location = new System.Drawing.Point(126, 264);
            this.lblNapomena.Name = "lblNapomena";
            this.lblNapomena.Size = new System.Drawing.Size(94, 21);
            this.lblNapomena.TabIndex = 49;
            this.lblNapomena.Text = "Napomena:";
            // 
            // lblPacijent
            // 
            this.lblPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPacijent.AutoSize = true;
            this.lblPacijent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacijent.Location = new System.Drawing.Point(219, 85);
            this.lblPacijent.Name = "lblPacijent";
            this.lblPacijent.Size = new System.Drawing.Size(71, 21);
            this.lblPacijent.TabIndex = 48;
            this.lblPacijent.Text = "Pacijent:";
            // 
            // txtNapomena
            // 
            this.txtNapomena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNapomena.BackColor = System.Drawing.Color.White;
            this.txtNapomena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNapomena.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNapomena.Location = new System.Drawing.Point(226, 265);
            this.txtNapomena.MaximumSize = new System.Drawing.Size(347, 151);
            this.txtNapomena.MinimumSize = new System.Drawing.Size(347, 100);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNapomena.Size = new System.Drawing.Size(347, 100);
            this.txtNapomena.TabIndex = 52;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblTitle.Location = new System.Drawing.Point(219, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 37);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "Zahtev za pregled";
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(123, 61);
            this.horizontalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(424, 1);
            this.horizontalDivider.TabIndex = 54;
            this.horizontalDivider.Text = "materialDivider1";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(617, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(111, 112);
            this.picLogo.TabIndex = 55;
            this.picLogo.TabStop = false;
            // 
            // txtDatumZahteva
            // 
            this.txtDatumZahteva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDatumZahteva.AutoSize = true;
            this.txtDatumZahteva.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatumZahteva.Location = new System.Drawing.Point(296, 171);
            this.txtDatumZahteva.Name = "txtDatumZahteva";
            this.txtDatumZahteva.Size = new System.Drawing.Size(0, 20);
            this.txtDatumZahteva.TabIndex = 57;
            // 
            // txtDoktor
            // 
            this.txtDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDoktor.AutoSize = true;
            this.txtDoktor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoktor.Location = new System.Drawing.Point(296, 130);
            this.txtDoktor.Name = "txtDoktor";
            this.txtDoktor.Size = new System.Drawing.Size(0, 20);
            this.txtDoktor.TabIndex = 58;
            // 
            // txtPacijent
            // 
            this.txtPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPacijent.AutoSize = true;
            this.txtPacijent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacijent.Location = new System.Drawing.Point(296, 86);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(0, 20);
            this.txtPacijent.TabIndex = 59;
            // 
            // btnZakazi
            // 
            this.btnZakazi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZakazi.BorderColor = System.Drawing.Color.Transparent;
            this.btnZakazi.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnZakazi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZakazi.FlatAppearance.BorderSize = 0;
            this.btnZakazi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnZakazi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnZakazi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZakazi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakazi.Location = new System.Drawing.Point(586, 290);
            this.btnZakazi.Name = "btnZakazi";
            this.btnZakazi.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnZakazi.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnZakazi.OnHoverTextColor = System.Drawing.Color.White;
            this.btnZakazi.Size = new System.Drawing.Size(142, 75);
            this.btnZakazi.TabIndex = 56;
            this.btnZakazi.Text = "Zakaži";
            this.btnZakazi.TextColor = System.Drawing.Color.White;
            this.btnZakazi.UseVisualStyleBackColor = true;
            this.btnZakazi.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtIsObradjen
            // 
            this.txtIsObradjen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIsObradjen.AutoSize = true;
            this.txtIsObradjen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsObradjen.Location = new System.Drawing.Point(295, 212);
            this.txtIsObradjen.Name = "txtIsObradjen";
            this.txtIsObradjen.Size = new System.Drawing.Size(0, 20);
            this.txtIsObradjen.TabIndex = 61;
            // 
            // lblIsObradjen
            // 
            this.lblIsObradjen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIsObradjen.AutoSize = true;
            this.lblIsObradjen.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsObradjen.Location = new System.Drawing.Point(208, 211);
            this.lblIsObradjen.Name = "lblIsObradjen";
            this.lblIsObradjen.Size = new System.Drawing.Size(82, 21);
            this.lblIsObradjen.TabIndex = 60;
            this.lblIsObradjen.Text = "Obradjen:";
            // 
            // frmZahtevZaPregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 377);
            this.Controls.Add(this.txtIsObradjen);
            this.Controls.Add(this.lblIsObradjen);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.txtDoktor);
            this.Controls.Add(this.txtDatumZahteva);
            this.Controls.Add(this.btnZakazi);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.lblDatumVremeZahteva);
            this.Controls.Add(this.lblDoktor);
            this.Controls.Add(this.lblNapomena);
            this.Controls.Add(this.lblPacijent);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmZahtevZaPregled";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmZahtevZaPregled";
            this.Load += new System.EventHandler(this.frmZahtevZaPregled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatumVremeZahteva;
        private System.Windows.Forms.Label lblDoktor;
        private System.Windows.Forms.Label lblNapomena;
        private System.Windows.Forms.Label lblPacijent;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.Label lblTitle;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.PictureBox picLogo;
        private Helpers.CustomElements.Button_WOC btnZakazi;
        private System.Windows.Forms.Label txtDatumZahteva;
        private System.Windows.Forms.Label txtDoktor;
        private System.Windows.Forms.Label txtPacijent;
        private System.Windows.Forms.Label txtIsObradjen;
        private System.Windows.Forms.Label lblIsObradjen;
    }
}