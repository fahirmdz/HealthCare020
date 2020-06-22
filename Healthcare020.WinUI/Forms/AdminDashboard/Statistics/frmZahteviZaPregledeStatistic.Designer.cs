namespace Healthcare020.WinUI.Forms.AdminDashboard.Statistics
{
    partial class frmZahteviZaPregledeStatistic
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
            this.chartZahteviZaPreglede = new LiveCharts.WinForms.PieChart();
            this.btnSixMonths = new FontAwesome.Sharp.IconButton();
            this.btnThreeMonths = new FontAwesome.Sharp.IconButton();
            this.btnTwelveMonths = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // chartZahteviZaPreglede
            // 
            this.chartZahteviZaPreglede.Location = new System.Drawing.Point(128, 163);
            this.chartZahteviZaPreglede.Name = "chartZahteviZaPreglede";
            this.chartZahteviZaPreglede.Size = new System.Drawing.Size(738, 333);
            this.chartZahteviZaPreglede.TabIndex = 0;
            this.chartZahteviZaPreglede.Text = "pieChart1";
            // 
            // btnSixMonths
            // 
            this.btnSixMonths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(99)))));
            this.btnSixMonths.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSixMonths.FlatAppearance.BorderSize = 0;
            this.btnSixMonths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSixMonths.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSixMonths.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSixMonths.ForeColor = System.Drawing.Color.White;
            this.btnSixMonths.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnSixMonths.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnSixMonths.IconSize = 30;
            this.btnSixMonths.Location = new System.Drawing.Point(199, 37);
            this.btnSixMonths.Name = "btnSixMonths";
            this.btnSixMonths.Rotation = 0D;
            this.btnSixMonths.Size = new System.Drawing.Size(148, 47);
            this.btnSixMonths.TabIndex = 32;
            this.btnSixMonths.Text = "6 meseci";
            this.btnSixMonths.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSixMonths.UseVisualStyleBackColor = false;
            this.btnSixMonths.Click += new System.EventHandler(this.btnSixMonths_Click);
            // 
            // btnThreeMonths
            // 
            this.btnThreeMonths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(99)))));
            this.btnThreeMonths.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThreeMonths.FlatAppearance.BorderSize = 0;
            this.btnThreeMonths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThreeMonths.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnThreeMonths.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThreeMonths.ForeColor = System.Drawing.Color.White;
            this.btnThreeMonths.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnThreeMonths.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnThreeMonths.IconSize = 30;
            this.btnThreeMonths.Location = new System.Drawing.Point(45, 37);
            this.btnThreeMonths.Name = "btnThreeMonths";
            this.btnThreeMonths.Rotation = 0D;
            this.btnThreeMonths.Size = new System.Drawing.Size(148, 47);
            this.btnThreeMonths.TabIndex = 33;
            this.btnThreeMonths.Text = "3 meseca";
            this.btnThreeMonths.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThreeMonths.UseVisualStyleBackColor = false;
            this.btnThreeMonths.Click += new System.EventHandler(this.btnThreeMonths_Click);
            // 
            // btnTwelveMonths
            // 
            this.btnTwelveMonths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(99)))));
            this.btnTwelveMonths.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTwelveMonths.FlatAppearance.BorderSize = 0;
            this.btnTwelveMonths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwelveMonths.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTwelveMonths.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwelveMonths.ForeColor = System.Drawing.Color.White;
            this.btnTwelveMonths.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnTwelveMonths.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnTwelveMonths.IconSize = 30;
            this.btnTwelveMonths.Location = new System.Drawing.Point(353, 37);
            this.btnTwelveMonths.Name = "btnTwelveMonths";
            this.btnTwelveMonths.Rotation = 0D;
            this.btnTwelveMonths.Size = new System.Drawing.Size(148, 47);
            this.btnTwelveMonths.TabIndex = 34;
            this.btnTwelveMonths.Text = "12 meseci";
            this.btnTwelveMonths.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTwelveMonths.UseVisualStyleBackColor = false;
            this.btnTwelveMonths.Click += new System.EventHandler(this.btnTwelveMonths_Click);
            // 
            // frmZahteviZaPregledeStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 584);
            this.Controls.Add(this.btnTwelveMonths);
            this.Controls.Add(this.btnThreeMonths);
            this.Controls.Add(this.btnSixMonths);
            this.Controls.Add(this.chartZahteviZaPreglede);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmZahteviZaPregledeStatistic";
            this.Load += new System.EventHandler(this.frmZahteviZaPregledeStatistic_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.PieChart chartZahteviZaPreglede;
        private FontAwesome.Sharp.IconButton btnSixMonths;
        private FontAwesome.Sharp.IconButton btnThreeMonths;
        private FontAwesome.Sharp.IconButton btnTwelveMonths;
    }
}