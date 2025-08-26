using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using DVLD_DriverAndVehiclesLicenseDepartment.License;
using DVLD_DriverAndVehiclesLicenseDepartment.License.Local_License;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Licenses.Detain_License
{
    public partial class frmDetainLicense : Form
    {
        private int _LicenseID;
        private clsLicense _License;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        private void ctrlDrivingLicenseInfoWithFilter1_OnLicenseFound(int obj)
        {
            _LicenseID = obj;
            frmDetainLicense_Load(null, null);
        }
        private void frmDetainLicense_Load(object sender, System.EventArgs e)
        {
            _License = clsLicense.FindLicenceByLicenseID(_LicenseID);

            if (_License == null)
                return;

            btnDetain.Enabled = true;
            llShowLicenseHistory.Enabled = true;

            if (_License != null &&  _License.IsDetianed)
            {
                MessageBox.Show("The License is already detained! Choose another license", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblDetainID.Text = _License.GetLicenseDetainID().ToString();
                btnDetain.Enabled = false;
            }
               

            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblLicenseID.Text = _LicenseID.ToString();  
            lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName;
        }
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_License.Driver.PersonID);
            frm.ShowDialog();
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fine fees  input box is not valid!, Check the validation error and correct it", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_License.DetainLicense(Convert.ToSingle(tbFineFees.Text), clsGlobal.LoggedInUser.UserID))
            {
                MessageBox.Show("The License is detained!", "Detain Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDetainID.Text = _License.GetLicenseDetainID().ToString();
                llShowLicenseInfo.Enabled = true;
                btnDetain.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error occured during detain process contsct admin", "Detian Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_License.Driver.PersonID);
            frm.ShowDialog();
        }
        private void tbFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFineFees, "This field is required!");
            } else if (!clsValidatoin.IsNumber(tbFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFineFees, "This field must contain a number");
            }
        }
    }
}
