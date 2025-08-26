using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Applications.Release_Detained_License;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License;
using DVLD_DriverAndVehiclesLicenseDepartment.People;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Licenses.Detain_License
{
    public partial class frmDetainLicensesList : Form
    {
        private DataTable _DataDetainLicenses;
        private clsDetainedLicense _DetainLicense;
        private void _LoadFiltersInComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("Detain ID");
            cbFilters.Items.Add("Is Released");
            cbFilters.Items.Add("National No");
            cbFilters.Items.Add("Full Name");
            cbFilters.Items.Add("Release Application ID");
            cbFilters.SelectedIndex = 0;

            cbIsReleased.Items.Add("All");
            cbIsReleased.Items.Add("Yes");
            cbIsReleased.Items.Add("No");

        }
        private int _GetDetainIDOfSelectedRow()
        {
            return Convert.ToInt32(dgvDetainedLicensesList.CurrentRow.Cells["DetainID"].Value);
        }
        public frmDetainLicensesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetainLicensesList_Load(object sender, EventArgs e)
        {
            _DataDetainLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicensesList.DataSource = _DataDetainLicenses;
            lblNumberOfRecords.Text = dgvDetainedLicensesList.Rows.Count.ToString();
            _LoadFiltersInComboBox();
            if (dgvDetainedLicensesList.Rows.Count > 0)
            {
                dgvDetainedLicensesList.Columns[0].HeaderText = "Detain ID";
                dgvDetainedLicensesList.Columns[1].HeaderText = "Licnese ID";
                dgvDetainedLicensesList.Columns[2].HeaderText = "Detain Date";
                dgvDetainedLicensesList.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicensesList.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicensesList.Columns[5].HeaderText = "Released Date";
                dgvDetainedLicensesList.Columns[6].HeaderText = "National No";
                dgvDetainedLicensesList.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicensesList.Columns[8].HeaderText = "Release App ID";
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.Text == "Is Released")
            {
                tbInputFilter.Visible = false;
                cbIsReleased.Visible = true;
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
                { 
                    tbInputFilter.Enabled = true;
                }
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
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "License ID":
                    FilterColumn = "LicenseID";
                    break;
                case "Detain Date":
                    FilterColumn = "DetainDate";
                    break;
                case "Fine Fees":
                    FilterColumn = "FineFees";
                    break;
                case "Released Date":
                    FilterColumn = "ReleasedDate";
                    break;
                case "Natioanl No":
                    FilterColumn = "NatioanlNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release App ID":
                    FilterColumn = "ReleaseAppID";
                    break;
            }
            if (FilterColumn == "None" || String.IsNullOrEmpty(tbInputFilter.Text))
            {
                _DataDetainLicenses.DefaultView.RowFilter = "";
            }
            else if (FilterColumn == "DetainID" || FilterColumn == "LicenseID" || FilterColumn == "ReleaseAppID")
            {
                _DataDetainLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbInputFilter.Text.Trim());
            } else
            {
                _DataDetainLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbInputFilter.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvDetainedLicensesList.Rows.Count.ToString();
        }

        private void tbInputFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.SelectedItem?.ToString() == "Detain ID" || cbFilters.SelectedItem?.ToString() == "License ID"
                || cbFilters.SelectedItem?.ToString() == "Release App ID")
            {
                // Allow only digits and control keys (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block the key
                }
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetDetainIDOfSelectedRow();
            _DetainLicense = clsDetainedLicense.FindDetainedLicenceByID(ID);

            frmPersonInfo frm = new frmPersonInfo(_DetainLicense.LicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetDetainIDOfSelectedRow();
            _DetainLicense = clsDetainedLicense.FindDetainedLicenceByID(ID);

            frmShowLicense frm = new frmShowLicense(_DetainLicense.LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetDetainIDOfSelectedRow();
            _DetainLicense = clsDetainedLicense.FindDetainedLicenceByID(ID);

            frmShowLicenseHistory frm = new frmShowLicenseHistory(_DetainLicense.LicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetDetainIDOfSelectedRow();
            _DetainLicense = clsDetainedLicense.FindDetainedLicenceByID(ID);

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(_DetainLicense.LicenseID);
            frm.ShowDialog();
            frmDetainLicensesList_Load(null, null);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void btnDetainNewLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }
    }
}
