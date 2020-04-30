namespace Healthcare020.WinUI.Gradovi
{
    partial class frmGradoviPrikaz
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
            this.dgrvGradoviPrikaz = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrzavaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvGradoviPrikaz)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrvGradoviPrikaz
            // 
            this.dgrvGradoviPrikaz.AllowUserToAddRows = false;
            this.dgrvGradoviPrikaz.AllowUserToDeleteRows = false;
            this.dgrvGradoviPrikaz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrvGradoviPrikaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvGradoviPrikaz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.DrzavaId,
            this.Naziv});
            this.dgrvGradoviPrikaz.Location = new System.Drawing.Point(12, 166);
            this.dgrvGradoviPrikaz.Name = "dgrvGradoviPrikaz";
            this.dgrvGradoviPrikaz.ReadOnly = true;
            this.dgrvGradoviPrikaz.Size = new System.Drawing.Size(776, 272);
            this.dgrvGradoviPrikaz.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // DrzavaId
            // 
            this.DrzavaId.DataPropertyName = "drzavaId";
            this.DrzavaId.HeaderText = "Drzava ID";
            this.DrzavaId.Name = "DrzavaId";
            this.DrzavaId.ReadOnly = true;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // frmGradoviPrikaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dgrvGradoviPrikaz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGradoviPrikaz";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGradoviPrikaz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrvGradoviPrikaz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrvGradoviPrikaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrzavaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
    }
}