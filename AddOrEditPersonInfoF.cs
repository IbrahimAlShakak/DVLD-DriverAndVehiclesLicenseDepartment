using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment;
using System.IO;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class AddOrEditPersonInfoF : Form
    {
        clsPerson Person;
        enum enFormMode {AddNewMode, EditMode };
        enFormMode _mode;
        bool _allFieldsValid = true;
        string _imageDirectory = Path.Combine(Application.StartupPath, "PeopleImages");

        //------------------------- Validations ----------------------------------------------------------------
        private void _ValidateRequiredLetters(TextBox tb, ErrorProvider ep, string name)
        {
            var txt = tb.Text.Trim();
            if (txt.Length == 0) { ep.SetError(tb, $"{name} is required."); _allFieldsValid = false; }
            else if (!Regex.IsMatch(txt, @"^[A-Za-z]+$"))
            { ep.SetError(tb, $"{name} must contain only letters."); _allFieldsValid = false; }
            else ep.SetError(tb, "");
        }
        private void _ValidateOptionalLetters(TextBox tb, ErrorProvider ep, string name)
        {
            var txt = tb.Text.Trim();
            if (txt.Length > 0 && !Regex.IsMatch(txt, @"^[A-Za-z]+$"))
            { ep.SetError(tb, $"{name} must contain only letters."); _allFieldsValid = false; }
            else ep.SetError(tb, "");
        }
        private void _ValidateNationalNo()
        {
            var txt = tbNationalNo.Text.Trim();
            if (txt.Length == 0)
            {
                epNationalNo.SetError(tbNationalNo, "National No is required.");
                _allFieldsValid = false;
            }
            else if (!Regex.IsMatch(txt, @"^[A-Za-z][A-Za-z0-9]*$"))
            {
                epNationalNo.SetError(tbNationalNo, "Must start with a letter and contain only letters/digits.");
                _allFieldsValid = false;
            }
            else if (clsPerson.isNarionalNoExist(tbNationalNo.Text) && _mode == enFormMode.AddNewMode)
            {
                epNationalNo.SetError(tbNationalNo, "This National Numer is already used!.");
                _allFieldsValid = false;
            }
            else epNationalNo.SetError(tbNationalNo, "");
        }
        private void _ValidatePhone()
        {
            var txt = tbPhone.Text.Trim();
            if (txt.Length == 0) { epPhone.SetError(tbPhone, "Phone is required."); _allFieldsValid = false; }
            else if (!Regex.IsMatch(txt, @"^\+?\d+$"))
            { epPhone.SetError(tbPhone, "Phone must be digits only (may start with '+')."); _allFieldsValid = false; }
            else epPhone.SetError(tbPhone, "");
        }
        private void _ValidateEmail()
        {
            var txt = tbEmail.Text.Trim();
            if (!Regex.IsMatch(txt, @"^$|^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { epEmail.SetError(tbEmail, "Invalid email format."); _allFieldsValid = false; }
            else epEmail.SetError(tbEmail, "");
        }
        private void _ValidateDOB()
        {
            if (dtpDateOfBirth.Value.Date > DateTime.Today.AddYears(-18))
            { epDOB.SetError(dtpDateOfBirth, "You must be at least 18 years old."); _allFieldsValid = false; }
            else epDOB.SetError(dtpDateOfBirth, "");
        }
        private void _ValidateAddress()
        {
            var txt = tbAddress.Text.Trim();
            if (txt.Length == 0)
                epAddress.SetError(tbAddress, "Address is required.");
            else if (!Regex.IsMatch(txt, @"^[A-Za-z0-9\s,\.\-]+$"))
                epAddress.SetError(tbAddress, "Address contains invalid characters.");
            else
                epAddress.SetError(tbAddress, "");
        }
        private void _ValidateGender()
        {
            {
                // neither button is selected?
                if (!rbMale.Checked && !rbFemale.Checked)
                {
                    epGender.SetError(rbFemale, "Please select a gender.");
                    _allFieldsValid = false;
                }
                else
                    epGender.SetError(rbMale, "");
            }

        }
        private void _LoadCountries()
        {
            cbCountry.DataSource = clsPerson.GetAllCountries();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.SelectedIndex = 89;
        }
        private void _ValidateAll()
        {
            _allFieldsValid = true;
            _ValidateRequiredLetters(tbFirstName, epFirstName, "First name");
            _ValidateRequiredLetters(tbSecondName, epSecondName, "Second name");
            _ValidateOptionalLetters(tbThirdName, epThirdName, "Third name");
            _ValidateRequiredLetters(tbLastName, epLastName, "Last name");
            _ValidateAddress();
            _ValidateNationalNo();
            _ValidatePhone();
            _ValidateEmail();
            _ValidateDOB();
            _ValidateGender();
        }
        // ------------------------------------------------------------------------------------------------------
        private void _LoadPersonInfoByID(int ID)
        {
            tbFirstName.Text = Person.FirstName;
            tbSecondName.Text = Person.SecondName;
            tbThirdName.Text = Person.ThirdName;
            tbLastName.Text = Person.LastName;
            tbNationalNo.Text = Person.NationalNo;
            dtpDateOfBirth.Value = Person.DateOfBirth;
            if (Person.Gender == 0) rbMale.Checked = true;
            else rbFemale.Checked = true;
            tbPhone.Text = Person.Phone;
            tbEmail.Text = Person.Email;
            cbCountry.SelectedValue = Person.NationalityCountryID;
            tbAddress.Text = Person.Address;
            if (!string.IsNullOrWhiteSpace(Person.ImagePath) && File.Exists(Person.ImagePath))
            {
                pbPersonImage.Image = Image.FromFile(Person.ImagePath);
            }
        }
        private void _CheckFormMode(int ID)
        {
            if (ID == -1)
            {
                _mode = enFormMode.AddNewMode;
                lblTitel.Text = "Add New Person";
                lblPersonID.Text = "N/A";
                Person = new clsPerson();
            }
            else
            {
                Person = clsPerson.Find(ID);
                if (Person != null)
                {
                    _mode = enFormMode.EditMode;
                    lblTitel.Text = "Edit Person Info";
                    lblPersonID.Text = ID.ToString();
                    _LoadPersonInfoByID(ID);
                }

            }
        }
        public AddOrEditPersonInfoF(int ID = -1)
        {
            InitializeComponent();
           
            _LoadCountries();
            _CheckFormMode(ID);
           
           
        }
        private void _SetImageToPerson()
        {
            
            Directory.CreateDirectory(_imageDirectory);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if(Person.ImagePath != "") Person.DeleteImageFile(Person.ImagePath);

                string ext = Path.GetExtension(ofd.FileName);
                string newFileName = Guid.NewGuid().ToString() + ext;
                string destinationPath = Path.Combine(_imageDirectory, newFileName);

                File.Copy(ofd.FileName, destinationPath);
                Person.ImagePath = destinationPath;

                if (pbPersonImage.Image != null)
                {
                    pbPersonImage.Image.Dispose();
                    pbPersonImage.Image = null;
                }

                pbPersonImage.Image = Image.FromFile(Person.ImagePath);
                llRemoveImage.Visible = true;
            }

        }
        private void _RemoveImage()
        {
            if (Person.ImagePath != "") Person.DeleteImageFile(Person.ImagePath);
            if (pbPersonImage.Image != null)
            {
                pbPersonImage.Image.Dispose();
                pbPersonImage.Image = null;
                llRemoveImage.Visible = false;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _ValidateAll();
            if (!_allFieldsValid)
            {
                MessageBox.Show("Please Make sure all the input fields without erros !", "Saving Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           if(Person.Save()) 
            {
                if(_mode == enFormMode.AddNewMode)
                {
                    if (MessageBox.Show("Added new person info to Databasse", "Adding Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        _LoadPersonInfoByID(Person.PersonId);

                }
                else
                {
                    this.Close();
                }
            }
        }
        //---------------------------- Text Change || Value Change -----------------------------------------------------
        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {
             _ValidateRequiredLetters(tbFirstName, epFirstName, "First name");
        }
        private void tbSecondName_TextChanged(object sender, EventArgs e)
        {
            _ValidateOptionalLetters(tbSecondName, epSecondName, "Second name");

        }
        private void tbThirdName_TextChanged(object sender, EventArgs e)
        {
            _ValidateOptionalLetters(tbThirdName, epThirdName, "Third name");
        }
        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            _ValidateRequiredLetters(tbLastName, epLastName, "Last name");
        }
        private void tbNationalNo_TextChanged(object sender, EventArgs e)
        {
            _ValidateNationalNo();
        }
        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            _ValidatePhone();
        }
        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            _ValidateEmail();
        }
        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            _ValidateDOB();
        }
        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            _ValidateAddress();
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _ValidateGender();
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _ValidateGender();
        }
        // ------------------------------------------------------------------------------------------------------

        //---------------------------- Image Handling -----------------------------------------------------------
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SetImageToPerson();
        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RemoveImage();
        }
        // ------------------------------------------------------------------------------------------------------
    }
}


