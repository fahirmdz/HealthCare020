namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmDoktorPregledi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoktorPregledi));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlCopyright = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCopyright.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(1024, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(172, 155);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 9;
            this.picLogo.TabStop = false;
            // 
            // pnlData
            // 
            this.pnlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlData.Location = new System.Drawing.Point(40, 173);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(1115, 389);
            this.pnlData.TabIndex = 10;
            // 
            // pnlCopyright
            // 
            this.pnlCopyright.BackColor = System.Drawing.Color.Transparent;
            this.pnlCopyright.Controls.Add(this.lblCopyright);
            this.pnlCopyright.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCopyright.Location = new System.Drawing.Point(0, 584);
            this.pnlCopyright.Name = "pnlCopyright";
            this.pnlCopyright.Size = new System.Drawing.Size(1208, 23);
            this.pnlCopyright.TabIndex = 22;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Calibri Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCopyright.Location = new System.Drawing.Point(504, 1);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(195, 13);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "© 2020. Fahir Mumdžić. All right reserved.";
            // 
            // frmDoktorPregledi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 607);
            this.Controls.Add(this.pnlCopyright);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoktorPregledi";
            this.Text = "frmDoktorPregledi";
            this.Load += new System.EventHandler(this.frmDoktorPregledi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCopyright.ResumeLayout(false);
            this.pnlCopyright.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlCopyright;
        private System.Windows.Forms.Label lblCopyright;
    }
}