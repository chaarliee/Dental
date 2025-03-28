namespace Dental.Forms.Dialogs
{
    partial class AddAppointment
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dentistsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dentists = new Dental.Dentists();
            this.patients = new Dental.Patients();
            this.patientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientsTableAdapter = new Dental.PatientsTableAdapters.PatientsTableAdapter();
            this.dentistsTableAdapter = new Dental.DentistsTableAdapters.DentistsTableAdapter();
            this.comboBoxPatients = new System.Windows.Forms.ComboBox();
            this.date_datepicker = new System.Windows.Forms.DateTimePicker();
            this.time_datepicker = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.comboBox1Services = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panelServices = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.unpaid = new System.Windows.Forms.RadioButton();
            this.paid = new System.Windows.Forms.RadioButton();
            this.label_dob = new System.Windows.Forms.Label();
            this.label_age = new System.Windows.Forms.Label();
            this.label_phone = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dentistsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "DOB  :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Age :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(530, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 55;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Phone :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Email :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Gender :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Patient";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(1, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(66, 20);
            this.lblTitle.TabIndex = 41;
            this.lblTitle.Text = "Patient";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(394, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(475, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(343, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Note";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Assigned Dentist";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DataSource = this.dentistsBindingSource;
            this.comboBox2.DisplayMember = "FullName";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(237, 132);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(180, 21);
            this.comboBox2.TabIndex = 70;
            this.comboBox2.ValueMember = "Id";
            // 
            // dentistsBindingSource
            // 
            this.dentistsBindingSource.DataMember = "Dentists";
            this.dentistsBindingSource.DataSource = this.dentists;
            // 
            // dentists
            // 
            this.dentists.DataSetName = "Dentists";
            this.dentists.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patients
            // 
            this.patients.DataSetName = "Patients";
            this.patients.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientsBindingSource
            // 
            this.patientsBindingSource.DataMember = "Patients";
            this.patientsBindingSource.DataSource = this.patients;
            // 
            // patientsTableAdapter
            // 
            this.patientsTableAdapter.ClearBeforeFill = true;
            // 
            // dentistsTableAdapter
            // 
            this.dentistsTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxPatients
            // 
            this.comboBoxPatients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPatients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPatients.FormattingEnabled = true;
            this.comboBoxPatients.Location = new System.Drawing.Point(6, 86);
            this.comboBoxPatients.Name = "comboBoxPatients";
            this.comboBoxPatients.Size = new System.Drawing.Size(180, 21);
            this.comboBoxPatients.TabIndex = 71;
            this.comboBoxPatients.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatients_SelectedIndexChanged);
            this.comboBoxPatients.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBoxPatients_Format);
            // 
            // date_datepicker
            // 
            this.date_datepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_datepicker.Location = new System.Drawing.Point(241, 88);
            this.date_datepicker.Name = "date_datepicker";
            this.date_datepicker.Size = new System.Drawing.Size(99, 20);
            this.date_datepicker.TabIndex = 72;
            // 
            // time_datepicker
            // 
            this.time_datepicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time_datepicker.Location = new System.Drawing.Point(346, 88);
            this.time_datepicker.Name = "time_datepicker";
            this.time_datepicker.Size = new System.Drawing.Size(75, 20);
            this.time_datepicker.TabIndex = 73;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 15);
            this.label12.TabIndex = 74;
            this.label12.Text = "Patient Details";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(234, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 15);
            this.label13.TabIndex = 75;
            this.label13.Text = "Appointment Details";
            // 
            // reason
            // 
            this.reason.Location = new System.Drawing.Point(10, 263);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(176, 137);
            this.reason.TabIndex = 76;
            this.reason.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(234, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 15);
            this.label14.TabIndex = 77;
            this.label14.Text = "Services Details";
            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(489, 164);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(61, 23);
            this.buttonAddService.TabIndex = 78;
            this.buttonAddService.Text = "Add";
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click_1);
            // 
            // comboBox1Services
            // 
            this.comboBox1Services.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1Services.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1Services.DataSource = this.dentistsBindingSource;
            this.comboBox1Services.DisplayMember = "FullName";
            this.comboBox1Services.FormattingEnabled = true;
            this.comboBox1Services.Location = new System.Drawing.Point(237, 205);
            this.comboBox1Services.Name = "comboBox1Services";
            this.comboBox1Services.Size = new System.Drawing.Size(125, 21);
            this.comboBox1Services.TabIndex = 79;
            this.comboBox1Services.ValueMember = "Id";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(441, 206);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 81;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(234, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 82;
            this.label15.Text = "Services";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(366, 189);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 83;
            this.label16.Text = "Quantity";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(438, 190);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 84;
            this.label17.Text = "Price";
            // 
            // panelServices
            // 
            this.panelServices.Location = new System.Drawing.Point(237, 232);
            this.panelServices.Name = "panelServices";
            this.panelServices.Size = new System.Drawing.Size(313, 145);
            this.panelServices.TabIndex = 85;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(449, 384);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 86;
            this.label18.Text = "Total";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(486, 384);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(10, 13);
            this.total.TabIndex = 87;
            this.total.Text = "-";
            // 
            // unpaid
            // 
            this.unpaid.AutoSize = true;
            this.unpaid.Location = new System.Drawing.Point(241, 383);
            this.unpaid.Name = "unpaid";
            this.unpaid.Size = new System.Drawing.Size(59, 17);
            this.unpaid.TabIndex = 88;
            this.unpaid.TabStop = true;
            this.unpaid.Text = "Unpaid";
            this.unpaid.UseVisualStyleBackColor = true;
            // 
            // paid
            // 
            this.paid.AutoSize = true;
            this.paid.Location = new System.Drawing.Point(327, 383);
            this.paid.Name = "paid";
            this.paid.Size = new System.Drawing.Size(46, 17);
            this.paid.TabIndex = 89;
            this.paid.TabStop = true;
            this.paid.Text = "Paid";
            this.paid.UseVisualStyleBackColor = true;
            // 
            // label_dob
            // 
            this.label_dob.AutoSize = true;
            this.label_dob.Location = new System.Drawing.Point(64, 138);
            this.label_dob.Name = "label_dob";
            this.label_dob.Size = new System.Drawing.Size(10, 13);
            this.label_dob.TabIndex = 95;
            this.label_dob.Text = "-";
            // 
            // label_age
            // 
            this.label_age.AutoSize = true;
            this.label_age.Location = new System.Drawing.Point(66, 158);
            this.label_age.Name = "label_age";
            this.label_age.Size = new System.Drawing.Size(10, 13);
            this.label_age.TabIndex = 94;
            this.label_age.Text = "-";
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Location = new System.Drawing.Point(66, 178);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(10, 13);
            this.label_phone.TabIndex = 93;
            this.label_phone.Text = "-";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(66, 196);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(10, 13);
            this.label_email.TabIndex = 92;
            this.label_email.Text = "-";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(66, 213);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(10, 13);
            this.label_address.TabIndex = 91;
            this.label_address.Text = "-";
            // 
            // label_gender
            // 
            this.label_gender.AutoSize = true;
            this.label_gender.Location = new System.Drawing.Point(64, 119);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(10, 13);
            this.label_gender.TabIndex = 90;
            this.label_gender.Text = "-";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(369, 205);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(66, 20);
            this.numericUpDown1.TabIndex = 96;
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label_dob);
            this.Controls.Add(this.label_age);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.label_gender);
            this.Controls.Add(this.paid);
            this.Controls.Add(this.unpaid);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panelServices);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox1Services);
            this.Controls.Add(this.buttonAddService);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.time_datepicker);
            this.Controls.Add(this.date_datepicker);
            this.Controls.Add(this.comboBoxPatients);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "AddAppointment";
            this.Size = new System.Drawing.Size(562, 454);
            ((System.ComponentModel.ISupportInitialize)(this.dentistsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource patientsBindingSource;
        private Dental.Patients patients;
        private PatientsTableAdapters.PatientsTableAdapter patientsTableAdapter;
        private System.Windows.Forms.BindingSource dentistsBindingSource;
        private Dental.Dentists dentists;
        private DentistsTableAdapters.DentistsTableAdapter dentistsTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxPatients;
        private System.Windows.Forms.DateTimePicker date_datepicker;
        private System.Windows.Forms.DateTimePicker time_datepicker;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox reason;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.ComboBox comboBox1Services;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panelServices;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.RadioButton unpaid;
        private System.Windows.Forms.RadioButton paid;
        private System.Windows.Forms.Label label_dob;
        private System.Windows.Forms.Label label_age;
        private System.Windows.Forms.Label label_phone;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
