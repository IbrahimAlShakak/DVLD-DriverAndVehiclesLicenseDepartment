using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.Licenses.International_Licenses;
using DVLD_DriverAndVehiclesLicenseDepartment.People;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.International_Driving_Licenses
{
    public partial class frmInternationalLicensesList : Form
    {
        private DataTable _dataInternationalLicenseApplicationsList;
        private void _LoadFiltersInComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("International License ID");
            cbFilters.Items.Add("Application ID");
            cbFilters.Items.Add("Driver ID");
            cbFilters.Items.Add("Local License ID");
            cbFilters.Items.Add("Is Active");

            cbFilters.SelectedIndex = 0;

            cbIsReleased.Items.Add("All");
            cbIsReleased.Items.Add("Yes");
            cbIsReleased.Items.Add("No");

        }
        private int _GetLocalDrivingLicneseApplicationIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvInternatioalDrivingApplicationsList.CurrentRow.Cells["InternationalLicenseID"].Value);
        }
        public frmInternationalLicensesList()
        {
            InitializeComponent();
        }

        private void frmInternationalLicensesList_Load(object sender, EventArgs e)
        {
            _dataInternationalLicenseApplicationsList = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternatioalDrivingApplicationsList.DataSource = _dataInternationalLicenseApplicationsList;
            lblNumberOfRecords.Text = dgvInternatioalDrivingApplicationsList.Rows.Count.ToString();
            _LoadFiltersInComboBox();
            if (dgvInternatioalDrivingApplicationsList.Rows.Count > 0)
            {
                dgvInternatioalDrivingApplicationsList.Columns[0].HeaderText = "International License ID";
                dgvInternatioalDrivingApplicationsList.Columns[1].HeaderText = "Application ID";
                dgvInternatioalDrivingApplicationsList.Columns[2].HeaderText = "Driver ID";
                dgvInternatioalDrivingApplicationsList.Columns[3].HeaderText = "Local License ID";
                dgvInternatioalDrivingApplicationsList.Columns[4].HeaderText = "Issue Date";
                dgvInternatioalDrivingApplicationsList.Columns[5].HeaderText = "Expiration Date";
                dgvInternatioalDrivingApplicationsList.Columns[6].HeaderText = "Is Active";

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.Text == "Is Active")
            {
                tbInputFilter.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                tbInputFilter.Visible = (cbFilters.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilters.Text == "None")
                {
                    tbInputFilter.Enabled = false;

                }
                else
                    tbInputFilter.Enabled = true;

                tbInputFilter.Text = "";
                tbInputFilter.Focus();
            }
        }

        private void tbInputFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilters.Text)
            {
                case "None":
                    FilterColumn = "None";
                    break;
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Local License ID":
                    FilterColumn = "LocalLicenseID";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
            }
            if (FilterColumn == "None" || String.IsNullOrEmpty(tbInputFilter.Text))
            {
                _dataInternationalLicenseApplicationsList.DefaultView.RowFilter = "";
            }
            else 
            {
                _dataInternationalLicenseApplicationsList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbInputFilter.Text.Trim());
            }
            
            lblNumberOfRecords.Text = dgvInternatioalDrivingApplicationsList.Rows.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dataInternationalLicenseApplicationsList.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dataInternationalLicenseApplicationsList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblNumberOfRecords.Text = _dataInternationalLicenseApplicationsList.Rows.Count.ToString();
        }

        private void tbInputFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense = clsInternationalLicense.FindInternatiolLicenseByID(_GetLocalDrivingLicneseApplicationIdOfSelectedRow());
            frmPersonInfo frm = new frmPersonInfo(InternationalLicense.ApplicantPersonID);
            frm.ShowDialog();
            frmInternationalLicensesList_Load(null, null);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense = clsInternationalLicense.FindInternatiolLicenseByID(_GetLocalDrivingLicneseApplicationIdOfSelectedRow());
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(InternationalLicense.InternatiolLicenseID);
            frm.ShowDialog();
            frmInternationalLicensesList_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense = clsInternationalLicense.FindInternatiolLicenseByID(_GetLocalDrivingLicneseApplicationIdOfSelectedRow());
            frmShowLicenseHistory frm = new frmShowLicenseHistory(InternationalLicense.ApplicantPersonID);
            frm.ShowDialog();
            frmInternationalLicensesList_Load(null, null);
        }
    }
}
