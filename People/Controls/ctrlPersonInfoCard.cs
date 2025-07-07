using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_DriverAndVehiclesLicenseDepartment.Properties;

namespace DVLD_DriverAndVehiclesLicenseDepartment.People.Controls
{
    public partial class ctrlPersonInfoCard : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;

        public int PersonID {
            get 
            { 
                return _PersonID; 
            } 
        }
        public clsPerson SelectedPersonInfo
        {
            get 
            { 
                return _Person; 
            }
        }

        public ctrlPersonInfoCard()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetDefaultCard();
                MessageBox.Show($"A Person with ID = {PersonID} is not found!", "Invalid Person ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetDefaultCard();
                MessageBox.Show($"A Person witth National Number = {NationalNo} is not found!", "Invalid National Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }
        public void ResetDefaultCard()
        {
            llEditPersonInfo.Enabled = false;
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblAddress.Text = "[????]";
            lblCountry.Text = "[????]";
            lblDOB.Text = "[????]";
            pbPersonImage.Image = Resources.NoImageIcon;
        }
        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonId;
            llEditPersonInfo.Enabled = true;
            lblPersonID.Text = _PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblDOB.Text = _Person.DateOfBirth.ToString("yyyy-MM-dd");

            _LoadPersonImage();

        }
        private void _LoadPersonImage()
        {
            if (_Person.ImagePath != "")
            {
                if(File.Exists(_Person.ImagePath))
                {
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                }
                else
                    MessageBox.Show("Could not find this image: = " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddOrEditPersonInfo frm = new frmAddOrEditPersonInfo(PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
