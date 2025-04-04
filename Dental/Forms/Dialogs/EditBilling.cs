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





        public EditBilling()
        {
            InitializeComponent();
        }

        private void EditBilling_Load(object sender, EventArgs e)
        {
            LoadServices(fetched_appointment_id);

            calculateTotal();

            refreshServices(connectionString, fetched_appointment_id);


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
                                    Size = new Size(125, 21),
                                    DataSource = GetDynamicDataSource(),
                                    DisplayMember = "services_name",
                                    ValueMember = "Id",
                                    Name = "servicecombobox_" + rowIndex,
                                    SelectedValue = serviceId
                                };


                                NumericUpDown numericUpDownQty = new NumericUpDown
                                {
                                    Location = new Point(132, yOffset),
                                    Size = new Size(66, 20),
                                    Name = "servicequantity_" + rowIndex
                                };
                                numericUpDownQty.Value = Convert.ToDecimal(reader["quantity"]);

                                TextBox textBoxPrice = new TextBox
                                {
                                    Location = new Point(203, yOffset),
                                    Size = new Size(100, 20),
                                    Name = "serviceprice_" + rowIndex
                                };

                                textBoxPrice.Text = reader["price"].ToString();



                                panelServicesEdit.Controls.Add(comboBoxService);
                                panelServicesEdit.Controls.Add(numericUpDownQty);
                                panelServicesEdit.Controls.Add(textBoxPrice);

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

                                NumericUpDown numericUPdown = (NumericUpDown)panelServicesEdit.Controls["servicequantity_" + rowIndex];
                                if (numericUPdown != null)
                                {
                                    numericUPdown.Value = Convert.ToDecimal(reader["quantity"]);
                                }
                                //numericUpDownQty.Value = Convert.ToDecimal(reader["quantity"]);

                                TextBox textBox = (TextBox)panelServicesEdit.Controls["serviceprice_" + rowIndex];
                                if (numericUPdown != null)
                                {
                                    textBox.Text = reader["price"].ToString();
                                }
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


    }
}
