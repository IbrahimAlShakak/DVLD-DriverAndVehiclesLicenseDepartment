namespace DVLD_DriverAndVehiclesLicenseDepartment
{
    partial class AddOrEditPersonInfoF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.tbThirdName = new System.Windows.Forms.TextBox();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.epNationalNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDOB = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.epGender = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFirstName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSecondName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epThirdName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLastName = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNationalNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSecondName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epThirdName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLastName)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.4F);
            this.label1.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.IDIcon;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(584, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Personal ID: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.4F);
            this.lblPersonID.Location = new System.Drawing.Point(893, 140);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(42, 24);
            this.lblPersonID.TabIndex = 2;
            this.lblPersonID.Text = "N/A";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitel.Location = new System.Drawing.Point(501, 9);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(358, 51);
            this.lblTitel.TabIndex = 3;
            this.lblTitel.Text = "Add New Person";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.SaveIcon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(719, 757);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 55);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CloseIcon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(510, 757);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 55);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.LinkColor = System.Drawing.Color.Red;
            this.llRemoveImage.Location = new System.Drawing.Point(1018, 609);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(143, 25);
            this.llRemoveImage.TabIndex = 48;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove Image";
            this.llRemoveImage.Visible = false;
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // llSetImage
            // 
            this.llSetImage.Location = new System.Drawing.Point(1018, 568);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(143, 25);
            this.llSetImage.TabIndex = 47;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.NoImageIcon;
            this.pbPersonImage.Location = new System.Drawing.Point(1023, 301);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(188, 246);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 53;
            this.pbPersonImage.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1080, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 25);
            this.label12.TabIndex = 52;
            this.label12.Text = "Last";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(1023, 237);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(188, 29);
            this.tbLastName.TabIndex = 34;
            this.tbLastName.TextChanged += new System.EventHandler(this.tbLastName_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(861, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 25);
            this.label11.TabIndex = 51;
            this.label11.Text = "Third";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(619, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 25);
            this.label10.TabIndex = 50;
            this.label10.Text = "Second";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 25);
            this.label9.TabIndex = 49;
            this.label9.Text = "First";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(358, 564);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(642, 173);
            this.tbAddress.TabIndex = 46;
            this.tbAddress.TextChanged += new System.EventHandler(this.tbAddress_TextChanged);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(798, 324);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(188, 29);
            this.dtpDateOfBirth.TabIndex = 43;
            this.dtpDateOfBirth.ValueChanged += new System.EventHandler(this.dtpDateOfBirth_ValueChanged);
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(798, 496);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(188, 32);
            this.cbCountry.TabIndex = 45;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(798, 411);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(188, 29);
            this.tbPhone.TabIndex = 44;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(434, 411);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(98, 29);
            this.rbFemale.TabIndex = 39;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(344, 411);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(76, 29);
            this.rbMale.TabIndex = 38;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // tbThirdName
            // 
            this.tbThirdName.Location = new System.Drawing.Point(798, 237);
            this.tbThirdName.Name = "tbThirdName";
            this.tbThirdName.Size = new System.Drawing.Size(188, 29);
            this.tbThirdName.TabIndex = 32;
            this.tbThirdName.TextChanged += new System.EventHandler(this.tbThirdName_TextChanged);
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(573, 237);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(188, 29);
            this.tbSecondName.TabIndex = 29;
            this.tbSecondName.TextChanged += new System.EventHandler(this.tbSecondName_TextChanged);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(344, 498);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(188, 29);
            this.tbEmail.TabIndex = 41;
            this.tbEmail.TextChanged += new System.EventHandler(this.tbEmail_TextChanged);
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.Location = new System.Drawing.Point(344, 324);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(188, 29);
            this.tbNationalNo.TabIndex = 36;
            this.tbNationalNo.TextChanged += new System.EventHandler(this.tbNationalNo_TextChanged);
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(348, 237);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(188, 29);
            this.tbFirstName.TabIndex = 28;
            this.tbFirstName.TextChanged += new System.EventHandler(this.tbFirstName_TextChanged);
            // 
            // label8
            // 
            this.label8.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CountryIcon;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(566, 477);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 70);
            this.label8.TabIndex = 42;
            this.label8.Text = "Country:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.PhoneIcon;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(566, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 70);
            this.label7.TabIndex = 40;
            this.label7.Text = "Phone:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.BirthDateIcon;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(566, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 70);
            this.label6.TabIndex = 37;
            this.label6.Text = "Date Of Birth:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.AddressIcon;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(169, 564);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 70);
            this.label5.TabIndex = 35;
            this.label5.Text = "Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.EmailIcon;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(169, 477);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 70);
            this.label4.TabIndex = 33;
            this.label4.Text = "Email:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.GenderIcon;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(169, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 70);
            this.label3.TabIndex = 31;
            this.label3.Text = "Gender:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.NationalNoIcon;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(164, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 70);
            this.label2.TabIndex = 30;
            this.label2.Text = "National No:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.NameIcon;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(169, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 70);
            this.label13.TabIndex = 27;
            this.label13.Text = "Name: ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // epNationalNo
            // 
            this.epNationalNo.ContainerControl = this;
            // 
            // epPhone
            // 
            this.epPhone.ContainerControl = this;
            // 
            // epEmail
            // 
            this.epEmail.ContainerControl = this;
            // 
            // epDOB
            // 
            this.epDOB.ContainerControl = this;
            // 
            // epAddress
            // 
            this.epAddress.ContainerControl = this;
            // 
            // epGender
            // 
            this.epGender.ContainerControl = this;
            // 
            // epFirstName
            // 
            this.epFirstName.ContainerControl = this;
            // 
            // epSecondName
            // 
            this.epSecondName.ContainerControl = this;
            // 
            // epThirdName
            // 
            this.epThirdName.ContainerControl = this;
            // 
            // epLastName
            // 
            this.epLastName.ContainerControl = this;
            // 
            // AddOrEditPersonInfoF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 889);
            this.Controls.Add(this.llRemoveImage);
            this.Controls.Add(this.llSetImage);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.tbThirdName);
            this.Controls.Add(this.tbSecondName);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbNationalNo);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.label1);
            this.Name = "AddOrEditPersonInfoF";
            this.ShowIcon = false;
            this.Text = "Add / Edit Person Info";
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNationalNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSecondName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epThirdName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLastName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.TextBox tbThirdName;
        private System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ErrorProvider epNationalNo;
        private System.Windows.Forms.ErrorProvider epPhone;
        private System.Windows.Forms.ErrorProvider epEmail;
        private System.Windows.Forms.ErrorProvider epDOB;
        private System.Windows.Forms.ErrorProvider epAddress;
        private System.Windows.Forms.ErrorProvider epGender;
        private System.Windows.Forms.ErrorProvider epFirstName;
        private System.Windows.Forms.ErrorProvider epSecondName;
        private System.Windows.Forms.ErrorProvider epThirdName;
        private System.Windows.Forms.ErrorProvider epLastName;
    }
}