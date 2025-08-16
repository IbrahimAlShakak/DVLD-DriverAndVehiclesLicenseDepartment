using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Tests
{
    public partial class frmTestAppointmentsList : Form
    {
        private int _LDLApplictionID = -1;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        private clsTestType _TestType;
        private DataTable _AllTestAppointments;
        public frmTestAppointmentsList(int LocalDrivingLicenseID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LDLApplictionID = LocalDrivingLicenseID;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByID(_LDLApplictionID);
            _TestType = clsTestType.FindTestType(TestType);
            
        }
        private void frmTestAppointmentsList_Load(object sender, EventArgs e)
        {
            switch(_TestType.ID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        this.Text = "Vision Test Appointments";
                        pbTestTypeImage.BackgroundImage = Properties.Resources.VisionIcon;
                        lblTitel.Text = "Vision Test Appointments";
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        this.Text = "Written Test Appointments";
                        pbTestTypeImage.BackgroundImage = Properties.Resources.WriitenTestIcon;
                        lblTitel.Text = "Written Test Appointments";
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        this.Text = "Practical Test Appointments";
                        pbTestTypeImage.BackgroundImage = Properties.Resources.PracticalTestIcon;
                        lblTitel.Text = "Practical Test Appointments";
                        break;
                    }
                default:
                    {
                        this.Text = "Test Appointments";
                        pbTestTypeImage.BackgroundImage = null;
                        lblTitel.Text = "Test Appointments";
                        break;
                    }
            }

            if(_LDLApplication != null)
            {
                ctrlApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LDLApplication.LocalDrivingLicenseApplicationID);
            }

            _AllTestAppointments = clsTestAppointment.GetTestAppointmentsForLDLApplicationIDFilterTestType(_LDLApplictionID, (int)_TestType.ID);
            dgvTestAppointments.DataSource = _AllTestAppointments;
            lblNumberOfRecords.Text = dgvTestAppointments.Rows.Count.ToString();

            if (dgvTestAppointments.Rows.Count > 0)
            {

                dgvTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvTestAppointments.Columns[3].HeaderText = "Is Locked";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void btnAddNewTestAppointment_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LDLApplication.LocalDrivingLicenseApplicationID, (int)_TestType.ID))
            {
                MessageBox.Show("Person already has an active appointment for this test, you can not add a new test appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsLocalDrivingLicenseApplication.DidPassTest(_LDLApplication.LocalDrivingLicenseApplicationID, (int)_TestType.ID))
            {
                MessageBox.Show("Person already passed this test, you can not add a new test appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest(_LDLApplication.LocalDrivingLicenseApplicationID, _TestType.ID);
            frm.ShowDialog();
            frmTestAppointmentsList_Load(null, null);
            
        }

        private void editTestAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int) dgvTestAppointments.CurrentRow.Cells[0].Value;


            frmScheduleTest frm = new frmScheduleTest(_LDLApplictionID, _TestType.ID, TestAppointmentID);
            frm.ShowDialog();
            frmTestAppointmentsList_Load(null, null);

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(TestAppointmentID);
            frm.ShowDialog();
            frmTestAppointmentsList_Load(null, null);
        }
    }
}