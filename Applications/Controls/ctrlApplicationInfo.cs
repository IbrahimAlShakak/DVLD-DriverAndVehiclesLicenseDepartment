using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License;
using DVLD_DriverAndVehiclesLicenseDepartment.People;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Controls
{
    public partial class ctrlApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LDLApplication;

        public ctrlApplicationInfo( )
        {
            InitializeComponent();
        }
        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            lblLocalDrivingLicenseApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseType.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblTestsPassed.Text = $"{_LDLApplication.NumberOfPassedTests()}/3";
            lblApplicationID.Text = _LDLApplication.ApplicationID.ToString();
            lblStatusDate.Text = _LDLApplication.StatusText;
            lblFees.Text = _LDLApplication.PaidFees.ToString();
            lblApplicationType.Text = _LDLApplication.ApplicationType.Title;
            lblApplicantName.Text = _LDLApplication.Applicant.FullName;
            lblApplicationDate.Text = _LDLApplication.ApplicationDate.ToString();
            lblStatusDate.Text = _LDLApplication.LastStatusDate.ToString();
            lblCreatedByUser.Text = _LDLApplication.CreatedByUser.UserName;

            lblViewPersonInfo.Enabled = true;

            if(_LDLApplication.GetActiveLicenseID() != -1)
                llShowLicenseInfo.Enabled = true;
        }
        private void _ResetDefault()
        {
            lblLocalDrivingLicenseApplicationID.Text = "???";
            lblLicenseType.Text = "???";
            lblTestsPassed.Text = "0/3";
            lblApplicationID.Text = "???";
            lblStatusDate.Text = "New";
            lblFees.Text = "0";
            lblApplicationType.Text = "New Local Driving License Service";
            lblApplicantName.Text = "???";
            lblApplicationDate.Text = "../../..";
            lblStatusDate.Text = "../../..";
            lblCreatedByUser.Text = "???";

            lblViewPersonInfo.Enabled = false;
            llShowLicenseInfo.Enabled = false;
        }
        private void ctrlApplicationInfo_Load(object sender, EventArgs e)
        {
            _ResetDefault();
            
        }
        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByID(LocalDrivingLicenseApplicationID);
            if(_LDLApplication != null)
            {
                _FillLocalDrivingLicenseApplicationInfo();
            }
            else
            {
                _ResetDefault();
                MessageBox.Show("No Application with Local Driving License ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_LDLApplication != null)
            {
                _FillLocalDrivingLicenseApplicationInfo();
            }
            else
            {
                _ResetDefault();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void lblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LDLApplication != null)
            {

                frmPersonInfo frm = new frmPersonInfo(_LDLApplication.ApplicantPersonID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Error loading Person Info", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);   
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_LDLApplication.GetActiveLicenseID());
            frm.ShowDialog();
        }
    }
}

