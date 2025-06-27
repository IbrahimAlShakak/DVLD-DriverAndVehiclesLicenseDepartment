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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.ctrlPersonInfoFillCard2 = new DVLD_DriverAndVehiclesLicenseDepartment.ctrlPersonInfoFillCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.IDIcon;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(424, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Personal ID: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(625, 135);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(32, 18);
            this.lblPersonID.TabIndex = 2;
            this.lblPersonID.Text = "N/A";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitel.Location = new System.Drawing.Point(373, 23);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(363, 52);
            this.lblTitel.TabIndex = 3;
            this.lblTitel.Text = "Add New Person";
            // 
            // ctrlPersonInfoFillCard2
            // 
            this.ctrlPersonInfoFillCard2.Location = new System.Drawing.Point(30, 187);
            this.ctrlPersonInfoFillCard2.Name = "ctrlPersonInfoFillCard2";
            this.ctrlPersonInfoFillCard2.Size = new System.Drawing.Size(1215, 641);
            this.ctrlPersonInfoFillCard2.TabIndex = 4;
            // 
            // AddOrEditPersonInfoF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 899);
            this.Controls.Add(this.ctrlPersonInfoFillCard2);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblPersonID);
            this.Controls.Add(this.label1);
            this.Name = "AddOrEditPersonInfoF";
            this.ShowIcon = false;
            this.Text = "Add / Edit Person Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblTitel;
        private ctrlPersonInfoFillCard ctrlPersonInfoFillCard1;
        private ctrlPersonInfoFillCard ctrlPersonInfoFillCard2;
    }
}