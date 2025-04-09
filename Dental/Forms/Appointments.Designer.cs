using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Dental.Forms
{
    partial class Appointments
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
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.add_appointment_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vwAppointmentFullDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet17 = new Dental.DentalDataSet17();
            this.viewappointmentBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet9 = new Dental.DentalDataSet9();
            this.viewappointmentBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet5 = new Dental.DentalDataSet5();
            this.viewappointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_appointment = new Dental.view_appointment();
            this.appointmentsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet4 = new Dental.DentalDataSet4();
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet3 = new Dental.DentalDataSet3();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.active_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.appointmentsTableAdapter = new Dental.DentalDataSet3TableAdapters.AppointmentsTableAdapter();
            this.appointmentsTableAdapter1 = new Dental.DentalDataSet4TableAdapters.AppointmentsTableAdapter();
            this.appointmentNumberPanel = new System.Windows.Forms.Panel();
            this.label_number_appointment = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.view_appointmentTableAdapter = new Dental.view_appointmentTableAdapters.View_appointmentTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.updatedView_appointment = new Dental.UpdatedView_appointment();
            this.viewappointmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.view_appointmentTableAdapter1 = new Dental.UpdatedView_appointmentTableAdapters.View_appointmentTableAdapter();
            this.view_appointmentTableAdapter2 = new Dental.DentalDataSet5TableAdapters.View_appointmentTableAdapter();
            this.view_appointmentTableAdapter3 = new Dental.DentalDataSet9TableAdapters.View_appointmentTableAdapter();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.vw_AppointmentFullDetailsTableAdapter = new Dental.DentalDataSet17TableAdapters.vw_AppointmentFullDetailsTableAdapter();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicesList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DentistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwAppointmentFullDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_appointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet3)).BeginInit();
            this.appointmentNumberPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatedView_appointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Appointments";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(778, 9);
            this.exit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(18, 18);
            this.exit.TabIndex = 18;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 41);
            this.panel1.TabIndex = 1;
            // 
            // add_appointment_btn
            // 
            this.add_appointment_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.add_appointment_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_appointment_btn.FlatAppearance.BorderSize = 0;
            this.add_appointment_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.add_appointment_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.add_appointment_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_appointment_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_appointment_btn.ForeColor = System.Drawing.Color.White;
            this.add_appointment_btn.Location = new System.Drawing.Point(734, 49);
            this.add_appointment_btn.Margin = new System.Windows.Forms.Padding(2);
            this.add_appointment_btn.Name = "add_appointment_btn";
            this.add_appointment_btn.Size = new System.Drawing.Size(59, 34);
            this.add_appointment_btn.TabIndex = 17;
            this.add_appointment_btn.Text = "Add";
            this.add_appointment_btn.UseVisualStyleBackColor = false;
            this.add_appointment_btn.Click += new System.EventHandler(this.add_appointment_btn_Click);
            this.add_appointment_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.add_appointment_btn_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.status,
            this.date,
            this.time,
            this.PatientFirstName,
            this.ServicesList,
            this.DentistName,
            this.PatientPhone});
            this.dataGridView1.DataSource = this.vwAppointmentFullDetailsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(798, 356);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // vwAppointmentFullDetailsBindingSource
            // 
            this.vwAppointmentFullDetailsBindingSource.DataMember = "vw_AppointmentFullDetails";
            this.vwAppointmentFullDetailsBindingSource.DataSource = this.dentalDataSet17;
            // 
            // dentalDataSet17
            // 
            this.dentalDataSet17.DataSetName = "DentalDataSet17";
            this.dentalDataSet17.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewappointmentBindingSource3
            // 
            this.viewappointmentBindingSource3.DataMember = "View_appointment";
            this.viewappointmentBindingSource3.DataSource = this.dentalDataSet9;
            // 
            // dentalDataSet9
            // 
            this.dentalDataSet9.DataSetName = "DentalDataSet9";
            this.dentalDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewappointmentBindingSource2
            // 
            this.viewappointmentBindingSource2.DataMember = "View_appointment";
            this.viewappointmentBindingSource2.DataSource = this.dentalDataSet5;
            // 
            // dentalDataSet5
            // 
            this.dentalDataSet5.DataSetName = "DentalDataSet5";
            this.dentalDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewappointmentBindingSource
            // 
            this.viewappointmentBindingSource.DataMember = "View_appointment";
            this.viewappointmentBindingSource.DataSource = this.view_appointment;
            // 
            // view_appointment
            // 
            this.view_appointment.DataSetName = "view_appointment";
            this.view_appointment.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appointmentsBindingSource1
            // 
            this.appointmentsBindingSource1.DataMember = "Appointments";
            this.appointmentsBindingSource1.DataSource = this.dentalDataSet4;
            // 
            // dentalDataSet4
            // 
            this.dentalDataSet4.DataSetName = "DentalDataSet4";
            this.dentalDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.dentalDataSet3;
            // 
            // dentalDataSet3
            // 
            this.dentalDataSet3.DataSetName = "DentalDataSet3";
            this.dentalDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 20);
            this.textBox1.TabIndex = 15;
            // 
            // active_button
            // 
            this.active_button.BackColor = System.Drawing.Color.RoyalBlue;
            this.active_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.active_button.FlatAppearance.BorderSize = 0;
            this.active_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.active_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.active_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.active_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.active_button.ForeColor = System.Drawing.Color.White;
            this.active_button.Location = new System.Drawing.Point(5, 167);
            this.active_button.Margin = new System.Windows.Forms.Padding(2);
            this.active_button.Name = "active_button";
            this.active_button.Size = new System.Drawing.Size(58, 29);
            this.active_button.TabIndex = 18;
            this.active_button.Text = "Active";
            this.active_button.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(67, 167);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 29);
            this.button1.TabIndex = 19;
            this.button1.Text = "Cancelled";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(27, 95);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(231, 20);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // appointmentsTableAdapter1
            // 
            this.appointmentsTableAdapter1.ClearBeforeFill = true;
            // 
            // appointmentNumberPanel
            // 
            this.appointmentNumberPanel.BackColor = System.Drawing.Color.White;
            this.appointmentNumberPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.appointmentNumberPanel.Controls.Add(this.label_number_appointment);
            this.appointmentNumberPanel.Controls.Add(this.label3);
            this.appointmentNumberPanel.Controls.Add(this.label2);
            this.appointmentNumberPanel.Location = new System.Drawing.Point(283, 95);
            this.appointmentNumberPanel.Name = "appointmentNumberPanel";
            this.appointmentNumberPanel.Size = new System.Drawing.Size(232, 100);
            this.appointmentNumberPanel.TabIndex = 21;
            // 
            // label_number_appointment
            // 
            this.label_number_appointment.AutoSize = true;
            this.label_number_appointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_number_appointment.Location = new System.Drawing.Point(18, 33);
            this.label_number_appointment.Name = "label_number_appointment";
            this.label_number_appointment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_number_appointment.Size = new System.Drawing.Size(20, 25);
            this.label_number_appointment.TabIndex = 2;
            this.label_number_appointment.Text = "-";
            this.label_number_appointment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Today";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Appointment";
            // 
            // view_appointmentTableAdapter
            // 
            this.view_appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(533, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 76);
            this.panel2.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(122, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(581, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Available Time";
            // 
            // updatedView_appointment
            // 
            this.updatedView_appointment.DataSetName = "UpdatedView_appointment";
            this.updatedView_appointment.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewappointmentBindingSource1
            // 
            this.viewappointmentBindingSource1.DataMember = "View_appointment";
            this.viewappointmentBindingSource1.DataSource = this.updatedView_appointment;
            // 
            // view_appointmentTableAdapter1
            // 
            this.view_appointmentTableAdapter1.ClearBeforeFill = true;
            // 
            // view_appointmentTableAdapter2
            // 
            this.view_appointmentTableAdapter2.ClearBeforeFill = true;
            // 
            // view_appointmentTableAdapter3
            // 
            this.view_appointmentTableAdapter3.ClearBeforeFill = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(655, 52);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 20);
            this.button6.TabIndex = 24;
            this.button6.Text = "Refresh";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(324, 52);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 20);
            this.button7.TabIndex = 23;
            this.button7.Text = "Search";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
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
            this.Column1.Width = 5;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            // 
            // PatientFirstName
            // 
            this.PatientFirstName.DataPropertyName = "PatientFirstName";
            this.PatientFirstName.HeaderText = "Patient Name";
            this.PatientFirstName.Name = "PatientFirstName";
            // 
            // ServicesList
            // 
            this.ServicesList.DataPropertyName = "ServicesList";
            this.ServicesList.HeaderText = "Services List";
            this.ServicesList.Name = "ServicesList";
            // 
            // DentistName
            // 
            this.DentistName.DataPropertyName = "DentistName";
            this.DentistName.HeaderText = "Dentist Name";
            this.DentistName.Name = "DentistName";
            // 
            // PatientPhone
            // 
            this.PatientPhone.DataPropertyName = "PatientPhone";
            this.PatientPhone.HeaderText = "Phone";
            this.PatientPhone.Name = "PatientPhone";
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.appointmentNumberPanel);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.active_button);
            this.Controls.Add(this.add_appointment_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Appointments";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.Appointments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwAppointmentFullDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_appointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet3)).EndInit();
            this.appointmentNumberPanel.ResumeLayout(false);
            this.appointmentNumberPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatedView_appointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

        

        private void add_appointment_btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(btn.Parent.BackColor);
            using (Brush brush = new SolidBrush(btn.BackColor))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, btn.Height, btn.Height, 90, 180);
                    path.AddArc(btn.Width - btn.Height, 0, btn.Height, btn.Height, 270, 180);
                    path.CloseFigure();
                    g.FillPath(brush, path);
                }
            }
            TextRenderer.DrawText(g, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button add_appointment_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button active_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DentalDataSet3 dentalDataSet3;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private DentalDataSet3TableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private DentalDataSet4 dentalDataSet4;
        private BindingSource appointmentsBindingSource1;
        private DentalDataSet4TableAdapters.AppointmentsTableAdapter appointmentsTableAdapter1;
        private Panel appointmentNumberPanel;
        private Label label_number_appointment;
        private Label label3;
        private Label label2;
        private view_appointment view_appointment;
        private BindingSource viewappointmentBindingSource;
        private view_appointmentTableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter;
        private Panel panel2;
        private Label label6;
        private UpdatedView_appointment updatedView_appointment;
        private BindingSource viewappointmentBindingSource1;
        private UpdatedView_appointmentTableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter1;
        private DentalDataSet5 dentalDataSet5;
        private BindingSource viewappointmentBindingSource2;
        private DentalDataSet5TableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter2;
        private DentalDataSet9 dentalDataSet9;
        private BindingSource viewappointmentBindingSource3;
        private DentalDataSet9TableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter3;
        private Button button6;
        private Button button7;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private DentalDataSet17 dentalDataSet17;
        private BindingSource vwAppointmentFullDetailsBindingSource;
        private DentalDataSet17TableAdapters.vw_AppointmentFullDetailsTableAdapter vw_AppointmentFullDetailsTableAdapter;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn PatientFirstName;
        private DataGridViewTextBoxColumn ServicesList;
        private DataGridViewTextBoxColumn DentistName;
        private DataGridViewTextBoxColumn PatientPhone;
    }
}