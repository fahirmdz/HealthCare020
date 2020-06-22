namespace Healthcare020.WinUI.Forms
{
    partial class MainForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.pnlControlBox = new System.Windows.Forms.Panel();
            this.picMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.picMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.picClose = new FontAwesome.Sharp.IconPictureBox();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.pnlControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.panelTop.Controls.Add(this.pnlControlBox);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1208, 37);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMainForm_MouseDown);
            // 
            // pnlControlBox
            // 
            this.pnlControlBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlControlBox.Controls.Add(this.picMaximize);
            this.pnlControlBox.Controls.Add(this.picMinimize);
            this.pnlControlBox.Controls.Add(this.picClose);
            this.pnlControlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControlBox.Location = new System.Drawing.Point(1058, 0);
            this.pnlControlBox.Name = "pnlControlBox";
            this.pnlControlBox.Size = new System.Drawing.Size(150, 37);
            this.pnlControlBox.TabIndex = 10;
            // 
            // picMaximize
            // 
            this.picMaximize.BackColor = System.Drawing.Color.Transparent;
            this.picMaximize.ForeColor = System.Drawing.SystemColors.Window;
            this.picMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.picMaximize.IconColor = System.Drawing.SystemColors.Window;
            this.picMaximize.IconSize = 37;
            this.picMaximize.Location = new System.Drawing.Point(50, 0);
            this.picMaximize.Name = "picMaximize";
            this.picMaximize.Size = new System.Drawing.Size(50, 37);
            this.picMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMaximize.TabIndex = 13;
            this.picMaximize.TabStop = false;
            this.picMaximize.Click += new System.EventHandler(this.picMaximize_Click);
            this.picMaximize.MouseLeave += new System.EventHandler(this.picMaximize_MouseLeave);
            this.picMaximize.MouseHover += new System.EventHandler(this.picMaximize_MouseHover);
            // 
            // picMinimize
            // 
            this.picMinimize.BackColor = System.Drawing.Color.Transparent;
            this.picMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.picMinimize.IconColor = System.Drawing.Color.White;
            this.picMinimize.IconSize = 37;
            this.picMinimize.Location = new System.Drawing.Point(0, 0);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(50, 37);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 12;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            this.picMinimize.MouseLeave += new System.EventHandler(this.picMinimize_MouseLeave);
            this.picMinimize.MouseHover += new System.EventHandler(this.picMinimize_MouseHover);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.picClose.IconColor = System.Drawing.Color.White;
            this.picClose.IconSize = 37;
            this.picClose.Location = new System.Drawing.Point(100, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(50, 37);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 11;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click_1);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            this.picClose.MouseHover += new System.EventHandler(this.picClose_MouseHover);
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.White;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 37);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1208, 630);
            this.panelDesktop.TabIndex = 12;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1208, 667);
            this.ControlBox = false;
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelTop.ResumeLayout(false);
            this.pnlControlBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel pnlControlBox;
        private FontAwesome.Sharp.IconPictureBox picClose;
        private FontAwesome.Sharp.IconPictureBox picMaximize;
        private FontAwesome.Sharp.IconPictureBox picMinimize;
    }
}

