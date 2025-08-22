using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Licenses.International_Licenses
{
    public partial class frmInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID;
        public frmInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmInternationalLicenseInfo_Load(object sender, System.EventArgs e)
        {
            if(_InternationalLicenseID != -1)
            {
                clsInternationalLicense InternationalLicense = clsInternationalLicense.FindInternatiolLicenseByID(_InternationalLicenseID);

                if (InternationalLicense == null)
                {
                    MessageBox.Show("Error loadind License info!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblName.Text = InternationalLicense.DriverInfo.PersonInfo.FullName;
                lblInternatioanlLicenseID.Text = _InternationalLicenseID.ToString();    
                lblLicenseID.Text = InternationalLicense.IssuedUsingLocallicenseID.ToString();
                lblNationalNo.Text = InternationalLicense.DriverInfo.PersonInfo.NationalNo;
                lblGender.Text = InternationalLicense.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
                lblIssueDate.Text = InternationalLicense.IssuedDate.ToString("dd/MM/yyyy");
                lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
                lblDateOfBirth.Text = InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
                lblDriverID.Text = InternationalLicense.DriverID.ToString();
                lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToString("dd/MM/yyyy");
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
