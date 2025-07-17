using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications
{
    public partial class frmAddOrUpdateLocalDrivingLicense : Form
    {
        private enum enMode { AddNewMode, EditMode };
        enMode _Mode = enMode.AddNewMode;

        private int _LDLApplicaitonID = -1;
        private clsLocalDrivingLicenseApplication _LDLApplication = new clsLocalDrivingLicenseApplication();

        private int _NewApplicationID = -1;
        private int _PersonID = -1;
        private void ResetDefault()
        {
            //  Application Date
            lblApplicationDate.Text = DateTime.Now.ToString("");

            //  License Classes
            cbLicenseClasses.Items.Clear();
            DataTable _dataLicenseClasses = clsLicenseClass.GetAllLicenseClassesData();
            foreach (DataRow row in _dataLicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"].ToString());
            }
            cbLicenseClasses.SelectedIndex = 2;

            //  Application Fees
            clsApplicationType ApplicationType = clsApplicationType.FindApplicationType(1);
            lblApplicationFees.Text = ApplicationType.ApplicationFees.ToString();

            //  User
            lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName;
        }
        public frmAddOrUpdateLocalDrivingLicense()
        {
            InitializeComponent();
        }
        public frmAddOrUpdateLocalDrivingLicense(int LocalDrivingLicenseApplication)
        {
            InitializeComponent();
            _LDLApplicaitonID = LocalDrivingLicenseApplication;
            _Mode = enMode.EditMode;
        }
        private void ctrlPersonInfoWithFilter1_OnPersonFound(int obj)
        {
            _PersonID = obj;
        }
        private void frmAddOrUpdateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.EditMode)
            {
                _LDLApplication = clsLocalDrivingLicenseApplication.FindLocalLicenseApplication(_LDLApplicaitonID);

                ctrlPersonInfoWithFilter1.LoadPersonInfo(_LDLApplication.Applicant.PersonId);

                lblTitel.Text = "Edit Drving License Application";

                _LDLApplicaitonID = _LDLApplication.LocalDrivingLicenseApplicationID;

                lbllocalDrivingLicenseApplicationID.Text = _LDLApplicaitonID.ToString();
                lblApplicationDate.Text = _LDLApplication.ApplicationDate.ToString();
                cbLicenseClasses.Text = _LDLApplication.LicenseClassInfo.ClassName;

                clsApplicationType ApplicationType = clsApplicationType.FindApplicationType(1);
                lblApplicationFees.Text = ApplicationType.ApplicationFees.ToString();

                lblCreatedBy.Text = clsGlobal.LoggedInUser.UserName;
            }
            if(_Mode == enMode.AddNewMode)   
            {
                lblTitel.Text = "Add New Drving License Application";
                ResetDefault();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.FindLicenseClassByClassName(cbLicenseClasses.Text).LicenseClassID;
            _NewApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_PersonID, 1, LicenseClassID);

            if (_NewApplicationID != -1)
            {
                MessageBox.Show($"Select another License class, the selected person have an active application for the selected class with ID = {_NewApplicationID}",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LDLApplication.ApplicantPersonID = _PersonID;
            _LDLApplication.ApplicationDate = DateTime.Now;
            _LDLApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LDLApplication.LastStatusDate = DateTime.Now;
            _LDLApplication.ApplicationTypeID = 1;
            _LDLApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LDLApplication.CreatedByUserID = clsGlobal.LoggedInUser.UserID;
            _LDLApplication.LicenseClassID = LicenseClassID;

            if (_LDLApplication.Save())
            {
                lbllocalDrivingLicenseApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.EditMode;
                lblTitel.Text = "Edit Drving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
