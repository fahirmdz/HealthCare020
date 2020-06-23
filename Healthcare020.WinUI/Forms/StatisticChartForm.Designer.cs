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
            this.chartLine = new LiveCharts.WinForms.CartesianChart();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnChartTypeChange = new FontAwesome.Sharp.IconButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
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
            this.btnTwelveMonths.Location = new System.Drawing.Point(328, 80);
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
            this.btnThreeMonths.Location = new System.Drawing.Point(20, 80);
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
            this.btnSixMonths.Location = new System.Drawing.Point(174, 80);
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
            this.chartPieMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPieMain.Location = new System.Drawing.Point(48, 45);
            this.chartPieMain.Margin = new System.Windows.Forms.Padding(10);
            this.chartPieMain.Name = "chartPieMain";
            this.chartPieMain.Size = new System.Drawing.Size(827, 309);
            this.chartPieMain.TabIndex = 35;
            this.chartPieMain.Text = "pieChart1";
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblChartTitle.Location = new System.Drawing.Point(23, 9);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(212, 40);
            this.lblChartTitle.TabIndex = 39;
            this.lblChartTitle.Text = "Naziv dijagrama";
            // 
            // chartLine
            // 
            this.chartLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartLine.Location = new System.Drawing.Point(96, 45);
            this.chartLine.Margin = new System.Windows.Forms.Padding(10);
            this.chartLine.Name = "chartLine";
            this.chartLine.Size = new System.Drawing.Size(807, 306);
            this.chartLine.TabIndex = 36;
            this.chartLine.Text = "cartesianChart1";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnChartTypeChange);
            this.pnlTop.Controls.Add(this.btnTwelveMonths);
            this.pnlTop.Controls.Add(this.btnSixMonths);
            this.pnlTop.Controls.Add(this.lblChartTitle);
            this.pnlTop.Controls.Add(this.btnThreeMonths);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1004, 154);
            this.pnlTop.TabIndex = 41;
            // 
            // btnChartTypeChange
            // 
            this.btnChartTypeChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChartTypeChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(61)))), ((int)(((byte)(110)))));
            this.btnChartTypeChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChartTypeChange.FlatAppearance.BorderSize = 0;
            this.btnChartTypeChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartTypeChange.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnChartTypeChange.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartTypeChange.ForeColor = System.Drawing.Color.White;
            this.btnChartTypeChange.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnChartTypeChange.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnChartTypeChange.IconSize = 30;
            this.btnChartTypeChange.Location = new System.Drawing.Point(826, 80);
            this.btnChartTypeChange.Name = "btnChartTypeChange";
            this.btnChartTypeChange.Rotation = 0D;
            this.btnChartTypeChange.Size = new System.Drawing.Size(148, 47);
            this.btnChartTypeChange.TabIndex = 40;
            this.btnChartTypeChange.Text = "Line chart";
            this.btnChartTypeChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChartTypeChange.UseVisualStyleBackColor = false;
            this.btnChartTypeChange.Click += new System.EventHandler(this.btnChartTypeChange_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chartLine);
            this.pnlMain.Controls.Add(this.chartPieMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 154);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1004, 430);
            this.pnlMain.TabIndex = 43;
            // 
            // StatisticChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 584);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticChartForm";
            this.Load += new System.EventHandler(this.StatisticChartForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected FontAwesome.Sharp.IconButton btnTwelveMonths;
        protected FontAwesome.Sharp.IconButton btnThreeMonths;
        protected FontAwesome.Sharp.IconButton btnSixMonths;
        protected LiveCharts.WinForms.PieChart chartPieMain;
        protected System.Windows.Forms.Label lblChartTitle;
        protected System.Windows.Forms.Panel pnlTop;
        protected FontAwesome.Sharp.IconButton btnChartTypeChange;
        protected LiveCharts.WinForms.CartesianChart chartLine;
        protected System.Windows.Forms.Panel pnlMain;
    }
}