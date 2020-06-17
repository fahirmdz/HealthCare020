namespace Healthcare020.WinUI.Helpers.CustomElements
{
    partial class PanelCheckInternetConnection
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
            this.icnExclamation = new FontAwesome.Sharp.IconPictureBox();
            this.lblCheckConnection = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDescriptionTwo = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnRetryConnection = new Button_WOC();
            ((System.ComponentModel.ISupportInitialize)(this.icnExclamation)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // icnExclamation
            // 
            this.icnExclamation.BackColor = System.Drawing.Color.Transparent;
            this.icnExclamation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(187)))), ((int)(((byte)(2)))));
            this.icnExclamation.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.icnExclamation.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(187)))), ((int)(((byte)(2)))));
            this.icnExclamation.IconSize = 127;
            this.icnExclamation.Location = new System.Drawing.Point(120, 14);
            this.icnExclamation.Name = "icnExclamation";
            this.icnExclamation.Size = new System.Drawing.Size(132, 127);
            this.icnExclamation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icnExclamation.TabIndex = 0;
            this.icnExclamation.TabStop = false;
            // 
            // lblCheckConnection
            // 
            this.lblCheckConnection.AutoSize = true;
            this.lblCheckConnection.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckConnection.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lblCheckConnection.Location = new System.Drawing.Point(72, 144);
            this.lblCheckConnection.Name = "lblCheckConnection";
            this.lblCheckConnection.Size = new System.Drawing.Size(233, 33);
            this.lblCheckConnection.TabIndex = 1;
            this.lblCheckConnection.Text = "Proverite konekciju";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lblDescription.Location = new System.Drawing.Point(7, 200);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(347, 19);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Čini se kao da nemate aktivnu internet konekciju.";
            // 
            // lblDescriptionTwo
            // 
            this.lblDescriptionTwo.AutoSize = true;
            this.lblDescriptionTwo.BackColor = System.Drawing.Color.Transparent;
            this.lblDescriptionTwo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionTwo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lblDescriptionTwo.Location = new System.Drawing.Point(23, 219);
            this.lblDescriptionTwo.Name = "lblDescriptionTwo";
            this.lblDescriptionTwo.Size = new System.Drawing.Size(313, 19);
            this.lblDescriptionTwo.TabIndex = 3;
            this.lblDescriptionTwo.Text = "Molimo vas da proverite i pokušate ponovo.";
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBody.Controls.Add(this.btnRetryConnection);
            this.pnlBody.Controls.Add(this.icnExclamation);
            this.pnlBody.Controls.Add(this.lblDescriptionTwo);
            this.pnlBody.Controls.Add(this.lblCheckConnection);
            this.pnlBody.Controls.Add(this.lblDescription);
            this.pnlBody.Location = new System.Drawing.Point(106, 13);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(359, 304);
            this.pnlBody.TabIndex = 4;
            // 
            // btnRetryConnection
            // 
            this.btnRetryConnection.BorderColor = System.Drawing.Color.Transparent;
            this.btnRetryConnection.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.btnRetryConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetryConnection.FlatAppearance.BorderSize = 0;
            this.btnRetryConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRetryConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRetryConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetryConnection.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetryConnection.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRetryConnection.Location = new System.Drawing.Point(90, 251);
            this.btnRetryConnection.Name = "btnRetryConnection";
            this.btnRetryConnection.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnRetryConnection.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(132)))), ((int)(((byte)(156)))));
            this.btnRetryConnection.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRetryConnection.Size = new System.Drawing.Size(184, 35);
            this.btnRetryConnection.TabIndex = 4;
            this.btnRetryConnection.Text = "Pokušaj ponovo";
            this.btnRetryConnection.TextColor = System.Drawing.Color.White;
            this.btnRetryConnection.UseVisualStyleBackColor = true;
            // 
            // PanelCheckInternetConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBody);
            this.Name = "PanelCheckInternetConnection";
            this.Size = new System.Drawing.Size(573, 375);
            this.Load += new System.EventHandler(this.PanelCheckInternetConnection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icnExclamation)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox icnExclamation;
        private System.Windows.Forms.Label lblCheckConnection;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDescriptionTwo;
        private System.Windows.Forms.Panel pnlBody;
        private Button_WOC btnRetryConnection;
    }
}
