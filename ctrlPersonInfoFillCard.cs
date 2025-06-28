using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class ctrlPersonInfoFillCard : UserControl
    {
        public static bool allFieldsValid = true;

        private void _LoadCountries()
        {
            cbCountry.DataSource = clsPerson.GetAllCountries();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.SelectedIndex = 89;
        }
        private void _ValidateRequiredLetters(TextBox tb, ErrorProvider ep, string name)
        {
            var txt = tb.Text.Trim();
            if (txt.Length == 0) { ep.SetError(tb, $"{name} is required."); allFieldsValid = false; }
            else if (!Regex.IsMatch(txt, @"^[A-Za-z]+$"))
            { ep.SetError(tb, $"{name} must contain only letters."); allFieldsValid = false; }
            else ep.SetError(tb, "");
        }
        private void _ValidateOptionalLetters(TextBox tb, ErrorProvider ep, string name)
        {
            var txt = tb.Text.Trim();
            if (txt.Length > 0 && !Regex.IsMatch(txt, @"^[A-Za-z]+$"))
            { ep.SetError(tb, $"{name} must contain only letters."); allFieldsValid = false; }
            else ep.SetError(tb, "");
        }
        private void _ValidateNationalNo()
        {
            var txt = tbNationalNo.Text.Trim();
            if (txt.Length == 0)
            { 
                epNationalNo.SetError(tbNationalNo, "National No is required.");
                allFieldsValid = false; 
            }
            else if (!Regex.IsMatch(txt, @"^[A-Za-z][A-Za-z0-9]*$"))
            { epNationalNo.SetError(tbNationalNo, "Must start with a letter and contain only letters/digits."); allFieldsValid = false; }
            else epNationalNo.SetError(tbNationalNo, "");
        }
        private void _ValidatePhone()
        {
            var txt = tbPhone.Text.Trim();
            if (txt.Length == 0) { epPhone.SetError(tbPhone, "Phone is required."); allFieldsValid = false; }
            else if (!Regex.IsMatch(txt, @"^\+?\d+$"))
            { epPhone.SetError(tbPhone, "Phone must be digits only (may start with '+')."); allFieldsValid = false; }
            else epPhone.SetError(tbPhone, "");
        }
        private void _ValidateEmail()
        {
            var txt = tbEmail.Text.Trim();
            if (!Regex.IsMatch(txt, @"^$|^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { epEmail.SetError(tbEmail, "Invalid email format."); allFieldsValid = false; }
            else epEmail.SetError(tbEmail, "");
        }
        private void _ValidateDOB()
        {
            if (dtpDateOfBirth.Value.Date > DateTime.Today.AddYears(-18))
            { epDOB.SetError(dtpDateOfBirth, "You must be at least 18 years old."); allFieldsValid = false; }
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
                    allFieldsValid = false;
                }
                else
                    epGender.SetError(rbMale, "");
            }

        }
        private void _ValidateAll()
        {
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

        public ctrlPersonInfoFillCard()
        {
            InitializeComponent();
            _LoadCountries();
            _ValidateAll();
        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        { _ValidateRequiredLetters(tbFirstName, epFirstName, "First name"); }
        private void tbSecondName_TextChanged(object sender, EventArgs e)
        { _ValidateOptionalLetters(tbSecondName, epSecondName, "Second name"); }
        private void tbThirdName_TextChanged(object sender, EventArgs e)
        { _ValidateOptionalLetters(tbThirdName, epThirdName, "Third name"); }
        private void tbLastName_TextChanged(object sender, EventArgs e)
        { _ValidateRequiredLetters(tbLastName, epLastName, "Last name"); }
        private void tbNationalNo_TextChanged(object sender, EventArgs e)
        { _ValidateNationalNo(); }
        private void tbPhone_TextChanged(object sender, EventArgs e)
        { _ValidatePhone(); }
        private void tbEmail_TextChanged(object sender, EventArgs e)
        { _ValidateEmail(); }
        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        { _ValidateDOB(); }
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
    }
}
