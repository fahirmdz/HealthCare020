﻿namespace Healthcare020.WinUI.Helpers.CustomElements
{
    partial class pnlDisplayData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlNavButtons = new System.Windows.Forms.Panel();
            this.btnPrevPage = new FontAwesome.Sharp.IconButton();
            this.btnNextPage = new FontAwesome.Sharp.IconButton();
            this.dgrvKorisnickiNalozi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zaključaj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnNewUser = new FontAwesome.Sharp.IconButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.icnSearch = new FontAwesome.Sharp.IconPictureBox();
            this.pnlNavButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKorisnickiNalozi)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNavButtons
            // 
            this.pnlNavButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavButtons.Controls.Add(this.btnPrevPage);
            this.pnlNavButtons.Controls.Add(this.btnNextPage);
            this.pnlNavButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 429);
            this.pnlNavButtons.Name = "pnlNavButtons";
            this.pnlNavButtons.Size = new System.Drawing.Size(777, 58);
            this.pnlNavButtons.TabIndex = 4;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrevPage.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevPage.FlatAppearance.BorderSize = 0;
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPrevPage.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnPrevPage.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnPrevPage.IconSize = 40;
            this.btnPrevPage.Location = new System.Drawing.Point(275, 3);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Rotation = 0D;
            this.btnPrevPage.Size = new System.Drawing.Size(75, 37);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.UseVisualStyleBackColor = false;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNextPage.BackColor = System.Drawing.Color.Transparent;
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNextPage.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.btnNextPage.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnNextPage.IconSize = 40;
            this.btnNextPage.Location = new System.Drawing.Point(396, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Rotation = 0D;
            this.btnNextPage.Size = new System.Drawing.Size(75, 37);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.UseVisualStyleBackColor = false;
            // 
            // dgrvKorisnickiNalozi
            // 
            this.dgrvKorisnickiNalozi.AllowUserToAddRows = false;
            this.dgrvKorisnickiNalozi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgrvKorisnickiNalozi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrvKorisnickiNalozi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvKorisnickiNalozi.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = "N/A";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvKorisnickiNalozi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgrvKorisnickiNalozi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgrvKorisnickiNalozi.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgrvKorisnickiNalozi.Location = new System.Drawing.Point(0, 63);
            this.dgrvKorisnickiNalozi.Name = "dgrvKorisnickiNalozi";
            this.dgrvKorisnickiNalozi.ReadOnly = true;
            this.dgrvKorisnickiNalozi.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgrvKorisnickiNalozi.RowTemplate.Height = 30;
            this.dgrvKorisnickiNalozi.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvKorisnickiNalozi.Size = new System.Drawing.Size(777, 366);
            this.dgrvKorisnickiNalozi.TabIndex = 5;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 2;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.MinimumWidth = 2;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // DateCreated
            // 
            this.DateCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateCreated.DataPropertyName = "DateCreated";
            this.DateCreated.HeaderText = "Datum kreiranja";
            this.DateCreated.MinimumWidth = 2;
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
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
            this.Zaključaj.HeaderText = "Zaključavanje";
            this.Zaključaj.MinimumWidth = 2;
            this.Zaključaj.Name = "Zaključaj";
            this.Zaključaj.ReadOnly = true;
            this.Zaključaj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Zaključaj.Text = "Zaključaj";
            this.Zaključaj.ToolTipText = "Zaključaj korisnički nalog na određeni broj sati";
            this.Zaključaj.UseColumnTextForButtonValue = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnNewUser);
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(777, 57);
            this.pnlTop.TabIndex = 8;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnNewUser.Location = new System.Drawing.Point(642, 13);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Rotation = 0D;
            this.btnNewUser.Size = new System.Drawing.Size(84, 30);
            this.btnNewUser.TabIndex = 4;
            this.btnNewUser.Text = "Novi ";
            this.btnNewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewUser.UseVisualStyleBackColor = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.icnSearch);
            this.pnlSearch.Location = new System.Drawing.Point(49, 15);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(200, 30);
            this.pnlSearch.TabIndex = 5;
            // 
            // txtSearch
            // 
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Hint = "";
            this.txtSearch.Location = new System.Drawing.Point(38, 4);
            this.txtSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.Size = new System.Drawing.Size(159, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.UseSystemPasswordChar = false;
            // 
            // icnSearch
            // 
            this.icnSearch.BackColor = System.Drawing.Color.White;
            this.icnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.icnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.icnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.icnSearch.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.icnSearch.IconSize = 30;
            this.icnSearch.Location = new System.Drawing.Point(0, 0);
            this.icnSearch.Name = "icnSearch";
            this.icnSearch.Size = new System.Drawing.Size(32, 30);
            this.icnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icnSearch.TabIndex = 0;
            this.icnSearch.TabStop = false;
            // 
            // pnlDisplayData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgrvKorisnickiNalozi);
            this.Controls.Add(this.pnlNavButtons);
            this.Name = "pnlDisplayData";
            this.Size = new System.Drawing.Size(777, 487);
            this.pnlNavButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvKorisnickiNalozi)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icnSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavButtons;
        private FontAwesome.Sharp.IconButton btnPrevPage;
        private FontAwesome.Sharp.IconButton btnNextPage;
        private System.Windows.Forms.DataGridView dgrvKorisnickiNalozi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewButtonColumn Zaključaj;
        private System.Windows.Forms.Panel pnlTop;
        private FontAwesome.Sharp.IconButton btnNewUser;
        private System.Windows.Forms.Panel pnlSearch;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSearch;
        private FontAwesome.Sharp.IconPictureBox icnSearch;
    }
}
