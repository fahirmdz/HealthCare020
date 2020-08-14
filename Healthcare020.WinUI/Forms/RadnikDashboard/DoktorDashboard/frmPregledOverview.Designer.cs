namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmPregledOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledOverview));
            this.txtPacijent = new System.Windows.Forms.Label();
            this.horizontalDivider = new MaterialSkin.Controls.MaterialDivider();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDoktor = new System.Windows.Forms.Label();
            this.lblPacijent = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtDoktor = new System.Windows.Forms.Label();
            this.txtDatumVreme = new System.Windows.Forms.Label();
            this.lblDatumVreme = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPacijent
            // 
            this.txtPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPacijent.AutoSize = true;
            this.txtPacijent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPacijent.Location = new System.Drawing.Point(288, 130);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(0, 20);
            this.txtPacijent.TabIndex = 100;
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.horizontalDivider.BackColor = System.Drawing.Color.Gainsboro;
            this.horizontalDivider.Depth = 0;
            this.horizontalDivider.Location = new System.Drawing.Point(151, 79);
            this.horizontalDivider.MouseState = MaterialSkin.MouseState.HOVER;
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(424, 1);
            this.horizontalDivider.TabIndex = 99;
            this.horizontalDivider.Text = "materialDivider1";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.lblTitle.Location = new System.Drawing.Point(291, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 37);
            this.lblTitle.TabIndex = 98;
            this.lblTitle.Text = "Pregled";
            // 
            // lblDoktor
            // 
            this.lblDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDoktor.AutoSize = true;
            this.lblDoktor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoktor.Location = new System.Drawing.Point(206, 170);
            this.lblDoktor.Name = "lblDoktor";
            this.lblDoktor.Size = new System.Drawing.Size(66, 21);
            this.lblDoktor.TabIndex = 96;
            this.lblDoktor.Text = "Doktor:";
            // 
            // lblPacijent
            // 
            this.lblPacijent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPacijent.AutoSize = true;
            this.lblPacijent.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacijent.Location = new System.Drawing.Point(201, 129);
            this.lblPacijent.Name = "lblPacijent";
            this.lblPacijent.Size = new System.Drawing.Size(71, 21);
            this.lblPacijent.TabIndex = 94;
            this.lblPacijent.Text = "Pacijent:";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(616, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(172, 155);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 93;
            this.picLogo.TabStop = false;
            // 
            // txtDoktor
            // 
            this.txtDoktor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDoktor.AutoSize = true;
            this.txtDoktor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoktor.Location = new System.Drawing.Point(288, 171);
            this.txtDoktor.Name = "txtDoktor";
            this.txtDoktor.Size = new System.Drawing.Size(0, 20);
            this.txtDoktor.TabIndex = 104;
            // 
            // txtDatumVreme
            // 
            this.txtDatumVreme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDatumVreme.AutoSize = true;
            this.txtDatumVreme.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatumVreme.Location = new System.Drawing.Point(288, 213);
            this.txtDatumVreme.Name = "txtDatumVreme";
            this.txtDatumVreme.Size = new System.Drawing.Size(0, 20);
            this.txtDatumVreme.TabIndex = 106;
            // 
            // lblDatumVreme
            // 
            this.lblDatumVreme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatumVreme.AutoSize = true;
            this.lblDatumVreme.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatumVreme.Location = new System.Drawing.Point(152, 212);
            this.lblDatumVreme.Name = "lblDatumVreme";
            this.lblDatumVreme.Size = new System.Drawing.Size(120, 21);
            this.lblDatumVreme.TabIndex = 105;
            this.lblDatumVreme.Text = "Datum i vreme:";
            // 
            // frmPregledOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.txtDatumVreme);
            this.Controls.Add(this.lblDatumVreme);
            this.Controls.Add(this.txtDoktor);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDoktor);
            this.Controls.Add(this.lblPacijent);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPregledOverview";
            this.Text = "frmPregledOverview";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label txtPacijent;
        private MaterialSkin.Controls.MaterialDivider horizontalDivider;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDoktor;
        private System.Windows.Forms.Label lblPacijent;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label txtDoktor;
        private System.Windows.Forms.Label txtDatumVreme;
        private System.Windows.Forms.Label lblDatumVreme;
    }
}