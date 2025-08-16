using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment.License
{
    public partial class frmShowLicenseHistory : Form
    {
        private int _PersonID = -1;
        private DataTable _LicenseHistory;
        public frmShowLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void _LoadLicensesHistory()
        {
            _LicenseHistory = clsLicense.LocalLicensesHistoryForPerson(_PersonID);
            dgvLocalLicenses.DataSource = _LicenseHistory;
            lblNumberOfRecords.Text = _LicenseHistory.Rows.Count.ToString();

            if (dgvLocalLicenses.Rows.Count > 0)
            {

                dgvLocalLicenses.Columns[0].HeaderText = "Licenses ID";
                dgvLocalLicenses.Columns[1].HeaderText = "Application ID";
                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";
            }

        }
        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            if(_PersonID != -1)
            {
                ctrlPersonInfoWithFilter1.LoadPersonInfo(_PersonID);
                ctrlPersonInfoWithFilter1.FilterEnabled = false;
                _LoadLicensesHistory();
            }
            else
            {
                ctrlPersonInfoWithFilter1.FilterEnabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonInfoWithFilter1_OnPersonFound(int obj)
        {
            _PersonID = obj;
            if (_PersonID != -1)
            {
                ctrlPersonInfoWithFilter1.LoadPersonInfo(_PersonID);
                _LoadLicensesHistory();
            }
            else
            {
                MessageBox.Show($"Person was not found with ID = {_PersonID}, try another personID!", "PersonID was not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
