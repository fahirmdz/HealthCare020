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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.userMenuDropdown = new Healthcare020.WinUI.Helpers.CustomElements.UserMenuDropdownPanel();
            this.btnUserMenu = new Healthcare020.WinUI.Helpers.CustomElements.UserMenuButton();
            this.panelTop.SuspendLayout();
            this.pnlControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panelDesktop.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserMenu)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(1208, 31);
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
            this.pnlControlBox.Location = new System.Drawing.Point(1079, 0);
            this.pnlControlBox.Name = "pnlControlBox";
            this.pnlControlBox.Size = new System.Drawing.Size(129, 31);
            this.pnlControlBox.TabIndex = 10;
            // 
            // picMaximize
            // 
            this.picMaximize.BackColor = System.Drawing.Color.Transparent;
            this.picMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMaximize.ForeColor = System.Drawing.SystemColors.Window;
            this.picMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.picMaximize.IconColor = System.Drawing.SystemColors.Window;
            this.picMaximize.IconSize = 31;
            this.picMaximize.Location = new System.Drawing.Point(50, 0);
            this.picMaximize.Name = "picMaximize";
            this.picMaximize.Size = new System.Drawing.Size(35, 31);
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
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.picMinimize.IconColor = System.Drawing.Color.White;
            this.picMinimize.IconSize = 31;
            this.picMinimize.Location = new System.Drawing.Point(0, 0);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(53, 31);
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
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.picClose.IconColor = System.Drawing.Color.White;
            this.picClose.IconSize = 31;
            this.picClose.Location = new System.Drawing.Point(85, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(44, 31);
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
            this.panelDesktop.Controls.Add(this.userMenuDropdown);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 73);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1208, 594);
            this.panelDesktop.TabIndex = 12;
            this.panelDesktop.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelDesktop_ControlAdded);
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.pnlTop.Controls.Add(this.btnUserMenu);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 31);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1208, 42);
            this.pnlTop.TabIndex = 12;
            // 
            // userMenuDropdown
            // 
            this.userMenuDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userMenuDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userMenuDropdown.Location = new System.Drawing.Point(961, 0);
            this.userMenuDropdown.Name = "userMenuDropdown";
            this.userMenuDropdown.Size = new System.Drawing.Size(247, 97);
            this.userMenuDropdown.TabIndex = 0;
            this.userMenuDropdown.Toggler = this.btnUserMenu;
            this.userMenuDropdown.Visible = false;
            // 
            // btnUserMenu
            // 
            this.btnUserMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnUserMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUserMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.btnUserMenu.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnUserMenu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.btnUserMenu.IconSize = 42;
            this.btnUserMenu.Location = new System.Drawing.Point(1150, 0);
            this.btnUserMenu.Name = "btnUserMenu";
            this.btnUserMenu.Size = new System.Drawing.Size(58, 42);
            this.btnUserMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnUserMenu.TabIndex = 0;
            this.btnUserMenu.TabStop = false;
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
            this.Controls.Add(this.pnlTop);
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
            this.panelDesktop.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnUserMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel pnlControlBox;
        private FontAwesome.Sharp.IconPictureBox picClose;
        private FontAwesome.Sharp.IconPictureBox picMaximize;
        private FontAwesome.Sharp.IconPictureBox picMinimize;
        private System.Windows.Forms.Panel pnlTop;
        private Helpers.CustomElements.UserMenuDropdownPanel userMenuDropdown;
        private Helpers.CustomElements.UserMenuButton btnUserMenu;
    }
}

