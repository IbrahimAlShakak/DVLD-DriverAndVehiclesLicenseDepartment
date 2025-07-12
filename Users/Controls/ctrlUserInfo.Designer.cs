namespace DVLD_DriverAndVehiclesLicenseDepartment.Users.Controls
{
    partial class ctrlUserInfocs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPersonInfo1 = new DVLD_DriverAndVehiclesLicenseDepartment.People.Controls.ctrlPersonInfo();
            this.gbLoginInformation = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.gbLoginInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(902, 394);
            this.ctrlPersonInfo1.TabIndex = 0;
            // 
            // gbLoginInformation
            // 
            this.gbLoginInformation.Controls.Add(this.lblIsActive);
            this.gbLoginInformation.Controls.Add(this.lblUsername);
            this.gbLoginInformation.Controls.Add(this.lblUserID);
            this.gbLoginInformation.Controls.Add(this.label3);
            this.gbLoginInformation.Controls.Add(this.label2);
            this.gbLoginInformation.Controls.Add(this.label1);
            this.gbLoginInformation.Location = new System.Drawing.Point(0, 400);
            this.gbLoginInformation.Name = "gbLoginInformation";
            this.gbLoginInformation.Size = new System.Drawing.Size(902, 100);
            this.gbLoginInformation.TabIndex = 1;
            this.gbLoginInformation.TabStop = false;
            this.gbLoginInformation.Text = "Login Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Is Active:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(179, 38);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(0, 16);
            this.lblUserID.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(465, 38);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 16);
            this.lblUsername.TabIndex = 4;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(738, 38);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(0, 16);
            this.lblIsActive.TabIndex = 5;
            // 
            // ctrlUserInfocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLoginInformation);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Name = "ctrlUserInfocs";
            this.Size = new System.Drawing.Size(912, 510);
            this.gbLoginInformation.ResumeLayout(false);
            this.gbLoginInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.GroupBox gbLoginInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label3;
    }
}
