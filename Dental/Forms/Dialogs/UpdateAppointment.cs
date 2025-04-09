﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dental.Model;

namespace Dental.Forms.Dialogs
{
    public partial class UpdateAppointment: UserControl
    {

        public int Id { get; set; }
        public int patient_id { get; set; }
        public int dentist_id { get; set; }
        public System.DateTime appointment_date { get; set; }
        public System.DateTime appointment_time { get; set; }
        public string note { get; set; }
        public string status { get; set; }

        public string service_status { get; set; }

        public int appointment_id;
        public UpdateAppointment()
        {
            InitializeComponent();

            LoadPatients();
            LoadDentist();

           


        }

        private void CloseControl()
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        public void LoadEditAppointmentData()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM Appointments WHERE Id = @id";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", appointment_id);
                    try
                    {
                        
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            if (reader.Read())
                            {
                                int patientIdFromDb = Convert.ToInt32(reader["patient_id"]);

                                comboBoxPatients.SelectedValue = Convert.ToInt32(reader["patient_id"]);
                                comboBox2.SelectedValue = Convert.ToInt32(reader["dentist_id"]);
                                date_datepicker.Value = (DateTime)reader["date"];

                                TimeSpan timeSpan = (TimeSpan)reader["time"];
                                time_datepicker.Value = DateTime.Today.Add(timeSpan);

                                //time_datepicker.Value = (Time)reader["time"];

                                reason.Text = reader["reason"].ToString();
                                string status = reader["status"].ToString();

                                object discountValue = reader["has_discount"];
                                if (discountValue != DBNull.Value)
                                {
                                    // Assuming 'discount' is VARCHAR(3) and contains 'Yes' or 'No'
                                    if (discountValue.ToString().Equals("Yes", StringComparison.OrdinalIgnoreCase))
                                    {
                                        //checkBox_discount.Checked = true;
                                    }
                                    else
                                    {
                                        //checkBox_discount.Checked = false;
                                    }
                                   
                                }
                                else
                                {
                                    // Handle the case where discount is NULL in the database
                                    //checkBox_discount.Checked = false; // Or set to a default value as needed
                                }







                                //if (status == "Scheduled")
                                //{
                                //    rbtn_unpaid.Checked = true;
                                //}
                                //else if (status == "Finished" || status == "Confirmed")
                                //{
                                //    rbtn_paid.Checked = true;
                                //}
                                //else
                                //{
                                //    rbtn_unpaid.Checked = true;
                                //}
                            }
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the appointment: " + ex.Message);
                    }
                }
            }
        }

        public void LoadPatients()
        {
           string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM Patients";

            DataTable dataTable = GetDataFromSql(connectionString, query);

            comboBoxPatients.DataSource = dataTable;
            comboBoxPatients.DisplayMember = "first_name";
            comboBoxPatients.ValueMember = "Id"; // Set the ValueMember to patient ID

            comboBoxPatients.Format += comboBoxPatients_Format;



        }

        public void LoadDentist()
        {
            string connectionString = Config.ConnectionString;
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

        public void LoadServices(int appointment_id)
        {
            panelServicesEdit.Controls.Clear();

            string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM appointment_services WHERE appointment_id = @appointment_id";

            // 1. Fill Panel with Controls and Empty Combo Data
            //FillPanelWithControls(connectionString);

            // 2. Set Control Data from DB
            SetControlDataFromDB(connectionString, appointment_id);
        }


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


        private void SetControlDataFromDB(string connectionString, int appointment_id)
        {
            string query = "SELECT * FROM appointment_services WHERE appointment_id = @appointment_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@appointment_id", appointment_id);
                    try
                    {
                       
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int yOffset = 0; // Initialize yOffset to 0
                            int rowIndex = 0;
                            while (reader.Read()) // Adjust count if needed
                            {
                                    //MessageBox.Show("appointment_id: " + appointment_id);
                                int serviceId = Convert.ToInt32(reader["services_id"]);
                                    //MessageBox.Show("services_id: " + Convert.ToInt32(reader["services_id"]));

                                ComboBox comboBoxService = new ComboBox
                                {
                                    Location = new Point(0, yOffset),
                                    Size = new Size(200, 21),
                                    DataSource = GetDynamicDataSource(),
                                    DisplayMember = "services_name",
                                    ValueMember = "Id",
                                    Name = "Dservicecombobox_" + rowIndex,
                                    SelectedValue = serviceId
                                };


                                //NumericUpDown numericUpDownQty = new NumericUpDown
                                //{
                                //    Location = new Point(132, yOffset),
                                //    Size = new Size(66, 20),
                                //    Name = "servicequantity_" + rowIndex
                                //};
                                //numericUpDownQty.Value = Convert.ToDecimal(reader["quantity"]);

                                //TextBox textBoxPrice = new TextBox
                                //{
                                //    Location = new Point(203, yOffset),
                                //    Size = new Size(100, 20),
                                //    Name = "serviceprice_" + rowIndex
                                //};

                               // textBoxPrice.Text = reader["price"].ToString();



                                panelServicesEdit.Controls.Add(comboBoxService);
                               // panelServicesEdit.Controls.Add(numericUpDownQty);
                               // panelServicesEdit.Controls.Add(textBoxPrice);

                                //ComboBox comboBox = (ComboBox)panelServicesEdit.Controls["servicecombobox_" + rowIndex];
                                //MessageBox.Show("comboBox " + comboBox);
                                //if (comboBox != null)
                                //{
                                //    comboBox.SelectedValue = serviceId;
                                //}

                                yOffset += 30;
                                rowIndex++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the patients: " + ex.Message);
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
                e.Value = $"{row["first_name"]} (ID: {row["Id"]}, Age: {row["age"]}, Address: {row["address"]}, Phone: {row["phone"]}, Email: {row["email"]}, Gender: {row["gender"]}, DOB: {row["DOB"]},Age: {row["Age"]})";
                //return $"{first_name} (ID: {Id},First_name: {first_name},Last_name: {last_name}, Address: {address}, Phone: {phone}, Email: {email}, Gender: {gender})";
            }

        }






        public void DisplayData()
        {
           
            appointment_id = Id;

            LoadEditAppointmentData();

            LoadServices(appointment_id);



        }

        public event EventHandler AppointEdited;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseControl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancel appointment
            int appointment_id = Id;
            //save edit here
            string status = "Cancelled";
          


            string connectionString = Config.ConnectionString; // Replace with your connection string
            string query = "UPDATE Appointments SET status = @status WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", appointment_id); //patientID should be the id of the patient you are updating

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Appointment updated successfully.");
                        AppointEdited?.Invoke(this, EventArgs.Empty);
                        CloseControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating Appointment information: " + ex.Message);
                    }
                }


            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //cancel appointment
            int appointment_id = Id;
            //save edit here
            string status = "Scheduled";


            //if (rbtn_unpaid.Checked)
            //{
            //    status = "Scheduled";
            //}
            //else if (rbtn_paid.Checked)
            //{
            //    status = "Finished";
            //}
            //else
            //{
            //    status = "Scheduled";
            //}





            string connectionString = Config.ConnectionString; // Replace with your connection string
            string query = "UPDATE Appointments SET status = @status, discount = @has_discount, total = @total WHERE Id = @id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    //command.Parameters.AddWithValue("@has_discount", checkBox_discount.Checked ? "Yes" : "No");
                    //command.Parameters.AddWithValue("@total", decimal.Parse(total_textbox.Text)); // Add total

                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", appointment_id); //patientID should be the id of the patient you are updating

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Appointment updated successfully.");
                        //AppointEdited?.Invoke(this, EventArgs.Empty);
                        //CloseControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating Appointment information: " + ex.Message);
                    }
                }


            }

            //string aps_status;


            //if (rbtn_unpaid.Checked)
            //{
            //    aps_status = "Unpaid";
            //}
            //else if (rbtn_paid.Checked)
            //{
            //    aps_status = "Paid";
            //}
            //else
            //{
            //    aps_status = "Unpaid";
            //}


            //string query_services = "UPDATE appointment_services SET status = @status WHERE appointment_id = @appointment_id";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command_aps = new SqlCommand(query_services, connection))
            //    {
            //        // Add parameters
            //        command_aps.Parameters.AddWithValue("@status", aps_status);
            //        command_aps.Parameters.AddWithValue("@appointment_id", appointment_id); //patientID should be the id of the patient you are updating

            //        try
            //        {
            //            connection.Open();
            //            command_aps.ExecuteNonQuery();
            //            MessageBox.Show("Appointment updated successfully.");
            //            AppointEdited?.Invoke(this, EventArgs.Empty);
            //            CloseControl();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error updating Appointment information: " + ex.Message);
            //        }
            //    }


            //}




        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            AddServiceRow();
        }

        private void AddServiceRow()
        {

            System.Console.WriteLine("added "+ panelServicesEdit.Controls.Count / 3);

            int service_counter = panelServicesEdit.Controls.Count / 3;
            if (service_counter >= 6)
            {
                MessageBox.Show("You have reached the required number of services.");
            }
            else
            {
                int yOffset = panelServicesEdit.Controls.Count / 3 * 30;

                ComboBox comboBoxService = new ComboBox
                {
                    Location = new Point(0, yOffset + 30),
                    Size = new Size(200, 21),
                    DataSource = GetDynamicDataSource(),
                    //DataSource = comboBox1Services.DataSource,
                    DisplayMember = "services_name",
                    ValueMember = "Id",
                    Name = "servicecombobox_" + service_counter
                };

                //comboBoxService.Name = "servicecombobox_" + panelServices.Controls.Count;

                //System.Console.WriteLine("Added ComboBox with name: " + comboBoxService.Name);

                //System.Console.WriteLine("count: " + service_counter);


                //if (panelServices.Controls.Count > 0)
                //{
                //    Control lastControl = panelServices.Controls[panelServices.Controls.Count - 1];
                //    if (lastControl is ComboBox)
                //    {
                //        System.Console.WriteLine("Last Combobox Name: " + lastControl.Name);
                //    }
                //}


                //NumericUpDown numericUpDownQty = new NumericUpDown
                //{
                //    Location = new Point(132, yOffset),
                //    Size = new Size(66, 20),
                //    Name = "servicequantity_" + service_counter
                //};

                TextBox textBoxPrice = new TextBox
                {
                    Location = new Point(203, yOffset),
                    Size = new Size(100, 20),
                    Name = "serviceprice_" + service_counter,
                    Visible = false
                };

                Button btnRemove = new Button
                {
                    Location = new Point(210, yOffset),
                    Size = new Size(25, 23),
                    Text = "X",
                    Tag = service_counter
                };

                btnRemove.Click += (s, e) =>
                {
                    // Remove the row by looking for controls with the same tag or index
                    var controlsToRemove = panelServicesEdit.Controls
                        .OfType<Control>()
                        .Where(ctrl => ctrl.Name.EndsWith("_" + btnRemove.Tag.ToString()))
                        .ToList();

                    foreach (var ctrl in controlsToRemove)
                    {
                        panelServicesEdit.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }

                    // Optionally repack the remaining controls
                    RepackServiceRows();
                };






                panelServicesEdit.Controls.Add(comboBoxService);
                //panelServices.Controls.Add(numericUpDownQty);
                panelServicesEdit.Controls.Add(textBoxPrice);
                panelServicesEdit.Controls.Add(btnRemove);

                //comboBoxService.SelectedIndexChanged += comboBoxService_SelectedIndexChanged;


                //service_counter++;
            }// else



        }

        private void RepackServiceRows()
        {
            int index = 0;
            var grouped = panelServicesEdit.Controls
                .OfType<Control>()
                .GroupBy(ctrl => ctrl.Name.Split('_').Last())
                .OrderBy(g => g.Key);

            foreach (var group in grouped)
            {
                int yOffset = index * 30;
                foreach (var ctrl in group)
                {
                    if (ctrl is ComboBox)
                    {
                        ctrl.Location = new Point(0, yOffset);
                        ctrl.Name = "servicecombobox_" + index;
                    }
                    else if (ctrl is NumericUpDown)
                    {
                        ctrl.Location = new Point(210, yOffset);
                        ctrl.Name = "servicequantity_" + index;
                    }
                    else if (ctrl is TextBox)
                    {
                        ctrl.Location = new Point(280, yOffset);
                        ctrl.Name = "serviceprice_" + index;
                    }
                    else if (ctrl is Button)
                    {
                        ctrl.Location = new Point(385, yOffset);
                        ctrl.Name = "btnclose_" + index;
                        ctrl.Tag = index;
                    }
                }
                index++;
            }
        }

        private void refreshServices(string connectionString, int appointment_id)
        {
            string query = "SELECT * FROM appointment_services WHERE appointment_id = @appointment_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@appointment_id", appointment_id);
                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int yOffset = 0; // Initialize yOffset to 0
                            int rowIndex = 0;
                            while (reader.Read()) // Adjust count if needed
                            {
                                //MessageBox.Show("appointment_id: " + appointment_id);
                                int serviceId = Convert.ToInt32(reader["services_id"]);
                                //MessageBox.Show("services_id: " + Convert.ToInt32(reader["services_id"]));


                                ComboBox comboBox = (ComboBox)panelServicesEdit.Controls["servicecombobox_" + rowIndex];
                                if (comboBox != null)
                                {
                                    comboBox.SelectedValue = serviceId;
                                }
                               
                                //NumericUpDown numericUPdown = (NumericUpDown)panelServicesEdit.Controls["servicequantity_" + rowIndex];
                                //if (numericUPdown != null)
                                //{
                                //    numericUPdown.Value = Convert.ToDecimal(reader["quantity"]);
                                //}
                                
                                //TextBox textBox = (TextBox)panelServicesEdit.Controls["serviceprice_" + rowIndex];
                                //if (numericUPdown != null)
                                //{
                                //    textBox.Text = reader["price"].ToString();
                                //}
                                //textBoxPrice.Text = reader["price"].ToString();
                                

                                yOffset += 30;
                                rowIndex++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the patients: " + ex.Message);
                    }
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string

            refreshServices(connectionString, appointment_id);

            calculateTotal();
        }

        private void button_total_Click(object sender, EventArgs e)
        {
            calculateTotal();
        }

        public void calculateTotal()
        {

            decimal total_price = 0;
            decimal quantity = 0;
            decimal price = 0;
            decimal discount = 0;

            //if (checkBox_discount.Checked)
            //{
               
            //    discount = 0.10M;
            //}
            //else
            //{
               
            //    discount = 0;


            //}

/*
            foreach (Control control in panelServicesEdit.Controls)
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


                    Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);
                    System.Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);


                }



            }
            total_textbox.Text = total_price.ToString();*/
        }

        private void UpdateAppointment_Load(object sender, EventArgs e)
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string

            refreshServices(connectionString, appointment_id);

            calculateTotal();
        }

    }
}
