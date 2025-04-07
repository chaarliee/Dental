using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental.Model;
using System.Data.SqlClient;

namespace Dental.Forms.Dialogs
{
    public partial class EditBilling: UserControl
    {

        public event EventHandler BillingEdited;

        public string connectionString = Config.ConnectionString;
        public int fetched_appointment_id { get; set; }

        public int totalServices;

        public int service_counter = 1;





        public EditBilling()
        {
            InitializeComponent();
        }

        private void EditBilling_Load(object sender, EventArgs e)
        {
            LoadServices(fetched_appointment_id);

            calculateTotal();

            refreshServices(connectionString, fetched_appointment_id);
            getAppointmentDetails();

        }

        public void getAppointmentDetails()
        {
            string query = "SELECT * FROM vw_AppointmentFullDetails WHERE Id = @appointment_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@appointment_id", fetched_appointment_id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Handle status-related UI logic
                            string status = reader["status"].ToString();
                            if (status == "Finished")
                            {
                                btnSave.Text = "Print";
                                btnCancel.Visible = false;
                            }

                            // ✅ Set labels from view
                            label_patient.Text = reader["PatientFirstName"].ToString();
                            label_dentist.Text = reader["DentistName"].ToString();
                            label_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd");
                            label_time.Text = TimeSpan.Parse(reader["time"].ToString()).ToString(@"hh\:mm");
                            label_status.Text = status;

                            // Optional: load more data like reason, phone, email, etc.
                            // label_email.Text = reader["PatientEmail"].ToString();
                            // label_phone.Text = reader["PatientPhone"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the appointment details: " + ex.Message);
                }
            }
        }


        public void LoadServices(int appointment_id)
        {
            panelServicesEdit.Controls.Clear();

           

            // 1. Fill Panel with Controls and Empty Combo Data
            //FillPanelWithControls(connectionString);

            // 2. Set Control Data from DB
            SetControlDataFromDB(connectionString, appointment_id);
        }

        private void SetControlDataFromDB(string connectionString, int appointment_id)
        {
            string query = "SELECT * FROM appointment_services WHERE appointment_id = @appointment_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@appointment_id", appointment_id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int yOffset = 0;
                        int rowIndex = 0;

                        while (reader.Read())
                        {
                            int serviceId = Convert.ToInt32(reader["services_id"]);

                            // 🧠 Fetch service fee and fixed flag
                            decimal serviceFee = 0;
                            bool isFixed = false;
                            GetServiceFeeAndFixed(serviceId, out serviceFee, out isFixed);

                            // 👇 Create controls
                            ComboBox comboBoxService = new ComboBox
                            {
                                Location = new Point(0, yOffset),
                                Size = new Size(125, 21),
                                DataSource = GetDynamicDataSource(),
                                DisplayMember = "services_name",
                                ValueMember = "Id",
                                Name = "Dservicecombobox_" + rowIndex
                            };
                            comboBoxService.SelectedValue = serviceId;

                            NumericUpDown numericUpDownQty = new NumericUpDown
                            {
                                Location = new Point(132, yOffset),
                                Size = new Size(66, 20),
                                Name = "Dservicequantity_" + rowIndex,
                                Value = Convert.ToDecimal(reader["quantity"]),
                                Enabled = !isFixed // disable if fixed
                            };

                            TextBox textBoxPrice = new TextBox
                            {
                                Location = new Point(203, yOffset),
                                Size = new Size(100, 20),
                                Name = "Dserviceprice_" + rowIndex,
                                Text = serviceFee.ToString(),
                            };

                            // 👇 Add controls
                            panelServicesEdit.Controls.Add(comboBoxService);
                            panelServicesEdit.Controls.Add(numericUpDownQty);
                            panelServicesEdit.Controls.Add(textBoxPrice);

                            yOffset += 30;
                            rowIndex++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the services: " + ex.Message);
                }
            }
        }

        private void GetServiceFeeAndFixed(int serviceId, out decimal fee, out bool isFixed)
        {
            fee = 0;
            isFixed = false;

            string query = "SELECT fees, fixed FROM services WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", serviceId);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fee = Convert.ToDecimal(reader["fees"]);
                            isFixed = Convert.ToBoolean(reader["fixed"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching service info: " + ex.Message);
                }
            }
        }


        private DataTable GetDynamicDataSource()
        {
            DataTable dt = new DataTable();
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


        public void calculateTotal()
        {

            decimal total_price = 0;
            decimal quantity = 0;
            decimal price = 0;
            decimal discount = 0;

            if (checkBox_discount.Checked)
            {
                discount = 0.10M;
            }
            else
            {
                discount = 0;

            }


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
                    //total_price += price * quantity;


                    Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);
                    System.Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);


                }



            }
            total_textbox.Text = total_price.ToString();


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

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!Paid.Checked && !Unpaid.Checked)
            {
                MessageBox.Show("Please select whether the payment is Paid or Unpaid before proceeding.");
                return;


            }

            int appointmentId = fetched_appointment_id; // Replace GetAppointmentId() with your actual method

            if (appointmentId > 0)
            {
                string connectionString = Config.ConnectionString;

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    System.Data.SqlClient.SqlTransaction transaction = null; // Declare transaction

                    try
                    {
                        connection.Open();
                        transaction = connection.BeginTransaction(); // Start transaction

                        // Update Appointments table
                        string updateAppointmentQuery = "UPDATE Appointments SET status = 'Finished' WHERE id = @AppointmentID";
                        using (System.Data.SqlClient.SqlCommand appointmentCommand = new System.Data.SqlClient.SqlCommand(updateAppointmentQuery, connection, transaction)) // Pass transaction
                        {
                            appointmentCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);
                            int appointmentRowsAffected = appointmentCommand.ExecuteNonQuery();

                            if (appointmentRowsAffected == 0)
                            {
                                MessageBox.Show("Appointment with ID " + appointmentId + " not found.");
                                transaction.Rollback(); // Rollback if appointment not found
                                return;
                            }
                        }

                        // Update Appointment_Services table
                        string updateServicesQuery = "UPDATE appointment_services SET status = 'Paid' WHERE appointment_id = @AppointmentID";
                        using (System.Data.SqlClient.SqlCommand servicesCommand = new System.Data.SqlClient.SqlCommand(updateServicesQuery, connection, transaction)) // Pass transaction
                        {
                            servicesCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);
                            int servicesRowsAffected = servicesCommand.ExecuteNonQuery();
                            //No need to check rows affected here, as we want to update all services associated with the appointment.
                        }

                        transaction.Commit(); // Commit transaction if both updates are successful
                        MessageBox.Show("Appointment and services status updated successfully!");

                        CloseControl();


                        //refresh data if needed.
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback(); // Rollback on error
                        }
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Appointment ID.");
            }

        }

        private void button_total_Click(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string

            refreshServices(connectionString, fetched_appointment_id);

            calculateTotal();
        }

        private void refreshServices(string connectionString, int appointment_id)
        {
            string query = "SELECT * FROM appointment_services WHERE appointment_id = @appointment_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@appointment_id", appointment_id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int yOffset = 0;
                        int rowIndex = 0;
                        while (reader.Read())
                        {
                            int serviceId = Convert.ToInt32(reader["services_id"]);

                            // 🔄 Fetch current fee and fixed status from services table
                            decimal fee;
                            bool isFixed;
                            GetServiceFeeAndFixed(serviceId, out fee, out isFixed);

                            ComboBox comboBox = (ComboBox)panelServicesEdit.Controls["Dservicecombobox_" + rowIndex];
                            if (comboBox != null)
                            {
                                comboBox.SelectedValue = serviceId;
                            }

                            NumericUpDown numericUPdown = (NumericUpDown)panelServicesEdit.Controls["Dservicequantity_" + rowIndex];
                            if (numericUPdown != null)
                            {
                                numericUPdown.Value = Convert.ToDecimal(reader["quantity"]);
                                numericUPdown.Enabled = !isFixed; // 🔐 Disable if fixed
                            }

                            TextBox textBox = (TextBox)panelServicesEdit.Controls["Dserviceprice_" + rowIndex];
                            if (textBox != null)
                            {
                                textBox.Text = fee.ToString("0.00");
                            }

                            yOffset += 30;
                            rowIndex++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the services: " + ex.Message);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddServiceRow();
        }

        private void AddServiceRow()
        {

            System.Console.WriteLine("count: " + panelServicesEdit.Controls.Count / 3);

            if (panelServicesEdit.Controls.Count / 3 >= 5)
            {
                MessageBox.Show("You have reached the required number of services.");
            }
            else
            {
                int yOffset = panelServicesEdit.Controls.Count / 3 * 30;

                ComboBox comboBoxService = new ComboBox
                {
                    Location = new Point(0, yOffset),
                    Size = new Size(125, 21),
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


                NumericUpDown numericUpDownQty = new NumericUpDown
                {
                    Location = new Point(132, yOffset),
                    Size = new Size(66, 20),
                    Name = "servicequantity_" + service_counter
                };

                TextBox textBoxPrice = new TextBox
                {
                    Location = new Point(203, yOffset),
                    Size = new Size(100, 20),
                    Name = "serviceprice_" + service_counter,
                   
                };





                panelServicesEdit.Controls.Add(comboBoxService);
                panelServicesEdit.Controls.Add(numericUpDownQty);
                panelServicesEdit.Controls.Add(textBoxPrice);

                comboBoxService.SelectedIndexChanged += comboBoxService_SelectedIndexChanged;


                service_counter++;
            }// else

        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBox textBoxPrice = (TextBox)panelServicesEdit.Controls["serviceprice_" + comboBox.Name.Split('_')[1]];

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

    }
}
