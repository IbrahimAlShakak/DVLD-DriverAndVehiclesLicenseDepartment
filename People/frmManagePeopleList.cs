using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.People;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class frmManagePeopleList : Form
    {
        private DataTable _dataAllPeoplr;

        private void _LoadData()
        {
            _dataAllPeoplr = clsPerson.GetAllPeople();
            dgvPeopleList.DataSource = _dataAllPeoplr;

        }
        private void _UpdateCountOfRecords()
        {
            lblNumberOfRecords.Text = dgvPeopleList.Rows.Count.ToString();
        }
        private void _LoadFilters()
        {
            foreach (DataColumn column in _dataAllPeoplr.Columns)
            {
                cbFilters.Items.Add(column.ColumnName);
            }
        }

        private void _Refresh()
        {
            _LoadData();
            _UpdateCountOfRecords();
            _LoadFilters();
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

        private int _GetPersonIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvPeopleList.CurrentRow.Cells["PersonID"].Value);
        }
        private void _deletePersonInfo()
        {
            int PersonID = _GetPersonIdOfSelectedRow();
            if (clsPerson.DeletePerson(PersonID))
            {
                MessageBox.Show("Person Info of selected row is Deleted :)", "Delete Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh();
            }
            else
            {
                MessageBox.Show("Fail to delete person info :(", "Delete Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmManagePeopleList()
        {
            InitializeComponent();
        }
        private void frmManagePeopleList_Load(object sender, EventArgs e)
        {
            _Refresh();
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

        private void tsmDelete_Click(object sender, EventArgs e)
        {

            _deletePersonInfo();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPersonInfo addOrEditPersonInfoF = new frmAddOrEditPersonInfo();
            addOrEditPersonInfoF.ShowDialog();
            _Refresh();

        }
        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int ID = _GetPersonIdOfSelectedRow();
            frmAddOrEditPersonInfo addOrEditPersonInfoF = new frmAddOrEditPersonInfo(ID);
            addOrEditPersonInfoF.ShowDialog();
            _Refresh();

        }
        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPersonInfo addOrEditPersonInfoF = new frmAddOrEditPersonInfo();
            addOrEditPersonInfoF.ShowDialog();
            _Refresh();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int ID = _GetPersonIdOfSelectedRow();
            frmPersonInfocs frm = new frmPersonInfocs(ID);
            frm.ShowDialog();
        }
    }
}
