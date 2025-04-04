using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Filtering.Templates;
using Dental.Model;
using System.Data.SqlClient;

namespace Dental.Forms.Dialogs
{
    public partial class EditDentists: UserControl
    {


        public int dentist_id { get; set; }
        public string Fullname { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public DateTime dob { get; set; }
        public string email { get; set; }
        public string specialization { get; set; }

        public event EventHandler DentistEdited;
        public EditDentists()
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


            txtFullName.Text = Fullname;
            txtAddress.Text = address;
            txtPhone.Text = phone;
            txtEmail.Text = email;  
            txtGender.Text = gender;
            //datepickerDOB.Value = dob;
            txtSpecialization.Text = specialization;    

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // Validate input data before saving (important!)
            if (string.IsNullOrEmpty(txtFullName.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtPhone.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtGender.Text) ||
                datepickerDOB.Value == DateTime.MinValue || // Or your default date
                string.IsNullOrEmpty(txtSpecialization.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return; // Exit the method if validation fails
            }

            // Database connection and command setup
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "UPDATE Dentists SET " +
                           "FullName = @FullName, " +
                           "Address = @Address, " +
                           "Gender = @Gender, " +
                           "DOB = @DOB, " +
                           "Phone = @Phone, " +
                           "Email = @Email, " +
                           "Specialization = @Specialization " +
                           "WHERE Id = @Id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Id", dentist_id); // Assuming dentist_id is the primary key
                        command.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@Gender", txtGender.Text);
                        command.Parameters.AddWithValue("@DOB", datepickerDOB.Value);
                        command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Specialization", txtSpecialization.Text);

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dentist information updated successfully.");
                            // Raise the DentistEdited event (if needed)
                            DentistEdited?.Invoke(this, EventArgs.Empty);

                            // Close the control or perform other actions
                            CloseControl();
                        }
                        else
                        {
                            MessageBox.Show("Dentist information update failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating dentist information: " + ex.Message);
                // Log the exception for debugging
                // You might want to handle this more gracefully for the user
            }


        }
    }
}
