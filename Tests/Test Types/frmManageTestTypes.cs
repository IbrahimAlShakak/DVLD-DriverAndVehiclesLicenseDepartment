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
using DVLD_DriverAndVehiclesLicenseDepartment.Application_Types;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Tests.Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dataAllTestTypes = clsTestType.GetAllTestTypes();
        private void _Refresh()
        {
            _dataAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypesList.DataSource = _dataAllTestTypes;
            lblNumberOfRecords.Text = dgvTestTypesList.Rows.Count.ToString();
        }
        private int _GetTestTypeIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvTestTypesList.CurrentRow.Cells["TestTypeID"].Value);
        }
        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            dgvTestTypesList.DataSource = _dataAllTestTypes;
            lblNumberOfRecords.Text = dgvTestTypesList.Rows.Count.ToString();
            if (dgvTestTypesList.Rows.Count > 0)
            {
                dgvTestTypesList.Columns[0].HeaderText = "ID";
                dgvTestTypesList.Columns[0].Width = 120;
                dgvTestTypesList.Columns[1].HeaderText = "Title";
                dgvTestTypesList.Columns[1].Width = 200;
                dgvTestTypesList.Columns[2].HeaderText = "Description";
                dgvTestTypesList.Columns[2].Width = 400;
                dgvTestTypesList.Columns[3].HeaderText = "Fees";
                dgvTestTypesList.Columns[3].Width = 100;

            }
        }
        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = _GetTestTypeIdOfSelectedRow();
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)ID);
            frm.ShowDialog();
            _Refresh();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}
