namespace DVLD_DriverAndVehiclesLicenseDepartment.License
{
    partial class frmShowLicenseHistory
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonInfoWithFilter1 = new DVLD_DriverAndVehiclesLicenseDepartment.People.Controls.ctrlPersonInfoWithFilter();
            this.lblInternatioanlLicensesCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternatioanlLicenses = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternatioanlLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Red;
            this.lblTitel.Location = new System.Drawing.Point(307, 42);
            this.lblTitel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(294, 46);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "License History";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocal);
            this.tabControl1.Controls.Add(this.tpInternational);
            this.tabControl1.Location = new System.Drawing.Point(21, 620);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(905, 270);
            this.tabControl1.TabIndex = 2;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.lblNumberOfRecords);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Controls.Add(this.dgvLocalLicenses);
            this.tpLocal.Location = new System.Drawing.Point(4, 25);
            this.tpLocal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpLocal.Size = new System.Drawing.Size(897, 241);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(79, 213);
            this.lblNumberOfRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(14, 16);
            this.lblNumberOfRecords.TabIndex = 2;
            this.lblNumberOfRecords.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 213);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Rows:";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToResizeColumns = false;
            this.dgvLocalLicenses.AllowUserToResizeRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(0, 0);
            this.dgvLocalLicenses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.RowHeadersWidth = 51;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(895, 209);
            this.dgvLocalLicenses.TabIndex = 0;
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.lblInternatioanlLicensesCount);
            this.tpInternational.Controls.Add(this.label3);
            this.tpInternational.Controls.Add(this.dgvInternatioanlLicenses);
            this.tpInternational.Location = new System.Drawing.Point(4, 25);
            this.tpInternational.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpInternational.Size = new System.Drawing.Size(897, 241);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Image = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.CloseIcon;
            this.btnClose.Location = new System.Drawing.Point(821, 897);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(13, 129);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.ShowAddNewPerson = true;
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(908, 474);
            this.ctrlPersonInfoWithFilter1.TabIndex = 4;
            this.ctrlPersonInfoWithFilter1.OnPersonFound += new System.Action<int>(this.ctrlPersonInfoWithFilter1_OnPersonFound);
            // 
            // lblInternatioanlLicensesCount
            // 
            this.lblInternatioanlLicensesCount.AutoSize = true;
            this.lblInternatioanlLicensesCount.Location = new System.Drawing.Point(80, 219);
            this.lblInternatioanlLicensesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInternatioanlLicensesCount.Name = "lblInternatioanlLicensesCount";
            this.lblInternatioanlLicensesCount.Size = new System.Drawing.Size(14, 16);
            this.lblInternatioanlLicensesCount.TabIndex = 5;
            this.lblInternatioanlLicensesCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "# Rows:";
            // 
            // dgvInternatioanlLicenses
            // 
            this.dgvInternatioanlLicenses.AllowUserToAddRows = false;
            this.dgvInternatioanlLicenses.AllowUserToDeleteRows = false;
            this.dgvInternatioanlLicenses.AllowUserToResizeColumns = false;
            this.dgvInternatioanlLicenses.AllowUserToResizeRows = false;
            this.dgvInternatioanlLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternatioanlLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternatioanlLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternatioanlLicenses.Location = new System.Drawing.Point(1, 6);
            this.dgvInternatioanlLicenses.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInternatioanlLicenses.Name = "dgvInternatioanlLicenses";
            this.dgvInternatioanlLicenses.RowHeadersWidth = 51;
            this.dgvInternatioanlLicenses.Size = new System.Drawing.Size(895, 209);
            this.dgvInternatioanlLicenses.TabIndex = 3;
            // 
            // frmShowLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 949);
            this.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTitel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmShowLicenseHistory";
            this.ShowIcon = false;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmShowLicenseHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternatioanlLicenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Button btnClose;
        private People.Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Label lblInternatioanlLicensesCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternatioanlLicenses;
    }
}