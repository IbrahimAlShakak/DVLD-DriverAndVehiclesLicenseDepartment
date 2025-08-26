using System;
using System.Windows.Forms;

namespace DVLD_DriverAndVehiclesLicenseDepartment.License.Controls
{
    public partial class ctrlDrivingLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseFound;
        protected virtual void LicenseFound(int LicenseID)
        {
            Action<int> handler = OnLicenseFound;
            if (handler != null) handler(LicenseID);
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        public ctrlDrivingLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void tbLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            int InputLicenseID = Convert.ToInt32(tbLicenseID.Text);
            if (ctrlDrivingLicenseInfo1.LoadDrivingLicenseInfo(InputLicenseID))
                LicenseFound(InputLicenseID);
            else
            {
                MessageBox.Show($"License with ID = {InputLicenseID} was not found!", "License Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            ctrlDrivingLicenseInfo1.LoadDrivingLicenseInfo(LicenseID);
        }
    }
}
