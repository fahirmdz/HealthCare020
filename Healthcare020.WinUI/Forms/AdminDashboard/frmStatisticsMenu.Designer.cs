namespace Healthcare020.WinUI.Forms.AdministratorDashboard
{
    partial class frmStatisticsMenu
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
            this.btnZakazivanjeStatistic = new FontAwesome.Sharp.IconButton();
            this.pnlZakazivanjaCounter = new System.Windows.Forms.Panel();
            this.lblZakazivanjaPregledaCounter = new System.Windows.Forms.Label();
            this.pnlPreglediCounter = new System.Windows.Forms.Panel();
            this.lblPreglediCounter = new System.Windows.Forms.Label();
            this.btnPreglediStatistic = new FontAwesome.Sharp.IconButton();
            this.pnlPoseteCounter = new System.Windows.Forms.Panel();
            this.lblPoseteCounter = new System.Windows.Forms.Label();
            this.btnPoseteStatistic = new FontAwesome.Sharp.IconButton();
            this.btnRefresh = new FontAwesome.Sharp.IconButton();
            this.pnlZakazivanjaCounter.SuspendLayout();
            this.pnlPreglediCounter.SuspendLayout();
            this.pnlPoseteCounter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnZakazivanjeStatistic
            // 
            this.btnZakazivanjeStatistic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnZakazivanjeStatistic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZakazivanjeStatistic.FlatAppearance.BorderSize = 0;
            this.btnZakazivanjeStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZakazivanjeStatistic.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnZakazivanjeStatistic.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakazivanjeStatistic.ForeColor = System.Drawing.Color.White;
            this.btnZakazivanjeStatistic.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnZakazivanjeStatistic.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnZakazivanjeStatistic.IconSize = 70;
            this.btnZakazivanjeStatistic.Location = new System.Drawing.Point(44, 143);
            this.btnZakazivanjeStatistic.Name = "btnZakazivanjeStatistic";
            this.btnZakazivanjeStatistic.Rotation = 0D;
            this.btnZakazivanjeStatistic.Size = new System.Drawing.Size(294, 182);
            this.btnZakazivanjeStatistic.TabIndex = 23;
            this.btnZakazivanjeStatistic.Text = "Zakazivanja pregleda";
            this.btnZakazivanjeStatistic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnZakazivanjeStatistic.UseVisualStyleBackColor = false;
            this.btnZakazivanjeStatistic.Click += new System.EventHandler(this.btnZakazivanjeStatistic_Click);
            // 
            // pnlZakazivanjaCounter
            // 
            this.pnlZakazivanjaCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.pnlZakazivanjaCounter.Controls.Add(this.lblZakazivanjaPregledaCounter);
            this.pnlZakazivanjaCounter.Location = new System.Drawing.Point(44, 324);
            this.pnlZakazivanjaCounter.Name = "pnlZakazivanjaCounter";
            this.pnlZakazivanjaCounter.Size = new System.Drawing.Size(294, 55);
            this.pnlZakazivanjaCounter.TabIndex = 28;
            // 
            // lblZakazivanjaPregledaCounter
            // 
            this.lblZakazivanjaPregledaCounter.AutoSize = true;
            this.lblZakazivanjaPregledaCounter.Font = new System.Drawing.Font("Segoe UI Semilight", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZakazivanjaPregledaCounter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblZakazivanjaPregledaCounter.Location = new System.Drawing.Point(124, 4);
            this.lblZakazivanjaPregledaCounter.Name = "lblZakazivanjaPregledaCounter";
            this.lblZakazivanjaPregledaCounter.Size = new System.Drawing.Size(34, 41);
            this.lblZakazivanjaPregledaCounter.TabIndex = 0;
            this.lblZakazivanjaPregledaCounter.Text = "0";
            // 
            // pnlPreglediCounter
            // 
            this.pnlPreglediCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.pnlPreglediCounter.Controls.Add(this.lblPreglediCounter);
            this.pnlPreglediCounter.Location = new System.Drawing.Point(367, 324);
            this.pnlPreglediCounter.Name = "pnlPreglediCounter";
            this.pnlPreglediCounter.Size = new System.Drawing.Size(280, 55);
            this.pnlPreglediCounter.TabIndex = 30;
            // 
            // lblPreglediCounter
            // 
            this.lblPreglediCounter.AutoSize = true;
            this.lblPreglediCounter.Font = new System.Drawing.Font("Segoe UI Semilight", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreglediCounter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPreglediCounter.Location = new System.Drawing.Point(123, 4);
            this.lblPreglediCounter.Name = "lblPreglediCounter";
            this.lblPreglediCounter.Size = new System.Drawing.Size(34, 41);
            this.lblPreglediCounter.TabIndex = 0;
            this.lblPreglediCounter.Text = "0";
            // 
            // btnPreglediStatistic
            // 
            this.btnPreglediStatistic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnPreglediStatistic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreglediStatistic.FlatAppearance.BorderSize = 0;
            this.btnPreglediStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreglediStatistic.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPreglediStatistic.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreglediStatistic.ForeColor = System.Drawing.Color.White;
            this.btnPreglediStatistic.IconChar = FontAwesome.Sharp.IconChar.Stethoscope;
            this.btnPreglediStatistic.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnPreglediStatistic.IconSize = 70;
            this.btnPreglediStatistic.Location = new System.Drawing.Point(367, 143);
            this.btnPreglediStatistic.Name = "btnPreglediStatistic";
            this.btnPreglediStatistic.Rotation = 0D;
            this.btnPreglediStatistic.Size = new System.Drawing.Size(280, 182);
            this.btnPreglediStatistic.TabIndex = 29;
            this.btnPreglediStatistic.Text = "Obavljeni pregledi";
            this.btnPreglediStatistic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPreglediStatistic.UseVisualStyleBackColor = false;
            this.btnPreglediStatistic.Click += new System.EventHandler(this.btnPreglediStatistic_Click);
            // 
            // pnlPoseteCounter
            // 
            this.pnlPoseteCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.pnlPoseteCounter.Controls.Add(this.lblPoseteCounter);
            this.pnlPoseteCounter.Location = new System.Drawing.Point(676, 324);
            this.pnlPoseteCounter.Name = "pnlPoseteCounter";
            this.pnlPoseteCounter.Size = new System.Drawing.Size(280, 55);
            this.pnlPoseteCounter.TabIndex = 30;
            // 
            // lblPoseteCounter
            // 
            this.lblPoseteCounter.AutoSize = true;
            this.lblPoseteCounter.Font = new System.Drawing.Font("Segoe UI Semilight", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoseteCounter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPoseteCounter.Location = new System.Drawing.Point(126, 4);
            this.lblPoseteCounter.Name = "lblPoseteCounter";
            this.lblPoseteCounter.Size = new System.Drawing.Size(34, 41);
            this.lblPoseteCounter.TabIndex = 0;
            this.lblPoseteCounter.Text = "0";
            // 
            // btnPoseteStatistic
            // 
            this.btnPoseteStatistic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnPoseteStatistic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPoseteStatistic.FlatAppearance.BorderSize = 0;
            this.btnPoseteStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoseteStatistic.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPoseteStatistic.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoseteStatistic.ForeColor = System.Drawing.Color.White;
            this.btnPoseteStatistic.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnPoseteStatistic.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnPoseteStatistic.IconSize = 70;
            this.btnPoseteStatistic.Location = new System.Drawing.Point(676, 143);
            this.btnPoseteStatistic.Name = "btnPoseteStatistic";
            this.btnPoseteStatistic.Rotation = 0D;
            this.btnPoseteStatistic.Size = new System.Drawing.Size(280, 182);
            this.btnPoseteStatistic.TabIndex = 29;
            this.btnPoseteStatistic.Text = "Posete";
            this.btnPoseteStatistic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPoseteStatistic.UseVisualStyleBackColor = false;
            this.btnPoseteStatistic.Click += new System.EventHandler(this.btnPoseteStatistic_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(83)))), ((int)(((byte)(99)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btnRefresh.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(241)))), ((int)(((byte)(219)))));
            this.btnRefresh.IconSize = 30;
            this.btnRefresh.Location = new System.Drawing.Point(44, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Rotation = 0D;
            this.btnRefresh.Size = new System.Drawing.Size(114, 44);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Osveži";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmStatisticsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 584);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlPoseteCounter);
            this.Controls.Add(this.btnPoseteStatistic);
            this.Controls.Add(this.pnlPreglediCounter);
            this.Controls.Add(this.btnPreglediStatistic);
            this.Controls.Add(this.pnlZakazivanjaCounter);
            this.Controls.Add(this.btnZakazivanjeStatistic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStatisticsMenu";
            this.Load += new System.EventHandler(this.frmStatisticsMenu_Load);
            this.pnlZakazivanjaCounter.ResumeLayout(false);
            this.pnlZakazivanjaCounter.PerformLayout();
            this.pnlPreglediCounter.ResumeLayout(false);
            this.pnlPreglediCounter.PerformLayout();
            this.pnlPoseteCounter.ResumeLayout(false);
            this.pnlPoseteCounter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnZakazivanjeStatistic;
        private System.Windows.Forms.Panel pnlZakazivanjaCounter;
        private System.Windows.Forms.Label lblZakazivanjaPregledaCounter;
        private System.Windows.Forms.Panel pnlPreglediCounter;
        private System.Windows.Forms.Label lblPreglediCounter;
        private FontAwesome.Sharp.IconButton btnPreglediStatistic;
        private System.Windows.Forms.Panel pnlPoseteCounter;
        private System.Windows.Forms.Label lblPoseteCounter;
        private FontAwesome.Sharp.IconButton btnPoseteStatistic;
        private FontAwesome.Sharp.IconButton btnRefresh;
    }
}