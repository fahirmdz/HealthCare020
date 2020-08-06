namespace Healthcare020.WinUI.Helpers.Dialogs
{
    partial class dlgForm   
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
            this.pnlSide = new System.Windows.Forms.Panel();
            this.txtLeftTitle = new System.Windows.Forms.RichTextBox();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody.SuspendLayout();
            this.pnlSide.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.pnlBody.Controls.Add(this.pnlSide);
            this.pnlBody.Location = new System.Drawing.Point(200, 152);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(803, 377);
            this.pnlBody.TabIndex = 1;
            this.pnlBody.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlBody_ControlAdded);
            this.pnlBody.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlBody_ControlRemoved);
            // 
            // pnlSide
            // 
            this.pnlSide.Controls.Add(this.txtLeftTitle);
            this.pnlSide.Controls.Add(this.btnClose);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(59, 377);
            this.pnlSide.TabIndex = 2;
            // 
            // txtLeftTitle
            // 
            this.txtLeftTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.txtLeftTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLeftTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtLeftTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtLeftTitle.Location = new System.Drawing.Point(26, 78);
            this.txtLeftTitle.Name = "txtLeftTitle";
            this.txtLeftTitle.ReadOnly = true;
            this.txtLeftTitle.Size = new System.Drawing.Size(17, 257);
            this.txtLeftTitle.TabIndex = 3;
            this.txtLeftTitle.Text = "He a l  t hcare   ";
            this.txtLeftTitle.SelectionChanged += new System.EventHandler(this.txtLeftTitle_SelectionChanged);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnClose.IconSize = 45;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Rotation = 0D;
            this.btnClose.Size = new System.Drawing.Size(59, 54);
            this.btnClose.TabIndex = 61;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1224, 683);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseClick);
            // 
            // dlgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1224, 683);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dlgForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgError";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.dlgForm_Load);
            this.Shown += new System.EventHandler(this.dlgForm_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dlgForm_KeyPress);
            this.pnlBody.ResumeLayout(false);
            this.pnlSide.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSide;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.RichTextBox txtLeftTitle;
    }
}