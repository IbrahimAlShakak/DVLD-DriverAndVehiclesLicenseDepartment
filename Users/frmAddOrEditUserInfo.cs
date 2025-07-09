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
        private int _idFound;
        public frmAddOrEditUserInfo()
        {
            InitializeComponent();
        }

        private void ctrlPersonInfoCardWithFilter1_OnPersonFound(int obj)
        {
            _idFound = obj;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(clsUser.PersonIdHasUserAccount(_idFound))
            {
                MessageBox.Show("This Person has an user account attached to it", "Link Person Profile Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "This is a mandatory field, can not be blank!");
            }
            else if(txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Passwords must match!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }



    }
}
