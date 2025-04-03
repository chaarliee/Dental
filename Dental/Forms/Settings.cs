using Dental.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental.Forms
{
    public partial class Settings: Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Settings_Load(object sender, EventArgs e)
        { 
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "SELECT application_name, phone, email, address, password FROM dbo.settings"; // Assuming you only want to select these columns

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows) // Check if there are any rows returned
                        {
                            while (reader.Read())
                            {
                                // Assuming you have TextBoxes or other controls to display the data
                                application_name.Text = reader["application_name"].ToString();
                                textBox2.Text = reader["phone"].ToString();
                                textBox3.Text = reader["email"].ToString();
                                textBox4.Text = reader["address"].ToString();
                                textBox5.Text = reader["password"].ToString(); // **Important Security Note Below**
                            }
                        }
                        else
                        {
                            MessageBox.Show("No settings data found.");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving settings: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update settings here
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "UPDATE dbo.settings SET application_name = @application_name, phone = @phone, email = @email, address = @address, password = @password, updated_At = GETDATE()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@application_name", application_name.Text);
                    command.Parameters.AddWithValue("@phone", textBox2.Text);
                    command.Parameters.AddWithValue("@email", textBox3.Text);
                    command.Parameters.AddWithValue("@address", textBox4.Text);
                    command.Parameters.AddWithValue("@password", textBox5.Text); // **Security Note: Hash the password!**

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Settings updated successfully.");
                            // Optionally, you might want to reload the settings or update the UI
                            // to reflect the changes.
                        }
                        else
                        {
                            MessageBox.Show("No settings were updated."); // This might happen if no changes were made.
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating settings: " + ex.Message);
                    }
                }
            }
        }
    }
}
