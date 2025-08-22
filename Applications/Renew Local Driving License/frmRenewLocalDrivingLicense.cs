using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Renew_Local_Driving_License
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private int _currentLocalLicenseID = -1;
        private clsLicense _currentLicense;
        private clsLicense _newLicense;

        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void ctrlDrivingLicenseInfoWithFilter1_OnLicenseFound(int obj)
        {
            _currentLocalLicenseID = obj;
            ctrlDrivingLicenseInfoWithFilter1_Load(null, null);
        }

        private void ctrlDrivingLicenseInfoWithFilter1_Load(object sender, System.EventArgs e)
        {
            if (_currentLocalLicenseID == -1)
                return;

            _currentLicense = clsLicense.FindLicenceByLicenseID(_currentLocalLicenseID);

            if (_currentLicense == null)
                return;

            if (_currentLicense.ExpirationDate > DateTime.Now)
            {
               
                MessageBox.Show($"License is still valid you can not issue a renew ! License valid till {_currentLicense.ExpirationDate}!", "Not Allowed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnRenew.Enabled = false;
            }

            if (!_currentLicense.IsActive)
            {

                MessageBox.Show($"License is not active!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
            }

            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblOldLicenseID.Text = _currentLocalLicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(_currentLicense.LicenseClassInfo.DefaultValidityLength).ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName;
            lblApplicationFees.Text = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblLicenseFees.Text = _currentLicense.LicenseClassInfo.ClassesFees.ToString();
            lblTotalFees.Text = (_currentLicense.LicenseClassInfo.ClassesFees + clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees).ToString();
            llShowLicenseHistory.Enabled = true;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_currentLicense.Driver.PersonID);
            frm.ShowDialog();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to renew this license ?", "Confirm Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK )
            {
                _newLicense = _currentLicense.RenewLicense(tbNotes.Text, clsGlobal.LoggedInUser.UserID);

                if (_newLicense != null)
                {
                    lblRenewAppID.Text = _newLicense.ApplicationID.ToString();
                    lblRenewedLicenseID.Text = _newLicense.LicenseID.ToString();
                    llShowLicenseInfo.Enabled = true;
                    MessageBox.Show($"License Renewed with ID = {_newLicense.LicenseID}!", "Renewed Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Error Occured with issuing renewal!", "Error Issuing Renewal", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
