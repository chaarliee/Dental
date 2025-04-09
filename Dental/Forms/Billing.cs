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

namespace Dental.Forms
{
    public partial class Billing: Form
    {
        public Billing()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dentalDataSet16.vw_AppointmentFullDetails' table. You can move, or remove it, as needed.
            this.vw_AppointmentFullDetailsTableAdapter.Fill(this.dentalDataSet16.vw_AppointmentFullDetails);
            // TODO: This line of code loads data into the 'dentalDataSet10.View_appointment' table. You can move, or remove it, as needed.
            this.view_appointmentTableAdapter1.Fill(this.dentalDataSet10.View_appointment);
            // TODO: This line of code loads data into the 'dentalDataSet6.View_appointment' table. You can move, or remove it, as needed.

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row's data from the data source

                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];

                int appointment_id = int.Parse(selectedRow.Cells[0].Value.ToString());

                //MessageBox.Show("appointment_id: " + appointment_id);
                EditBilling editBillingControl = new EditBilling();
                editBillingControl.fetched_appointment_id = appointment_id;


                //editBillingControl.DisplayData();
                this.Controls.Add(editBillingControl);
                editBillingControl.BillingEdited += editBillingControl_BillingEdited;
                editBillingControl.BringToFront();

            }
        }

        private void editBillingControl_BillingEdited(object sender, EventArgs e)
        {
            loadData(); // Call the loadData method
        }

        public void loadData()
        {
            textBox1.Clear();
            string connectionString = Config.ConnectionString;
            string query = "SELECT  Id, date, time, reason, status, FullName, first_name, last_name, phone, created_At, service_status, services_names, email FROM View_appointment";
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

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = Config.ConnectionString;
            string searchTerm = textBox1.Text.Trim(); // Get the search term and remove leading/trailing whitespace
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"SELECT Id, date, time, reason, status, FullName, first_name, last_name, phone, created_At, service_status, services_names, email
                       FROM View_appointment
                       WHERE first_name LIKE @searchTerm OR
                             FullName LIKE @searchTerm OR
                             CONVERT(VARCHAR, date, 101) LIKE @searchTerm OR -- Searching date (MM/DD/YYYY format)
                             CONVERT(VARCHAR, time, 108) LIKE @searchTerm OR -- Searching time (HH:MM:SS format)
                             phone LIKE @searchTerm OR
                             service_status LIKE @searchTerm";

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




    }
}
