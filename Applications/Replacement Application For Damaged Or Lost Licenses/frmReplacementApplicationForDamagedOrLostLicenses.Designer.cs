namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Replacement_Application_For_Damaged_Or_Lost_Licenses
{
    partial class frmReplacementApplicationForDamagedOrLostLicenses
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
            this.lblTitel = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseInfoWithFilter1 = new DVLD_DriverAndVehiclesLicenseDepartment.License.Controls.ctrlDrivingLicenseInfoWithFilter();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbApplicationNewLicense = new System.Windows.Forms.GroupBox();
            this.lblReplacementLicenseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblReplacementAppID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.gbReplacement = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.gbApplicationNewLicense.SuspendLayout();
            this.gbReplacement.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Red;
            this.lblTitel.Location = new System.Drawing.Point(186, 9);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(220, 24);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Replacemetn Application";
            // 
            // ctrlDrivingLicenseInfoWithFilter1
            // 
            this.ctrlDrivingLicenseInfoWithFilter1.Location = new System.Drawing.Point(10, 99);
            this.ctrlDrivingLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlDrivingLicenseInfoWithFilter1.Name = "ctrlDrivingLicenseInfoWithFilter1";
            this.ctrlDrivingLicenseInfoWithFilter1.Size = new System.Drawing.Size(612, 383);
            this.ctrlDrivingLicenseInfoWithFilter1.TabIndex = 1;
            this.ctrlDrivingLicenseInfoWithFilter1.OnLicenseFound += new System.Action<int>(this.ctrlDrivingLicenseInfoWithFilter1_OnLicenseFound);
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Enabled = false;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(145, 607);
            this.llShowLicenseInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.llShowLicenseInfo.TabIndex = 10;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show License Info";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Location = new System.Drawing.Point(18, 607);
            this.llShowLicenseHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.llShowLicenseHistory.TabIndex = 9;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIssueReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(517, 599);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(106, 29);
            this.btnIssueReplacement.TabIndex = 8;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CloseIcon;
            this.btnClose.Location = new System.Drawing.Point(436, 599);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // gbApplicationNewLicense
            // 
            this.gbApplicationNewLicense.Controls.Add(this.lblReplacementLicenseID);
            this.gbApplicationNewLicense.Controls.Add(this.label7);
            this.gbApplicationNewLicense.Controls.Add(this.lblApplicationDate);
            this.gbApplicationNewLicense.Controls.Add(this.label6);
            this.gbApplicationNewLicense.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationNewLicense.Controls.Add(this.lblCreatedBy);
            this.gbApplicationNewLicense.Controls.Add(this.lblApplicationFees);
            this.gbApplicationNewLicense.Controls.Add(this.lblReplacementAppID);
            this.gbApplicationNewLicense.Controls.Add(this.label11);
            this.gbApplicationNewLicense.Controls.Add(this.label12);
            this.gbApplicationNewLicense.Controls.Add(this.label9);
            this.gbApplicationNewLicense.Controls.Add(this.l);
            this.gbApplicationNewLicense.Location = new System.Drawing.Point(12, 479);
            this.gbApplicationNewLicense.Name = "gbApplicationNewLicense";
            this.gbApplicationNewLicense.Size = new System.Drawing.Size(611, 114);
            this.gbApplicationNewLicense.TabIndex = 11;
            this.gbApplicationNewLicense.TabStop = false;
            this.gbApplicationNewLicense.Text = "Application Info For Replacement";
            // 
            // lblReplacementLicenseID
            // 
            this.lblReplacementLicenseID.AutoSize = true;
            this.lblReplacementLicenseID.Location = new System.Drawing.Point(428, 32);
            this.lblReplacementLicenseID.Name = "lblReplacementLicenseID";
            this.lblReplacementLicenseID.Size = new System.Drawing.Size(25, 13);
            this.lblReplacementLicenseID.TabIndex = 109;
            this.lblReplacementLicenseID.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Replacement License ID:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(166, 58);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(25, 13);
            this.lblApplicationDate.TabIndex = 107;
            this.lblApplicationDate.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Application Date:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(428, 58);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(25, 13);
            this.lblOldLicenseID.TabIndex = 104;
            this.lblOldLicenseID.Text = "???";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(428, 84);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(25, 13);
            this.lblCreatedBy.TabIndex = 103;
            this.lblCreatedBy.Text = "???";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(166, 84);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(25, 13);
            this.lblApplicationFees.TabIndex = 99;
            this.lblApplicationFees.Text = "???";
            // 
            // lblReplacementAppID
            // 
            this.lblReplacementAppID.AutoSize = true;
            this.lblReplacementAppID.Location = new System.Drawing.Point(166, 32);
            this.lblReplacementAppID.Name = "lblReplacementAppID";
            this.lblReplacementAppID.Size = new System.Drawing.Size(25, 13);
            this.lblReplacementAppID.TabIndex = 97;
            this.lblReplacementAppID.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 95;
            this.label11.Text = "Old License ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Application Fees:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Created By:";
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(6, 32);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(142, 13);
            this.l.TabIndex = 89;
            this.l.Text = "Replacement Application ID:";
            // 
            // gbReplacement
            // 
            this.gbReplacement.Controls.Add(this.rbLostLicense);
            this.gbReplacement.Controls.Add(this.rbDamagedLicense);
            this.gbReplacement.Location = new System.Drawing.Point(12, 51);
            this.gbReplacement.Name = "gbReplacement";
            this.gbReplacement.Size = new System.Drawing.Size(599, 43);
            this.gbReplacement.TabIndex = 12;
            this.gbReplacement.TabStop = false;
            this.gbReplacement.Text = "Replacement For";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(342, 19);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(85, 17);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Location = new System.Drawing.Point(80, 20);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(111, 17);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // frmReplacementApplicationForDamagedOrLostLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 643);
            this.Controls.Add(this.gbReplacement);
            this.Controls.Add(this.gbApplicationNewLicense);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDrivingLicenseInfoWithFilter1);
            this.Controls.Add(this.lblTitel);
            this.Name = "frmReplacementApplicationForDamagedOrLostLicenses";
            this.ShowIcon = false;
            this.Text = "Replacement Application";
            this.Load += new System.EventHandler(this.frmReplacementApplicationForDamagedOrLostLicenses_Load);
            this.gbApplicationNewLicense.ResumeLayout(false);
            this.gbApplicationNewLicense.PerformLayout();
            this.gbReplacement.ResumeLayout(false);
            this.gbReplacement.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitel;
        private License.Controls.ctrlDrivingLicenseInfoWithFilter ctrlDrivingLicenseInfoWithFilter1;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbApplicationNewLicense;
        private System.Windows.Forms.Label lblReplacementLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblReplacementAppID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.GroupBox gbReplacement;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
    }
}