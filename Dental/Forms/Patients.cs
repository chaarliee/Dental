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
            // TODO: This line of code loads data into the 'dentalDataSet2.Patients' table. You can move, or remove it, as needed.
            this.patientsTableAdapter.Fill(this.dentalDataSet2.Patients);


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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    // Get the selected row's data from the data source
            //    int index = e.RowIndex;
            //    DataGridViewRow selectedRow = dataGridView1.Rows[index];
            //    string fname = selectedRow.Cells[0].Value.ToString(); // Assuming the first column is the ID
            //    string lname = selectedRow.Cells[1].Value.ToString();
            //    string address = selectedRow.Cells[2].Value.ToString();
            //    string phone = selectedRow.Cells[3].Value.ToString();
            //    string email = selectedRow.Cells[4].Value.ToString();
            //    string dob = selectedRow.Cells[5].Value.ToString();
            //    string gender = selectedRow.Cells[6].Value.ToString();
            //    string age = selectedRow.Cells[8].Value.ToString();
            //    int patient_id = int.Parse(selectedRow.Cells[9].Value.ToString());

            //    EditPatient editPatientControl = new EditPatient();
            //    editPatientControl.Id = patient_id;
            //    editPatientControl.Fullname = fname;
            //    editPatientControl.LastName = lname;
            //    editPatientControl.Address = address;
            //    editPatientControl.Phone = phone;
            //    editPatientControl.Email = email;
            //    editPatientControl.DateOfBirth = dob;
            //    editPatientControl.Gender = gender;
            //    editPatientControl.Age = age;

            //    editPatientControl.DisplayData();
            //    this.Controls.Add(editPatientControl);
            //    editPatientControl.PatientEdited += AddPatientControl_PatientAdded;
            //    editPatientControl.BringToFront();

            //}
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row's data from the data source
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                string fname = selectedRow.Cells[0].Value.ToString(); // Assuming the first column is the ID
                string lname = selectedRow.Cells[1].Value.ToString();
                string address = selectedRow.Cells[2].Value.ToString();
                string phone = selectedRow.Cells[3].Value.ToString();
                string email = selectedRow.Cells[4].Value.ToString();
                string dob = selectedRow.Cells[5].Value.ToString();
                string gender = selectedRow.Cells[6].Value.ToString();
                string age = selectedRow.Cells[8].Value.ToString();
                int patient_id = int.Parse(selectedRow.Cells[9].Value.ToString());

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

                editPatientControl.DisplayData();
                this.Controls.Add(editPatientControl);
                editPatientControl.PatientEdited += AddPatientControl_PatientAdded;
                editPatientControl.BringToFront();

            }

        }
    }
}
