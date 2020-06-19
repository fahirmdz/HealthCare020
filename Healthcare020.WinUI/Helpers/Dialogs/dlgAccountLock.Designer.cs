using Healthcare020.WinUI.Helpers.CustomElements;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    partial class dlgAccountLock
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
            this.dlgPrompt = new System.Windows.Forms.Panel();
            this.lblHours = new System.Windows.Forms.Label();
            this.btnLockOk = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.cmbBrojSati = new System.Windows.Forms.ComboBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dlgPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgPrompt
            // 
            this.dlgPrompt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dlgPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.dlgPrompt.Controls.Add(this.lblHours);
            this.dlgPrompt.Controls.Add(this.btnLockOk);
            this.dlgPrompt.Controls.Add(this.btnClose);
            this.dlgPrompt.Controls.Add(this.cmbBrojSati);
            this.dlgPrompt.Location = new System.Drawing.Point(347, 174);
            this.dlgPrompt.MaximumSize = new System.Drawing.Size(264, 164);
            this.dlgPrompt.MinimumSize = new System.Drawing.Size(264, 164);
            this.dlgPrompt.Name = "dlgPrompt";
            this.dlgPrompt.Size = new System.Drawing.Size(264, 164);
            this.dlgPrompt.TabIndex = 1;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHours.Location = new System.Drawing.Point(57, 29);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(155, 23);
            this.lblHours.TabIndex = 14;
            this.lblHours.Text = "Odaberite broj sati";
            // 
            // btnLockOk
            // 
            this.btnLockOk.BackColor = System.Drawing.Color.Transparent;
            this.btnLockOk.BorderColor = System.Drawing.Color.Transparent;
            this.btnLockOk.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnLockOk.FlatAppearance.BorderSize = 0;
            this.btnLockOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLockOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLockOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockOk.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLockOk.Location = new System.Drawing.Point(89, 110);
            this.btnLockOk.Name = "btnLockOk";
            this.btnLockOk.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnLockOk.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(210)))), ((int)(((byte)(204)))));
            this.btnLockOk.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLockOk.Size = new System.Drawing.Size(93, 37);
            this.btnLockOk.TabIndex = 13;
            this.btnLockOk.Text = "OK";
            this.btnLockOk.TextColor = System.Drawing.Color.White;
            this.btnLockOk.UseVisualStyleBackColor = false;
            this.btnLockOk.Click += new System.EventHandler(this.btnLockOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconSize = 27;
            this.btnClose.Location = new System.Drawing.Point(228, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 27);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClose.TabIndex = 12;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbBrojSati
            // 
            this.cmbBrojSati.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBrojSati.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBrojSati.FormattingEnabled = true;
            this.cmbBrojSati.Location = new System.Drawing.Point(57, 64);
            this.cmbBrojSati.Name = "cmbBrojSati";
            this.cmbBrojSati.Size = new System.Drawing.Size(157, 31);
            this.cmbBrojSati.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dlgPrompt);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(996, 546);
            this.pnlMain.TabIndex = 2;
            // 
            // dlgAccountLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 546);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dlgAccountLock";
            this.Text = "dlgAccountLock";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.dlgAccountLock_Load);
            this.Shown += new System.EventHandler(this.dlgAccountLock_Shown);
            this.dlgPrompt.ResumeLayout(false);
            this.dlgPrompt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel dlgPrompt;
        private System.Windows.Forms.ComboBox cmbBrojSati;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private Button_WOC btnLockOk;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Panel pnlMain;
    }
}