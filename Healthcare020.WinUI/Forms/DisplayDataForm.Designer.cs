namespace Healthcare020.WinUI.Forms
{
    partial class DisplayDataForm<TDto>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgrvMain = new System.Windows.Forms.DataGridView();
            this.btnPrevPage = new FontAwesome.Sharp.IconButton();
            this.btnNextPage = new FontAwesome.Sharp.IconButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtSearch = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnNew = new FontAwesome.Sharp.IconButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.icnSearch = new FontAwesome.Sharp.IconPictureBox();
            this.pnlNavButtons = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvMain)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnSearch)).BeginInit();
            this.pnlNavButtons.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrvMain
            // 
            this.dgrvMain.AllowUserToAddRows = false;
            this.dgrvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.dgrvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgrvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgrvMain.ColumnHeadersHeight = 29;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.Format = "d";
            dataGridViewCellStyle19.NullValue = "N/A";
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrvMain.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgrvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrvMain.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgrvMain.Location = new System.Drawing.Point(0, 57);
            this.dgrvMain.Name = "dgrvMain";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgrvMain.RowHeadersWidth = 51;
            this.dgrvMain.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.dgrvMain.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgrvMain.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgrvMain.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.dgrvMain.RowTemplate.Height = 30;
            this.dgrvMain.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrvMain.Size = new System.Drawing.Size(777, 430);
            this.dgrvMain.TabIndex = 0;
            this.dgrvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvMain_CellContentClick);
            this.dgrvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvMain_CellDoubleClick);
            this.dgrvMain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgrvMain_CellFormatting);
            this.dgrvMain.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrvMain_CellValueChanged);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrevPage.BackColor = System.Drawing.Color.Transparent;
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
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click_1);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNextPage.BackColor = System.Drawing.Color.Transparent;
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
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click_1);
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
            this.toolTip.SetToolTip(this.txtSearch, "Pretraga korisnika po korisničkom imenu");
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNew.IconColor = System.Drawing.Color.White;
            this.btnNew.IconSize = 25;
            this.btnNew.Location = new System.Drawing.Point(642, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Rotation = 0D;
            this.btnNew.Size = new System.Drawing.Size(84, 30);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Dodaj ";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
            // pnlNavButtons
            // 
            this.pnlNavButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavButtons.Controls.Add(this.btnPrevPage);
            this.pnlNavButtons.Controls.Add(this.btnNextPage);
            this.pnlNavButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavButtons.Location = new System.Drawing.Point(0, 429);
            this.pnlNavButtons.Name = "pnlNavButtons";
            this.pnlNavButtons.Size = new System.Drawing.Size(777, 58);
            this.pnlNavButtons.TabIndex = 3;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(777, 57);
            this.pnlTop.TabIndex = 7;
            // 
            // DisplayDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(777, 487);
            this.Controls.Add(this.pnlNavButtons);
            this.Controls.Add(this.dgrvMain);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DisplayDataForm";
            this.Text = "frmUsers";
            this.Load += new System.EventHandler(this.DisplayDataForm_Load);
            this.SizeChanged += new System.EventHandler(this.DisplayDataForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvMain)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icnSearch)).EndInit();
            this.pnlNavButtons.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView dgrvMain;
        protected FontAwesome.Sharp.IconButton btnPrevPage;
        protected FontAwesome.Sharp.IconButton btnNextPage;
        protected System.Windows.Forms.ToolTip toolTip;
        protected FontAwesome.Sharp.IconButton btnNew;
        protected System.Windows.Forms.Panel pnlSearch;
        protected FontAwesome.Sharp.IconPictureBox icnSearch;
        protected MaterialSkin.Controls.MaterialSingleLineTextField txtSearch;
        protected System.Windows.Forms.Panel pnlNavButtons;
        protected System.Windows.Forms.Panel pnlTop;
    }
}