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
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Login
{
    public partial class frmLogin : Form
    {
        clsUser loginUser;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if (clsGlobal.GetUserNameAndPassword(ref UserName, ref Password))
            {
                tbUserName.Text = UserName;
                tbPassword.Text = Password;
                chkRememberMe.Checked = true;
            }

        }
        private void Input_Validating(object sender, CancelEventArgs e)
        {
            TextBox InputTemp = (TextBox) sender;

            if(string.IsNullOrEmpty(InputTemp.Text))
            {
                e.Cancel = true;
                InputTemp.Focus();
                errorProvider1.SetError(InputTemp, "This is a mandatory field, can not be blank!");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(InputTemp, null);
            }
               
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Requried fiels is not validated correctly", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

            string InputUserName = tbUserName.Text.Trim().ToString(), InputPassword = tbPassword.Text;

            loginUser = clsUser.FindUser(InputUserName);

            if(loginUser == null || !loginUser.IsValidPassword(InputPassword))
            {
                MessageBox.Show("Username / Password is invalid!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!loginUser.IsActive)
            {
                MessageBox.Show("Your account is deactivated please check with your Admin!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsGlobal.LoggedInUser = loginUser;

            if(chkRememberMe.Checked)
            {
                clsGlobal.SaveUsernameAndPassowrd(loginUser.UserName, loginUser.Password);

            }
            else
            {
                clsGlobal.DeleteSavedCredentials();
            }

            frmMain frm = new frmMain();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        
    }
}
