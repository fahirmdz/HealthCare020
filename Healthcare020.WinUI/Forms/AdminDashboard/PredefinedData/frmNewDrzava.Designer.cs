namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    sealed partial class frmNewDrzava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewDrzava));
            this.txtNaziv = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblNaziv = new MaterialSkin.Controls.MaterialLabel();
            this.lblPozivniBroj = new MaterialSkin.Controls.MaterialLabel();
            this.txtPozivniBroj = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNaziv.Depth = 0;
            this.txtNaziv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNaziv.Hint = "";
            this.txtNaziv.Location = new System.Drawing.Point(291, 112);
            this.txtNaziv.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.PasswordChar = '\0';
            this.txtNaziv.SelectedText = "";
            this.txtNaziv.SelectionLength = 0;
            this.txtNaziv.SelectionStart = 0;
            this.txtNaziv.Size = new System.Drawing.Size(203, 23);
            this.txtNaziv.TabIndex = 20;
            this.txtNaziv.UseSystemPasswordChar = false;
            // 
            // lblNaziv
            // 
            this.lblNaziv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Depth = 0;
            this.lblNaziv.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNaziv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNaziv.Location = new System.Drawing.Point(277, 78);
            this.lblNaziv.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(46, 19);
            this.lblNaziv.TabIndex = 19;
            this.lblNaziv.Text = "Naziv";
            // 
            // lblPozivniBroj
            // 
            this.lblPozivniBroj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPozivniBroj.AutoSize = true;
            this.lblPozivniBroj.Depth = 0;
            this.lblPozivniBroj.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPozivniBroj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPozivniBroj.Location = new System.Drawing.Point(277, 169);
            this.lblPozivniBroj.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPozivniBroj.Name = "lblPozivniBroj";
            this.lblPozivniBroj.Size = new System.Drawing.Size(87, 19);
            this.lblPozivniBroj.TabIndex = 18;
            this.lblPozivniBroj.Text = "Pozivni broj";
            // 
            // txtPozivniBroj
            // 
            this.txtPozivniBroj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPozivniBroj.Depth = 0;
            this.txtPozivniBroj.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPozivniBroj.Hint = "";
            this.txtPozivniBroj.Location = new System.Drawing.Point(291, 202);
            this.txtPozivniBroj.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPozivniBroj.Name = "txtPozivniBroj";
            this.txtPozivniBroj.PasswordChar = '\0';
            this.txtPozivniBroj.SelectedText = "";
            this.txtPozivniBroj.SelectionLength = 0;
            this.txtPozivniBroj.SelectionStart = 0;
            this.txtPozivniBroj.Size = new System.Drawing.Size(203, 23);
            this.txtPozivniBroj.TabIndex = 21;
            this.txtPozivniBroj.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(250, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(268, 34);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnBack);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(776, 70);
            this.pnlTop.TabIndex = 23;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnBack.IconSize = 25;
            this.btnBack.Location = new System.Drawing.Point(14, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Rotation = 0D;
            this.btnBack.Size = new System.Drawing.Size(88, 34);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.txtPozivniBroj);
            this.pnlMain.Controls.Add(this.lblPozivniBroj);
            this.pnlMain.Controls.Add(this.txtNaziv);
            this.pnlMain.Controls.Add(this.lblNaziv);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 70);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(776, 416);
            this.pnlMain.TabIndex = 24;
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // frmNewDrzava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(776, 486);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewDrzava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNewDrzava";
            this.Load += new System.EventHandler(this.frmNewDrzava_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtNaziv;
        private MaterialSkin.Controls.MaterialLabel lblNaziv;
        private MaterialSkin.Controls.MaterialLabel lblPozivniBroj;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPozivniBroj;
        private Helpers.CustomElements.Button_WOC btnSave;
        private System.Windows.Forms.Panel pnlTop;
        private FontAwesome.Sharp.IconButton btnBack;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ErrorProvider Errors;
    }
}