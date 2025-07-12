using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Users
{
    public partial class frmUsersList : Form
    {
        private static DataTable _dataAllUsers = clsUser.GetAllUsers();
        private void _Refresh()
        {
            _dataAllUsers = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dataAllUsers;
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

        }
        private void _LoadFiltersInComboBox()
        {
            cbFilters.Items.Add("None");
            cbFilters.Items.Add("User ID");
            cbFilters.Items.Add("Person ID");
            cbFilters.Items.Add("Full Name");
            cbFilters.Items.Add("UserName");
            cbFilters.Items.Add("Is Active");
            cbIsActiveOrNot.Items.Add("All");
            cbIsActiveOrNot.Items.Add("Yes");
            cbIsActiveOrNot.Items.Add("No");

        }
        private int _GetUserIdOfSelectedRow()
        {
            return Convert.ToInt32(dgvUsersList.CurrentRow.Cells["UserID"].Value);
        }
        public frmUsersList()
        {
            InitializeComponent();
        }
        private void frmUsersList_Load(object sender, EventArgs e)
        {
            dgvUsersList.DataSource = _dataAllUsers;
            _LoadFiltersInComboBox();
            cbFilters.SelectedIndex = 0;
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
            if (dgvUsersList.Rows.Count > 0)
            {

                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 110;

                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].Width = 120;


                dgvUsersList.Columns[2].HeaderText = "Full Name";
                dgvUsersList.Columns[2].Width = 360;

                dgvUsersList.Columns[3].HeaderText = "UserName";
                dgvUsersList.Columns[3].Width = 140;


                dgvUsersList.Columns[4].HeaderText = "Is Active";
                dgvUsersList.Columns[4].Width = 120;
            }
        }
        private void tbInputFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilters.SelectedItem?.ToString() == "Person ID" || cbFilters.SelectedItem?.ToString() == "User ID")
            {
                // Allow only digits and control keys (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block the key
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.SelectedItem?.ToString() == "None")
            {
                cbIsActiveOrNot.Visible = false;
                tbInputFilter.Visible = false;
            }
            else if (cbFilters.SelectedItem?.ToString() == "Is Active")
            {
                cbIsActiveOrNot.Visible = true;
                tbInputFilter.Visible = false;
                cbIsActiveOrNot.SelectedIndex = 0;
            }
            else
            {
                cbIsActiveOrNot.Visible = false;
                tbInputFilter.Visible = true;
            }
            if (tbInputFilter.Visible)
            {
                tbInputFilter.Text = "";
                tbInputFilter.Focus();
            }
        }
        private void tbInputFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilters.Text)
            {
                case "None":
                    {
                        FilterColumn = "None";
                        break;
                    }
                case "User ID":
                    {
                        FilterColumn = "UserID";
                        break;
                    }
                case "Person ID":
                    {
                        FilterColumn = "PersonID";
                        break;
                    }
                case "Full Name":
                    {
                        FilterColumn = "FullName";
                        break;
                    }
                case "UserName":
                    {
                        FilterColumn = "UserName";
                        break;
                    }
                case "Is Active":
                    {
                        FilterColumn = "IsActive";
                        break;
                    }
                default:
                    break;
            }

            if (FilterColumn == "None" || tbInputFilter.Text.Trim() == "")
            {
                _dataAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
            {
                _dataAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbInputFilter.Text.Trim());
            }
            else
            {
                _dataAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbInputFilter.Text.Trim());
            }

            lblNumberOfRecords.Text = _dataAllUsers.Rows.Count.ToString();
        }
        private void cbIsActiveOrNot_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cbFilters.Text == "Is Active" ? "IsActive" : "";

            if (FilterColumn == "IsActive")
            {
                string input = cbIsActiveOrNot.SelectedItem.ToString();

                if (input == "Yes")
                    _dataAllUsers.DefaultView.RowFilter = "[IsActive] = true";

                else if (input == "No")
                    _dataAllUsers.DefaultView.RowFilter = "[IsActive] = false";

                else
                    _dataAllUsers.DefaultView.RowFilter = "";
            }
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditUserInfo frm = new frmAddOrEditUserInfo();
            frm.ShowDialog();
            _Refresh();

        }
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrEditUserInfo frm = new frmAddOrEditUserInfo();
            frm.ShowDialog();
            _Refresh();
        }
        private void editUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = _GetUserIdOfSelectedRow();
            frmAddOrEditUserInfo frm = new frmAddOrEditUserInfo(UserId);
            frm.ShowDialog();
            _Refresh();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserId = _GetUserIdOfSelectedRow();
            if(MessageBox.Show($"Are you you want to delete User with ID = {UserId}?", "Delete Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsUser.DeleteUser(UserId))
                {
                    MessageBox.Show($"User with ID = {UserId} has been deleted!", "Delete Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Refresh();
                }
                else
                {
                    MessageBox.Show($"User Account is not deleted!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }
    }
}
