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
            // 1. Validate Input
            if (string.IsNullOrEmpty(services.Text) || string.IsNullOrEmpty(fees.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            decimal serviceFeeValue;
            if (!decimal.TryParse(fees.Text, out serviceFeeValue))
            {
                MessageBox.Show("Invalid fee format. Please enter a valid number.");
                return;
            }

            // Get checkbox value for 'fixed'
            int fixedValue = checkBox1.Checked ? 1 : 0;

            // 2. SQL Query including fixed column
            string connectionString = Config.ConnectionString;
            string query = "UPDATE services " +
                           "SET services_name = @services_name, " +
                           "    fees = @fees, " +
                           "    fixed = @fixed " +
                           "WHERE Id = @services_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@services_name", services.Text);
                        command.Parameters.AddWithValue("@fees", serviceFeeValue);
                        command.Parameters.AddWithValue("@fixed", fixedValue);
                        command.Parameters.AddWithValue("@services_id", services_id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Service information updated successfully.");
                            ServicesEdited?.Invoke(this, EventArgs.Empty);

                            services.Text = "";
                            fees.Text = "";
                            checkBox1.Checked = false;
                            CloseControl();
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
                MessageBox.Show("Error updating service information: " + ex.Message);
            }
        }

        private void EditServices_Load(object sender, EventArgs e)
        {

            string connectionString = Config.ConnectionString;
            string query = "SELECT services_name, fees, fixed FROM services WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", services_id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assign to your form fields
                            services.Text = reader["services_name"].ToString();
                            fees.Text = reader["fees"].ToString();
                            checkBox1.Checked = Convert.ToBoolean(reader["fixed"]);
                        }
                        else
                        {
                            MessageBox.Show("Service not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading service: " + ex.Message);
                }
            }


        }
    }
}
