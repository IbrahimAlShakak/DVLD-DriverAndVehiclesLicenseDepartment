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
        private void _ResrDefault()
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
        }
        private void ctrlApplicationInfo_Load(object sender, EventArgs e)
        {
            _ResrDefault();
            
        }
        public void LoadApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByID(LocalDrivingLicenseApplicationID);
            if(_LDLApplication != null)
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
    }
}

