namespace Healthcare020.WinUI.Helpers.CustomElements
{
    partial class NoDataPanel
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
            this.IcnData = new FontAwesome.Sharp.IconPictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnRetry = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.IcnData)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // IcnData
            // 
            this.IcnData.BackColor = System.Drawing.Color.White;
            this.IcnData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.IcnData.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.IcnData.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.IcnData.IconSize = 134;
            this.IcnData.Location = new System.Drawing.Point(258, 15);
            this.IcnData.Name = "IcnData";
            this.IcnData.Size = new System.Drawing.Size(145, 134);
            this.IcnData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IcnData.TabIndex = 0;
            this.IcnData.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMain.Controls.Add(this.lblMessage);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Location = new System.Drawing.Point(42, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(668, 410);
            this.pnlMain.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRetry);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 139);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.IcnData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 165);
            this.panel2.TabIndex = 20;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lblMessage.Location = new System.Drawing.Point(152, 168);
            this.lblMessage.MaximumSize = new System.Drawing.Size(362, 100);
            this.lblMessage.MinimumSize = new System.Drawing.Size(362, 100);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(362, 100);
            this.lblMessage.TabIndex = 21;
            this.lblMessage.Text = "Trenutno nema dostupnih podataka";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRetry
            // 
            this.btnRetry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRetry.BackColor = System.Drawing.Color.White;
            this.btnRetry.BorderColor = System.Drawing.Color.Transparent;
            this.btnRetry.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnRetry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetry.FlatAppearance.BorderSize = 0;
            this.btnRetry.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRetry.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.Location = new System.Drawing.Point(241, 13);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnRetry.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.btnRetry.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRetry.Size = new System.Drawing.Size(173, 45);
            this.btnRetry.TabIndex = 18;
            this.btnRetry.Text = "Osveži";
            this.btnRetry.TextColor = System.Drawing.Color.White;
            this.btnRetry.UseVisualStyleBackColor = false;
            // 
            // NoDataPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Name = "NoDataPanel";
            this.Size = new System.Drawing.Size(766, 410);
            this.SizeChanged += new System.EventHandler(this.NoDataPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.IcnData)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button_WOC btnRetry;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMessage;
    }
}
