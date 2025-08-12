using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Tests
{
    public partial class frmScheduleTest : Form
    {
        private enum enMode { AddNewMode, EditMode }
        private enMode _Mode = enMode.AddNewMode;

        private enum enLoadType { FirsTimeTestAttend, RetakeTest }
        private enLoadType _LoadType = enLoadType.FirsTimeTestAttend;

        private int _LDLApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LDLApplication;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID = -1;

        private bool _HandleActiveTesAppointmentConstraint()
        {
            if (_Mode == enMode.AddNewMode && _LDLApplication.IsThereAnActiveScheduledTest((int)_TestTypeID))
            {
                lblSubTitel.Text = "Person Already have an active appointment for this test";
                lblSubTitel.Visible = true;
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }
            lblSubTitel.Visible = false;
            return true;
        }

        private bool _HandleTestAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblSubTitel.Visible = true;
                lblSubTitel.Text = "Person already sat for the test, appointment loacked.";
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lblSubTitel.Visible = false;

            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblSubTitel.Visible = false;
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    if (!_LDLApplication.DidPassTest(clsTestType.enTestType.VisionTest))
                    {
                        lblSubTitel.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblSubTitel.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblSubTitel.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }
                    return true;

                case clsTestType.enTestType.StreetTest:
                    if (!_LDLApplication.DidPassTest(clsTestType.enTestType.WrittenTest))
                    {
                        lblSubTitel.Text = "Cannot Sechule, Written Test should be passed first";
                        lblSubTitel.Visible = true;
                        btnSave.Enabled = false;
                        dtpDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblSubTitel.Visible = false;
                        btnSave.Enabled = true;
                        dtpDate.Enabled = true;
                    }
                    return true;
            }
            return true;
        }
        private bool _HandleRetakeTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNewMode && _LoadType == enLoadType.RetakeTest)
            {
                clsApplication RetakeTestApplication = new clsApplication();
                RetakeTestApplication.ApplicantPersonID = _LDLApplication.ApplicantPersonID;
                RetakeTestApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                RetakeTestApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                RetakeTestApplication.PaidFees = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.RetakeTest).Fees;
                RetakeTestApplication.CreatedByUserID = clsGlobal.LoggedInUser.UserID;
                if (!RetakeTestApplication.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = RetakeTestApplication.ApplicationID;
            }
            return true;
        }
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LDLApplicationID = LocalDrivingLicenseApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByID(_LDLApplicationID);
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;

        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if (_LDLApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LDLApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                this.Close();
            }

            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitel.Text = "Schedule Vision Test";
                        pbImageTest.BackgroundImage = Properties.Resources.VisionIcon;
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitel.Text = "Schedule Written Test";
                        pbImageTest.BackgroundImage = Properties.Resources.WriitenTestIcon;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitel.Text = "Schedule Practical Test";
                        pbImageTest.BackgroundImage = Properties.Resources.PracticalTestIcon;
                        break;
                    }
                default:
                    {
                        lblTitel.Text = "Schedule Vision Test";
                        pbImageTest.BackgroundImage = Properties.Resources.VisionIcon;
                        break;
                    }
            }

            if (_TestAppointmentID == -1)
                _Mode = enMode.AddNewMode;
            else
                _Mode = enMode.EditMode;

            if (_LDLApplication.DidAttendTest(_TestTypeID))
                _LoadType = enLoadType.RetakeTest;
            else
                _LoadType = enLoadType.FirsTimeTestAttend;

            switch (_LoadType)
            {
                case enLoadType.FirsTimeTestAttend:
                    {
                        gbRetakeTest.Enabled = false;
                        lblRetakeapplicationFees.Text = "0";
                        lblRetakeApplicationID.Text = "???";
                        break;
                    }
                case enLoadType.RetakeTest:
                    {
                        gbRetakeTest.Enabled = true;
                        lblTitel.Text = "Schedule Retake Test";
                        lblRetakeapplicationFees.Text = clsApplicationType.FindApplicationType((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                        lblRetakeApplicationID.Text = "-1";
                        break;
                    }
            }

            lblDrivingLicenseApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LDLApplication.Applicant.FullName;
            lblTrialCount.Text = _LDLApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            dtpDate.MinDate = DateTime.Today;
            dtpDate.Value = DateTime.Today;
            lblFees.Text = clsTestType.FindTestType(_TestTypeID).Fees.ToString();

            if (_Mode == enMode.AddNewMode)
            {
                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                _TestAppointment = clsTestAppointment.FindTestAppointment(_TestAppointmentID);

                if (_TestAppointment == null)
                {
                    MessageBox.Show("Test Appointment was not received!", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    this.Close();
                }
                lblFees.Text = _TestAppointment.PaidFees.ToString();
                dtpDate.MinDate = _TestAppointment.AppointmentDate < DateTime.Today ? _TestAppointment.AppointmentDate : DateTime.Today;
                dtpDate.Value = _TestAppointment.AppointmentDate < DateTime.Today ? _TestAppointment.AppointmentDate : DateTime.Today;

                if (_TestAppointment.RetakeTestApplicationID == -1)
                {
                    lblRetakeapplicationFees.Text = "0";
                    lblRetakeApplicationID.Text = "N/A";
                }
                else
                {
                    lblRetakeapplicationFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                    gbRetakeTest.Enabled = true;
                    lblTitel.Text = "Schedule Retake Test";
                    lblRetakeApplicationID.Text = _TestAppointment.RetakeTestApplicationID.ToString();

                }
            }

            lblTotalFees.Text = (Convert.ToSingle(lblRetakeapplicationFees.Text) + Convert.ToSingle(lblFees.Text)).ToString();

            if (!_HandleActiveTesAppointmentConstraint())
                this.Close();

            if (!_HandleTestAppointmentLockedConstraint())
                this.Close();

            if (!_HandlePrviousTestConstraint())
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeTestAppointmentConstraint())
                this.Close();

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblTotalFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.LoggedInUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.EditMode;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
