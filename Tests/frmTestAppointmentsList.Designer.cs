namespace DVLD_DriverAndVehiclesLicenseDepartment.Tests
{
    partial class frmTestAppointmentsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitel = new System.Windows.Forms.Label();
            this.pbTestTypeImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTestAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnAddNewTestAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlApplicationInfo1 = new DVLD_DriverAndVehiclesLicenseDepartment.Applications.Controls.ctrlApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitel.Location = new System.Drawing.Point(269, 173);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(251, 32);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Test Appointments";
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTestTypeImage.Location = new System.Drawing.Point(319, 12);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(247, 158);
            this.pbTestTypeImage.TabIndex = 2;
            this.pbTestTypeImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 682);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Appointments:";
            // 
            // dgvTestAppointments
            // 
            this.dgvTestAppointments.AllowUserToAddRows = false;
            this.dgvTestAppointments.AllowUserToDeleteRows = false;
            this.dgvTestAppointments.AllowUserToResizeColumns = false;
            this.dgvTestAppointments.AllowUserToResizeRows = false;
            this.dgvTestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestAppointments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTestAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTestAppointments.Location = new System.Drawing.Point(12, 710);
            this.dgvTestAppointments.Name = "dgvTestAppointments";
            this.dgvTestAppointments.RowHeadersWidth = 51;
            this.dgvTestAppointments.RowTemplate.Height = 24;
            this.dgvTestAppointments.Size = new System.Drawing.Size(753, 176);
            this.dgvTestAppointments.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestAppointmentToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 80);
            // 
            // editTestAppointmentToolStripMenuItem
            // 
            this.editTestAppointmentToolStripMenuItem.Name = "editTestAppointmentToolStripMenuItem";
            this.editTestAppointmentToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.editTestAppointmentToolStripMenuItem.Text = "Edit Test Appointment";
            this.editTestAppointmentToolStripMenuItem.Click += new System.EventHandler(this.editTestAppointmentToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.takeTestToolStripMenuItem.Text = "TakeTest";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 889);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "# Records: ";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(90, 889);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(14, 16);
            this.lblNumberOfRecords.TabIndex = 6;
            this.lblNumberOfRecords.Text = "0";
            // 
            // btnAddNewTestAppointment
            // 
            this.btnAddNewTestAppointment.BackgroundImage = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.plus;
            this.btnAddNewTestAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewTestAppointment.Location = new System.Drawing.Point(679, 671);
            this.btnAddNewTestAppointment.Name = "btnAddNewTestAppointment";
            this.btnAddNewTestAppointment.Size = new System.Drawing.Size(86, 33);
            this.btnAddNewTestAppointment.TabIndex = 8;
            this.btnAddNewTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewTestAppointment.Click += new System.EventHandler(this.btnAddNewTestAppointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CloseIcon;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(663, 892);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 39);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlApplicationInfo1
            // 
            this.ctrlApplicationInfo1.Location = new System.Drawing.Point(12, 218);
            this.ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            this.ctrlApplicationInfo1.Size = new System.Drawing.Size(753, 447);
            this.ctrlApplicationInfo1.TabIndex = 0;
            // 
            // frmTestAppointmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 936);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewTestAppointment);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTestAppointments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTestTypeImage);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.ctrlApplicationInfo1);
            this.Name = "frmTestAppointmentsList";
            this.ShowIcon = false;
            this.Text = "Test Appointments";
            this.Load += new System.EventHandler(this.frmTestAppointmentsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Controls.ctrlApplicationInfo ctrlApplicationInfo1;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTestAppointments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnAddNewTestAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem editTestAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}