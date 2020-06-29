namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmNewUputnica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewUputnica));
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.txtPacijent = new System.Windows.Forms.Label();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtRazlog = new System.Windows.Forms.TextBox();
            this.lblDoktor = new System.Windows.Forms.Label();
            this.lblRazlog = new System.Windows.Forms.Label();
            this.lblPacijent = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.lblNapomena = new System.Windows.Forms.Label();
            this.cmbDoktori = new System.Windows.Forms.ComboBox();
            this.btnCancel = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.SuspendLayout();
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
            this.btnSave.Location = new System.Drawing.Point(800, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(151, 75);
            this.btnSave.TabIndex = 86;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPacijent
            // 
            this.txtPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPacijent.AutoSize = true;
            this.txtPacijent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacijent.Location = new System.Drawing.Point(258, 121);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(0, 20);
            this.txtPacijent.TabIndex = 85;
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(233, 78);
            this.horizontalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(424, 1);
            this.horizontalDivider.TabIndex = 83;
            this.horizontalDivider.Text = "materialDivider1";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblTitle.Location = new System.Drawing.Point(373, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(128, 37);
            this.lblTitle.TabIndex = 82;
            this.lblTitle.Text = "Uputnica";
            // 
            // txtRazlog
            // 
            this.txtRazlog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRazlog.BackColor = System.Drawing.Color.White;
            this.txtRazlog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazlog.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazlog.Location = new System.Drawing.Point(248, 210);
            this.txtRazlog.MinimumSize = new System.Drawing.Size(479, 99);
            this.txtRazlog.Multiline = true;
            this.txtRazlog.Name = "txtRazlog";
            this.txtRazlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRazlog.Size = new System.Drawing.Size(479, 99);
            this.txtRazlog.TabIndex = 81;
            // 
            // lblDoktor
            // 
            this.lblDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDoktor.AutoSize = true;
            this.lblDoktor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoktor.Location = new System.Drawing.Point(176, 161);
            this.lblDoktor.Name = "lblDoktor";
            this.lblDoktor.Size = new System.Drawing.Size(66, 21);
            this.lblDoktor.TabIndex = 80;
            this.lblDoktor.Text = "Doktor:";
            // 
            // lblRazlog
            // 
            this.lblRazlog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRazlog.AutoSize = true;
            this.lblRazlog.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazlog.Location = new System.Drawing.Point(176, 210);
            this.lblRazlog.Name = "lblRazlog";
            this.lblRazlog.Size = new System.Drawing.Size(63, 21);
            this.lblRazlog.TabIndex = 79;
            this.lblRazlog.Text = "Razlog:";
            // 
            // lblPacijent
            // 
            this.lblPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPacijent.AutoSize = true;
            this.lblPacijent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacijent.Location = new System.Drawing.Point(171, 120);
            this.lblPacijent.Name = "lblPacijent";
            this.lblPacijent.Size = new System.Drawing.Size(71, 21);
            this.lblPacijent.TabIndex = 78;
            this.lblPacijent.Text = "Pacijent:";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(800, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(172, 155);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 77;
            this.picLogo.TabStop = false;
            // 
            // txtNapomena
            // 
            this.txtNapomena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNapomena.BackColor = System.Drawing.Color.White;
            this.txtNapomena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNapomena.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNapomena.Location = new System.Drawing.Point(248, 325);
            this.txtNapomena.MinimumSize = new System.Drawing.Size(479, 99);
            this.txtNapomena.Multiline = true;
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNapomena.Size = new System.Drawing.Size(479, 99);
            this.txtNapomena.TabIndex = 90;
            // 
            // lblNapomena
            // 
            this.lblNapomena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNapomena.AutoSize = true;
            this.lblNapomena.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNapomena.Location = new System.Drawing.Point(145, 326);
            this.lblNapomena.Name = "lblNapomena";
            this.lblNapomena.Size = new System.Drawing.Size(94, 21);
            this.lblNapomena.TabIndex = 89;
            this.lblNapomena.Text = "Napomena:";
            // 
            // cmbDoktori
            // 
            this.cmbDoktori.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDoktori.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbDoktori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoktori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDoktori.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbDoktori.FormattingEnabled = true;
            this.cmbDoktori.Location = new System.Drawing.Point(248, 157);
            this.cmbDoktori.Name = "cmbDoktori";
            this.cmbDoktori.Size = new System.Drawing.Size(267, 31);
            this.cmbDoktori.TabIndex = 91;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ButtonColor = System.Drawing.Color.Silver;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(800, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.OnHoverButtonColor = System.Drawing.Color.Gray;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(151, 46);
            this.btnCancel.TabIndex = 92;
            this.btnCancel.Text = "Poništi";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // frmNewUputnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbDoktori);
            this.Controls.Add(this.txtNapomena);
            this.Controls.Add(this.lblNapomena);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtRazlog);
            this.Controls.Add(this.lblDoktor);
            this.Controls.Add(this.lblRazlog);
            this.Controls.Add(this.lblPacijent);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewUputnica";
            this.Text = "frmNewUputnica";
            this.Load += new System.EventHandler(this.frmNewUputnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Helpers.CustomElements.Button_WOC btnSave;
        private System.Windows.Forms.Label txtPacijent;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtRazlog;
        private System.Windows.Forms.Label lblDoktor;
        private System.Windows.Forms.Label lblRazlog;
        private System.Windows.Forms.Label lblPacijent;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.Label lblNapomena;
        private System.Windows.Forms.ComboBox cmbDoktori;
        private Helpers.CustomElements.Button_WOC btnCancel;
        private System.Windows.Forms.ErrorProvider Errors;
    }
}