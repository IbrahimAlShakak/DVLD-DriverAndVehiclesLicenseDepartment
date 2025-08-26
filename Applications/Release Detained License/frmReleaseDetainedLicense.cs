using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _LicenseID;
        private clsLicense _License;
        private clsDetainedLicense _DetainedLicense;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            ctrlDrivingLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrlDrivingLicenseInfoWithFilter1.FilterEnabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ctrlDrivingLicenseInfoWithFilter1_OnLicenseFound(int obj)
        {
            _LicenseID = obj;
            frmReleaseDetainedLicense_Load(null, null);

        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            _License = clsLicense.FindLicenceByLicenseID(_LicenseID);

            if (_License == null)
                return;

            if (!_License.IsDetianed)
            {
                MessageBox.Show("The License is not detained! Choose another license", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDetainID.Text = _License.GetLicenseDetainID().ToString();
                btnRelease.Enabled = false;
                return;
            }

            _DetainedLicense = clsDetainedLicense.FindDetainedLicenceByLicenseID(_LicenseID);
            
            if (_DetainedLicense == null)
                return;
            
            btnRelease.Enabled = true;
            llShowLicenseInfo.Enabled = true;
            llShowLicenseHistory.Enabled = true;

            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("dd/MM/yyyy");
            lblLicenseID.Text = _LicenseID.ToString();
            lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName;
            lblApplicationFees.Text = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblTotalFees.Text = (clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees + _DetainedLicense.FineFees).ToString();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(_License.Releaselicense(clsGlobal.LoggedInUser.UserID))
            {
                MessageBox.Show("License is released!", "Release Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _DetainedLicense = clsDetainedLicense.FindDetainedLicenceByLicenseID(_LicenseID);
                lblApplicationID.Text = _DetainedLicense.ReleaseApplicationID.ToString();
                btnRelease.Enabled = false;
            }else
            {
                MessageBox.Show("Error occured during release process contsct admin", "Release Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_LicenseID);
            frm.ShowDialog();

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_License.Driver.PersonID);
            frm.ShowDialog();
        }
    }
}
