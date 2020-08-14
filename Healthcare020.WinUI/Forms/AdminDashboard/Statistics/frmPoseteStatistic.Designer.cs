namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    sealed partial class frmPoseteStatistic
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
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTwelveMonths
            // 
            this.btnTwelveMonths.FlatAppearance.BorderSize = 0;
            // 
            // btnThreeMonths
            // 
            this.btnThreeMonths.FlatAppearance.BorderSize = 0;
            // 
            // btnSixMonths
            // 
            this.btnSixMonths.FlatAppearance.BorderSize = 0;
            // 
            // chartPieMain
            // 
            this.chartPieMain.Size = new System.Drawing.Size(623, 175);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(800, 154);
            // 
            // btnChartTypeChange
            // 
            this.btnChartTypeChange.FlatAppearance.BorderSize = 0;
            this.btnChartTypeChange.Location = new System.Drawing.Point(622, 80);
            // 
            // chartLine
            // 
            this.chartLine.Size = new System.Drawing.Size(603, 172);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(800, 296);
            // 
            // frmPoseteStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmPoseteStatistic";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}