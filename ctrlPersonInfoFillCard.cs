using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    public partial class ctrlPersonInfoFillCard : UserControl
    {
        private void _ValidateRequiredLetters(TextBox tb, ErrorProvider ep, string name)
        {
            var txt = tb.Text.Trim();
            if (txt.Length == 0) ep.SetError(tb, $"{name} is required.");
            else if (!Regex.IsMatch(txt, @"^[A-Za-z]+$"))
                ep.SetError(tb, $"{name} must contain only letters.");
            else ep.SetError(tb, "");
        }
        private void _ValidateOptionalLetters(TextBox tb, ErrorProvider ep, string name)
        {
            var txt = tb.Text.Trim();
            if (txt.Length > 0 && !Regex.IsMatch(txt, @"^[A-Za-z]+$"))
                ep.SetError(tb, $"{name} must contain only letters.");
            else ep.SetError(tb, "");
        }
        private void _ValidateNationalNo(TextBox tb, ErrorProvider ep)
        {
            var txt = tb.Text.Trim();
            if (txt.Length == 0) ep.SetError(tb, "National No is required.");
            else if (!Regex.IsMatch(txt, @"^[A-Za-z][A-Za-z0-9]*$"))
                ep.SetError(tb, "Must start with a letter and contain only letters/digits.");
            else ep.SetError(tb, "");
        }
        private void _ValidatePhone(TextBox tb, ErrorProvider ep)
        {
            var txt = tb.Text.Trim();
            if (txt.Length == 0) ep.SetError(tb, "Phone is required.");
            else if (!Regex.IsMatch(txt, @"^\+?\d+$"))
                ep.SetError(tb, "Phone must be digits only (may start with '+').");
            else ep.SetError(tb, "");
        }
        private void _ValidateEmail(TextBox tb, ErrorProvider ep)
        {
            var txt = tb.Text.Trim();
            if (!Regex.IsMatch(txt, @"^$|^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                ep.SetError(tb, "Invalid email format.");
            else ep.SetError(tb, "");
        }
        private void _ValidateDOB(DateTimePicker dp, ErrorProvider ep)
        {
            if (dp.Value.Date > DateTime.Today.AddYears(-18))
                ep.SetError(dp, "You must be at least 18 years old.");
            else ep.SetError(dp, "");
        }
        private void _ValidateAddress(TextBox tb, ErrorProvider ep)
        {
            var txt = tb.Text.Trim();
            if (txt.Length == 0)
                ep.SetError(tb, $"Address is required.");
            else if (!Regex.IsMatch(txt, @"^[A-Za-z0-9\s,\.\-]+$"))
                ep.SetError(tb, $"Address contains invalid characters.");
            else
                ep.SetError(tb, "");
        }

        public ctrlPersonInfoFillCard()
        {
            InitializeComponent();
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
           { _ValidateNationalNo(tbNationalNo, epNationalNo); }
        private void tbPhone_TextChanged(object sender, EventArgs e)
           { _ValidatePhone(tbPhone, epPhone); }
        private void tbEmail_TextChanged(object sender, EventArgs e)
           { _ValidateEmail(tbEmail, epEmail); }
        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
           {_ValidateDOB(dtpDateOfBirth, epDOB); }
        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            _ValidateAddress(tbAddress, epAddress);
        }
    }
}
