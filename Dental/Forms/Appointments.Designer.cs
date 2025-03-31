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
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.updatedView_appointment = new Dental.UpdatedView_appointment();
            this.viewappointmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.view_appointmentTableAdapter1 = new Dental.UpdatedView_appointmentTableAdapters.View_appointmentTableAdapter();
            this.view_appointmentTableAdapter2 = new Dental.DentalDataSet5TableAdapters.View_appointmentTableAdapter();
            this.first_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.services_names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dentalDataSet9 = new Dental.DentalDataSet9();
            this.viewappointmentBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.view_appointmentTableAdapter3 = new Dental.DentalDataSet9TableAdapters.View_appointmentTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource3)).BeginInit();
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
            this.first_name,
            this.FullName,
            this.dateDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.services_names,
            this.phone,
            this.status,
            this.service_status,
            this.createdAtDataGridViewTextBoxColumn,
            this.Id});
            this.dataGridView1.DataSource = this.viewappointmentBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(0, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(798, 356);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            this.label_number_appointment.Size = new System.Drawing.Size(20, 25);
            this.label_number_appointment.TabIndex = 2;
            this.label_number_appointment.Text = "-";
            this.label_number_appointment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(533, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 100);
            this.panel2.TabIndex = 22;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.RoyalBlue;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(137, 62);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 25);
            this.button4.TabIndex = 26;
            this.button4.Text = "11 am";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.RoyalBlue;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(137, 33);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(59, 25);
            this.button5.TabIndex = 25;
            this.button5.Text = "10 am";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(51, 62);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 25);
            this.button3.TabIndex = 24;
            this.button3.Text = "9 am";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(51, 33);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 25);
            this.button2.TabIndex = 23;
            this.button2.Text = "8 am";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 9);
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
            // first_name
            // 
            this.first_name.DataPropertyName = "first_name";
            this.first_name.HeaderText = "Patient";
            this.first_name.Name = "first_name";
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Dentist";
            this.FullName.Name = "FullName";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.MaxInputLength = 3276743;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // services_names
            // 
            this.services_names.DataPropertyName = "services_names";
            this.services_names.HeaderText = "Services";
            this.services_names.Name = "services_names";
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "Phone";
            this.phone.Name = "phone";
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // service_status
            // 
            this.service_status.DataPropertyName = "service_status";
            this.service_status.HeaderText = "Payment Status";
            this.service_status.Name = "service_status";
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "created_At";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "created_At";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 5;
            // 
            // dentalDataSet9
            // 
            this.dentalDataSet9.DataSetName = "DentalDataSet9";
            this.dentalDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewappointmentBindingSource3
            // 
            this.viewappointmentBindingSource3.DataMember = "View_appointment";
            this.viewappointmentBindingSource3.DataSource = this.dentalDataSet9;
            // 
            // view_appointmentTableAdapter3
            // 
            this.view_appointmentTableAdapter3.ClearBeforeFill = true;
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.appointmentNumberPanel);
            this.Controls.Add(this.dateTimePicker1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewappointmentBindingSource3)).EndInit();
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
        private Button button4;
        private Button button5;
        private Button button3;
        private Button button2;
        private UpdatedView_appointment updatedView_appointment;
        private BindingSource viewappointmentBindingSource1;
        private UpdatedView_appointmentTableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter1;
        private DentalDataSet5 dentalDataSet5;
        private BindingSource viewappointmentBindingSource2;
        private DentalDataSet5TableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter2;
        private DataGridViewTextBoxColumn first_name;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn services_names;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn service_status;
        private DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Id;
        private DentalDataSet9 dentalDataSet9;
        private BindingSource viewappointmentBindingSource3;
        private DentalDataSet9TableAdapters.View_appointmentTableAdapter view_appointmentTableAdapter3;
    }
}