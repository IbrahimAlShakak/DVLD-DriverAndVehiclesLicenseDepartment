using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes;
using DVLD_DriverAndVehiclesLicenseDepartment.Properties;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class frmAddOrEditPersonInfo : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        enum enMode { AddNewMode, EditMode };

        enMode _Mode;
        clsPerson _Person;
        int _PersonID = -1;

        public frmAddOrEditPersonInfo()
        {
            InitializeComponent();

            _Mode = enMode.AddNewMode;


        }
        public frmAddOrEditPersonInfo(int ID)
        {
            InitializeComponent();
            _Mode = enMode.EditMode;
            _PersonID = ID;


        }
        private void frmAddOrEditPersonInfo_Load(object sender, EventArgs e)
        {
            _ResetDefaultVlaues();
            if (_Mode == enMode.EditMode) 
            { 
                _LoadData(); 
            }
        }

        //------------------------- Validations ----------------------------------------------------------------
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                eP.SetError(Temp, "This field is required!");
            }
            else
            {
                eP.SetError(Temp, null);
            }
        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (tbEmail.Text.Trim() == "") return;

            if (!clsValidatoin.ValidateEmail(tbEmail.Text))
            {
                e.Cancel = true;
                eP.SetError(tbEmail, "Invalid email address format!");
            }
            else
            {
                eP.SetError(tbEmail, null);
            }
        }
        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                eP.SetError(tbNationalNo, "This field is required!");
            }
            else
            {
                eP.SetError(tbNationalNo, null);
            }

            if (tbNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.isPersonExist(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                eP.SetError(tbNationalNo, "National Number is used for another person!");
            }
            else
            {
                eP.SetError(tbNationalNo, null);
            }
        }
        // ------------------------------------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }
        
        //---------------------------- Image Handling -----------------------------------------------------------
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            llRemoveImage.Visible = false;
        }


        // ------------------------------------------------------------------------------------------------------

        //          Private Methods
        private void _FillCountriesInCB()
        {
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.SelectedIndex = cbCountry.FindString("Iraq");
        }
        private void _ResetDefaultVlaues()
        {
            _FillCountriesInCB();

            if (_Mode == enMode.AddNewMode)
            {
                _Person = new clsPerson();
                lblTitel.Text = "Add New Person";
                lblPersonID.Text = "N/A";
            }
            else
            {
                lblTitel.Text = "Edit Person Info";
                lblPersonID.Text = _PersonID.ToString();
            }

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            tbFirstName.Text = string.Empty;
            tbSecondName.Text = string.Empty;
            tbThirdName.Text = string.Empty;
            tbLastName.Text = string.Empty;
            tbNationalNo.Text = string.Empty;
            rbMale.Checked = true;
            tbPhone.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbAddress.Text = string.Empty;

        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if ( _Person == null )
            {
                MessageBox.Show("No Perosn with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.PersonId.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Gender == 0) rbMale.Checked = true;
            else rbFemale.Checked = true;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            cbCountry.SelectedValue = _Person.CountryInfo.CountryID;
            tbAddress.Text = _Person.Address;

            if (!string.IsNullOrWhiteSpace(_Person.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
                llRemoveImage.Visible = true;
            }
        }
        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        _Person.ImagePath = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private void _Save()
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, Check the validation error and correct it", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (!_HandlePersonImage()) return;

            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked) _Person.Gender = 0;
            else _Person.Gender = 1;
            _Person.Phone = tbPhone.Text.Trim();
            _Person.Email = tbEmail.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.SelectedIndex).CountryID;
            _Person.Address = tbAddress.Text.Trim();

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonId.ToString();
                lblTitel.Text = "Edit Person Info";
                _Mode = enMode.EditMode;

                MessageBox.Show("Data saved successfully.", "Person is Saved", MessageBoxButtons.OK);
                DataBack?.Invoke(this, _Person.PersonId);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}