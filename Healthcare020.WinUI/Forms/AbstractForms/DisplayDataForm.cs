using Healthcare020.WinUI.Helpers;
using Healthcare020.WinUI.Helpers.CustomElements;
using Healthcare020.WinUI.Helpers.DesignConfigs;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.ResourceParameters;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare020.WinUI.Forms.AbstractForms
{
    public partial class DisplayDataForm<TDto> : Form
    {
        protected APIService _apiService;
        protected IBindingList _dataForDgrv;
        protected PanelCheckInternetConnection _internetError;
        protected int CurrentRowCount;
        protected DataGridView MainDgrv;
        protected int PossibleRowsCount;
        protected BaseResourceParameters ResourceParameters;
        protected Form FormForBackButton;

        protected string SearchText;

        protected DisplayDataForm()
        {
            InitializeComponent();
            _dataForDgrv = new BindingSource();
            SearchText = string.Empty;

            //Main data grid view settings
            dgrvMain.SetDgrvDesignConfig();
            MainDgrv = dgrvMain;
            dgrvMain.AllowUserToDeleteRows = true;

            btnPrevPage.Enabled = false;

            //Tool tips
            this.toolTip.SetToolTip(btnPrevPage, "Previous page");
            this.toolTip.SetToolTip(btnNextPage, "Next page");

            if (!ConnectionCheck.CheckForInternetConnection())
            {
                pnlTop.Hide();
                dgrvMain.Hide();
                pnlNavButtons.Hide();
                _internetError = new PanelCheckInternetConnection(this);
                _internetError.Show();
                _internetError.BringToFront();
                Controls.Add(_internetError);
                _internetError.SetRetryConnectionEvent(RetryConnection);
            }
        }

        public async Task RefreshData() => await LoadData();

        public async void RetryConnection(object sender, EventArgs e)
        {
            if (ConnectionCheck.CheckForInternetConnection())
            {
                _internetError.Hide();
                pnlTop.Show();
                dgrvMain.Show();
                pnlNavButtons.Show();
                await LoadData();
            }
        }

        protected void AddColumnsToMainDgrv(DataGridViewColumn[] dgrvColumns)
        {
            //POSTOJI B U G PRI DODAVANJU SEKVENCE SA AddRange
            foreach (var column in dgrvColumns)
            {
                dgrvMain.Columns.Insert(dgrvMain.Columns.Count, column);
            }
        }

        protected virtual void btnNew_Click(object sender, EventArgs e)
        {
        }

        protected void DgrvColumnsStyle()
        {
            for (int i = 0; i < dgrvMain.Columns.Count; i++)
            {
                var column = dgrvMain.Columns[i];
                column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                column.ReadOnly = true;
                column.MinimumWidth = 2;
            }
        }

        protected virtual void dgrvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected virtual void dgrvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected virtual void dgrvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Bind nested/complex types to DataGridView cell, e.g. Grad.Drzava.Naziv -> Drzava bug
            if (e.RowIndex >= CurrentRowCount - 1)
                return;

            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];
            if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
            {
                string[] props = col.DataPropertyName.Split('.');
                PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                if (propInfo == null)
                    return;
                object val = propInfo.GetValue(row.DataBoundItem, null);
                for (int i = 1; i < props.Length; i++)
                {
                    propInfo = val.GetType().GetProperty(props[i]);
                    val = propInfo.GetValue(val, null);
                }
                e.Value = val;
            }
        }

        protected virtual void dgrvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected void DisplayDataForm_Load(object sender, EventArgs e)
        {
            this.SizeChanged += formDisplayed_SizeChanged;
        }

        protected virtual async Task LoadData()
        {
            this.UseWaitCursor = true;

            var result = await _apiService
                .Get<TDto>(ResourceParameters);

            if (!result.Succeeded || !result.HasData)
                return;

            _dataForDgrv = new BindingList<TDto>(result.Data);
            CurrentRowCount = _dataForDgrv.Count;

            dgrvMain.DataSource = _dataForDgrv;

            btnNextPage.Enabled = result.HasData && result.Data.Any() &&  ResourceParameters.PageNumber != result.PaginationMetadata.TotalPages;
            btnPrevPage.Enabled = ResourceParameters.PageNumber != 1;

            this.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }

        protected void SetSourceForDgrv(IBindingList source) => dgrvMain.DataSource = source;

        protected virtual void txtSearch_Leave(object sender, EventArgs e)
        {
            SearchText = txtSearch.Text.Trim().ToLower();
        }

        private async void btnNextPage_Click_1(object sender, EventArgs e)
        {
            ResourceParameters.PageNumber++;
            await LoadData();
            btnPrevPage.Enabled = true;
        }

        private async void btnPrevPage_Click_1(object sender, EventArgs e)
        {
            if (ResourceParameters.PageNumber == 1)
                return;

            ResourceParameters.PageNumber--;
            await LoadData();

            if (ResourceParameters.PageNumber == 1)
                btnPrevPage.Enabled = false;
            btnNextPage.Enabled = true;
        }

        private async void formDisplayed_SizeChanged(object sender, EventArgs e)
        {
            if (ResourceParameters != null)
            {
                CalculateRowsCount();
                dgrvMain.DataSource = null;
                await LoadData();
            }
        }

        private void DisplayDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.SizeChanged -= formDisplayed_SizeChanged;
        }

        private void DisplayDataForm_Shown(object sender, EventArgs e)
        {
            this.SizeChanged += formDisplayed_SizeChanged;
        }

        private async void DisplayDataForm_Load_1(object sender, EventArgs e)
        {
            await LoadData();
        }

        protected virtual void btnBack_Click(object sender, EventArgs e)
        {
            FormForBackButton?.OpenAsChildOfControl(Parent);
        }

        private void CalculateRowsCount()
        {
            PossibleRowsCount = dgrvMain.GetRowsCount();
            PossibleRowsCount = PossibleRowsCount <= 0 ? 1 : PossibleRowsCount;
            dgrvMain.RowCount = PossibleRowsCount;
            ResourceParameters.PageSize = PossibleRowsCount;
        }

        private async void dgrvMain_SizeChanged(object sender, EventArgs e)
        {
            dgrvMain.DataSource = null;
            CalculateRowsCount();
            await LoadData();
        }
    }
}