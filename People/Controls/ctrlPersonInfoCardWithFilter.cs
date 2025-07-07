using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment.People.Controls
{
    public partial class ctrlPersonInfoCardWithFilter : UserControl
    {
        public event Action<int> OnPersonFound;
        protected virtual void PersonFound(int PersonId)
        {
            Action<int> handler = OnPersonFound;
            if (handler != null) handler(PersonId);
        }

        private bool _ShowAddNewPerson = true;
        public bool ShowAddNewPerson
        {
            get { return _ShowAddNewPerson; }
            set
            {
                _ShowAddNewPerson = value;
                btnAddNewPerson.Enabled = _ShowAddNewPerson;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public int PersonID
        {
            get { return ctrlPersonInfoCard1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonInfoCard1.SelectedPersonInfo; }
        }


        private void _LoadFiltersInComboBox()
        {
            cbFilters.Items.Add("Person ID");
            cbFilters.Items.Add("National Number");
            cbFilters.SelectedIndex = 0;
        }

        private void _SearchForPerson()
        {
            switch(cbFilters.Text)
            {
                case "Person ID":
                    {
                        ctrlPersonInfoCard1.LoadPersonInfo(int.Parse(tbSearchInput.Text));
                        break;
                    }
                case "National Number":
                    {
                        ctrlPersonInfoCard1.LoadPersonInfo(tbSearchInput.Text.ToString());
                        break;
                    }
                default:
                    break;
            }
        }
        public ctrlPersonInfoCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlPersonInfoCard1_Load(object sender, EventArgs e)
        {
            _LoadFiltersInComboBox();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SearchForPerson();


        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPersonInfo frm  = new frmAddOrEditPersonInfo();
            frm.DataBack += _DataBackFromForm;
            frm.ShowDialog();
        }
        private void _DataBackFromForm(object sender, int PersonID)
        {
            cbFilters.SelectedIndex = 0;
            tbSearchInput.Text = PersonID.ToString();
            ctrlPersonInfoCard1.LoadPersonInfo(PersonID);
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearchInput.Text = "";
        }

        private void tbSearchInput_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbSearchInput, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(tbSearchInput, null);
            }
        }
        private void tbFilteringInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.SelectedItem?.ToString() == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Cancel the input
                }
            }
        }
        private void tbFilteringInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (!ValidateChildren())
                {
                    MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _SearchForPerson();

                e.SuppressKeyPress = true;
            }

            
        }

        
    }
}
