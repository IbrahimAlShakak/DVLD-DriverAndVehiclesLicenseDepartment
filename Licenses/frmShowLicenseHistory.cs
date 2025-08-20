using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment.License
{
    public partial class frmShowLicenseHistory : Form
    {
        private int _PersonID = -1;
        private DataTable _LocalLicensesHistory;
        private DataTable _InternationalLicensesHistory;
        public frmShowLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void _LoadInternationalLicenseHistory()
        {
            _InternationalLicensesHistory = clsInternationalLicense.GetInternationalLicensesHistoryForPerson(_PersonID);

            dgvInternatioanlLicenses.DataSource = _InternationalLicensesHistory;

            lblInternatioanlLicensesCount.Text = _InternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternatioanlLicenses.Rows.Count > 0)
            {

                dgvInternatioanlLicenses.Columns[0].HeaderText = "Licenses ID";
                dgvInternatioanlLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternatioanlLicenses.Columns[2].HeaderText = "Local License ID";
                dgvInternatioanlLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternatioanlLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternatioanlLicenses.Columns[5].HeaderText = "Is Active";
            }
        }
        private void _LoadLocalLicensesHistory()
        {
            _LocalLicensesHistory = clsLicense.LocalLicensesHistoryForPerson(_PersonID);

            dgvLocalLicenses.DataSource = _LocalLicensesHistory;

            lblNumberOfRecords.Text = _LocalLicensesHistory.Rows.Count.ToString();

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
                _LoadLocalLicensesHistory();
                _LoadInternationalLicenseHistory();
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
                _LoadLocalLicensesHistory();
                _LoadInternationalLicenseHistory();
            }
            else
            {
                MessageBox.Show($"Person was not found with ID = {_PersonID}, try another personID!", "PersonID was not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
