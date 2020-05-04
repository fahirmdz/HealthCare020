namespace Healthcare020.WinUI.AdminDashboard
{
    partial class frmUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrvKorisnickiNalozi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrevPage = new FontAwesome.Sharp.IconButton();
            this.btnNextPage = new FontAwesome.Sharp.IconButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKorisnickiNalozi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrvKorisnickiNalozi
            // 
            this.dgrvKorisnickiNalozi.AllowUserToAddRows = false;
            this.dgrvKorisnickiNalozi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgrvKorisnickiNalozi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrvKorisnickiNalozi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrvKorisnickiNalozi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvKorisnickiNalozi.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgrvKorisnickiNalozi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.NullValue = "N/A";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(102)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrvKorisnickiNalozi.ColumnHeadersHeight = 35;
            this.dgrvKorisnickiNalozi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Username,
            this.DateCreated});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = "N/A";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvKorisnickiNalozi.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgrvKorisnickiNalozi.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgrvKorisnickiNalozi.Location = new System.Drawing.Point(73, 60);
            this.dgrvKorisnickiNalozi.Name = "dgrvKorisnickiNalozi";
            this.dgrvKorisnickiNalozi.ReadOnly = true;
            this.dgrvKorisnickiNalozi.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgrvKorisnickiNalozi.RowTemplate.Height = 30;
            this.dgrvKorisnickiNalozi.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvKorisnickiNalozi.Size = new System.Drawing.Size(630, 327);
            this.dgrvKorisnickiNalozi.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // DateCreated
            // 
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Datum kreiranje naloga";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevPage.FlatAppearance.BorderSize = 0;
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPrevPage.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnPrevPage.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnPrevPage.IconSize = 40;
            this.btnPrevPage.Location = new System.Drawing.Point(322, 393);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Rotation = 0D;
            this.btnPrevPage.Size = new System.Drawing.Size(75, 43);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click_1);
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNextPage.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.btnNextPage.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnNextPage.IconSize = 40;
            this.btnNextPage.Location = new System.Drawing.Point(412, 393);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Rotation = 0D;
            this.btnNextPage.Size = new System.Drawing.Size(75, 43);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click_1);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 486);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.dgrvKorisnickiNalozi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsers";
            this.Text = "frmUsers";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKorisnickiNalozi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvKorisnickiNalozi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private FontAwesome.Sharp.IconButton btnPrevPage;
        private FontAwesome.Sharp.IconButton btnNextPage;
        private System.Windows.Forms.ToolTip toolTip;
    }
}