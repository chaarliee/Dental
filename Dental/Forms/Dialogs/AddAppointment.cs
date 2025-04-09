using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using Dental.Model;
using System.Management.Instrumentation;
using DevExpress.Xpo.DB.Helpers;

namespace Dental.Forms.Dialogs
{
    public partial class AddAppointment : UserControl
    {

        private DataTable serviceDataTable = new DataTable();

        public string AppointmentStatus = "Scheduled";
        public AddAppointment()
        {
            InitializeComponent();
            LoadPatients();
            LoadDentist();
            //LoadServices();
            InitializeDataTable();

            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

            panelPatient.AutoScroll = false;
            panelPatient.HorizontalScroll.Enabled = false;
            panelPatient.HorizontalScroll.Visible = false;
            panelPatient.HorizontalScroll.Maximum = 0;
            panelPatient.AutoScroll = true;
        }

        public int service_counter = 1;
        public int select_patient;
        public bool isNewPatient = false;
        public event EventHandler AppointmentAdded;

        private void InitializeDataTable()
        {
            serviceDataTable.Columns.Add("ServiceId", typeof(int));
            serviceDataTable.Columns.Add("Quantity", typeof(int));
            serviceDataTable.Columns.Add("Price", typeof(decimal));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CloseControl();
        }

        private void CloseControl()
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        


        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseControl();

        }

        private void LoadPatients()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM Patients";

            DataTable dataTable = GetDataFromSql(connectionString, query);

            comboBoxPatients.DataSource = dataTable;
            comboBoxPatients.DisplayMember = "first_name"; // Or some other single column.

            //To display the whole row, you would have to customize the display member.
            //This can be done using the format event.
            comboBoxPatients.Format += comboBoxPatients_Format;
        }

        public class Person
        {
            public int Id { get; set; }
            public string first_name { get; set; }

            public string last_name { get; set; }
            public int address { get; set; }
            public string phone { get; set; }

            public string age { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string DOB { get; set; }


           

            // Override ToString() to customize the display in the combobox
            public override string ToString()
            {
                return $"{first_name} (ID: {Id},First_name: {first_name},Last_name: {last_name}, Address: {address}, Phone: {phone}, Email: {email}, Gender: {gender}, DOB: {DOB},Age: {age})";
            }
        }


        private void LoadDentist()
        {
            string connectionString =Config.ConnectionString;
            string query = "SELECT * FROM Dentists";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            comboBox2.DataSource = dt;
                            comboBox2.DisplayMember = "FullName";
                            comboBox2.ValueMember = "Id";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the patients: " + ex.Message);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal discount = 0;
            string has_discount = "No";

            if (label50.Text != "0")
            {
                discount = 0.10M;
                has_discount = "Yes";
            }

            string connectionString = Config.ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 🟨 Insert new patient if needed
                    if (isNewPatient)
                    {
                        string fullName = "";
                        string phone = "";
                        string email = "";

                        foreach (Control ctrl in panelPatient.Controls)
                        {
                            if (ctrl is TextBox tb)
                            {
                                if (tb.Name == "textbox_patient") fullName = tb.Text;
                                else if (tb.Name == "textbox_phone") phone = tb.Text;
                                else if (tb.Name == "textbox_email") email = tb.Text;
                            }
                        }

                        string insertPatientQuery = @"
                    INSERT INTO Patients (first_name, phone, email, created_At)
                    VALUES (@first_name, @phone, @email, @created_At);
                    SELECT SCOPE_IDENTITY();";

                        using (SqlCommand patientCmd = new SqlCommand(insertPatientQuery, connection))
                        {
                            patientCmd.Parameters.AddWithValue("@first_name", fullName);
                            patientCmd.Parameters.AddWithValue("@phone", phone);
                            patientCmd.Parameters.AddWithValue("@email", email);
                            patientCmd.Parameters.AddWithValue("@created_At", DateTime.Now);

                            // 🟢 Get the newly inserted patient ID
                            select_patient = Convert.ToInt32(patientCmd.ExecuteScalar());
                        }
                    }

                    // 🟩 Insert appointment
                    string appointmentQuery = @"
                INSERT INTO Appointments 
                (patient_id, dentist_id, date, time, reason, status, created_At, discount, has_discount, total)
                VALUES 
                (@patient_id, @dentist_id, @date, @time, @reason, @status, @created_At, @discount, @has_discount, @total);
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(appointmentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@patient_id", select_patient);
                        command.Parameters.AddWithValue("@dentist_id", comboBox2.SelectedValue);
                        command.Parameters.AddWithValue("@date", date_datepicker.Value.Date);
                        command.Parameters.AddWithValue("@time", time_datepicker.Value.TimeOfDay);
                        command.Parameters.AddWithValue("@reason", reason.Text);
                        command.Parameters.AddWithValue("@status", AppointmentStatus);
                        command.Parameters.AddWithValue("@created_At", DateTime.Now);
                        command.Parameters.AddWithValue("@discount", discount);
                        command.Parameters.AddWithValue("@has_discount", has_discount);
                        command.Parameters.AddWithValue("@total", 0);

                        int appointmentId = Convert.ToInt32(command.ExecuteScalar());

                        MessageBox.Show("Appointment saved. Appointment ID: " + appointmentId);

                        SaveServiceDataInDB(appointmentId);
                        save_patient_history(select_patient, appointmentId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving appointment: " + ex.Message);
            }
        }


        public void save_patient_history(int patient_id,int appointment_id)
        {

            string connectionString = Config.ConnectionString; // Replace with your connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL INSERT statement with parameterized queries
                    string insertQuery = @"
                INSERT INTO patient_history (
                    patient_id, 
                    appointment_id,
                    good_health, 
                    under_med_treat, 
                    what_condition_treated,
                    surgical_oprt, 
                    what_illness, 
                    taking_any_pres, 
                    what_prescript,
                    tobacco, 
                    drugs, 
                    allergic, 
                    bleeding_time, 
                    pregnant, 
                    blood_type, 
                    blood_pressure, 
                    have_these_illness,
                    specified_illness
                )
                VALUES (
                    @patient_id, @appointment_id,
                    @good_health, @under_med_treat, @what_condition_treated,
                    @surgical_oprt, @what_illness, @taking_any_pres, @what_prescript,
                    @tobacco, @drugs, @allergic, @bleeding_time, @pregnant, 
                     @blood_type, @blood_pressure, @have_these_illness,
                    @specified_illness
                )";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@patient_id", patient_id);
                        command.Parameters.AddWithValue("@appointment_id", appointment_id);
                        command.Parameters.AddWithValue("@good_health", GetRadioButtonValue(groupBox1));
                        command.Parameters.AddWithValue("@under_med_treat", GetRadioButtonValue(groupBox2));
                        command.Parameters.AddWithValue("@what_condition_treated", what_condition_treated.Text); // Correct TextBox
                        command.Parameters.AddWithValue("@surgical_oprt", GetRadioButtonValue(groupBox3));
                        command.Parameters.AddWithValue("@what_illness", textBox2.Text); // Correct TextBox (assuming you have textBox2)
                        command.Parameters.AddWithValue("@taking_any_pres", GetRadioButtonValue(groupBox4));
                        command.Parameters.AddWithValue("@what_prescript", textBox3.Text); // Correct TextBox (assuming you have textBox3)
                        command.Parameters.AddWithValue("@tobacco", GetRadioButtonValue(groupBox5));
                        command.Parameters.AddWithValue("@drugs", GetRadioButtonValue(groupBox6));
                        command.Parameters.AddWithValue("@allergic", GetCheckedAllergies());
                        command.Parameters.AddWithValue("@bleeding_time", dateTimePicker1.Value); // Use DateTime directly
                        command.Parameters.AddWithValue("@pregnant", GetRadioButtonValue(groupBox10));
                        command.Parameters.AddWithValue("@q12", GetRadioButtonValue(groupBox11));
                        command.Parameters.AddWithValue("@blood_type", textBox5.Text);
                        command.Parameters.AddWithValue("@blood_pressure", textBox6.Text); //Example: Assuming you have a comboBox for blood type
                        command.Parameters.AddWithValue("@have_these_illness", GetRadioButtonValue(groupBox11)); //Example: Assuming you have a groupBox12 for illness
                        command.Parameters.AddWithValue("@specified_illness", textBox7.Text); //Example: Assuming you have a textBox7 for specified illness

                        // Execute the query
                        command.ExecuteNonQuery();

                        MessageBox.Show("Patient history saved successfully!");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                // Log the error (optional)
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the error (optional)
            }



        }

        private int GetRadioButtonValue(System.Windows.Forms.GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is System.Windows.Forms.RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text.ToLower() == "yes" ? 1 : 0;
                }
            }
            return 0; // Default to 0 if none is selected
        }

        private string GetCheckedAllergies()
        {
            string allergies = "";
            if (checkBox1.Checked) allergies += "Antibiotics, ";
            if (checkBox2.Checked) allergies += "Local Anesthetic, ";
            if (checkBox3.Checked) allergies += "Aspirin, ";
            if (checkBox5.Checked) allergies += "Latex, ";
            if (checkBox4.Checked) allergies += textBox4.Text; // Assuming you have a textBox for "Other"
            return allergies.TrimEnd(',', ' '); // Remove trailing comma and space
        }


        private void SaveServiceDataInDB(int appointmentId)
        {
            SaveServiceData();

            string paymentStatus = "Unpaid";
            string connectionString = Config.ConnectionString;
            string query = "INSERT INTO appointment_services (appointment_id, services_id, quantity, price, status, created_At) VALUES (@appointment_id, @services_id, @quantity, @price, @status, @created_At)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (DataRow row in serviceDataTable.Rows)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("@appointment_id", appointmentId);
                            command.Parameters.AddWithValue("@services_id", row["ServiceId"]);
                            command.Parameters.AddWithValue("@quantity", row["Quantity"]);
                            command.Parameters.AddWithValue("@price", row["Price"]);
                            command.Parameters.AddWithValue("@status", paymentStatus);
                            command.Parameters.AddWithValue("@created_At", DateTime.Now);

                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while saving service data: " + ex.Message);
                        }
                    }
                }
            }

            MessageBox.Show("All service data saved successfully.");
            AppointmentAdded?.Invoke(this, EventArgs.Empty);
            CloseControl();





        }



        //private void LoadServices()
        //{
        //    string connectionString = Config.ConnectionString;
        //    string query = "SELECT * FROM Services";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    DataTable dt = new DataTable();
        //                    dt.Load(reader);
        //                    servicecombobox_0.DataSource = dt;
        //                    servicecombobox_0.DisplayMember = "services_name";
        //                    servicecombobox_0.ValueMember = "Id";
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("An error occurred while loading the services: " + ex.Message);
        //            }
        //        }
        //    }
        //}

        private DataTable GetDynamicDataSource()
        {
            DataTable dt = new DataTable();
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "SELECT Id, services_name FROM services";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }


        private void AddServiceRow()
        {
            int serviceCount = panelServices.Controls.OfType<ComboBox>().Count();
            if (serviceCount >= 6)
            {
                MessageBox.Show("You have reached the required number of services.");
                return;
            }

            int yOffset = serviceCount * 30;
            string suffix = serviceCount.ToString();

            // ComboBox for services
            ComboBox comboBoxService = new ComboBox
            {
                Location = new Point(0, yOffset),
                Size = new Size(190, 21),
                DataSource = GetDynamicDataSource(),
                DisplayMember = "services_name",
                ValueMember = "Id",
                Name = "servicecombobox_" + suffix
            };

            // Hidden price textbox
            TextBox textBoxPrice = new TextBox
            {
                Location = new Point(200, yOffset),
                Size = new Size(90, 21),
                Name = "serviceprice_" + suffix,
                Visible = false
            };

            // Button to remove the row
            Button btnRemove = new Button
            {
                Location = new Point(205, yOffset),
                Size = new Size(25, 23),
                Text = "X",
                Name = "btnclose_" + suffix,
                Tag = suffix
            };

            // Proper remove logic
            btnRemove.Click += (s, e) =>
            {
                string index = ((Button)s).Tag.ToString();

                Control combo = panelServices.Controls.Find("servicecombobox_" + index, false).FirstOrDefault();
                Control price = panelServices.Controls.Find("serviceprice_" + index, false).FirstOrDefault();
                Control button = panelServices.Controls.Find("btnclose_" + index, false).FirstOrDefault();

                if (combo != null) panelServices.Controls.Remove(combo);
                if (price != null) panelServices.Controls.Remove(price);
                if (button != null) panelServices.Controls.Remove(button);

                combo?.Dispose();
                price?.Dispose();
                button?.Dispose();

                RepackServiceRows(); // Realign after removing
            };

            // Add controls to the panel
            panelServices.Controls.Add(comboBoxService);
            panelServices.Controls.Add(textBoxPrice);
            panelServices.Controls.Add(btnRemove);

        }

        private void RepackServiceRows()
        {
            var groups = panelServices.Controls
         .OfType<Control>()
         .Where(c => c.Name.StartsWith("servicecombobox_") || c.Name.StartsWith("serviceprice_") || c.Name.StartsWith("btnclose_"))
         .GroupBy(c => c.Name.Split('_')[1])
         .OrderBy(g => int.Parse(g.Key))
         .ToList();

            int index = 0;

            foreach (var group in groups)
            {
                int yOffset = index * 30;

                foreach (var ctrl in group)
                {
                    if (ctrl is ComboBox)
                    {
                        ctrl.Location = new Point(0, yOffset);
                        ctrl.Name = "servicecombobox_" + index;
                    }
                    else if (ctrl is TextBox)
                    {
                        ctrl.Location = new Point(200, yOffset);
                        ctrl.Name = "serviceprice_" + index;
                    }
                    else if (ctrl is Button)
                    {
                        ctrl.Location = new Point(205, yOffset);
                        ctrl.Name = "btnclose_" + index;
                        ctrl.Tag = index;
                    }
                }

                index++;
            }
        }


        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBox textBoxPrice = (TextBox)panelServices.Controls["serviceprice_" + comboBox.Name.Split('_')[1]];

            if (comboBox.SelectedValue != null)
            {
                int selectedServiceId = (int)comboBox.SelectedValue;
                string connectionString = Config.ConnectionString;
                string query = "SELECT fees FROM Services WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedServiceId);
                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                textBoxPrice.Text = result.ToString();
                            }
                            else
                            {
                                textBoxPrice.Text = "0"; // Or any default value you want
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error fetching fees: " + ex.Message);
                            textBoxPrice.Text = "0"; // Or any default value you want
                        }
                    }
                }
            }
        }








        private void buttonAddService_Click_1(object sender, EventArgs e)
        {
            AddServiceRow();
        }


        private void comboBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPatients.SelectedItem != null)
            {
                if (comboBoxPatients.DataSource is DataTable dataTable)
                {
                    DataRow selectedRow = ((DataRowView)comboBoxPatients.SelectedItem).Row;

                    int id = (int)selectedRow["Id"];
                    string name = selectedRow["first_name"].ToString();
                    string address = selectedRow["address"].ToString();
                    string phone = selectedRow["Phone"].ToString();
                    string gender = selectedRow["Gender"].ToString();
                    string email = selectedRow["Email"].ToString();
                    string dob = selectedRow["DOB"].ToString();
                    string age = selectedRow["Age"].ToString();
                    string insurance = selectedRow["Insurance"].ToString();

                    


                    select_patient = id;
                    label_gender.Text = gender;
                    label_dob.Text = dob;
                    label_age.Text = age;
                    label_phone.Text = phone;
                    label_email.Text = email;
                    label_address.Text = address;
                    //label48.Text = insurance;
                

                    if (int.TryParse(insurance, out int insuranceId))
                    {
                        getInsurance_name(insuranceId);
                    }
                    else
                    {
                        label48.Text = "N/A";
                    }



                    Console.WriteLine($"Selected: ID={id}, Name={name}, Address={address}");
                }
                else if (comboBoxPatients.DataSource is List<Person> people)
                {
                    Person selectedPerson = (Person)comboBoxPatients.SelectedItem;

                    Console.WriteLine($"Selected: ID={selectedPerson.Id}, Name={selectedPerson.first_name}, Address={selectedPerson.address}, Phone={selectedPerson.phone}");
                }

            }
        }

        public void getInsurance_name(int insurance_id)
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT company, discount_rate FROM Insurance_company WHERE id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", insurance_id);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label48.Text = reader["company"].ToString();
                                label50.Text = reader["discount_rate"].ToString();
                            }
                            else
                            {
                                label48.Text = "N/A";
                                label50.Text = "0";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching insurance info: " + ex.Message);
                        label48.Text = "Error";
                        label50.Text = "Error";
                    }
                }
            }

        }


        private DataTable GetDataFromSql(string connectionString, string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void comboBoxPatients_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is DataRow row)
            {
                e.Value = $"{row["first_name"]} (ID: {row["Id"]}, Age: {row["age"]}, Address: {row["address"]}, Phone: {row["phone"]}, Email: {row["email"]}, Gender: {row["gender"]}, DOB: {row["DOB"]},Age: {row["Age"]},Insurance: {row["insurance"]})";
                //return $"{first_name} (ID: {Id},First_name: {first_name},Last_name: {last_name}, Address: {address}, Phone: {phone}, Email: {email}, Gender: {gender})";
            }
        }

        private void SaveServiceData()
        {
            serviceDataTable.Clear();

            foreach (Control control in panelServices.Controls)
            {
                if (control is ComboBox comboBoxService && comboBoxService.Name.StartsWith("servicecombobox_"))
                {
                    string index = comboBoxService.Name.Split('_')[1];
                    TextBox textBoxPrice = panelServices.Controls.Find("serviceprice_" + index, true).FirstOrDefault() as TextBox;

                    if (comboBoxService.SelectedValue != null && textBoxPrice != null)
                    {
                        int serviceId = Convert.ToInt32(comboBoxService.SelectedValue);
                        int quantity = 1;
                        decimal price = 0;

                        //decimal.TryParse(textBoxPrice.Text, out price);

                        serviceDataTable.Rows.Add(serviceId, quantity, price);
                    }
                }
            }

        }

       

        public void calculateTotal()
        {
            decimal total_price = 0;
            decimal quantity = 0;
            decimal price = 0;
            decimal discount = 0;

          

            
            foreach (Control control in panelServices.Controls)
            {

               
                if (control is NumericUpDown)
                {
                    NumericUpDown numericUpDownQty = (NumericUpDown)control;
                    if (!string.IsNullOrEmpty(numericUpDownQty.Text))
                    {
                        quantity = decimal.Parse(numericUpDownQty.Text);
                    }
                    else
                    {
                        quantity = 0;
                    }
                }

                if (control is TextBox)
                {
                    TextBox textBoxPrice = (TextBox)control;
                    if (!string.IsNullOrEmpty(textBoxPrice.Text))
                    {
                        price = decimal.Parse(textBoxPrice.Text);
                    }
                    else
                    {
                        price = 0;
                    }


                    decimal itemTotal = price * quantity;
                    decimal itemDiscount = itemTotal * discount;
                    decimal discountedItemTotal = itemTotal - itemDiscount;

                    total_price += discountedItemTotal;
                    //total_price += price * quantity;


                    Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);
                    System.Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);


                }



              




            }
            //total_textbox.Text = total_price.ToString();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            isNewPatient = true;
            panelPatient.Controls.Clear();

            int ycontrol = 0;
            int xcontrol = 0;
            Label label = new Label
            {
                Text = "Patient Name",
                Location = new Point(xcontrol, ycontrol),
                AutoSize = true
            };
            ycontrol += 15;
            TextBox newTextBox = new TextBox
            {
                Name = "textbox_patient",
                Location = new Point(xcontrol, ycontrol), // X=10, Y=10
                Size = new Size(200, 30)      // Width=200, Height=30
            };
            ycontrol += 20;

            Label label2 = new Label
            {
                Text = "Phone",
                Location = new Point(xcontrol, ycontrol),
                AutoSize = true
            };
            ycontrol += 15;

            TextBox newTextBox2 = new TextBox
            {
                Name = "textbox_phone",
                Location = new Point(xcontrol, ycontrol), // X=10, Y=10
                Size = new Size(200, 30)      // Width=200, Height=30
            };
            ycontrol += 20;

            Label label3 = new Label
            {
                Text = "Email",
                Location = new Point(xcontrol, ycontrol),
                AutoSize = true
            };

            ycontrol += 15;

            TextBox newTextBox3 = new TextBox
            {
                Name = "textbox_email",
                Location = new Point(xcontrol, ycontrol), // X=10, Y=10
                Size = new Size(200, 30)      // Width=200, Height=30
            };
            ycontrol += 20;

           


            panelPatient.Controls.Add(newTextBox);
            panelPatient.Controls.Add(label);
            panelPatient.Controls.Add(newTextBox2);
            panelPatient.Controls.Add(label2);
            panelPatient.Controls.Add(newTextBox3);
            panelPatient.Controls.Add(label3);
      


        }

        





        //private void servicecombobox_0_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox)sender;

        //    if (comboBox.SelectedValue != null)
        //    {
        //        int selectedServiceId = (int)comboBox.SelectedValue;
        //        string connectionString = Config.ConnectionString;
        //        string query = "SELECT fees FROM Services WHERE Id = @Id";

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@Id", selectedServiceId);
        //                try
        //                {
        //                    connection.Open();
        //                    object result = command.ExecuteScalar();
        //                    if (result != null)
        //                    {
        //                        serviceprice_0.Text = result.ToString();
        //                    }
        //                    else
        //                    {
        //                        serviceprice_0.Text = "0"; // Or any default value you want
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error fetching fees: " + ex.Message);
        //                    serviceprice_0.Text = "0"; // Or any default value you want
        //                }
        //            }
        //        }
        //    }
        //}





    }

     
 }
