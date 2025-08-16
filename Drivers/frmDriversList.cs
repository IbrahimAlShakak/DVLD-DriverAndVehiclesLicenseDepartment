using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.People;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Drivers
{
    public partial class frmDriversList : Form
    {
        private DataTable _DriversData;
        private int _GetDriverIDOfSelectedRow()
        {
            return Convert.ToInt32(dgvDriversList.CurrentRow.Cells["DriverID"].Value);
        }

        public frmDriversList()
        {
            InitializeComponent();
        }

        private void frmDriversList_Load(object sender, EventArgs e)
        {
            _DriversData = clsDriver.GetAllDriversInfo();
            dgvDriversList.DataSource = _DriversData;
            lblNumberOfRecords.Text = dgvDriversList.Rows.Count.ToString();

            cbFilters.Items.Add("None");
            cbFilters.Items.Add("Driver ID");
            cbFilters.Items.Add("Person ID");
            cbFilters.Items.Add("National No");
            cbFilters.Items.Add("Full Name");
            cbFilters.SelectedIndex = 0;

            if (dgvDriversList.Rows.Count > 0)
            {

                dgvDriversList.Columns[0].HeaderText = "Driver ID";
                dgvDriversList.Columns[1].HeaderText = "Person ID";
                dgvDriversList.Columns[2].HeaderText = "National No";
                dgvDriversList.Columns[3].HeaderText = "Full Name";
                dgvDriversList.Columns[4].HeaderText = "Date";
                dgvDriversList.Columns[5].HeaderText = "Active Licenses";
            }
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

        private void tbInputFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilters.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Date":
                    FilterColumn = "CreatedDate";
                    break;
                case "Active Licenses":
                    FilterColumn = "NumberOfActiveLicenses";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (tbInputFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _DriversData.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = _DriversData.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID" || FilterColumn == "DriverID")
                _DriversData.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbInputFilter.Text.Trim());
            else
                _DriversData.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbInputFilter.Text.Trim());

            lblNumberOfRecords.Text = _DriversData.Rows.Count.ToString();
        }
        private void tbInputFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.SelectedItem?.ToString() == "Person ID" || cbFilters.SelectedItem?.ToString() == "Driver ID")
            {
                // Allow only digits and control keys (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block the key
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmShowPersonInfo_Click(object sender, EventArgs e)
        {
            int DriverID = _GetDriverIDOfSelectedRow();
            int PersonID = clsDriver.FindDriverByID(DriverID).PersonID;
            frmPersonInfo frm = new frmPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int DriverID = _GetDriverIDOfSelectedRow();
            int PersonID = clsDriver.FindDriverByID(DriverID).PersonID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
