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

namespace DVLD_DriverAndVehiclesLicenseDepartment.Tests
{
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID;
        clsTestAppointment _TestAppointment;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlTestAppointmentInfo1.LoadTestApointmentInfo(_TestAppointmentID);
            _TestAppointment = clsTestAppointment.FindTestAppointment(_TestAppointmentID);
            
            if(_TestAppointment.TestID != -1)
            {
                btnSave.Enabled = false;
                rbPass.Enabled = false;
                rbFail.Enabled = false;
            }

            rbFail.Checked = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(rbPass.Checked == false && rbPass.Checked == false)
            {
                MessageBox.Show("Please choose the result of the test!", "This is a mandatory field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsTest Test = new clsTest();

            Test.TestAppointmentID = _TestAppointmentID;
            Test.TestResult = rbPass.Checked ? true : false;
            Test.CreatedByUserID = clsGlobal.LoggedInUser.UserID;
            Test.Notes = tbNotes.Text;

            if(Test.Save())
            {
                MessageBox.Show("Test result was saved successfully!", "Result Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                _TestAppointment.IsLocked = true;
                _TestAppointment.Save();
                ctrlTestAppointmentInfo1.LoadTestApointmentInfo(_TestAppointmentID);
            }
            else
            {
                MessageBox.Show("Test result was not saved!", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
