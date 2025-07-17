using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_DriverAndVehiclesLicenseDepartment.Application_Types;
using DVLD_DriverAndVehiclesLicenseDepartment.Applications;
using DVLD_DriverAndVehiclesLicenseDepartment.Applications.Local_Driving_License;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using DVLD_DriverAndVehiclesLicenseDepartment.Login;
using DVLD_DriverAndVehiclesLicenseDepartment.Tests.Test_Types;
using DVLD_DriverAndVehiclesLicenseDepartment.Users;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleList managePeopleF = new frmPeopleList();
            managePeopleF.ShowDialog();
        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.LoggedInUser = null;
            this.Close();
        }
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList frm = new frmUsersList();
            frm.ShowDialog();
        }
        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = clsGlobal.LoggedInUser.UserID;
            frmUserInfo frm = new frmUserInfo(UserID);
            frm.ShowDialog();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = clsGlobal.LoggedInUser.UserID;
            frmUserChangePassword frm = new frmUserChangePassword(UserID);
            frm.ShowDialog();
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalDrivingLicense frm = new frmAddOrUpdateLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationsList frm = new frmLocalDrivingLicenseApplicationsList();
            frm.ShowDialog();
        }
    }
}
