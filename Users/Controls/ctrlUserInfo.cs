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
using DVLD_DriverAndVehiclesLicenseDepartment.Properties;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Users.Controls
{
    public partial class ctrlUserInfocs : UserControl
    {
        private clsUser _User;
        private int _UserID = -1;
        public int UserID
        {
            get
            {
                return _UserID;
            }
        }
        public clsUser SelectedUserInfo
        {
            get
            {
                return _User;
            }
        }

        public ctrlUserInfocs()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindUser(UserID);
            if (_User == null)
            {
                ResetDefault();
                MessageBox.Show($"A User with ID = {UserID} is not found!", "Invalid User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _UserID = _User.UserID;
            _FillPersonInfo();
        }
        public void LoadUserInfo(string UserName)
        {
            _User = clsUser.FindUser(UserName);
            if (_User == null)
            {
                ResetDefault();
                MessageBox.Show($"A User with UserName = {UserName} is not found!", "Invalid UserName", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _UserID = _User.UserID;
            _FillPersonInfo();
        }
        public void ResetDefault()
        {
            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";
        }
        private void _FillPersonInfo()
        {
            ctrlPersonInfo1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            lblUsername.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }
    }
}
