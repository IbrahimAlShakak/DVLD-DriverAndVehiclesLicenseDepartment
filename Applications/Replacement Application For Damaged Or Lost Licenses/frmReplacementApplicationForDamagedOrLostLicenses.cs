using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Replacement_Application_For_Damaged_Or_Lost_Licenses
{
    public partial class frmReplacementApplicationForDamagedOrLostLicenses : Form
    {
        private int _currentLicenseID = -1;
        private clsLicense _currentLicense;
        private clsLicense _newLicense;
        private clsLicense.enIssueReason _enIssueReason;

        public frmReplacementApplicationForDamagedOrLostLicenses()
        {
            InitializeComponent();
        }

        private void frmReplacementApplicationForDamagedOrLostLicenses_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Checked = true;
            lblTitel.Text = "Replacement Application For Damaged License";
            lblApplicationFees.Text = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();

            _enIssueReason = clsLicense.enIssueReason.ReplacementForDamage;
            
            if (_currentLicense == null) return;

            if (!_currentLicense.IsActive)
            {

                MessageBox.Show($"License is not active!, Choose an active license", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
            }
            else
                btnIssueReplacement.Enabled = true;

            llShowLicenseHistory.Enabled = true;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblOldLicenseID.Text = _currentLicenseID.ToString();
            lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName;
            
        }

        private void ctrlDrivingLicenseInfoWithFilter1_OnLicenseFound(int obj)
        {
            _currentLicenseID = obj;
            _currentLicense = clsLicense.FindLicenceByLicenseID(obj);
            frmReplacementApplicationForDamagedOrLostLicenses_Load(null, null);
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitel.Text = "Replacement Application For Damaged License";
            lblApplicationFees.Text = clsApplicationType.FindApplicationType((int) clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();
            _enIssueReason = clsLicense.enIssueReason.ReplacementForDamage;
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitel.Text = "Replacement Application For Lost License";
            lblApplicationFees.Text = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).Fees.ToString();
            _enIssueReason = clsLicense.enIssueReason.ReplacementForLost;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_currentLicense.Driver.PersonID);
            frm.ShowDialog();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue Replacement for this license ?", "Confirm Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _newLicense = _currentLicense.ReplacementLicenseForDamagedOrLost(clsGlobal.LoggedInUser.UserID, _enIssueReason);

                if (_newLicense != null)
                {
                    lblReplacementAppID.Text = _newLicense.ApplicationID.ToString();
                    lblReplacementLicenseID.Text = _newLicense.LicenseID.ToString();
                    llShowLicenseInfo.Enabled = true;
                    MessageBox.Show($"License Replaced with ID = {_newLicense.LicenseID}!", "Replacement Confirmrd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Error Occured with issuing replacement!", "Error Issuing Replacement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_newLicense.LicenseID);
            frm.ShowDialog();
        }
    }
}
