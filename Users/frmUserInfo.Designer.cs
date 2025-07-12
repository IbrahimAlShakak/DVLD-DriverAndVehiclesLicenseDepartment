namespace DVLD_DriverAndVehiclesLicenseDepartment.Users
{
    partial class frmUserInfo
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
            this.ctrlUserInfocs1 = new DVLD_DriverAndVehiclesLicenseDepartment.Users.Controls.ctrlUserInfocs();
            this.SuspendLayout();
            // 
            // ctrlUserInfocs1
            // 
            this.ctrlUserInfocs1.Location = new System.Drawing.Point(2, 0);
            this.ctrlUserInfocs1.Name = "ctrlUserInfocs1";
            this.ctrlUserInfocs1.Size = new System.Drawing.Size(912, 510);
            this.ctrlUserInfocs1.TabIndex = 0;
            this.ctrlUserInfocs1.Load += new System.EventHandler(this.ctrlUserInfocs1_Load);
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 501);
            this.Controls.Add(this.ctrlUserInfocs1);
            this.Name = "frmUserInfo";
            this.ShowIcon = false;
            this.Text = "User Info";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlUserInfocs ctrlUserInfocs1;
    }
}