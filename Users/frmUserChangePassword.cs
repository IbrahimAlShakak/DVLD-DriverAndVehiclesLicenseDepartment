using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Users
{
    public partial class frmUserChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;
        public frmUserChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private void ConfirmCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "This is a mandatory field, can not be blank!");
            }
            else if (clsValidatoin.ComputeHash(txtCurrentPassword.Text)!= _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords is not corrrect!!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
        private void ConfirmNewPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This is a mandatory field, can not be blank!");
            }
            else if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password must match with new Password!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
        private void NewPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "This is a mandatory field, can not be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, null);
                
            }
        }
        private void frmUserChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserInfocs1.LoadUserInfo(_UserID);
            _User = ctrlUserInfocs1.SelectedUserInfo;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                _User.Password = clsValidatoin.ComputeHash(txtNewPassword.Text);
                if (!_User.Save()) MessageBox.Show("Error while saving the new passowrd occurred!", "Failed to Save New Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Password is changed", "Change password confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
