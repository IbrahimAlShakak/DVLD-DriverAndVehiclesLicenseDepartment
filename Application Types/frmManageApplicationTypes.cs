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
    public partial class frmManageApplicationTypes : Form
    {
        private DataTable _dataAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
        private clsApplicationType _ApplicationType;
        private void _Refresh()
        {
            _dataAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypesList.DataSource = _dataAllApplicationTypes;
            lblNumberOfRecords.Text = dgvApplicationTypesList.Rows.Count.ToString();
        }
        private int _GetApplicationTypeIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvApplicationTypesList.CurrentRow.Cells["ApplicationTypeID"].Value);
        }
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvApplicationTypesList.DataSource = _dataAllApplicationTypes;
            lblNumberOfRecords.Text = dgvApplicationTypesList.Rows.Count.ToString();
            if (dgvApplicationTypesList.Rows.Count > 0)
            {
                dgvApplicationTypesList.Columns[0].HeaderText = "ID";
                dgvApplicationTypesList.Columns[1].HeaderText = "Title";
                dgvApplicationTypesList.Columns[2].HeaderText = "Fees";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetApplicationTypeIdOfSelectedRow();
            frmEditApplicationType frm = new frmEditApplicationType(ID);
            frm.ShowDialog();
            _Refresh();
        }
    }
}
