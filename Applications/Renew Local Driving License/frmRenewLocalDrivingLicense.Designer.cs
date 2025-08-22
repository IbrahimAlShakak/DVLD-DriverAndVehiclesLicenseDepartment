namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Renew_Local_Driving_License
{
    partial class frmRenewLocalDrivingLicense
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
            this.lblTtiel = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseInfoWithFilter1 = new DVLD_DriverAndVehiclesLicenseDepartment.License.Controls.ctrlDrivingLicenseInfoWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.gbApplicationNewLicense = new System.Windows.Forms.GroupBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblRenewAppID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.gbApplicationNewLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTtiel
            // 
            this.lblTtiel.AutoSize = true;
            this.lblTtiel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTtiel.ForeColor = System.Drawing.Color.Red;
            this.lblTtiel.Location = new System.Drawing.Point(139, 9);
            this.lblTtiel.Name = "lblTtiel";
            this.lblTtiel.Size = new System.Drawing.Size(329, 25);
            this.lblTtiel.TabIndex = 0;
            this.lblTtiel.Text = "Renew Local License Application";
            // 
            // ctrlDrivingLicenseInfoWithFilter1
            // 
            this.ctrlDrivingLicenseInfoWithFilter1.Location = new System.Drawing.Point(11, 56);
            this.ctrlDrivingLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrlDrivingLicenseInfoWithFilter1.Name = "ctrlDrivingLicenseInfoWithFilter1";
            this.ctrlDrivingLicenseInfoWithFilter1.Size = new System.Drawing.Size(612, 383);
            this.ctrlDrivingLicenseInfoWithFilter1.TabIndex = 1;
            this.ctrlDrivingLicenseInfoWithFilter1.OnLicenseFound += new System.Action<int>(this.ctrlDrivingLicenseInfoWithFilter1_OnLicenseFound);
            this.ctrlDrivingLicenseInfoWithFilter1.Load += new System.EventHandler(this.ctrlDrivingLicenseInfoWithFilter1_Load);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CloseIcon;
            this.btnClose.Location = new System.Drawing.Point(465, 713);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRenew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRenew.Location = new System.Drawing.Point(546, 713);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(75, 29);
            this.btnRenew.TabIndex = 3;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // gbApplicationNewLicense
            // 
            this.gbApplicationNewLicense.Controls.Add(this.tbNotes);
            this.gbApplicationNewLicense.Controls.Add(this.lblRenewedLicenseID);
            this.gbApplicationNewLicense.Controls.Add(this.label7);
            this.gbApplicationNewLicense.Controls.Add(this.lblApplicationDate);
            this.gbApplicationNewLicense.Controls.Add(this.label6);
            this.gbApplicationNewLicense.Controls.Add(this.lblExpirationDate);
            this.gbApplicationNewLicense.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationNewLicense.Controls.Add(this.lblCreatedBy);
            this.gbApplicationNewLicense.Controls.Add(this.lblTotalFees);
            this.gbApplicationNewLicense.Controls.Add(this.lblIssueDate);
            this.gbApplicationNewLicense.Controls.Add(this.lblLicenseFees);
            this.gbApplicationNewLicense.Controls.Add(this.lblApplicationFees);
            this.gbApplicationNewLicense.Controls.Add(this.lblRenewAppID);
            this.gbApplicationNewLicense.Controls.Add(this.label13);
            this.gbApplicationNewLicense.Controls.Add(this.label11);
            this.gbApplicationNewLicense.Controls.Add(this.label12);
            this.gbApplicationNewLicense.Controls.Add(this.label9);
            this.gbApplicationNewLicense.Controls.Add(this.label10);
            this.gbApplicationNewLicense.Controls.Add(this.label5);
            this.gbApplicationNewLicense.Controls.Add(this.label3);
            this.gbApplicationNewLicense.Controls.Add(this.l);
            this.gbApplicationNewLicense.Controls.Add(this.label2);
            this.gbApplicationNewLicense.Location = new System.Drawing.Point(12, 444);
            this.gbApplicationNewLicense.Name = "gbApplicationNewLicense";
            this.gbApplicationNewLicense.Size = new System.Drawing.Size(611, 263);
            this.gbApplicationNewLicense.TabIndex = 4;
            this.gbApplicationNewLicense.TabStop = false;
            this.gbApplicationNewLicense.Text = "Application New License Info";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(132, 177);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(324, 63);
            this.tbNotes.TabIndex = 5;
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.AutoSize = true;
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(389, 32);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(25, 13);
            this.lblRenewedLicenseID.TabIndex = 109;
            this.lblRenewedLicenseID.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Renewed License ID:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(138, 61);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(25, 13);
            this.lblApplicationDate.TabIndex = 107;
            this.lblApplicationDate.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Application Date:";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(389, 90);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(25, 13);
            this.lblExpirationDate.TabIndex = 105;
            this.lblExpirationDate.Text = "???";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(389, 61);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(25, 13);
            this.lblOldLicenseID.TabIndex = 104;
            this.lblOldLicenseID.Text = "???";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(389, 119);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(25, 13);
            this.lblCreatedBy.TabIndex = 103;
            this.lblCreatedBy.Text = "???";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(389, 148);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(25, 13);
            this.lblTotalFees.TabIndex = 102;
            this.lblTotalFees.Text = "???";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(138, 90);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(25, 13);
            this.lblIssueDate.TabIndex = 101;
            this.lblIssueDate.Text = "???";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Location = new System.Drawing.Point(138, 148);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(25, 13);
            this.lblLicenseFees.TabIndex = 100;
            this.lblLicenseFees.Text = "???";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(138, 119);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(25, 13);
            this.lblApplicationFees.TabIndex = 99;
            this.lblApplicationFees.Text = "???";
            // 
            // lblRenewAppID
            // 
            this.lblRenewAppID.AutoSize = true;
            this.lblRenewAppID.Location = new System.Drawing.Point(138, 32);
            this.lblRenewAppID.Name = "lblRenewAppID";
            this.lblRenewAppID.Size = new System.Drawing.Size(25, 13);
            this.lblRenewAppID.TabIndex = 97;
            this.lblRenewAppID.Text = "???";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = "Notes:";
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
            this.label12.Location = new System.Drawing.Point(6, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Application Fees:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Created By:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 92;
            this.label10.Text = "License Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 91;
            this.label5.Text = "Total Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Expiration Date:";
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(6, 32);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(113, 13);
            this.l.TabIndex = 89;
            this.l.Text = "Renew Application ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Issue Date:";
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Enabled = false;
            this.llShowLicenseInfo.Location = new System.Drawing.Point(145, 713);
            this.llShowLicenseInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(95, 13);
            this.llShowLicenseInfo.TabIndex = 6;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show License Info";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Location = new System.Drawing.Point(18, 713);
            this.llShowLicenseHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(109, 13);
            this.llShowLicenseHistory.TabIndex = 5;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // frmRenewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 751);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.gbApplicationNewLicense);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDrivingLicenseInfoWithFilter1);
            this.Controls.Add(this.lblTtiel);
            this.Name = "frmRenewLocalDrivingLicense";
            this.ShowInTaskbar = false;
            this.Text = "Renew Local Driving License";
            this.gbApplicationNewLicense.ResumeLayout(false);
            this.gbApplicationNewLicense.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTtiel;
        private License.Controls.ctrlDrivingLicenseInfoWithFilter ctrlDrivingLicenseInfoWithFilter1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.GroupBox gbApplicationNewLicense;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblRenewAppID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
    }
}