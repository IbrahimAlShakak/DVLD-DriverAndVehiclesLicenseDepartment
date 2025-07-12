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
            else if (txtCurrentPassword.Text != _User.Password)
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
                _User.Password = txtNewPassword.Text;
                if (!_User.Save()) MessageBox.Show("Error while saving the new passowrd occurred!", "Failed to Save New Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
