namespace Healthcare020.WinUI.Helpers.Dialogs
{
    partial class dlgSuccess
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
            this.label1 = new System.Windows.Forms.Label();
            this.icnSuccess = new FontAwesome.Sharp.IconPictureBox();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnSuccess)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.icnSuccess);
            this.pnlBody.Location = new System.Drawing.Point(327, 165);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(371, 209);
            this.pnlBody.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label1.Location = new System.Drawing.Point(143, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Uspešno!";
            // 
            // icnSuccess
            // 
            this.icnSuccess.BackColor = System.Drawing.Color.Transparent;
            this.icnSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.icnSuccess.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.icnSuccess.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.icnSuccess.IconSize = 98;
            this.icnSuccess.Location = new System.Drawing.Point(145, 27);
            this.icnSuccess.Name = "icnSuccess";
            this.icnSuccess.Size = new System.Drawing.Size(109, 98);
            this.icnSuccess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icnSuccess.TabIndex = 0;
            this.icnSuccess.TabStop = false;
            // 
            // dlgSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 562);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dlgSuccess";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgSuccess";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.dlgSuccess_Load);
            this.Shown += new System.EventHandler(this.dlgSuccess_Shown);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnSuccess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox icnSuccess;
    }
}