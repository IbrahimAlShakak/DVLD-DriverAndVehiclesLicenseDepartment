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

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class ManagePeopleF : Form
    {
        private void _LoadData()
        {
            dgvPeopleList.DataSource = clsPerson.GetAllPeopleList();
            lblNumberOfRecords.Text = dgvPeopleList.Rows.Count.ToString();
        }
        public ManagePeopleF()
        {
            InitializeComponent();
            _LoadData();


        }
    }
}
