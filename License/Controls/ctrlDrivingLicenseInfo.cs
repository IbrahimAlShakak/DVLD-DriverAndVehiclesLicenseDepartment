using System.IO;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment.License.Controls
{
    public partial class ctrlDrivingLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicense _License;
        public ctrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (_License.Driver.PersonInfo.ImagePath != "")
            {
                if (File.Exists(_License.Driver.PersonInfo.ImagePath))
                {
                    pbPersonImage.ImageLocation = _License.Driver.PersonInfo.ImagePath;
                }
                else
                    MessageBox.Show("Could not find this image: = " + _License.Driver.PersonInfo.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDrivingLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.FindLicenceByLicenseID(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _License.Driver.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.Driver.PersonInfo.NationalNo;
            lblGender.Text = _License.Driver.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _License.IssueDate.ToString("dd/MM/yyyy");

            switch(_License.IssueReason)
            {
                case clsLicense.enIssueReason.FirstTime:
                    lblIssueReason.Text = "First Time";
                    break;
                case clsLicense.enIssueReason.Renew:
                    lblIssueReason.Text = "Renew";
                    break;
                case clsLicense.enIssueReason.ReplacementForDamage:
                    lblIssueReason.Text = "Replacement For Damage";
                    break;
                case clsLicense.enIssueReason.ReplacementForLost:
                    lblIssueReason.Text = "Replacement For Lost";
                    break;
            }

            lblNotes.Text = _License.Notes;
            lblIsActive.Text = _License.IsActive == true ? "Yes" : "No";
            lblDateOfBirth.Text = _License.Driver.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MM/yyyy");
            lblIsDetained.Text = "No";

            _LoadPersonImage();
        }
    }
}
