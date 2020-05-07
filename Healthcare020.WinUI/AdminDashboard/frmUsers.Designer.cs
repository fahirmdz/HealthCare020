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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrvKorisnickiNalozi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zaključaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrevPage = new FontAwesome.Sharp.IconButton();
            this.btnNextPage = new FontAwesome.Sharp.IconButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnNewUser = new FontAwesome.Sharp.IconButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKorisnickiNalozi)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrvKorisnickiNalozi
            // 
            this.dgrvKorisnickiNalozi.AllowUserToAddRows = false;
            this.dgrvKorisnickiNalozi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgrvKorisnickiNalozi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrvKorisnickiNalozi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrvKorisnickiNalozi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvKorisnickiNalozi.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgrvKorisnickiNalozi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = "N/A";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(102)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvKorisnickiNalozi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrvKorisnickiNalozi.ColumnHeadersHeight = 35;
            this.dgrvKorisnickiNalozi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Username,
            this.DateCreated,
            this.Zaključaj});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = "N/A";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvKorisnickiNalozi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrvKorisnickiNalozi.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgrvKorisnickiNalozi.Location = new System.Drawing.Point(62, 47);
            this.dgrvKorisnickiNalozi.Name = "dgrvKorisnickiNalozi";
            this.dgrvKorisnickiNalozi.ReadOnly = true;
            this.dgrvKorisnickiNalozi.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgrvKorisnickiNalozi.RowTemplate.Height = 30;
            this.dgrvKorisnickiNalozi.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvKorisnickiNalozi.Size = new System.Drawing.Size(646, 340);
            this.dgrvKorisnickiNalozi.TabIndex = 0;
            this.dgrvKorisnickiNalozi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvKorisnickiNalozi_CellContentClick);
            this.dgrvKorisnickiNalozi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgrvKorisnickiNalozi_CellFormatting);
            this.dgrvKorisnickiNalozi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvKorisnickiNalozi_CellValueChanged);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "Id";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 147;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Username.DataPropertyName = "Username";
            this.Username.Frozen = true;
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 148;
            // 
            // DateCreated
            // 
            this.DateCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.Frozen = true;
            this.DateCreated.HeaderText = "Datum kreiranja";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            this.DateCreated.Width = 147;
            // 
            // Zaključaj
            // 
            this.Zaključaj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Zaključaj.DefaultCellStyle = dataGridViewCellStyle3;
            this.Zaključaj.HeaderText = "Akcija";
            this.Zaključaj.Name = "Zaključaj";
            this.Zaključaj.ReadOnly = true;
            this.Zaključaj.Text = "Zaključaj";
            this.Zaključaj.ToolTipText = "Zaključaj korisnički nalog na određeni broj sati";
            this.Zaključaj.UseColumnTextForButtonValue = true;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevPage.FlatAppearance.BorderSize = 0;
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPrevPage.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnPrevPage.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnPrevPage.IconSize = 40;
            this.btnPrevPage.Location = new System.Drawing.Point(311, 393);
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
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewUser.FlatAppearance.BorderSize = 0;
            this.btnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewUser.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNewUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.ForeColor = System.Drawing.Color.White;
            this.btnNewUser.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNewUser.IconColor = System.Drawing.Color.White;
            this.btnNewUser.IconSize = 25;
            this.btnNewUser.Location = new System.Drawing.Point(608, 1);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Rotation = 0D;
            this.btnNewUser.Size = new System.Drawing.Size(84, 30);
            this.btnNewUser.TabIndex = 4;
            this.btnNewUser.Text = "Novi ";
            this.btnNewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewUser.UseVisualStyleBackColor = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dgrvKorisnickiNalozi);
            this.pnlBody.Controls.Add(this.btnPrevPage);
            this.pnlBody.Controls.Add(this.btnNextPage);
            this.pnlBody.Controls.Add(this.btnNewUser);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(776, 486);
            this.pnlBody.TabIndex = 5;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 486);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsers";
            this.Text = "frmUsers";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKorisnickiNalozi)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvKorisnickiNalozi;
        private FontAwesome.Sharp.IconButton btnPrevPage;
        private FontAwesome.Sharp.IconButton btnNextPage;
        private System.Windows.Forms.ToolTip toolTip;
        private FontAwesome.Sharp.IconButton btnNewUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewButtonColumn Zaključaj;
        private System.Windows.Forms.Panel pnlBody;
    }
}