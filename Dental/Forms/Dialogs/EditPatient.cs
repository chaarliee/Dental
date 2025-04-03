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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Dental.Model;

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

            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

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


            string connectionString = Config.ConnectionString; // Replace with your connection string
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


                        save_patient_history(patient_id); 


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

        public void save_patient_history(int patient_id)
        {

            string connectionString = Config.ConnectionString; // Replace with your connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL INSERT statement with parameterized queries
                    string insertQuery = @"
                INSERT INTO patient_history (
                    patient_id, 
                    good_health, 
                    under_med_treat, 
                    what_condition_treated,
                    surgical_oprt, 
                    what_illness, 
                    taking_any_pres, 
                    what_prescript,
                    tobacco, 
                    drugs, 
                    allergic, 
                    bleeding_time, 
                    pregnant, 
                    blood_type, 
                    blood_pressure, 
                    have_these_illness,
                    specified_illness
                )
                VALUES (
                    @patient_id, @q1, @q2, @q2_text,
                    @q3, @q3_text, @q4, @q4_text,
                    @q5, @q6, @q7_text, @q8_time, @q9, 
                     @blood_type, @blood_pressure, @have_these_illness,
                    @specified_illness
                )";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@patient_id", patient_id);
                        command.Parameters.AddWithValue("@q1", GetRadioButtonValue(groupBox1));
                        command.Parameters.AddWithValue("@q2", GetRadioButtonValue(groupBox2));
                        command.Parameters.AddWithValue("@q2_text", textBox1.Text); // Correct TextBox
                        command.Parameters.AddWithValue("@q3", GetRadioButtonValue(groupBox3));
                        command.Parameters.AddWithValue("@q3_text", textBox2.Text); // Correct TextBox (assuming you have textBox2)
                        command.Parameters.AddWithValue("@q4", GetRadioButtonValue(groupBox4));
                        command.Parameters.AddWithValue("@q4_text", textBox3.Text); // Correct TextBox (assuming you have textBox3)
                        command.Parameters.AddWithValue("@q5", GetRadioButtonValue(groupBox5));
                        command.Parameters.AddWithValue("@q6", GetRadioButtonValue(groupBox6));
                        command.Parameters.AddWithValue("@q7_text", GetCheckedAllergies());
                        command.Parameters.AddWithValue("@q8_time", dateTimePicker1.Value); // Use DateTime directly
                        command.Parameters.AddWithValue("@q9", GetRadioButtonValue(groupBox10));
                        command.Parameters.AddWithValue("@q12", GetRadioButtonValue(groupBox11));
                        command.Parameters.AddWithValue("@blood_type", textBox5.Text);
                        command.Parameters.AddWithValue("@blood_pressure", textBox6.Text); //Example: Assuming you have a comboBox for blood type
                        command.Parameters.AddWithValue("@have_these_illness", GetRadioButtonValue(groupBox11)); //Example: Assuming you have a groupBox12 for illness
                        command.Parameters.AddWithValue("@specified_illness", textBox7.Text); //Example: Assuming you have a textBox7 for specified illness

                        // Execute the query
                        command.ExecuteNonQuery();

                        MessageBox.Show("Patient history saved successfully!");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                // Log the error (optional)
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the error (optional)
            }



        }


        private int GetRadioButtonValue(System.Windows.Forms.GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is System.Windows.Forms.RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text.ToLower() == "yes" ? 1 : 0;
                }
            }
            return 0; // Default to 0 if none is selected
        }

        private string GetCheckedAllergies()
        {
            string allergies = "";
            if (checkBox1.Checked) allergies += "Antibiotics, ";
            if (checkBox2.Checked) allergies += "Local Anesthetic, ";
            if (checkBox3.Checked) allergies += "Aspirin, ";
            if (checkBox5.Checked) allergies += "Latex, ";
            if (checkBox4.Checked) allergies += textBox4.Text; // Assuming you have a textBox for "Other"
            return allergies.TrimEnd(',', ' '); // Remove trailing comma and space
        }



        public event EventHandler PatientEdited;

        private void EditPatient_Load(object sender, EventArgs e)
        {

            LoadPatientHistory(patient_id);
            
        }

        private void LoadPatientHistory(int patientId)
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = @"
                    SELECT 
                        good_health, under_med_treat, what_condition_treated,
                        surgical_oprt, what_illness, taking_any_pres, what_prescript,
                        tobacco, drugs, allergic, bleeding_time, pregnant, breastfeeding,
                        pills, blood_type, blood_pressure, have_these_illness,
                        specified_illness
                    FROM patient_history
                    WHERE patient_id = @patientId";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // If a record is found
                            {
                                // Load data into UI controls
                                SetRadioButton(groupBox1, "good_health", reader["good_health"]);
                                SetRadioButton(groupBox2, "under_med_treat", reader["under_med_treat"]);
                                textBox1.Text = reader["what_condition_treated"].ToString();
                                textBox2.Text = reader["surgical_oprt"].ToString();
                                textBox4.Text = reader["what_illness"].ToString();
                                SetRadioButton(groupBox4, "taking_any_pres", reader["taking_any_pres"]);
                                textBox3.Text = reader["what_prescript"].ToString();
                                SetRadioButton(groupBox5, "tobacco", reader["tobacco"]);
                                SetRadioButton(groupBox6, "drugs", reader["drugs"]);
                                SetAllergiesCheckboxes(reader["allergic"].ToString());
                                dateTimePicker1.Value = reader.IsDBNull(reader.GetOrdinal("bleeding_time")) ? DateTime.Now : (DateTime)reader["bleeding_time"];
                                SetRadioButton(groupBox10, "pregnant", reader["pregnant"]);
                                textBox5.Text = reader["blood_type"].ToString();
                                textBox6.Text = reader["blood_pressure"].ToString();
                                SetRadioButton(groupBox11, "have_these_illness", reader["have_these_illness"]); //Example: Assuming you have a groupBox13
                                textBox7.Text = reader["specified_illness"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No patient history found for this patient.");
                                // Optionally, clear the form or handle this scenario differently
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                // Log the error
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the error
            }
        }


        private void SetRadioButton(System.Windows.Forms.GroupBox groupBox, string columnName, object value)
        {
            if (value != DBNull.Value && value is bool boolValue)
            {
                foreach (Control control in groupBox.Controls)
                {
                    if (control is System.Windows.Forms.RadioButton radioButton)
                    {
                        if (radioButton.Text.ToLower() == "yes" && boolValue)
                        {
                            radioButton.Checked = true;
                            break;
                        }
                        else if (radioButton.Text.ToLower() == "no" && !boolValue)
                        {
                            radioButton.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        private void SetAllergiesCheckboxes(string allergies)
        {
            if (!string.IsNullOrEmpty(allergies))
            {
                string[] allergyArray = allergies.Split(new string[] { ", " }, StringSplitOptions.None);
                foreach (string allergy in allergyArray)
                {
                    if (checkBox1.Text == allergy) checkBox1.Checked = true;
                    if (checkBox2.Text == allergy) checkBox2.Checked = true;
                    if (checkBox3.Text == allergy) checkBox3.Checked = true;
                    if (checkBox5.Text == allergy) checkBox5.Checked = true;
                    if (checkBox4.Text == allergy)
                    {
                        checkBox4.Checked = true;
                        textBox4.Text = allergy;
                    }
                }
            }
        }















    }
}
