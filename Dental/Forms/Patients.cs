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
            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";
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

    }
}
