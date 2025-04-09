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
using Dental.Model;

namespace Dental.Forms.Dialogs
{
    public partial class EditUser: UserControl
    {
        public event EventHandler UserEdited;
        public int fetched_user_id { get; set; }

        public EditUser()
        {
            InitializeComponent();
            
        }

        public void load_user()
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "SELECT Email, Password, Fullname, IsAdmin FROM Users WHERE Id = @user_id"; // Assuming you only want to select these columns
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user_id", fetched_user_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtEmail.Text = reader["Email"].ToString();
                        txtPassword.Text = reader["Password"].ToString();
                        txtFullname.Text = reader["Fullname"].ToString();

                        bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                        radioYes.Checked = isAdmin;
                        radioNo.Checked = !isAdmin;
                    }
                }
            }
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

        private void EditUser_Load(object sender, EventArgs e)
        {
            load_user();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int isAdmin = radioYes.Checked ? 1 : 0;

            string connectionString = Config.ConnectionString;
            string query = @"UPDATE dbo.Users 
                     SET Email = @Email, 
                         Password = @Password, 
                         Fullname = @Fullname, 
                         IsAdmin = @IsAdmin 
                     WHERE Id = @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    command.Parameters.AddWithValue("@Fullname", txtFullname.Text.Trim());
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);
                    command.Parameters.AddWithValue("@UserId", fetched_user_id); // <-- Make sure this is set!

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User updated successfully.");
                            UserEdited?.Invoke(this, EventArgs.Empty);
                            CloseControl();
                            //this.Parent.Controls.Remove(this); // Close the user control
                        }
                        else
                        {
                            MessageBox.Show("User not found or no changes made.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating user: " + ex.Message);
                    }
                }
            }
        }
    }
}
