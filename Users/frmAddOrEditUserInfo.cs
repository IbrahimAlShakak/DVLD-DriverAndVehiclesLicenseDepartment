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
    public partial class frmAddOrEditUserInfo : Form
    {
        enum enMode { AddNewMode, EditMode };

        enMode _Mode;
        clsUser _User;
        int _UserID = -1;
        int _PersonID = -1;
        private void _ResetDefaultVlaues()
        {
            if (_Mode == enMode.AddNewMode)
            {
                _User = new clsUser();
                lblTitel.Text = "Add New User";
                lblUserID.Text = "????";
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                chkIsActive.Checked = false;
            }
            else
            {
                lblTitel.Text = "Edit User Info";
                _LoadUserData();
            }


        }
        private void _LoadUserData()
        {
            _User = clsUser.FindUser(_UserID);
            if (_User == null)
            {
                MessageBox.Show($"User Account with ID: {_UserID} is not found", "Faild to retrieve data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Mode = enMode.AddNewMode;
                _ResetDefaultVlaues();
                return;
            }
            lblUserID.Text = _UserID.ToString();
            _PersonID = _User.PersonID;
            ctrlPersonInfoCardWithFilter1.FilterEnabled = false;
            ctrlPersonInfoCardWithFilter1.LoadPersonInfo(_PersonID);
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
        }

        private void frmAddOrEditUserInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultVlaues();
        }
        public frmAddOrEditUserInfo()
        {
            InitializeComponent();
            _Mode = enMode.AddNewMode;
        }
        public frmAddOrEditUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.EditMode;
        }

        private void ctrlPersonInfoCardWithFilter1_OnPersonFound(int obj)
        {
            _PersonID = obj;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUser.PersonIdHasUserAccount(_PersonID) && _Mode != enMode.EditMode)
            {
                MessageBox.Show("This Person has an user account attached to it", "Link Person Profile Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_PersonID == -1)
            {
                MessageBox.Show("Person ID was not received", "Receiving Person ID Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            tabControl1.SelectedIndex = 1;




        }
        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox InputTemp = (TextBox)sender;

            if (string.IsNullOrEmpty(InputTemp.Text))
            {
                e.Cancel = true;
                InputTemp.Focus();
                errorProvider1.SetError(InputTemp, "This is a mandatory field, can not be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(InputTemp, null);
            }
        }
        private void ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This is a mandatory field, can not be blank!");
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords must match!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;
            _User.PersonID = _PersonID;
            if (_User.Save())
            {
                if (_Mode == enMode.AddNewMode)
                {
                    _UserID = _User.UserID;
                    _Mode = enMode.EditMode;
                    _ResetDefaultVlaues();

                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show($"Failed to Save User Info", "Faild to save data!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ConfirmPassword_Validating(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "This is a mandatory field, can not be blank!");
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords must match!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
    }
}
