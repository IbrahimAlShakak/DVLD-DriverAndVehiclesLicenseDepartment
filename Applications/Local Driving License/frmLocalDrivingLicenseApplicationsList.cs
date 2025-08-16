using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License;
using DVLD_DriverAndVehiclesLicenseDepartment.Tests;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationsList : Form
    {
        private DataTable _dataLocalLicenseApplicationsList;
        private void _LoadFiltersInComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("L.D.L.App ID");
            cbFilters.Items.Add("National No");
            cbFilters.Items.Add("Full Name");
            cbFilters.Items.Add("Status");

            cbFilters.SelectedIndex = 0;

        }
        private int _GetLocalDrivingLicneseApplicationIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvLocalLicenseApplicationsList.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
        }
        public frmLocalDrivingLicenseApplicationsList()
        {
            InitializeComponent();
        }
        private void frmLocalDrivingLicenseApplicationsList_Load(object sender, EventArgs e)
        {
            _dataLocalLicenseApplicationsList = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationsList();
            dgvLocalLicenseApplicationsList.DataSource = _dataLocalLicenseApplicationsList;
            lblNumberOfRecords.Text = dgvLocalLicenseApplicationsList.Rows.Count.ToString();
            _LoadFiltersInComboBox();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.SelectedItem?.ToString() == "None")
            {
                tbInputFilter.Visible = false;
            }
            else
            {
                tbInputFilter.Visible = true;
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
                case "L.D.L.App ID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
            }
            if (FilterColumn == "None" || String.IsNullOrEmpty(tbInputFilter.Text))
            {
                _dataLocalLicenseApplicationsList.DefaultView.RowFilter = "";
            }
            else if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                _dataLocalLicenseApplicationsList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbInputFilter.Text.Trim());
            }
            else
            {
                _dataLocalLicenseApplicationsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbInputFilter.Text.Trim());

            }
            lblNumberOfRecords.Text = dgvLocalLicenseApplicationsList.Rows.Count.ToString();
        }
        private void tbInputFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.SelectedItem?.ToString() == "L.D.L.App ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block the key
                }
            }
        }
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            if (MessageBox.Show($"Are you sure you want to delete application with ID = {ID}", "Be Careful Deletion Request", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.FindByID(ID).Delete())
                {
                    MessageBox.Show("Local driving application was deleted successfully!", "Deletion Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLocalDrivingLicenseApplicationsList_Load(null, null);
                }
                else
                    MessageBox.Show("Local driving application was not deleted!", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmAddOrUpdateLocalDrivingLicense frm = new frmAddOrUpdateLocalDrivingLicense(ID);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }
        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalDrivingLicense frm = new frmAddOrUpdateLocalDrivingLicense();
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.FindByID(ID);
            if (LDLApplication.SetCacelled())
            {
                MessageBox.Show("Local driving application was cancelled!", "Cancelled Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmLocalDrivingLicenseApplicationsList_Load(null, null);
            }
            else MessageBox.Show("Local driving application was not cancelled!", "Cancellation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void dgvLocalLicenseApplicationsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var hit = dgvLocalLicenseApplicationsList.HitTest(e.X, e.Y);
            if (hit.RowIndex < 0) return;

            dgvLocalLicenseApplicationsList.ClearSelection();
            dgvLocalLicenseApplicationsList.Rows[hit.RowIndex].Selected = true;

            int _SelectLocaldrivingLicenseApplicationID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            clsLocalDrivingLicenseApplication _SelectedLDLApplication = clsLocalDrivingLicenseApplication.FindByID(_SelectLocaldrivingLicenseApplicationID);
            int _NumberOfPassedTests = _SelectedLDLApplication.NumberOfPassedTests();
            string Status = _SelectedLDLApplication.StatusText;




            if (Status == "Cancelled")
            {
                cmsApplicationDetails.Enabled = true;
                cmsEditApplication.Enabled = false;
                cmsDeleteApplication.Enabled = false;
                cmsCancelApplication.Enabled = false;
                cmsScheduleTest.Enabled = false;
                cmsScheduleVisionTest.Enabled = false;
                cmsScheduleTheoryTest.Enabled = false;
                cmsSchedulePracticalTest.Enabled = false;
                cmsIssueDrivingLicneseForTheFirstTime.Enabled = false;
                cmsShowLicense.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;

            }
            else if (Status == "Completed")
            {
                cmsApplicationDetails.Enabled = true;
                cmsEditApplication.Enabled = false;
                cmsDeleteApplication.Enabled = false;
                cmsCancelApplication.Enabled = false;
                cmsScheduleTest.Enabled = false;
                cmsScheduleVisionTest.Enabled = false;
                cmsScheduleTheoryTest.Enabled = false;
                cmsSchedulePracticalTest.Enabled = false;
                cmsIssueDrivingLicneseForTheFirstTime.Enabled = false;
                cmsShowLicense.Enabled = true;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
            }
            else // Status == NEW
            {
                cmsApplicationDetails.Enabled = true;
                cmsEditApplication.Enabled = true;
                cmsDeleteApplication.Enabled = true;
                cmsCancelApplication.Enabled = true;
                cmsShowLicense.Enabled = false;
                showPersonLicenseHistoryToolStripMenuItem.Enabled = true;

                switch (_NumberOfPassedTests)
                {
                    case 0:
                        cmsScheduleTest.Enabled = true;
                        cmsScheduleVisionTest.Enabled = true;
                        cmsScheduleTheoryTest.Enabled = false;
                        cmsSchedulePracticalTest.Enabled = false;
                        cmsIssueDrivingLicneseForTheFirstTime.Enabled = false;
                        break;
                    case 1:
                        cmsScheduleTest.Enabled = true;
                        cmsScheduleVisionTest.Enabled = false;
                        cmsScheduleTheoryTest.Enabled = true;
                        cmsSchedulePracticalTest.Enabled = false;
                        cmsIssueDrivingLicneseForTheFirstTime.Enabled = false;
                        break;
                    case 2:
                        cmsScheduleTest.Enabled = true;
                        cmsScheduleVisionTest.Enabled = false;
                        cmsScheduleTheoryTest.Enabled = false;
                        cmsSchedulePracticalTest.Enabled = true;
                        cmsIssueDrivingLicneseForTheFirstTime.Enabled = false;
                        break;
                    case 3:
                        cmsScheduleTest.Enabled = false;
                        cmsScheduleVisionTest.Enabled = false;
                        cmsScheduleTheoryTest.Enabled = false;
                        cmsSchedulePracticalTest.Enabled = false;
                        cmsIssueDrivingLicneseForTheFirstTime.Enabled = true;
                        break;

                }

            }
        }

        private void cmsScheduleVisionTest_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmTestAppointmentsList frm = new frmTestAppointmentsList(ID, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);

        }

        private void cmsScheduleTheoryTest_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmTestAppointmentsList frm = new frmTestAppointmentsList(ID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void cmsSchedulePracticalTest_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmTestAppointmentsList frm = new frmTestAppointmentsList(ID, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void cmsIssueDrivingLicneseForTheFirstTime_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmIssueLocalLicenseFirstTime frm = new frmIssueLocalLicenseFirstTime(ID);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void cmsShowLicense_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            int LicenseID = clsLocalDrivingLicenseApplication.FindByID(ID).GetActiveLicenseID();
            frmShowLicense frm = new frmShowLicense(LicenseID);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            int PersonID = clsLocalDrivingLicenseApplication.FindByID(ID).ApplicantPersonID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(PersonID);
            frm.ShowDialog();
            frmLocalDrivingLicenseApplicationsList_Load(null, null);
        }
    }
}
