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
using DVLD_DriverAndVehiclesLicenseDepartment.Tests;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationsList : Form
    {
        private DataTable _dataLocalLicenseApplicationsList = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationsList();
        private void _Refresh()
        {
            _dataLocalLicenseApplicationsList = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationsList();
            dgvLocalLicenseApplicationsList.DataSource = _dataLocalLicenseApplicationsList;
            lblNumberOfRecords.Text = dgvLocalLicenseApplicationsList.Rows.Count.ToString();

        }
        private void _LoadFiltersInComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("L.D.L.App ID");
            cbFilters.Items.Add("National No");
            cbFilters.Items.Add("Full Name");
            cbFilters.Items.Add("Status");

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
                lblNumberOfRecords.Text = dgvLocalLicenseApplicationsList.Rows.Count.ToString();
                return;
            }
            else if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                _dataLocalLicenseApplicationsList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbInputFilter.Text.Trim());
                lblNumberOfRecords.Text = dgvLocalLicenseApplicationsList.Rows.Count.ToString();
                return;
            }
            else
            {
                _dataLocalLicenseApplicationsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbInputFilter.Text.Trim());
                lblNumberOfRecords.Text = dgvLocalLicenseApplicationsList.Rows.Count.ToString();
                return;
            }
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
                    MessageBox.Show("Local driving application was deleted successfully!", "Deletion Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            _Refresh();
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmAddOrUpdateLocalDrivingLicense frm = new frmAddOrUpdateLocalDrivingLicense(ID);
            frm.ShowDialog();
        }
        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalDrivingLicense frm = new frmAddOrUpdateLocalDrivingLicense();
            frm.ShowDialog();
            _Refresh();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.FindByID(ID);
            if (LDLApplication.SetCacelled()) _Refresh();
        }

        private void dgvLocalLicenseApplicationsList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvLocalLicenseApplicationsList.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvLocalLicenseApplicationsList.ClearSelection();
                    dgvLocalLicenseApplicationsList.Rows[hit.RowIndex].Selected = true;
                    int TestPassed = Convert.ToInt32(dgvLocalLicenseApplicationsList.CurrentRow.Cells["PassedTestCount"].Value);
                    string Status = dgvLocalLicenseApplicationsList.CurrentRow.Cells["Status"].Value.ToString(); ;
                    if (Status != "New")
                    {
                        cmsScheduleTest.Enabled = false;
                    }
                    else
                    {
                        cmsScheduleTest.Enabled = true;
                        switch (TestPassed)
                        {
                            case 0:
                                cmsScheduleVisionTest.Enabled = true;
                                cmsScheduleTheoryTest.Enabled = false;
                                cmsSchedulePracticalTest.Enabled = false;
                                break;
                            case 1:
                                cmsScheduleVisionTest.Enabled = false;
                                cmsScheduleTheoryTest.Enabled = true;
                                cmsSchedulePracticalTest.Enabled = false;
                                break;
                            case 2:
                                cmsScheduleVisionTest.Enabled = false;
                                cmsScheduleTheoryTest.Enabled = false;
                                cmsSchedulePracticalTest.Enabled = true;
                                break;
                            default:
                                cmsScheduleVisionTest.Enabled = false;
                                cmsScheduleTheoryTest.Enabled = false;
                                cmsSchedulePracticalTest.Enabled = false;
                                break;
                        }
                    }
                }
            }
        }

        private void cmsScheduleVisionTest_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmTestAppointmentsList frm = new frmTestAppointmentsList(ID, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            _Refresh();

        }

        private void cmsScheduleTheoryTest_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmTestAppointmentsList frm = new frmTestAppointmentsList(ID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            _Refresh();
        }

        private void cmsSchedulePracticalTest_Click(object sender, EventArgs e)
        {
            int ID = _GetLocalDrivingLicneseApplicationIdOfSelectedRow();
            frmTestAppointmentsList frm = new frmTestAppointmentsList(ID, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            _Refresh();
        }
    }
}
