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
    public partial class Services: Form
    {


        string loggedUsername = Form1.GlobalVariables.LoggedInUsername;
        public Services()
        {
            InitializeComponent();
            loadData();

            if(loggedUsername == "admin")
            {
                // Show the button if the user is admin
                add_patient_btn.Visible = true;
            }
            else
            {
                add_patient_btn.Visible = false;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void add_patient_btn_Click(object sender, EventArgs e)
        {
            AddServices addServicesControl = new AddServices();
            addServicesControl.ServicesAdded += AddServicesControl_ServicesAdded; // Subscribe to the event
            this.Controls.Add(addServicesControl);
            addServicesControl.BringToFront();
        }

        private void AddServicesControl_ServicesAdded(object sender, EventArgs e)
        {
           loadData(); // Call the loadData method
        }

        public void loadData()
        {

            textBox1.Clear(); // Clear the search box
            string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM services";
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (loggedUsername == "admin")
            {
                if (e.RowIndex >= 0)
                {
                    // Get the selected row's data from the data source
                    int index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];


                    EditServices editServicesControl = new EditServices();



                    editServicesControl.services_id = int.Parse(selectedRow.Cells[0].Value.ToString());
                    editServicesControl.services_name = selectedRow.Cells[1].Value.ToString();
                    editServicesControl.service_fee = selectedRow.Cells[2].Value.ToString();


                    editServicesControl.DisplayData();
                    this.Controls.Add(editServicesControl);
                    editServicesControl.ServicesEdited += AddServicesControl_ServicesAdded;
                    editServicesControl.BringToFront();

                }
            }
            else
            {

            }
              
            
        }

        private void Services_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dentalDataSet13.services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter1.Fill(this.dentalDataSet13.services);
            // TODO: This line of code loads data into the 'dentalDataSet7.services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.dentalDataSet7.services);

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

            string query = @"SELECT Id, services_name, fees
                       FROM services
                       WHERE services_name LIKE @searchTerm";

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
            loadData();
        }
    }
}
