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
using static DevExpress.XtraEditors.SyntaxEditor.HtmlMarkupHighlighter;

namespace Dental.Forms
{
    public partial class Dentists: Form
    {
        string loggedUsername = Form1.GlobalVariables.LoggedInUsername;
        private string connectionString = Config.ConnectionString;

        public Dentists()
        {
            InitializeComponent();
            loadData();

          
            if (loggedUsername == "admin")
            {
                // Show the button if the user is admin
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }

        }

    

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void AddDentistControl_DentistAdded(object sender, EventArgs e)
        {
            loadData(); // Call the loadData method
        }


        private void loadData()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM Dentists";
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

        private void Dentists_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Dentists' table. You can move, or remove it, as needed.
            this.dentistsTableAdapter.Fill(this.dataSet1.Dentists);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddDentists addDentistControl = new AddDentists();
            addDentistControl.DentistAdded += AddDentistControl_DentistAdded; // Subscribe to the event
            this.Controls.Add(addDentistControl);
            addDentistControl.BringToFront();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (loggedUsername == "admin")
            {
                // Show the button if the user is admin

                if (e.RowIndex >= 0)
                {
                    // Get the selected row's data from the data source
                    int index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];

                    int dentist_id = int.Parse(selectedRow.Cells[0].Value.ToString());
                    DateTime parsedDate;
                    string dateString = selectedRow.Cells[6].Value.ToString();



                    EditDentists editDentistControl = new EditDentists();

                    if (DateTime.TryParse(dateString, out parsedDate))
                    {
                        editDentistControl.dob = parsedDate;
                    }

                    editDentistControl.dentist_id = dentist_id;
                    editDentistControl.Fullname = selectedRow.Cells[1].Value.ToString();
                    editDentistControl.phone = selectedRow.Cells[2].Value.ToString();
                    editDentistControl.email = selectedRow.Cells[3].Value.ToString();
                    editDentistControl.address = selectedRow.Cells[4].Value.ToString();
                    editDentistControl.gender = selectedRow.Cells[6].Value.ToString();             //editDentistControl.dob = (DateTime)selectedRow.Cells[5].Value;
                    editDentistControl.specialization = selectedRow.Cells[7].Value.ToString();


                    editDentistControl.DisplayData();
                    this.Controls.Add(editDentistControl);
                    editDentistControl.DentistEdited += AddDentistControl_DentistAdded;
                    editDentistControl.BringToFront();

                }

            }
            else
            {
                button1.Visible = false;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim(); // Get the search term and remove leading/trailing whitespace
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"SELECT Id, FullName, Address, Gender, DOB, Phone, Email, Specialization
                       FROM Dentists
                       WHERE FullName LIKE @searchTerm OR
                             Address LIKE @searchTerm OR
                             Gender LIKE @searchTerm OR
                             Phone LIKE @searchTerm OR
                             Email LIKE @searchTerm OR
                             Specialization LIKE @searchTerm";// Searching across multiple relevant fields

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
            textBox1.Clear();
            loadData();
        }
    }
}
