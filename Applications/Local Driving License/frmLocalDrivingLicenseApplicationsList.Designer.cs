namespace DVLD_DriverAndVehiclesLicenseDepartment.Applications.Local_Driving_License
{
    partial class frmLocalDrivingLicenseApplicationsList
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
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalLicenseApplicationsList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsScheduleTheoryTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSchedulePracticalTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsIssueDrivingLicneseForTheFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitel = new System.Windows.Forms.Label();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbInputFilter = new System.Windows.Forms.TextBox();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseApplicationsList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(87, 585);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(14, 16);
            this.lblNumberOfRecords.TabIndex = 22;
            this.lblNumberOfRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 585);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "# Records:";
            // 
            // dgvLocalLicenseApplicationsList
            // 
            this.dgvLocalLicenseApplicationsList.AllowUserToAddRows = false;
            this.dgvLocalLicenseApplicationsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalLicenseApplicationsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenseApplicationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseApplicationsList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalLicenseApplicationsList.Location = new System.Drawing.Point(9, 241);
            this.dgvLocalLicenseApplicationsList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLocalLicenseApplicationsList.Name = "dgvLocalLicenseApplicationsList";
            this.dgvLocalLicenseApplicationsList.RowHeadersWidth = 51;
            this.dgvLocalLicenseApplicationsList.RowTemplate.Height = 31;
            this.dgvLocalLicenseApplicationsList.Size = new System.Drawing.Size(1332, 343);
            this.dgvLocalLicenseApplicationsList.TabIndex = 19;
            this.dgvLocalLicenseApplicationsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvLocalLicenseApplicationsList_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsApplicationDetails,
            this.toolStripSeparator1,
            this.cmsEditApplication,
            this.cmsDeleteApplication,
            this.toolStripSeparator2,
            this.cmsCancelApplication,
            this.toolStripSeparator3,
            this.cmsScheduleTest,
            this.toolStripSeparator4,
            this.cmsIssueDrivingLicneseForTheFirstTime,
            this.toolStripSeparator6,
            this.cmsShowLicense,
            this.toolStripSeparator5,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(265, 260);
            // 
            // cmsApplicationDetails
            // 
            this.cmsApplicationDetails.Name = "cmsApplicationDetails";
            this.cmsApplicationDetails.Size = new System.Drawing.Size(264, 24);
            this.cmsApplicationDetails.Text = "Show Application Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // cmsEditApplication
            // 
            this.cmsEditApplication.Name = "cmsEditApplication";
            this.cmsEditApplication.Size = new System.Drawing.Size(264, 24);
            this.cmsEditApplication.Text = "Edit Application";
            this.cmsEditApplication.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // cmsDeleteApplication
            // 
            this.cmsDeleteApplication.Name = "cmsDeleteApplication";
            this.cmsDeleteApplication.Size = new System.Drawing.Size(264, 24);
            this.cmsDeleteApplication.Text = "Delete Application";
            this.cmsDeleteApplication.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(261, 6);
            // 
            // cmsCancelApplication
            // 
            this.cmsCancelApplication.Name = "cmsCancelApplication";
            this.cmsCancelApplication.Size = new System.Drawing.Size(264, 24);
            this.cmsCancelApplication.Text = "Cancel Application";
            this.cmsCancelApplication.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(261, 6);
            // 
            // cmsScheduleTest
            // 
            this.cmsScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsScheduleVisionTest,
            this.cmsScheduleTheoryTest,
            this.cmsSchedulePracticalTest});
            this.cmsScheduleTest.Name = "cmsScheduleTest";
            this.cmsScheduleTest.Size = new System.Drawing.Size(264, 24);
            this.cmsScheduleTest.Text = "Schedule Test ";
            // 
            // cmsScheduleVisionTest
            // 
            this.cmsScheduleVisionTest.Name = "cmsScheduleVisionTest";
            this.cmsScheduleVisionTest.Size = new System.Drawing.Size(242, 26);
            this.cmsScheduleVisionTest.Text = "Schedule Vision Test";
            this.cmsScheduleVisionTest.Click += new System.EventHandler(this.cmsScheduleVisionTest_Click);
            // 
            // cmsScheduleTheoryTest
            // 
            this.cmsScheduleTheoryTest.Name = "cmsScheduleTheoryTest";
            this.cmsScheduleTheoryTest.Size = new System.Drawing.Size(242, 26);
            this.cmsScheduleTheoryTest.Text = "Schedule Theory Test";
            this.cmsScheduleTheoryTest.Click += new System.EventHandler(this.cmsScheduleTheoryTest_Click);
            // 
            // cmsSchedulePracticalTest
            // 
            this.cmsSchedulePracticalTest.Name = "cmsSchedulePracticalTest";
            this.cmsSchedulePracticalTest.Size = new System.Drawing.Size(242, 26);
            this.cmsSchedulePracticalTest.Text = "Schedule Practical Test";
            this.cmsSchedulePracticalTest.Click += new System.EventHandler(this.cmsSchedulePracticalTest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(261, 6);
            // 
            // cmsIssueDrivingLicneseForTheFirstTime
            // 
            this.cmsIssueDrivingLicneseForTheFirstTime.Enabled = false;
            this.cmsIssueDrivingLicneseForTheFirstTime.Name = "cmsIssueDrivingLicneseForTheFirstTime";
            this.cmsIssueDrivingLicneseForTheFirstTime.Size = new System.Drawing.Size(264, 24);
            this.cmsIssueDrivingLicneseForTheFirstTime.Text = "Driving License (First Time)";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(261, 6);
            // 
            // cmsShowLicense
            // 
            this.cmsShowLicense.Enabled = false;
            this.cmsShowLicense.Name = "cmsShowLicense";
            this.cmsShowLicense.Size = new System.Drawing.Size(264, 24);
            this.cmsShowLicense.Text = "Show License";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(261, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Red;
            this.lblTitel.Location = new System.Drawing.Point(521, 146);
            this.lblTitel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(379, 29);
            this.lblTitel.TabIndex = 18;
            this.lblTitel.Text = "Local Driving License Applications";
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.BackgroundImage = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.addApplicationIcon;
            this.btnAddNewLocalDrivingLicenseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1210, 188);
            this.btnAddNewLocalDrivingLicenseApplication.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(131, 47);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 23;
            this.btnAddNewLocalDrivingLicenseApplication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CloseIcon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1210, 587);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 47);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.LocalApplicationsIcon;
            this.pictureBox1.Location = new System.Drawing.Point(537, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // tbInputFilter
            // 
            this.tbInputFilter.Location = new System.Drawing.Point(303, 216);
            this.tbInputFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbInputFilter.Name = "tbInputFilter";
            this.tbInputFilter.Size = new System.Drawing.Size(176, 22);
            this.tbInputFilter.TabIndex = 26;
            this.tbInputFilter.Visible = false;
            this.tbInputFilter.TextChanged += new System.EventHandler(this.tbInputFilter_TextChanged);
            this.tbInputFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInputFilter_KeyPress);
            // 
            // cbFilters
            // 
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Location = new System.Drawing.Point(113, 214);
            this.cbFilters.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(176, 24);
            this.cbFilters.TabIndex = 25;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Filter By:";
            // 
            // frmLocalDrivingLicenseApplicationsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 639);
            this.Controls.Add(this.tbInputFilter);
            this.Controls.Add(this.cbFilters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLocalLicenseApplicationsList);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLocalDrivingLicenseApplicationsList";
            this.ShowIcon = false;
            this.Text = "Local Driving License Applications List";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseApplicationsList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalLicenseApplicationsList;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbInputFilter;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem cmsApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsEditApplication;
        private System.Windows.Forms.ToolStripMenuItem cmsDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsCancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmsIssueDrivingLicneseForTheFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem cmsScheduleTheoryTest;
        private System.Windows.Forms.ToolStripMenuItem cmsSchedulePracticalTest;
    }
}