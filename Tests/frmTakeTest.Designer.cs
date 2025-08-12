namespace DVLD_DriverAndVehiclesLicenseDepartment.Tests
{
    partial class frmTakeTest
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
            this.ctrlTestAppointmentInfo1 = new DVLD_DriverAndVehiclesLicenseDepartment.Tests.Controls.ctrlTestAppointmentInfo();
            this.Res = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlTestAppointmentInfo1
            // 
            this.ctrlTestAppointmentInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlTestAppointmentInfo1.Name = "ctrlTestAppointmentInfo1";
            this.ctrlTestAppointmentInfo1.Size = new System.Drawing.Size(536, 529);
            this.ctrlTestAppointmentInfo1.TabIndex = 0;
            // 
            // Res
            // 
            this.Res.AutoSize = true;
            this.Res.Location = new System.Drawing.Point(142, 574);
            this.Res.Name = "Res";
            this.Res.Size = new System.Drawing.Size(48, 16);
            this.Res.TabIndex = 1;
            this.Res.Text = "Result:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Notes:";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(222, 619);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(326, 104);
            this.tbNotes.TabIndex = 3;
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Location = new System.Drawing.Point(222, 572);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(59, 20);
            this.rbPass.TabIndex = 4;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Location = new System.Drawing.Point(313, 572);
            this.rbFail.Name = "rbFail";
            this.rbFail.Size = new System.Drawing.Size(50, 20);
            this.rbFail.TabIndex = 5;
            this.rbFail.TabStop = true;
            this.rbFail.Text = "Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CloseIcon;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(175, 766);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 39);
            this.btnClose.TabIndex = 6;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.SaveIcon;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(285, 766);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 39);
            this.btnSave.TabIndex = 7;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 832);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rbFail);
            this.Controls.Add(this.rbPass);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Res);
            this.Controls.Add(this.ctrlTestAppointmentInfo1);
            this.Name = "frmTakeTest";
            this.ShowIcon = false;
            this.Text = "Take Test";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlTestAppointmentInfo ctrlTestAppointmentInfo1;
        private System.Windows.Forms.Label Res;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}