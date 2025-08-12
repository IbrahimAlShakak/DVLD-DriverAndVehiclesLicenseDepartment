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

namespace DVLD_DriverAndVehiclesLicenseDepartment.Tests.Controls
{
    public partial class ctrlTestAppointmentInfo : UserControl
    {
        clsTestAppointment _TestAppointment;

        private void _ResetDefault()
        {
            lblDrivingLicenseApplicationID.Text = "???";
            lblLicenseClass.Text = "???";
            lblName.Text = "???";
            lblTrialCount.Text = "0";
            lblDate.Text = "../../....";
            lblFees.Text = "0";
            lblTestID.Text = "None";
        }
        public ctrlTestAppointmentInfo()
        {
            InitializeComponent();
        }

        public void LoadTestApointmentInfo(int TestAppointmentID)
        {
            _TestAppointment = clsTestAppointment.FindTestAppointment(TestAppointmentID);

            if (_TestAppointment == null)
            {
                _ResetDefault();
                MessageBox.Show("Error Loading Local Driving License Application", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_TestAppointment.TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitel.Text = "Vision Test";
                        pbImageTest.BackgroundImage = Properties.Resources.VisionIcon;
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitel.Text = "Written Test";
                        pbImageTest.BackgroundImage = Properties.Resources.WriitenTestIcon;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitel.Text = "Practical Test";
                        pbImageTest.BackgroundImage = Properties.Resources.PracticalTestIcon;
                        break;
                    }
                default:
                    {
                        lblTitel.Text = "Vision Test";
                        pbImageTest.BackgroundImage = Properties.Resources.VisionIcon;
                        break;
                    }
            }

            lblDrivingLicenseApplicationID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _TestAppointment.LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _TestAppointment.LocalDrivingLicenseApplication.Applicant.FullName;
            lblTrialCount.Text = _TestAppointment.LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestAppointment.TestTypeID).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("dd/MM/yyyy");
            lblFees.Text = _TestAppointment.TestType.Fees.ToString();
            lblTestID.Text = _TestAppointment.TestID > -1 ? _TestAppointment.TestID.ToString() : "None";
        }
    }
}
