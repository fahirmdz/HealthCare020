using System.Drawing;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Helpers.DesignConfigs
{
    public static class DgrvDesignConfig
    {
        public static void SetDgrvDesignConfig(this DataGridView dgrv)
        {
            dgrv.EnableHeadersVisualStyles = false;
            dgrv.ReadOnly = false;
            dgrv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgrv.BorderStyle = BorderStyle.None;
            dgrv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgrv.AutoGenerateColumns = false;
            dgrv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);

            dgrv.AllowUserToAddRows = false;
            dgrv.AllowUserToDeleteRows = false;
            dgrv.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            dgrv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgrv.BackgroundColor = System.Drawing.Color.White;
            dgrv.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgrv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(54, 52, 52);
            dgrv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 190, 190);
            dgrv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgrv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            dgrv.ColumnHeadersDefaultCellStyle.NullValue = "N/A";
            dgrv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(102)))), ((int)(((byte)(115)))));
            dgrv.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgrv.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgrv.ColumnHeadersHeight = 35;

            dgrv.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgrv.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgrv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgrv.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            dgrv.DefaultCellStyle.Format = "d";
            dgrv.DefaultCellStyle.NullValue = "N/A";
            dgrv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            dgrv.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dgrv.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgrv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgrv.GridColor = System.Drawing.SystemColors.ButtonFace;
            dgrv.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            dgrv.RowTemplate.Height = 30;
            dgrv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            dgrv.TabIndex = 0;
        }

        /// <summary>
        /// Returns data grid view rows count, based on height of passed control
        /// </summary>
        /// <returns></returns>
        public static int GetRowsCount(this DataGridView dgrv) => dgrv.Height / dgrv.RowTemplate.Height -3;
    }
}