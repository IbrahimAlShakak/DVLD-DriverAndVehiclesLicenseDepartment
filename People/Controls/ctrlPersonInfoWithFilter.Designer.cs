namespace DVLD_DriverAndVehiclesLicenseDepartment.People.Controls
{
    partial class ctrlPersonInfoWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearchInput = new System.Windows.Forms.TextBox();
            this.cbFilters = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ctrlPersonInfoCard1 = new DVLD_DriverAndVehiclesLicenseDepartment.People.Controls.ctrlPersonInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnAddNewPerson);
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.tbSearchInput);
            this.gbFilter.Controls.Add(this.cbFilters);
            this.gbFilter.Controls.Add(this.label13);
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(903, 67);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.plus;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.Location = new System.Drawing.Point(770, 20);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(76, 32);
            this.btnAddNewPerson.TabIndex = 42;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::DVLD_DriverAndVehiclesLicenseDepartment.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Location = new System.Drawing.Point(688, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 32);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearchInput
            // 
            this.tbSearchInput.Location = new System.Drawing.Point(377, 25);
            this.tbSearchInput.Name = "tbSearchInput";
            this.tbSearchInput.Size = new System.Drawing.Size(299, 22);
            this.tbSearchInput.TabIndex = 39;
            this.tbSearchInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilteringInput_KeyDown);
            this.tbSearchInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilteringInput_KeyPress);
            this.tbSearchInput.Validating += new System.ComponentModel.CancelEventHandler(this.tbSearchInput_Validating);
            // 
            // cbFilters
            // 
            this.cbFilters.FormattingEnabled = true;
            this.cbFilters.Location = new System.Drawing.Point(72, 24);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(299, 24);
            this.cbFilters.TabIndex = 38;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(5, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 24);
            this.label13.TabIndex = 37;
            this.label13.Text = "Filter By:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlPersonInfoCard1
            // 
            this.ctrlPersonInfoCard1.Location = new System.Drawing.Point(3, 76);
            this.ctrlPersonInfoCard1.Name = "ctrlPersonInfoCard1";
            this.ctrlPersonInfoCard1.Size = new System.Drawing.Size(903, 392);
            this.ctrlPersonInfoCard1.TabIndex = 0;
            this.ctrlPersonInfoCard1.Load += new System.EventHandler(this.ctrlPersonInfoCard1_Load);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonInfoCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlPersonInfoCard1);
            this.Name = "ctrlPersonInfoCardWithFilter";
            this.Size = new System.Drawing.Size(908, 474);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonInfo ctrlPersonInfoCard1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.ComboBox cbFilters;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearchInput;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
