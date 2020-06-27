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
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDatumVremeZahteva
            // 
            this.lblDatumVremeZahteva.AutoSize = true;
            this.lblDatumVremeZahteva.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumVremeZahteva.Location = new System.Drawing.Point(7, 173);
            this.lblDatumVremeZahteva.Name = "lblDatumVremeZahteva";
            this.lblDatumVremeZahteva.Size = new System.Drawing.Size(245, 21);
            this.lblDatumVremeZahteva.TabIndex = 51;
            this.lblDatumVremeZahteva.Text = "Datum i vreme kreiranja zahteva:";
            // 
            // lblDoktor
            // 
            this.lblDoktor.AutoSize = true;
            this.lblDoktor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoktor.Location = new System.Drawing.Point(186, 132);
            this.lblDoktor.Name = "lblDoktor";
            this.lblDoktor.Size = new System.Drawing.Size(66, 21);
            this.lblDoktor.TabIndex = 50;
            this.lblDoktor.Text = "Doktor:";
            // 
            // lblNapomena
            // 
            this.lblNapomena.AutoSize = true;
            this.lblNapomena.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNapomena.Location = new System.Drawing.Point(162, 213);
            this.lblNapomena.Name = "lblNapomena";
            this.lblNapomena.Size = new System.Drawing.Size(90, 21);
            this.lblNapomena.TabIndex = 49;
            this.lblNapomena.Text = "Napomena";
            // 
            // lblPacijent
            // 
            this.lblPacijent.AutoSize = true;
            this.lblPacijent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacijent.Location = new System.Drawing.Point(181, 88);
            this.lblPacijent.Name = "lblPacijent";
            this.lblPacijent.Size = new System.Drawing.Size(71, 21);
            this.lblPacijent.TabIndex = 48;
            this.lblPacijent.Text = "Pacijent:";
            // 
            // txtNapomena
            // 
            this.txtNapomena.BackColor = System.Drawing.Color.White;
            this.txtNapomena.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNapomena.Location = new System.Drawing.Point(166, 248);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNapomena.Size = new System.Drawing.Size(377, 90);
            this.txtNapomena.TabIndex = 52;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblTitle.Location = new System.Drawing.Point(242, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 37);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "Zahtev za pregled";
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(146, 61);
            this.horizontalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(424, 1);
            this.horizontalDivider.TabIndex = 54;
            this.horizontalDivider.Text = "materialDivider1";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(643, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(111, 112);
            this.picLogo.TabIndex = 55;
            this.picLogo.TabStop = false;
            // 
            // txtDatumZahteva
            // 
            this.txtDatumZahteva.AutoSize = true;
            this.txtDatumZahteva.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatumZahteva.Location = new System.Drawing.Point(258, 174);
            this.txtDatumZahteva.Name = "txtDatumZahteva";
            this.txtDatumZahteva.Size = new System.Drawing.Size(0, 20);
            this.txtDatumZahteva.TabIndex = 57;
            // 
            // txtDoktor
            // 
            this.txtDoktor.AutoSize = true;
            this.txtDoktor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoktor.Location = new System.Drawing.Point(258, 133);
            this.txtDoktor.Name = "txtDoktor";
            this.txtDoktor.Size = new System.Drawing.Size(0, 20);
            this.txtDoktor.TabIndex = 58;
            // 
            // txtPacijent
            // 
            this.txtPacijent.AutoSize = true;
            this.txtPacijent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacijent.Location = new System.Drawing.Point(258, 89);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(0, 20);
            this.txtPacijent.TabIndex = 59;
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
            this.btnSave.Location = new System.Drawing.Point(577, 281);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(164, 57);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // frmZahtevZaPregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(787, 377);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.txtDoktor);
            this.Controls.Add(this.txtDatumZahteva);
            this.Controls.Add(this.btnSave);
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
        private Helpers.CustomElements.Button_WOC btnSave;
        private System.Windows.Forms.Label txtDatumZahteva;
        private System.Windows.Forms.Label txtDoktor;
        private System.Windows.Forms.Label txtPacijent;
    }
}