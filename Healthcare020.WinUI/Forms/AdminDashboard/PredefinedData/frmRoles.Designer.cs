namespace Healthcare020.WinUI.Forms.AdministratorDashboard.PredefinedData
{
    partial class frmRoles
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
            this.btnPrevPage.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnPrevPage.FlatAppearance.BorderSize = 0;
            this.btnPrevPage.Location = new System.Drawing.Point(287, 3);
            this.toolTip.SetToolTip(this.btnPrevPage, "Previous page");
            this.btnPrevPage.UseWaitCursor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.Location = new System.Drawing.Point(408, 3);
            this.toolTip.SetToolTip(this.btnNextPage, "Next page");
            this.btnNextPage.UseWaitCursor = true;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.Location = new System.Drawing.Point(665, 13);
            this.btnNew.UseWaitCursor = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.UseWaitCursor = true;
            // 
            // icnSearch
            // 
            this.icnSearch.UseWaitCursor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.UseWaitCursor = true;
            // 
            // pnlNavButtons
            // 
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 392);
            this.pnlNavButtons.Size = new System.Drawing.Size(800, 58);
            this.pnlNavButtons.UseWaitCursor = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(800, 57);
            this.pnlTop.UseWaitCursor = true;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.UseWaitCursor = true;
            // 
            // frmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmRoles";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmRoles_Load);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icnSearch)).EndInit();
            this.pnlNavButtons.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}