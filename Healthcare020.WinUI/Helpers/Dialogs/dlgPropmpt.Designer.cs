using Healthcare020.WinUI.Helpers.CustomElements;

namespace Healthcare020.WinUI.Helpers.Dialogs
{
    partial class dlgPropmpt
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
            this.btnCancel = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.btnYes = new Healthcare020.WinUI.Helpers.CustomElements.Button_WOC();
            this.label1 = new System.Windows.Forms.Label();
            this.icnDanger = new FontAwesome.Sharp.IconPictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnDanger)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnYes);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.icnDanger);
            this.pnlBody.Location = new System.Drawing.Point(309, 166);
            this.pnlBody.MaximumSize = new System.Drawing.Size(358, 195);
            this.pnlBody.MinimumSize = new System.Drawing.Size(358, 195);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(358, 195);
            this.pnlBody.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ButtonColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(74, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(105, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Poništi";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.BorderColor = System.Drawing.Color.Transparent;
            this.btnYes.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(97)))), ((int)(((byte)(102)))));
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(185, 144);
            this.btnYes.Name = "btnYes";
            this.btnYes.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.btnYes.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.btnYes.OnHoverTextColor = System.Drawing.Color.White;
            this.btnYes.Size = new System.Drawing.Size(105, 40);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Da !";
            this.btnYes.TextColor = System.Drawing.Color.White;
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label1.Location = new System.Drawing.Point(102, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jeste li sigurni?";
            // 
            // icnDanger
            // 
            this.icnDanger.BackColor = System.Drawing.Color.Transparent;
            this.icnDanger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(188)))), ((int)(((byte)(130)))));
            this.icnDanger.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.icnDanger.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(188)))), ((int)(((byte)(130)))));
            this.icnDanger.IconSize = 98;
            this.icnDanger.Location = new System.Drawing.Point(138, 3);
            this.icnDanger.Name = "icnDanger";
            this.icnDanger.Size = new System.Drawing.Size(109, 98);
            this.icnDanger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icnDanger.TabIndex = 0;
            this.icnDanger.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(996, 546);
            this.pnlMain.TabIndex = 1;
            // 
            // dlgPropmpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 546);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dlgPropmpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgPropmpt";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.dlgPropmpt_Load);
            this.Shown += new System.EventHandler(this.dlgPropmpt_Shown);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icnDanger)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private FontAwesome.Sharp.IconPictureBox icnDanger;
        private Button_WOC btnYes;
        private System.Windows.Forms.Label label1;
        private Button_WOC btnCancel;
        private System.Windows.Forms.Panel pnlMain;
    }
}