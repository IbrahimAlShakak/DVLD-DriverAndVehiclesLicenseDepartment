using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using DVLD_DriverAndVehiclesLicenseDepartment.Licenses.International_Licenses;

namespace DVLD_DriverAndVehiclesLicenseDepartment.License.International_Licenses
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private int _LocalLicenseID;
        private clsLicense _LocalLicense;
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDrivingLicenseInfoWithFilter1_OnLicenseFound(int obj)
        {
            _LocalLicenseID = obj;
            _LocalLicense = clsLicense.FindLicenceByLicenseID(_LocalLicenseID);
            frmNewInternationalLicenseApplication_Load(null, null);
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            if (_InternationalLicenseID == -1)
            {
                lblTitel.Text = "New International License Application";
            }
            else
            {
                lblTitel.Text = "International License Application";
                llShowLicenseInfo.Enabled = true;
                
            }

            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName;
            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
            lblFees.Text = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();

            if(_LocalLicense != null)
            {
                llShowLicenseHistory.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_LocalLicense.LicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }
        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(clsInternationalLicense.DriverHasActiveInternationalLicense(_LocalLicense.DriverID))
            {
                MessageBox.Show($"Driver has already an international license issued! With ID = {clsInternationalLicense.GetActiveInternationalLicenseIDForDriver(_LocalLicense.DriverID)}",
                    "Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _InternationalLicense = new clsInternationalLicense();
            _InternationalLicense.ApplicantPersonID = _LocalLicense.Driver.PersonID;
            _InternationalLicense.PaidFees = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
            _InternationalLicense.CreatedByUserID = clsGlobal.LoggedInUser.UserID;
            _InternationalLicense.DriverID = _LocalLicense.DriverID;
            _InternationalLicense.IssuedUsingLocallicenseID = _LocalLicense.LicenseID;
            _InternationalLicense.IssuedDate = DateTime.Now;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.IsActive = true;

            if(_InternationalLicense.Save())
            {
                _InternationalLicenseID = _InternationalLicense.InternatiolLicenseID;
                lblInternationalLicenseApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                lblInternationalLicenseID.Text = _InternationalLicenseID.ToString();
                llShowLicenseInfo.Enabled = true;
                MessageBox.Show($"New international driving license was issued with ID = {_InternationalLicenseID}", "New International License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error creating new license!", "License is now isuued!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
