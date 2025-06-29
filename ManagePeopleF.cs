using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class ManagePeopleF : Form
    {
        private DataTable _dataAllPeoplr = clsPerson.GetAllPeopleList();
        private void _LoadData()
        {
            dgvPeopleList.DataSource = _dataAllPeoplr;
           
        }
        private void _UpdateCountOfRecords()
        {
            lblNumberOfRecords.Text = dgvPeopleList.Rows.Count.ToString();
        }
        private void _loadFilters()
        {
            foreach (DataColumn column in _dataAllPeoplr.Columns)
            {
                cbFilters.Items.Add(column.ColumnName);
            }
        }
        private void _LoadFilteredData(DataTable filteredData)
        {
            dgvPeopleList.DataSource = filteredData;

        }
        private DataTable _GetFilterData()
        {
            string selectedFilter = cbFilters.SelectedItem?.ToString();
            string filterValue = tbInputFilter.Text;

            if (string.IsNullOrWhiteSpace(selectedFilter) || string.IsNullOrWhiteSpace(filterValue))
                return _dataAllPeoplr.Copy();

            DataRow[] ResultRows = _dataAllPeoplr.Select($"{selectedFilter}='{filterValue}'");

            DataTable filteredTable = _dataAllPeoplr.Clone();

            foreach (DataRow r in ResultRows)
            {
                filteredTable.ImportRow(r);
            }

            return filteredTable;
        }
        public ManagePeopleF()
        {
            InitializeComponent();
            _LoadData();
            _UpdateCountOfRecords();
            _loadFilters();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddOrEditPersonInfoF addOrEditPersonInfoF = new AddOrEditPersonInfoF(-1);
            addOrEditPersonInfoF.Show();
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInputFilter.Visible = true;
        }
        private void tbInputFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
                // Make sure when the PersonId filter is selected, the user allowed to press only numbers.
                if (cbFilters.SelectedItem?.ToString() == "PersonID")
                {
                    // Allow only digits and control keys (like backspace)
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true; // Block the key
                    }
                }
        }

        private void tbInputFilter_TextChanged(object sender, EventArgs e)
        {
            _LoadFilteredData(_GetFilterData());
            _UpdateCountOfRecords();

        }
    }
}
