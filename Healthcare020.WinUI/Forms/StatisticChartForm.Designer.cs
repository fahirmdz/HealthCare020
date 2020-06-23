namespace Healthcare020.WinUI.Forms
{
    partial class StatisticChartForm
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
            this.btnTwelveMonths = new FontAwesome.Sharp.IconButton();
            this.btnThreeMonths = new FontAwesome.Sharp.IconButton();
            this.btnSixMonths = new FontAwesome.Sharp.IconButton();
            this.chartPieMain = new LiveCharts.WinForms.PieChart();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnTwelveMonths.Location = new System.Drawing.Point(342, 81);
            this.btnTwelveMonths.Name = "btnTwelveMonths";
            this.btnTwelveMonths.Rotation = 0D;
            this.btnTwelveMonths.Size = new System.Drawing.Size(148, 47);
            this.btnTwelveMonths.TabIndex = 38;
            this.btnTwelveMonths.Text = "12 meseci";
            this.btnTwelveMonths.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTwelveMonths.UseVisualStyleBackColor = false;
            this.btnTwelveMonths.Click += new System.EventHandler(this.btnTwelveMonths_Click);
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
            this.btnThreeMonths.Location = new System.Drawing.Point(34, 81);
            this.btnThreeMonths.Name = "btnThreeMonths";
            this.btnThreeMonths.Rotation = 0D;
            this.btnThreeMonths.Size = new System.Drawing.Size(148, 47);
            this.btnThreeMonths.TabIndex = 37;
            this.btnThreeMonths.Text = "3 meseca";
            this.btnThreeMonths.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThreeMonths.UseVisualStyleBackColor = false;
            this.btnThreeMonths.Click += new System.EventHandler(this.btnThreeMonths_Click);
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
            this.btnSixMonths.Location = new System.Drawing.Point(188, 81);
            this.btnSixMonths.Name = "btnSixMonths";
            this.btnSixMonths.Rotation = 0D;
            this.btnSixMonths.Size = new System.Drawing.Size(148, 47);
            this.btnSixMonths.TabIndex = 36;
            this.btnSixMonths.Text = "6 meseci";
            this.btnSixMonths.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSixMonths.UseVisualStyleBackColor = false;
            this.btnSixMonths.Click += new System.EventHandler(this.btnSixMonths_Click);
            // 
            // chartPieMain
            // 
            this.chartPieMain.Location = new System.Drawing.Point(131, 209);
            this.chartPieMain.Name = "chartPieMain";
            this.chartPieMain.Size = new System.Drawing.Size(738, 333);
            this.chartPieMain.TabIndex = 35;
            this.chartPieMain.Text = "pieChart1";
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Semilight", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblChartTitle.Location = new System.Drawing.Point(27, 9);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(219, 40);
            this.lblChartTitle.TabIndex = 39;
            this.lblChartTitle.Text = "Naziv dijagrama";
            // 
            // StatisticChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 584);
            this.Controls.Add(this.lblChartTitle);
            this.Controls.Add(this.btnTwelveMonths);
            this.Controls.Add(this.btnThreeMonths);
            this.Controls.Add(this.btnSixMonths);
            this.Controls.Add(this.chartPieMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticChartForm";
            this.Load += new System.EventHandler(this.StatisticChartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected FontAwesome.Sharp.IconButton btnTwelveMonths;
        protected FontAwesome.Sharp.IconButton btnThreeMonths;
        protected FontAwesome.Sharp.IconButton btnSixMonths;
        protected LiveCharts.WinForms.PieChart chartPieMain;
        protected System.Windows.Forms.Label lblChartTitle;
    }
}