using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class frmManagePeopleList : Form
    {
        private void _refresh()
        {
            _LoadData();
            _UpdateCountOfRecords();
            _loadFilters();
        }
        private DataTable _dataAllPeoplr;
        private void _LoadData()
        {
            _dataAllPeoplr = clsPerson.GetAllPeople(); // Refresh from DB
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
        private void AddOrEditForm(int ID = -1)
        {
            frmAddOrEditPersonInfo addOrEditPersonInfoF = new frmAddOrEditPersonInfo(ID);
            addOrEditPersonInfoF.ShowDialog();
            _refresh();

        }
        private int _GetIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvPeopleList.CurrentRow.Cells["PersonID"].Value);
        }
        private void _deletePersonInfo()
        {
            int PersonID = _GetIdOfSelectedRow();
            clsPerson Person = clsPerson.Find(PersonID);
            if (Person.DeleteImageFile())
            {
                if(Person.DeletePersonInfo())
                {
                    MessageBox.Show("Person Info of selected row is Deleted :)", "Delete Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _refresh();
                }
 
            }
            else
            {
                MessageBox.Show("Fail to delete person info :(", "Delete Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmManagePeopleList()
        {
            InitializeComponent();
            _refresh();
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
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddOrEditForm();
            
        }
        private void tsmEdit_Click(object sender, EventArgs e)
        {
            AddOrEditForm(_GetIdOfSelectedRow());
            
        }
        private void tsmDelete_Click(object sender, EventArgs e)
        {
           
            _deletePersonInfo();
        }

        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            AddOrEditForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
