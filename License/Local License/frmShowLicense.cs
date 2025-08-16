using System;
using System.Windows.Forms;

namespace DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License
{
    public partial class frmShowLicense : Form
    {
        private int _LicenseID;
        public frmShowLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseInfo1.LoadDrivingLicenseInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
