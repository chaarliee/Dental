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
    public partial class AddPatients: UserControl
    {
        public AddPatients()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            string connectionString = Config.ConnectionString;
            string query = "INSERT INTO Patients (first_name, last_name, address, gender, DOB, phone, email, created_At,age) VALUES (@first_name, @last_name, @address, @gender, @DOB, @phone, @email , @created_At,@age)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@first_name", first_name.Text);
                    command.Parameters.AddWithValue("@last_name", last_name.Text);
                    command.Parameters.AddWithValue("@address", address.Text);
                    command.Parameters.AddWithValue("@gender", gender.Text);
                    command.Parameters.AddWithValue("@DOB", dob.Text);
                    command.Parameters.AddWithValue("@age", int.Parse(age.Text));
                    command.Parameters.AddWithValue("@phone", phone.Text);
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@created_At", DateTime.Now);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Patient information saved successfully.");
                        PatientAdded?.Invoke(this, EventArgs.Empty); // Raise the event
                        CloseControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the data: " + ex.Message);
                    }
                }
            }
        }

        public event EventHandler PatientAdded;

        private void age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }
    }
}
