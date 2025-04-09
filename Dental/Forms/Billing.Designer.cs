namespace Dental.Forms
{
    partial class Billing
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.viewappointmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet10 = new Dental.DentalDataSet10();
            this.viewappointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet6 = new Dental.DentalDataSet6();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.view_appointmentTableAdapter = new Dental.DentalDataSet6TableAdapters.View_appointmentTableAdapter();
            this.view_appointmentTableAdapter1 = new Dental.DentalDataSet10TableAdapters.View_appointmentTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dentalDataSet16 = new Dental.DentalDataSet16();
            this.vwAppointmentFullDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vw_AppointmentFullDetailsTableAdapter = new Dental.DentalDataSet16TableAdapters.vw_AppointmentFullDetailsTableAdapter();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicesList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DentistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwAppointmentFullDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 41);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Billing";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(780, 9);
            this.exit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(18, 18);
            this.exit.TabIndex = 18;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.PatientFirstName,
            this.date,
            this.time,
            this.ServicesList,
            this.PatientPhone,
            this.DentistName,
            this.status});
            this.dataGridView1.DataSource = this.vwAppointmentFullDetailsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(798, 464);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // viewappointmentBindingSource1
            // 
            this.viewappointmentBindingSource1.DataMember = "View_appointment";
            this.viewappointmentBindingSource1.DataSource = this.dentalDataSet10;
            // 
            // dentalDataSet10
            // 
            this.dentalDataSet10.DataSetName = "DentalDataSet10";
            this.dentalDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewappointmentBindingSource
            // 
            this.viewappointmentBindingSource.DataMember = "View_appointment";
            this.viewappointmentBindingSource.DataSource = this.dentalDataSet6;
            // 
            // dentalDataSet6
            // 
            this.dentalDataSet6.DataSetName = "DentalDataSet6";
            this.dentalDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 17;
            // 
            // view_appointmentTableAdapter
            // 
            this.view_appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // view_appointmentTableAdapter1
            // 
            this.view_appointmentTableAdapter1.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 20;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(182, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 19;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dentalDataSet16
            // 
            this.dentalDataSet16.DataSetName = "DentalDataSet16";
            this.dentalDataSet16.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwAppointmentFullDetailsBindingSource
            // 
            this.vwAppointmentFullDetailsBindingSource.DataMember = "vw_AppointmentFullDetails";
            this.vwAppointmentFullDetailsBindingSource.DataSource = this.dentalDataSet16;
            // 
            // vw_AppointmentFullDetailsTableAdapter
            // 
            this.vw_AppointmentFullDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // PatientFirstName
            // 
            this.PatientFirstName.DataPropertyName = "PatientFirstName";
            this.PatientFirstName.HeaderText = "PatientFirstName";
            this.PatientFirstName.Name = "PatientFirstName";
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "date";
            this.date.Name = "date";
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "time";
            this.time.Name = "time";
            // 
            // ServicesList
            // 
            this.ServicesList.DataPropertyName = "ServicesList";
            this.ServicesList.HeaderText = "ServicesList";
            this.ServicesList.Name = "ServicesList";
            // 
            // PatientPhone
            // 
            this.PatientPhone.DataPropertyName = "PatientPhone";
            this.PatientPhone.HeaderText = "PatientPhone";
            this.PatientPhone.Name = "PatientPhone";
            // 
            // DentistName
            // 
            this.DentistName.DataPropertyName = "DentistName";
            this.DentistName.HeaderText = "DentistName";
            this.DentistName.Name = "DentistName";
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            // 
            // Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 539);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Billing";
            this.Text = "Billing";
            this.Load += new System.EventHandler(this.Billing_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwAppointmentFullDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private DentalDataSet6 dentalDataSet6;
        private System.Windows.Forms.BindingSource viewappointmentBindingSource;
        private DentalDataSet6TableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter;
        private DentalDataSet10 dentalDataSet10;
        private System.Windows.Forms.BindingSource viewappointmentBindingSource1;
        private DentalDataSet10TableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DentalDataSet16 dentalDataSet16;
        private System.Windows.Forms.BindingSource vwAppointmentFullDetailsBindingSource;
        private DentalDataSet16TableAdapters.vw_AppointmentFullDetailsTableAdapter vw_AppointmentFullDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicesList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn DentistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}