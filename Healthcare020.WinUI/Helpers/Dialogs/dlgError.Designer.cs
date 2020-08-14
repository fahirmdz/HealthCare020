namespace Healthcare020.WinUI.Helpers.Dialogs
{
    sealed partial class dlgError
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.icnError = new FontAwesome.Sharp.IconPictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnError)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Controls.Add(this.icnError);
            this.pnlBody.Location = new System.Drawing.Point(299, 165);
            this.pnlBody.MaximumSize = new System.Drawing.Size(362, 199);
            this.pnlBody.MinimumSize = new System.Drawing.Size(362, 199);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(362, 199);
            this.pnlBody.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblError
            // 
            this.lblError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.MaximumSize = new System.Drawing.Size(362, 100);
            this.lblError.MinimumSize = new System.Drawing.Size(362, 100);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(362, 100);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "Greška!";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // icnError
            // 
            this.icnError.BackColor = System.Drawing.Color.Transparent;
            this.icnError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(97)))), ((int)(((byte)(102)))));
            this.icnError.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.icnError.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(97)))), ((int)(((byte)(102)))));
            this.icnError.IconSize = 105;
            this.icnError.Location = new System.Drawing.Point(128, 12);
            this.icnError.Name = "icnError";
            this.icnError.Size = new System.Drawing.Size(116, 105);
            this.icnError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icnError.TabIndex = 0;
            this.icnError.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 550);
            this.pnlMain.TabIndex = 2;
            // 
            // dlgError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dlgError";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgError";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.dlgError_Load);
            this.Shown += new System.EventHandler(this.dlgError_Shown);
            this.pnlBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icnError)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblError;
        private FontAwesome.Sharp.IconPictureBox icnError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMain;
    }
}