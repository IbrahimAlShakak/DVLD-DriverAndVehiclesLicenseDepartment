using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.People;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class frmPeopleList : Form
    {
        private static DataTable _dataAllPeople = clsPerson.GetAllPeople();
        private DataTable _dataPeople = _dataAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GenderCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        private void _Refresh()
        {
            _dataAllPeople = clsPerson.GetAllPeople();
            _dataPeople = _dataAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                           "FirstName", "SecondName", "ThirdName", "LastName",
                                                           "GenderCaption", "DateOfBirth", "CountryName",
                                                           "Phone", "Email");
            dgvPeopleList.DataSource = _dataPeople;
            lblNumberOfRecords.Text = dgvPeopleList.Rows.Count.ToString();
        }
        private int _GetPersonIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvPeopleList.CurrentRow.Cells["PersonID"].Value);
        }
        private void _LoadFiltersInComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("Person ID");
            cbFilters.Items.Add("National No.");
            cbFilters.Items.Add("First Name");
            cbFilters.Items.Add("Second Name");
            cbFilters.Items.Add("Third Name");
            cbFilters.Items.Add("Last Name");
            cbFilters.Items.Add("Gender");
            cbFilters.Items.Add("Date Of Birth");
            cbFilters.Items.Add("Nationality");
            cbFilters.Items.Add("Phone");
            cbFilters.Items.Add("Email");
        }
        public frmPeopleList()
        {
            InitializeComponent();
        }
        private void frmPeopleList_Load(object sender, EventArgs e)
        {
            dgvPeopleList.DataSource = _dataPeople;
            _LoadFiltersInComboBox();
            cbFilters.SelectedIndex = 0;
            lblNumberOfRecords.Text = dgvPeopleList.Rows.Count.ToString();
            if (dgvPeopleList.Rows.Count > 0)
            {

                dgvPeopleList.Columns[0].HeaderText = "Person ID";
                dgvPeopleList.Columns[0].Width = 110;

                dgvPeopleList.Columns[1].HeaderText = "National No.";
                dgvPeopleList.Columns[1].Width = 120;


                dgvPeopleList.Columns[2].HeaderText = "First Name";
                dgvPeopleList.Columns[2].Width = 120;

                dgvPeopleList.Columns[3].HeaderText = "Second Name";
                dgvPeopleList.Columns[3].Width = 140;


                dgvPeopleList.Columns[4].HeaderText = "Third Name";
                dgvPeopleList.Columns[4].Width = 120;

                dgvPeopleList.Columns[5].HeaderText = "Last Name";
                dgvPeopleList.Columns[5].Width = 120;

                dgvPeopleList.Columns[6].HeaderText = "Gender";
                dgvPeopleList.Columns[6].Width = 120;

                dgvPeopleList.Columns[7].HeaderText = "Date Of Birth";
                dgvPeopleList.Columns[7].Width = 140;

                dgvPeopleList.Columns[8].HeaderText = "Nationality";
                dgvPeopleList.Columns[8].Width = 120;


                dgvPeopleList.Columns[9].HeaderText = "Phone";
                dgvPeopleList.Columns[9].Width = 120;


                dgvPeopleList.Columns[10].HeaderText = "Email";
                dgvPeopleList.Columns[10].Width = 170;
            }
        }
        private void tbInputFilter_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilters.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (tbInputFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dataPeople.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = _dataPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dataPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbInputFilter.Text.Trim());
            else
                _dataPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbInputFilter.Text.Trim());

            lblNumberOfRecords.Text = dgvPeopleList.Rows.Count.ToString();

        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInputFilter.Visible = (cbFilters.Text != "None");
            if (tbInputFilter.Visible)
            {
                tbInputFilter.Text = "";
                tbInputFilter.Focus();
            }
        }
        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int ID = _GetPersonIdOfSelectedRow();
            frmPersonInfo frm = new frmPersonInfo(ID);
            frm.ShowDialog();
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
        private void tsmDelete_Click(object sender, EventArgs e)
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
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPersonInfo addOrEditPersonInfoF = new frmAddOrEditPersonInfo();
            addOrEditPersonInfoF.ShowDialog();
            _Refresh();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tbInputFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Make sure when the PersonId filter is selected, the user allowed to press only numbers.
            if (cbFilters.SelectedItem?.ToString() == "Person ID")
            {
                // Allow only digits and control keys (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block the key
                }
            }
        }
    }
}
