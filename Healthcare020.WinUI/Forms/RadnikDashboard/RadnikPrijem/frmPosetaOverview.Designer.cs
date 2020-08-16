namespace Healthcare020.WinUI.Forms.RadnikDashboard.RadnikPrijem
{
    partial class frmPosetaOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosetaOverview));
            this.txtIsObradjen = new System.Windows.Forms.Label();
            this.lblIsObradjen = new System.Windows.Forms.Label();
            this.txtPacijent = new System.Windows.Forms.Label();
            this.txtDatumZahteva = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDatumVremeZahteva = new System.Windows.Forms.Label();
            this.lblZakazaniDatum = new System.Windows.Forms.Label();
            this.lblPacijent = new System.Windows.Forms.Label();
            this.txtBrojTelefonaPosetioca = new System.Windows.Forms.Label();
            this.lblBrojTelefonaPosetioca = new System.Windows.Forms.Label();
            this.dateZakazaniDatum = new System.Windows.Forms.DateTimePicker();
            this.lblZakazanoVreme = new System.Windows.Forms.Label();
            this.timeZakazanoVreme = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIsObradjen
            // 
            this.txtIsObradjen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIsObradjen.AutoSize = true;
            this.txtIsObradjen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsObradjen.Location = new System.Drawing.Point(324, 309);
            this.txtIsObradjen.Name = "txtIsObradjen";
            this.txtIsObradjen.Size = new System.Drawing.Size(0, 20);
            this.txtIsObradjen.TabIndex = 75;
            // 
            // lblIsObradjen
            // 
            this.lblIsObradjen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIsObradjen.AutoSize = true;
            this.lblIsObradjen.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsObradjen.Location = new System.Drawing.Point(237, 308);
            this.lblIsObradjen.Name = "lblIsObradjen";
            this.lblIsObradjen.Size = new System.Drawing.Size(82, 21);
            this.lblIsObradjen.TabIndex = 74;
            this.lblIsObradjen.Text = "Obradjen:";
            // 
            // txtPacijent
            // 
            this.txtPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPacijent.AutoSize = true;
            this.txtPacijent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacijent.Location = new System.Drawing.Point(325, 139);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(0, 20);
            this.txtPacijent.TabIndex = 73;
            // 
            // txtDatumZahteva
            // 
            this.txtDatumZahteva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDatumZahteva.AutoSize = true;
            this.txtDatumZahteva.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatumZahteva.Location = new System.Drawing.Point(325, 183);
            this.txtDatumZahteva.Name = "txtDatumZahteva";
            this.txtDatumZahteva.Size = new System.Drawing.Size(0, 20);
            this.txtDatumZahteva.TabIndex = 71;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(677, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(111, 112);
            this.picLogo.TabIndex = 69;
            this.picLogo.TabStop = false;
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(166, 77);
            this.horizontalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(424, 1);
            this.horizontalDivider.TabIndex = 68;
            this.horizontalDivider.Text = "materialDivider1";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblTitle.Location = new System.Drawing.Point(262, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(226, 37);
            this.lblTitle.TabIndex = 67;
            this.lblTitle.Text = "Zahtev za posetu";
            // 
            // lblDatumVremeZahteva
            // 
            this.lblDatumVremeZahteva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatumVremeZahteva.AutoSize = true;
            this.lblDatumVremeZahteva.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumVremeZahteva.Location = new System.Drawing.Point(74, 182);
            this.lblDatumVremeZahteva.Name = "lblDatumVremeZahteva";
            this.lblDatumVremeZahteva.Size = new System.Drawing.Size(245, 21);
            this.lblDatumVremeZahteva.TabIndex = 65;
            this.lblDatumVremeZahteva.Text = "Datum i vreme kreiranja zahteva:";
            // 
            // lblZakazaniDatum
            // 
            this.lblZakazaniDatum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZakazaniDatum.AutoSize = true;
            this.lblZakazaniDatum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZakazaniDatum.Location = new System.Drawing.Point(191, 225);
            this.lblZakazaniDatum.Name = "lblZakazaniDatum";
            this.lblZakazaniDatum.Size = new System.Drawing.Size(126, 21);
            this.lblZakazaniDatum.TabIndex = 64;
            this.lblZakazaniDatum.Text = "Zakazani datum:";
            // 
            // lblPacijent
            // 
            this.lblPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPacijent.AutoSize = true;
            this.lblPacijent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacijent.Location = new System.Drawing.Point(171, 138);
            this.lblPacijent.Name = "lblPacijent";
            this.lblPacijent.Size = new System.Drawing.Size(148, 21);
            this.lblPacijent.TabIndex = 62;
            this.lblPacijent.Text = "Pacijent na lečenju:";
            // 
            // txtBrojTelefonaPosetioca
            // 
            this.txtBrojTelefonaPosetioca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBrojTelefonaPosetioca.AutoSize = true;
            this.txtBrojTelefonaPosetioca.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrojTelefonaPosetioca.Location = new System.Drawing.Point(324, 347);
            this.txtBrojTelefonaPosetioca.Name = "txtBrojTelefonaPosetioca";
            this.txtBrojTelefonaPosetioca.Size = new System.Drawing.Size(0, 20);
            this.txtBrojTelefonaPosetioca.TabIndex = 77;
            // 
            // lblBrojTelefonaPosetioca
            // 
            this.lblBrojTelefonaPosetioca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBrojTelefonaPosetioca.AutoSize = true;
            this.lblBrojTelefonaPosetioca.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojTelefonaPosetioca.Location = new System.Drawing.Point(133, 346);
            this.lblBrojTelefonaPosetioca.Name = "lblBrojTelefonaPosetioca";
            this.lblBrojTelefonaPosetioca.Size = new System.Drawing.Size(185, 21);
            this.lblBrojTelefonaPosetioca.TabIndex = 76;
            this.lblBrojTelefonaPosetioca.Text = "Broj telefona posetioca:";
            // 
            // dateZakazaniDatum
            // 
            this.dateZakazaniDatum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateZakazaniDatum.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateZakazaniDatum.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.dateZakazaniDatum.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.dateZakazaniDatum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateZakazaniDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateZakazaniDatum.Location = new System.Drawing.Point(324, 222);
            this.dateZakazaniDatum.Name = "dateZakazaniDatum";
            this.dateZakazaniDatum.Size = new System.Drawing.Size(117, 25);
            this.dateZakazaniDatum.TabIndex = 78;
            // 
            // lblZakazanoVreme
            // 
            this.lblZakazanoVreme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZakazanoVreme.AutoSize = true;
            this.lblZakazanoVreme.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZakazanoVreme.Location = new System.Drawing.Point(187, 267);
            this.lblZakazanoVreme.Name = "lblZakazanoVreme";
            this.lblZakazanoVreme.Size = new System.Drawing.Size(131, 21);
            this.lblZakazanoVreme.TabIndex = 79;
            this.lblZakazanoVreme.Text = "Zakazano vreme:";
            // 
            // timeZakazanoVreme
            // 
            this.timeZakazanoVreme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeZakazanoVreme.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeZakazanoVreme.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.timeZakazanoVreme.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.timeZakazanoVreme.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeZakazanoVreme.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeZakazanoVreme.Location = new System.Drawing.Point(324, 267);
            this.timeZakazanoVreme.Name = "timeZakazanoVreme";
            this.timeZakazanoVreme.Size = new System.Drawing.Size(117, 25);
            this.timeZakazanoVreme.TabIndex = 80;
            // 
            // frmPosetaOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeZakazanoVreme);
            this.Controls.Add(this.lblZakazanoVreme);
            this.Controls.Add(this.dateZakazaniDatum);
            this.Controls.Add(this.txtBrojTelefonaPosetioca);
            this.Controls.Add(this.lblBrojTelefonaPosetioca);
            this.Controls.Add(this.txtIsObradjen);
            this.Controls.Add(this.lblIsObradjen);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.txtDatumZahteva);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDatumVremeZahteva);
            this.Controls.Add(this.lblZakazaniDatum);
            this.Controls.Add(this.lblPacijent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPosetaOverview";
            this.Text = "frmPosetaOverview";
            this.Load += new System.EventHandler(this.frmPosetaOverview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtIsObradjen;
        private System.Windows.Forms.Label lblIsObradjen;
        private System.Windows.Forms.Label txtPacijent;
        private System.Windows.Forms.Label txtDatumZahteva;
        private System.Windows.Forms.PictureBox picLogo;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDatumVremeZahteva;
        private System.Windows.Forms.Label lblZakazaniDatum;
        private System.Windows.Forms.Label lblPacijent;
        private System.Windows.Forms.Label txtBrojTelefonaPosetioca;
        private System.Windows.Forms.Label lblBrojTelefonaPosetioca;
        private System.Windows.Forms.DateTimePicker dateZakazaniDatum;
        private System.Windows.Forms.Label lblZakazanoVreme;
        private System.Windows.Forms.DateTimePicker timeZakazanoVreme;
    }
}