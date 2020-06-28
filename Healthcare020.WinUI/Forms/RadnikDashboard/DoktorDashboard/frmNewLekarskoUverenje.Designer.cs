namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmNewLekarskoUverenje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewLekarskoUverenje));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtPacijent = new System.Windows.Forms.Label();
            this.txtDoktor = new System.Windows.Forms.Label();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtOpisStanja = new System.Windows.Forms.TextBox();
            this.lblDoktor = new System.Windows.Forms.Label();
            this.lblOpisStanja = new System.Windows.Forms.Label();
            this.lblPacijent = new System.Windows.Forms.Label();
            this.btnPdf = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.lblZdravstvenoStanje = new System.Windows.Forms.Label();
            this.cmbZdravstvenoStanje = new System.Windows.Forms.ComboBox();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(816, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(172, 155);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 10;
            this.picLogo.TabStop = false;
            // 
            // txtPacijent
            // 
            this.txtPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPacijent.AutoSize = true;
            this.txtPacijent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacijent.Location = new System.Drawing.Point(231, 106);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(0, 20);
            this.txtPacijent.TabIndex = 71;
            // 
            // txtDoktor
            // 
            this.txtDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDoktor.AutoSize = true;
            this.txtDoktor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoktor.Location = new System.Drawing.Point(226, 147);
            this.txtDoktor.Name = "txtDoktor";
            this.txtDoktor.Size = new System.Drawing.Size(0, 20);
            this.txtDoktor.TabIndex = 70;
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(214, 85);
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
            this.lblTitle.Location = new System.Drawing.Point(317, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 37);
            this.lblTitle.TabIndex = 67;
            this.lblTitle.Text = "Lekarsko uverenje";
            // 
            // txtOpisStanja
            // 
            this.txtOpisStanja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOpisStanja.BackColor = System.Drawing.Color.White;
            this.txtOpisStanja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpisStanja.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpisStanja.Location = new System.Drawing.Point(226, 222);
            this.txtOpisStanja.MinimumSize = new System.Drawing.Size(585, 246);
            this.txtOpisStanja.Multiline = true;
            this.txtOpisStanja.Name = "txtOpisStanja";
            this.txtOpisStanja.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOpisStanja.Size = new System.Drawing.Size(585, 246);
            this.txtOpisStanja.TabIndex = 66;
            // 
            // lblDoktor
            // 
            this.lblDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDoktor.AutoSize = true;
            this.lblDoktor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoktor.Location = new System.Drawing.Point(154, 146);
            this.lblDoktor.Name = "lblDoktor";
            this.lblDoktor.Size = new System.Drawing.Size(66, 21);
            this.lblDoktor.TabIndex = 64;
            this.lblDoktor.Text = "Doktor:";
            // 
            // lblOpisStanja
            // 
            this.lblOpisStanja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOpisStanja.AutoSize = true;
            this.lblOpisStanja.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpisStanja.Location = new System.Drawing.Point(126, 225);
            this.lblOpisStanja.Name = "lblOpisStanja";
            this.lblOpisStanja.Size = new System.Drawing.Size(93, 21);
            this.lblOpisStanja.TabIndex = 63;
            this.lblOpisStanja.Text = "Opis stanja:";
            // 
            // lblPacijent
            // 
            this.lblPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPacijent.AutoSize = true;
            this.lblPacijent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacijent.Location = new System.Drawing.Point(154, 105);
            this.lblPacijent.Name = "lblPacijent";
            this.lblPacijent.Size = new System.Drawing.Size(71, 21);
            this.lblPacijent.TabIndex = 62;
            this.lblPacijent.Text = "Pacijent:";
            // 
            // btnPdf
            // 
            this.btnPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPdf.BorderColor = System.Drawing.Color.Transparent;
            this.btnPdf.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPdf.Location = new System.Drawing.Point(837, 340);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnPdf.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPdf.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPdf.Size = new System.Drawing.Size(151, 50);
            this.btnPdf.TabIndex = 73;
            this.btnPdf.Text = "PDF";
            this.btnPdf.TextColor = System.Drawing.Color.White;
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
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
            this.btnSave.Location = new System.Drawing.Point(837, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(151, 75);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblZdravstvenoStanje
            // 
            this.lblZdravstvenoStanje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZdravstvenoStanje.AutoSize = true;
            this.lblZdravstvenoStanje.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZdravstvenoStanje.Location = new System.Drawing.Point(69, 185);
            this.lblZdravstvenoStanje.Name = "lblZdravstvenoStanje";
            this.lblZdravstvenoStanje.Size = new System.Drawing.Size(151, 21);
            this.lblZdravstvenoStanje.TabIndex = 74;
            this.lblZdravstvenoStanje.Text = "Zdravstveno stanje:";
            // 
            // cmbZdravstvenoStanje
            // 
            this.cmbZdravstvenoStanje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbZdravstvenoStanje.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbZdravstvenoStanje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZdravstvenoStanje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZdravstvenoStanje.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cmbZdravstvenoStanje.FormattingEnabled = true;
            this.cmbZdravstvenoStanje.Location = new System.Drawing.Point(226, 185);
            this.cmbZdravstvenoStanje.Name = "cmbZdravstvenoStanje";
            this.cmbZdravstvenoStanje.Size = new System.Drawing.Size(175, 31);
            this.cmbZdravstvenoStanje.TabIndex = 75;
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gainsboro;
            this.toolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            // 
            // frmNewLekarskoUverenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.cmbZdravstvenoStanje);
            this.Controls.Add(this.lblZdravstvenoStanje);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.txtDoktor);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtOpisStanja);
            this.Controls.Add(this.lblDoktor);
            this.Controls.Add(this.lblOpisStanja);
            this.Controls.Add(this.lblPacijent);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewLekarskoUverenje";
            this.Text = "frmNewLekarskoUverenje";
            this.Load += new System.EventHandler(this.frmNewLekarskoUverenje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label txtPacijent;
        private System.Windows.Forms.Label txtDoktor;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtOpisStanja;
        private System.Windows.Forms.Label lblDoktor;
        private System.Windows.Forms.Label lblOpisStanja;
        private System.Windows.Forms.Label lblPacijent;
        private Helpers.CustomElements.Button_WOC btnSave;
        private Helpers.CustomElements.Button_WOC btnPdf;
        private System.Windows.Forms.Label lblZdravstvenoStanje;
        private System.Windows.Forms.ComboBox cmbZdravstvenoStanje;
        private System.Windows.Forms.ErrorProvider Errors;
        private System.Windows.Forms.ToolTip toolTip;
    }
}