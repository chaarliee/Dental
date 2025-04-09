using Dental.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraBars.Customization;
using System.Net;
using Dental.Model;

namespace Dental.Forms
{
    public partial class Patients: Form
    {


        private string connectionString = Config.ConnectionString;
        public Patients()
        {
            InitializeComponent();
         
          
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Patients_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dentalDataSet14.Patients' table. You can move, or remove it, as needed.
            this.patientsTableAdapter2.Fill(this.dentalDataSet14.Patients);


        }

        private void add_patient_btn_Click(object sender, EventArgs e)
        {
            AddPatients addPatientControl = new AddPatients();
            addPatientControl.PatientAdded += AddPatientControl_PatientAdded; // Subscribe to the event
            this.Controls.Add(addPatientControl);
            addPatientControl.BringToFront();
        }

        private void AddPatientControl_PatientAdded(object sender, EventArgs e)
        {
            loadData(); // Call the loadData method
        }

        private void loadData()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM Patients";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridView1.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loadData();
        }

      

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row's data from the data source
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                int patient_id = int.Parse(selectedRow.Cells[0].Value.ToString());

                string fname = selectedRow.Cells[1].Value != DBNull.Value ? selectedRow.Cells[1].Value.ToString() : "";
                string lname = selectedRow.Cells[2].Value != DBNull.Value ? selectedRow.Cells[2].Value.ToString() : "";
                string address = selectedRow.Cells[3].Value != DBNull.Value ? selectedRow.Cells[3].Value.ToString() : "";
                string phone = selectedRow.Cells[4].Value != DBNull.Value ? selectedRow.Cells[4].Value.ToString() : "";
                string email = selectedRow.Cells[5].Value != DBNull.Value ? selectedRow.Cells[5].Value.ToString() : "";

                DateTime dob = DateTime.MinValue;
                if (selectedRow.Cells[6].Value != DBNull.Value)
                {
                    DateTime.TryParse(selectedRow.Cells[6].Value.ToString(), out dob);
                }

                string gender = selectedRow.Cells[7].Value != DBNull.Value ? selectedRow.Cells[7].Value.ToString() : "";
                string age = selectedRow.Cells[9].Value != DBNull.Value ? selectedRow.Cells[9].Value.ToString() : "";
                //int insurance = int.Parse(selectedRow.Cells[10].Value.ToString());

                int insurance = 0;

                if (selectedRow.Cells[10]?.Value != null)
                {
                    int.TryParse(selectedRow.Cells[10].Value.ToString(), out insurance);
                }

                // Assuming the 11th column is the insurance number
                string insuranceNum = selectedRow.Cells[11].Value.ToString();


                EditPatient editPatientControl = new EditPatient();
                editPatientControl.Id = patient_id;
                editPatientControl.Fullname = fname;
                editPatientControl.LastName = lname;
                editPatientControl.Address = address;
                editPatientControl.Phone = phone;
                editPatientControl.Email = email;
                editPatientControl.DateOfBirth = dob;
                editPatientControl.Gender = gender;
                editPatientControl.Age = age;
                editPatientControl.Insurance = insurance;
                editPatientControl.insuranceNumber = insuranceNum;

                editPatientControl.DisplayData();
                this.Controls.Add(editPatientControl);
                editPatientControl.PatientEdited += AddPatientControl_PatientAdded;
                editPatientControl.BringToFront();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim(); // Get the search term and remove leading/trailing whitespace
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"SELECT Id,first_name, last_name, address, phone, email, DOB, gender, created_At, age
                           FROM Patients
                           WHERE first_name LIKE @searchTerm OR
                                 last_name LIKE @searchTerm OR
                                 address LIKE @searchTerm OR
                                 email LIKE @searchTerm OR
                                 phone LIKE @searchTerm"; // Searching across multiple relevant fields

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameterized query to prevent SQL injection
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable searchResults = new DataTable();
                            adapter.Fill(searchResults);

                            // Bind the DataTable to your DataGridView
                            dataGridView1.DataSource = searchResults;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching patients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData(); // Reload the data to show all patients
            textBox1.Clear(); // Clear the search box
        }

       
    }
}
