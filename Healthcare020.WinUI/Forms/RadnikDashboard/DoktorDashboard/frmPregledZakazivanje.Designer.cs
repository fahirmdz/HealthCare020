namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmPregledZakazivanje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledZakazivanje));
            this.lblDatumPregleda = new System.Windows.Forms.Label();
            this.lblDoktor = new System.Windows.Forms.Label();
            this.lblPacijent = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtDoktor = new System.Windows.Forms.Label();
            this.txtPacijent = new System.Windows.Forms.Label();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.lblZahtevZaPregledId = new System.Windows.Forms.Label();
            this.txtZahtevZaPregled = new System.Windows.Forms.Label();
            this.datePregled = new System.Windows.Forms.DateTimePicker();
            this.timePregled = new System.Windows.Forms.DateTimePicker();
            this.lblVremePregleda = new System.Windows.Forms.Label();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.icnRecommendedTime = new FontAwesome.Sharp.IconPictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnRecommendedTime)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDatumPregleda
            // 
            this.lblDatumPregleda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatumPregleda.AutoSize = true;
            this.lblDatumPregleda.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumPregleda.Location = new System.Drawing.Point(101, 225);
            this.lblDatumPregleda.Name = "lblDatumPregleda";
            this.lblDatumPregleda.Size = new System.Drawing.Size(132, 21);
            this.lblDatumPregleda.TabIndex = 51;
            this.lblDatumPregleda.Text = "Datum pregleda:";
            // 
            // lblDoktor
            // 
            this.lblDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDoktor.AutoSize = true;
            this.lblDoktor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoktor.Location = new System.Drawing.Point(167, 182);
            this.lblDoktor.Name = "lblDoktor";
            this.lblDoktor.Size = new System.Drawing.Size(66, 21);
            this.lblDoktor.TabIndex = 50;
            this.lblDoktor.Text = "Doktor:";
            // 
            // lblPacijent
            // 
            this.lblPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPacijent.AutoSize = true;
            this.lblPacijent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacijent.Location = new System.Drawing.Point(162, 138);
            this.lblPacijent.Name = "lblPacijent";
            this.lblPacijent.Size = new System.Drawing.Size(71, 21);
            this.lblPacijent.TabIndex = 48;
            this.lblPacijent.Text = "Pacijent:";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblTitle.Location = new System.Drawing.Point(219, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(274, 37);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "Zakazivanje pregleda";
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
            // txtDoktor
            // 
            this.txtDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDoktor.AutoSize = true;
            this.txtDoktor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoktor.Location = new System.Drawing.Point(239, 183);
            this.txtDoktor.Name = "txtDoktor";
            this.txtDoktor.Size = new System.Drawing.Size(0, 20);
            this.txtDoktor.TabIndex = 58;
            // 
            // txtPacijent
            // 
            this.txtPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPacijent.AutoSize = true;
            this.txtPacijent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacijent.Location = new System.Drawing.Point(239, 139);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(0, 20);
            this.txtPacijent.TabIndex = 59;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(586, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(142, 75);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Potvrdi";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblZahtevZaPregledId
            // 
            this.lblZahtevZaPregledId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZahtevZaPregledId.AutoSize = true;
            this.lblZahtevZaPregledId.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZahtevZaPregledId.Location = new System.Drawing.Point(69, 97);
            this.lblZahtevZaPregledId.Name = "lblZahtevZaPregledId";
            this.lblZahtevZaPregledId.Size = new System.Drawing.Size(164, 21);
            this.lblZahtevZaPregledId.TabIndex = 60;
            this.lblZahtevZaPregledId.Text = "Zahtev za pregled ID:";
            // 
            // txtZahtevZaPregled
            // 
            this.txtZahtevZaPregled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtZahtevZaPregled.AutoSize = true;
            this.txtZahtevZaPregled.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZahtevZaPregled.Location = new System.Drawing.Point(239, 98);
            this.txtZahtevZaPregled.Name = "txtZahtevZaPregled";
            this.txtZahtevZaPregled.Size = new System.Drawing.Size(0, 20);
            this.txtZahtevZaPregled.TabIndex = 61;
            // 
            // datePregled
            // 
            this.datePregled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datePregled.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePregled.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.datePregled.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.datePregled.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePregled.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePregled.Location = new System.Drawing.Point(243, 225);
            this.datePregled.Name = "datePregled";
            this.datePregled.Size = new System.Drawing.Size(117, 25);
            this.datePregled.TabIndex = 62;
            // 
            // timePregled
            // 
            this.timePregled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timePregled.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePregled.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.timePregled.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.timePregled.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePregled.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePregled.Location = new System.Drawing.Point(243, 268);
            this.timePregled.Name = "timePregled";
            this.timePregled.Size = new System.Drawing.Size(117, 25);
            this.timePregled.TabIndex = 64;
            // 
            // lblVremePregleda
            // 
            this.lblVremePregleda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVremePregleda.AutoSize = true;
            this.lblVremePregleda.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVremePregleda.Location = new System.Drawing.Point(101, 268);
            this.lblVremePregleda.Name = "lblVremePregleda";
            this.lblVremePregleda.Size = new System.Drawing.Size(131, 21);
            this.lblVremePregleda.TabIndex = 63;
            this.lblVremePregleda.Text = "Vreme pregleda:";
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // icnRecommendedTime
            // 
            this.icnRecommendedTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.icnRecommendedTime.BackColor = System.Drawing.Color.White;
            this.icnRecommendedTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.icnRecommendedTime.IconChar = FontAwesome.Sharp.IconChar.QuestionCircle;
            this.icnRecommendedTime.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.icnRecommendedTime.IconSize = 25;
            this.icnRecommendedTime.Location = new System.Drawing.Point(366, 268);
            this.icnRecommendedTime.Name = "icnRecommendedTime";
            this.icnRecommendedTime.Size = new System.Drawing.Size(32, 25);
            this.icnRecommendedTime.TabIndex = 65;
            this.icnRecommendedTime.TabStop = false;
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gainsboro;
            this.toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            // 
            // frmPregledZakazivanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 377);
            this.Controls.Add(this.icnRecommendedTime);
            this.Controls.Add(this.timePregled);
            this.Controls.Add(this.lblVremePregleda);
            this.Controls.Add(this.datePregled);
            this.Controls.Add(this.txtZahtevZaPregled);
            this.Controls.Add(this.lblZahtevZaPregledId);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.txtDoktor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDatumPregleda);
            this.Controls.Add(this.lblDoktor);
            this.Controls.Add(this.lblPacijent);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPregledZakazivanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmZahtevZaPregled";
            this.Load += new System.EventHandler(this.frmZahtevZaPregled_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnRecommendedTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDatumPregleda;
        private System.Windows.Forms.Label lblDoktor;
        private System.Windows.Forms.Label lblPacijent;
        private System.Windows.Forms.Label lblTitle;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.PictureBox picLogo;
        private Helpers.CustomElements.Button_WOC btnSave;
        private System.Windows.Forms.Label txtDoktor;
        private System.Windows.Forms.Label txtPacijent;
        private System.Windows.Forms.Label lblZahtevZaPregledId;
        private System.Windows.Forms.Label txtZahtevZaPregled;
        private System.Windows.Forms.DateTimePicker datePregled;
        private System.Windows.Forms.DateTimePicker timePregled;
        private System.Windows.Forms.Label lblVremePregleda;
        private System.Windows.Forms.ErrorProvider Errors;
        private FontAwesome.Sharp.IconPictureBox icnRecommendedTime;
        private System.Windows.Forms.ToolTip toolTip;
    }
}