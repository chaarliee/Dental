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
    public partial class EditServices: UserControl
    {

        public int services_id { get; set; }
        public string services_name { get; set; }
        public string service_fee { get; set; }


        public event EventHandler ServicesEdited;


        public EditServices()
        {
            InitializeComponent();
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

        public void DisplayData()
        {
            

            services.Text = services_name;
            fees.Text = service_fee;    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Validate Input (Important!)
            if (string.IsNullOrEmpty(services.Text) || string.IsNullOrEmpty(fees.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return; // Exit the method if validation fails
            }

            decimal serviceFeeValue;
            if (!decimal.TryParse(fees.Text, out serviceFeeValue))
            {
                MessageBox.Show("Invalid fee format. Please enter a valid number.");
                return; // Exit the method if parsing fails
            }

            // 2. Database Connection and Command
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "UPDATE services " +
                           "SET services_name = @services_name, " +
                           "    fees = @fees " +
                           "WHERE Id = @services_id"; // Assuming 'id' is the primary key

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 3. Add Parameters (Prevent SQL Injection)
                        command.Parameters.AddWithValue("@services_name", services.Text);
                        command.Parameters.AddWithValue("@fees", serviceFeeValue);
                        command.Parameters.AddWithValue("@services_id", services_id); // Add the ID parameter

                        // 4. Execute the Query
                        int rowsAffected = command.ExecuteNonQuery();

                        // 5. Handle the Result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Service information updated successfully.");
                            // Raise the ServicesEdited event (if needed)
                            ServicesEdited?.Invoke(this, EventArgs.Empty);

                            // Clear the form or perform other actions as needed
                            services.Text = "";
                            fees.Text = "";
                            CloseControl(); // Assuming you want to close the control after saving
                        }
                        else
                        {
                            MessageBox.Show("Service information update failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 6. Handle Exceptions (Important!)
                MessageBox.Show("Error updating service information: " + ex.Message);
                // Log the exception for debugging purposes.
                // You might want to provide more user-friendly error messages.
            }
        }
    }
}
