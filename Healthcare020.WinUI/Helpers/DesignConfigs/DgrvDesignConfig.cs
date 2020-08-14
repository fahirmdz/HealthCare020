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
            dgrv.DefaultCellStyle.Padding = new Padding(0, 6, 0, 0);
            dgrv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgrv.BackgroundColor = Color.White;
            dgrv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgrv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(54, 52, 52);
            dgrv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 190, 190);
            dgrv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dgrv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            dgrv.ColumnHeadersDefaultCellStyle.NullValue = "N/A";
            dgrv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(49, 102, 115);
            dgrv.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dgrv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgrv.ColumnHeadersHeight = 35;

            dgrv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgrv.DefaultCellStyle.BackColor = Color.White;
            dgrv.DefaultCellStyle.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgrv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dgrv.DefaultCellStyle.Format = "d";
            dgrv.DefaultCellStyle.NullValue = "N/A";
            dgrv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 96, 117);
            dgrv.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dgrv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgrv.Dock = DockStyle.Fill;
            dgrv.GridColor = SystemColors.ButtonFace;
            dgrv.RowTemplate.DefaultCellStyle.Padding = new Padding(0, 6, 0, 0);
            dgrv.RowTemplate.Height = 30;
            dgrv.RowTemplate.Resizable = DataGridViewTriState.True;
            dgrv.TabIndex = 0;
        }

        /// <summary>
        /// Returns data grid view rows count, based on height of passed control
        /// </summary>
        /// <returns></returns>
        public static int GetRowsCount(this DataGridView dgrv) => dgrv.Height / dgrv.RowTemplate.Height -3;
    }
}