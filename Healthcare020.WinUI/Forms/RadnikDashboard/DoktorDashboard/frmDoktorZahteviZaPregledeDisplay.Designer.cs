namespace Healthcare020.WinUI.Forms.RadnikDashboard.DoktorDashboard
{
    partial class frmDoktorZahteviZaPregledeDisplay
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
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnSearch)).BeginInit();
            this.pnlNavButtons.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.FlatAppearance.BorderSize = 0;
            this.btnPrevPage.Location = new System.Drawing.Point(287, 3);
            this.toolTip.SetToolTip(this.btnPrevPage, "Previous page");
            // 
            // btnNextPage
            // 
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.Location = new System.Drawing.Point(408, 3);
            this.toolTip.SetToolTip(this.btnNextPage, "Next page");
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.Location = new System.Drawing.Point(665, 13);
            // 
            // icnSearch
            // 
            this.icnSearch.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            // 
            // pnlNavButtons
            // 
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 392);
            this.pnlNavButtons.Size = new System.Drawing.Size(800, 58);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(800, 57);
            // 
            // frmDoktorPreglediDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmDoktorPreglediDisplay";
            this.Text = "frmDoktorPreglediDisplay";
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icnSearch)).EndInit();
            this.pnlNavButtons.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}