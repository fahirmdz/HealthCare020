namespace Healthcare020.WinUI.Forms.AdminDashboard.PredefinedData
{
    sealed partial class frmNewZdravstvenoStanje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewZdravstvenoStanje));
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDialog = new System.Windows.Forms.Panel();
            this.lblOpis = new System.Windows.Forms.Label();
            this.btnSave = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.txtOpis = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // Errors
            // 
            this.Errors.ContainerControl = this;
            this.Errors.Icon = ((System.Drawing.Icon)(resources.GetObject("Errors.Icon")));
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDialog);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 450);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDialog
            // 
            this.pnlDialog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.pnlDialog.Controls.Add(this.txtOpis);
            this.pnlDialog.Controls.Add(this.lblOpis);
            this.pnlDialog.Controls.Add(this.btnSave);
            this.pnlDialog.Controls.Add(this.btnClose);
            this.pnlDialog.Location = new System.Drawing.Point(225, 131);
            this.pnlDialog.Name = "pnlDialog";
            this.pnlDialog.Size = new System.Drawing.Size(321, 192);
            this.pnlDialog.TabIndex = 2;
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpis.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblOpis.Location = new System.Drawing.Point(143, 38);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(57, 29);
            this.lblOpis.TabIndex = 14;
            this.lblOpis.Text = "Opis";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(117, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(210)))), ((int)(((byte)(204)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(93, 37);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconSize = 27;
            this.btnClose.Location = new System.Drawing.Point(276, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 27);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClose.TabIndex = 12;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtOpis
            // 
            this.txtOpis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(107)))), ((int)(((byte)(130)))));
            this.txtOpis.Depth = 0;
            this.txtOpis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpis.ForeColor = System.Drawing.Color.White;
            this.txtOpis.Hint = "";
            this.txtOpis.Location = new System.Drawing.Point(68, 87);
            this.txtOpis.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.PasswordChar = '\0';
            this.txtOpis.SelectedText = "";
            this.txtOpis.SelectionLength = 0;
            this.txtOpis.SelectionStart = 0;
            this.txtOpis.Size = new System.Drawing.Size(203, 23);
            this.txtOpis.TabIndex = 21;
            this.txtOpis.UseSystemPasswordChar = false;
            // 
            // frmNewZdravstvenoStanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewZdravstvenoStanje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNewZdravstvenoStanje";
            this.Shown += new System.EventHandler(this.frmNewZdravstvenoStanje_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlDialog.ResumeLayout(false);
            this.pnlDialog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider Errors;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDialog;
        private System.Windows.Forms.Label lblOpis;
        private Helpers.CustomElements.Button_WOC btnSave;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtOpis;
    }
}