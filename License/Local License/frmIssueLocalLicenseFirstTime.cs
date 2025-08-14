using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;

namespace DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License
{
    public partial class frmIssueLocalLicenseFirstTime : Form
    {
        private int _LDLApplicationID;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        public frmIssueLocalLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmIssueLocalLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByID(this._LDLApplicationID);
            ctrlApplicationInfo1.LoadApplicationInfo(_LDLApplicationID);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            int newLicenseID = _LDLApplication.IssueDrivingLicenseFirstTime(tbNotes.Text, clsGlobal.LoggedInUser.UserID);
            if(newLicenseID == -1)
            {
                MessageBox.Show("Error Issuing a License", "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show(@"New Local Driving License Issued! With ID = {newLicenseID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
