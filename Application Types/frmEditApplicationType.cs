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

namespace DVLD_DriverAndVehiclesLicenseDepartment.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationType _ApplicationType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.FindApplicationType(_ApplicationTypeID);
            if(_ApplicationType != null)
            {
                lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
                txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
                txtFees.Text = _ApplicationType.ApplicationFees.ToString();
            } else
            {
                MessageBox.Show($"No Application Type Found With This ID {_ApplicationTypeID}", "Failed To Get Applicaiton Type Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.ApplicationTypeTitle = txtTitle.Text.ToString();
            _ApplicationType.ApplicationFees = Convert.ToSingle(txtFees.Text.ToString());
            if (_ApplicationType.Save()) MessageBox.Show("Application Type Info was updated.", "Update Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show($"Update Faild, Contact Admin", "Failed Tp Update Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
