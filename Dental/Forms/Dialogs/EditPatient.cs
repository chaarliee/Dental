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

namespace Dental.Forms.Dialogs
{
    public partial class EditPatient: UserControl
    {
        //public YourDataType DisplayedData { get; set; }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Age { get; set; }




        public int patient_id;



        public EditPatient()
        {
            InitializeComponent();
        }

        public void DisplayData()
        {
            // Populate the labels with the values from DisplayedData
            //label1.Text = DisplayedData.Property1;
            //label2.Text = DisplayedData.Property2.ToString();
            // ... populate other labels ...
            patient_id = Id;
            textbox_fname.Text = Fullname;
            textbox_lname.Text = LastName;
            textbox_phone.Text = Phone;
            textbox_gender.Text = Gender;
            textbox_address.Text = Address;
            textbox_email.Text = Email;
            textbox_dob.Text = DateOfBirth;
            textbox_age.Text = Age;
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
            int patient_id = Id;
            //save edit here
            string fullName = textbox_fname.Text;
            string lastName = textbox_lname.Text;
            string address = textbox_address.Text;
            string phone = textbox_phone.Text;
            string email = textbox_email.Text;
            string dateOfBirth = textbox_dob.Text;
            string gender = textbox_gender.Text;
            string age = textbox_age.Text;


            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;"; // Replace with your connection string
            string query = "UPDATE Patients SET first_name = @fullName, last_name = @lastName, address = @address, phone = @phone, email = @email, DOB = @dateOfBirth, gender = @gender, age = @age WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@fullName", fullName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@id", patient_id); //patientID should be the id of the patient you are updating

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Patient information updated successfully.");
                        PatientEdited?.Invoke(this, EventArgs.Empty);
                        CloseControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating patient information: " + ex.Message);
                    }
                }


            }

        }

        public event EventHandler PatientEdited;







    }
}
