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
            this.icnData = new FontAwesome.Sharp.IconPictureBox();
            this.lblNoData = new System.Windows.Forms.Label();
            this.btnRetry = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.icnData)).BeginInit();
            this.SuspendLayout();
            // 
            // icnData
            // 
            this.icnData.BackColor = System.Drawing.Color.White;
            this.icnData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.icnData.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.icnData.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.icnData.IconSize = 134;
            this.icnData.Location = new System.Drawing.Point(202, 69);
            this.icnData.Name = "icnData";
            this.icnData.Size = new System.Drawing.Size(145, 134);
            this.icnData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icnData.TabIndex = 0;
            this.icnData.TabStop = false;
            // 
            // lblNoData
            // 
            this.lblNoData.AutoSize = true;
            this.lblNoData.BackColor = System.Drawing.Color.Transparent;
            this.lblNoData.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lblNoData.Location = new System.Drawing.Point(68, 206);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(425, 32);
            this.lblNoData.TabIndex = 4;
            this.lblNoData.Text = "Trenutno nema dostupnih podataka";
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
            this.btnRetry.Location = new System.Drawing.Point(183, 264);
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
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.lblNoData);
            this.Controls.Add(this.icnData);
            this.Name = "NoDataPanel";
            this.Size = new System.Drawing.Size(571, 410);
            ((System.ComponentModel.ISupportInitialize)(this.icnData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox icnData;
        private System.Windows.Forms.Label lblNoData;
        private Button_WOC btnRetry;
    }
}
