using Dental.Forms.Dialogs;
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
using static Dental.Form1;

namespace Dental.Forms
{
    public partial class Settings: Form
    {

        string loggedUsername = Form1.GlobalVariables.LoggedInUsername;
        public Settings()
        {
            InitializeComponent();
            loadUserData();

            if (Form1.GlobalVariables.IsAdmin)
            {
                // Show the button if the user is admin
                button2.Visible = true;
                panel3.Visible = true;
            }
            else
            {
                button2.Visible = false;
                panel3.Visible = false;
            }


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

            /*--------------------------*/
            textBox5.Text = GetUserPasswordByEmail(); // Fetch the password for the logged-in user



            /*--------------------------*/
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "SELECT application_name, phone, email, address FROM dbo.settings"; // Assuming you only want to select these columns

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
                                //textBox5.Text = reader["password"].ToString(); // **Important Security Note Below**
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


        private string GetUserPasswordByEmail()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT Password FROM Users WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", GlobalVariables.LoggedInUsername);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Password not found for the logged-in user.");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching password: " + ex.Message);
                    return null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update settings here
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "UPDATE dbo.settings SET application_name = @application_name, phone = @phone, email = @email, address = @address, updated_At = GETDATE()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@application_name", application_name.Text);
                    command.Parameters.AddWithValue("@phone", textBox2.Text);
                    command.Parameters.AddWithValue("@email", textBox3.Text);
                    command.Parameters.AddWithValue("@address", textBox4.Text);
                    //command.Parameters.AddWithValue("@password", textBox5.Text); // **Security Note: Hash the password!**

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

        private void button3_Click(object sender, EventArgs e)
        {
            AddUser addUserControl = new AddUser();
            addUserControl.UserAdded += AddUserControl_UserAdded; // Subscribe to the event
            this.Controls.Add(addUserControl);
            addUserControl.BringToFront();
        }

        private void AddUserControl_UserAdded(object sender, EventArgs e)
        {
            loadUserData(); // Call the loadData method
        }

        public void loadUserData()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT Id, Email, Fullname, IsAdmin FROM Users"; // Exclude password for security

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                try
                {
                    DataTable userTable = new DataTable();
                    adapter.Fill(userTable);
                    dataGridView1.DataSource = userTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row's data from the data source

                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];

                int user_id = int.Parse(selectedRow.Cells[0].Value.ToString());

                //MessageBox.Show("appointment_id: " + appointment_id);
                EditUser editUserControl = new EditUser();
                editUserControl.fetched_user_id = user_id;


                //editBillingControl.DisplayData();
                this.Controls.Add(editUserControl);
                editUserControl.UserEdited += AddUserControl_UserAdded;
                editUserControl.BringToFront();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string newPassword = textBox5.Text;
            string email = GlobalVariables.LoggedInUsername;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Password field cannot be empty.");
                return;
            }

            string connectionString = Config.ConnectionString;
            string query = "UPDATE Users SET Password = @Password WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Password", newPassword);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No matching user found for update.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message);
                }
            }
        }
    }
}
