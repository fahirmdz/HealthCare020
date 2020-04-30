namespace Healthcare020.WinUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMaximize = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.panelMainForm = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(968, 14);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(16, 23);
            this.picClose.TabIndex = 7;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMaximize
            // 
            this.picMaximize.Image = ((System.Drawing.Image)(resources.GetObject("picMaximize.Image")));
            this.picMaximize.Location = new System.Drawing.Point(937, 12);
            this.picMaximize.Name = "picMaximize";
            this.picMaximize.Size = new System.Drawing.Size(25, 25);
            this.picMaximize.TabIndex = 8;
            this.picMaximize.TabStop = false;
            this.picMaximize.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.Image = ((System.Drawing.Image)(resources.GetObject("picMinimize.Image")));
            this.picMinimize.Location = new System.Drawing.Point(906, 12);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(25, 25);
            this.picMinimize.TabIndex = 9;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panelMainForm
            // 
            this.panelMainForm.Location = new System.Drawing.Point(3, 2);
            this.panelMainForm.Name = "panelMainForm";
            this.panelMainForm.Size = new System.Drawing.Size(993, 47);
            this.panelMainForm.TabIndex = 10;
            this.panelMainForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMainForm_MouseDown);
            this.panelMainForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMainForm_MouseMove);
            this.panelMainForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMainForm_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panelMainForm);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picMaximize);
            this.Controls.Add(this.picClose);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMaximize;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.Panel panelMainForm;
    }
}

