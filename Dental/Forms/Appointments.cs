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
    public partial class Appointments: Form
    {
        public Appointments()
        {
            InitializeComponent();
            getTotalAppointmentToday();


        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void getTotalAppointmentToday()
        {

            string connectionString = Config.ConnectionString;
            string query = "SELECT COUNT(*) FROM Appointments WHERE CAST(date AS DATE) = CAST(GETDATE() AS DATE)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        int totalAppointments = (int)command.ExecuteScalar();
                        label_number_appointment.Text = totalAppointments.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error getting total appointments: " + ex.Message);
                        label_number_appointment.Text = "0"; // Or some default value
                    }
                }
            }


        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dentalDataSet9.View_appointment' table. You can move, or remove it, as needed.
            this.view_appointmentTableAdapter3.Fill(this.dentalDataSet9.View_appointment);
            // TODO: This line of code loads data into the 'dentalDataSet5.View_appointment' table. You can move, or remove it, as needed.


        }

       

        private void add_appointment_btn_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointmentControl = new AddAppointment();
            addAppointmentControl.AppointmentAdded += addAppointmentControl_AppointmentAdded; // Subscribe to the event
            this.Controls.Add(addAppointmentControl);
            addAppointmentControl.BringToFront();

        }

        private void addAppointmentControl_AppointmentAdded(object sender, EventArgs e)
        {
            loadData(); // Call the loadData method
        }

        private void loadData()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT * FROM view_appointment";
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row's data from the data source

                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
              
                int appointment_id = int.Parse(selectedRow.Cells[9].Value.ToString());
              

                //MessageBox.Show("appointment_id: " + appointment_id);
                UpdateAppointment updateAppointmentControl = new UpdateAppointment();
                updateAppointmentControl.Id = appointment_id;
                

                updateAppointmentControl.DisplayData();
                this.Controls.Add(updateAppointmentControl);
                updateAppointmentControl.AppointEdited += addAppointmentControl_AppointmentAdded;
                updateAppointmentControl.BringToFront();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            loadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = Config.ConnectionString;
            string searchTerm = textBox1.Text.Trim(); // Get the search term and remove leading/trailing whitespace
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter a search term.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = @"SELECT Id, date, time, reason, status, FullName, first_name, last_name, phone, created_At, service_status, services_names, email
                       FROM view_appointment
                       WHERE CONVERT(VARCHAR, date, 101) LIKE @searchTerm OR -- Searching date (MM/DD/YYYY format)
                             CONVERT(VARCHAR, time, 108) LIKE @searchTerm OR -- Searching time (HH:MM:SS format)
                             FullName LIKE @searchTerm OR
                             first_name LIKE @searchTerm OR
                             last_name LIKE @searchTerm OR
                            phone LIKE @searchTerm OR     
                            services_names LIKE @searchTerm OR
                             service_status LIKE @searchTerm";// Searching across multiple relevant fields

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date; // Get the date from the dateTimePicker
            DisplayAvailableTimesInLabels(selectedDate);
        }

        public void DisplayAvailableTimesInLabels(DateTime selectedDate)
        {
            DataTable availableTimes = GetTop5AvailableTimes(selectedDate);

            // Clear existing label text
            label4.Text = "";
            label5.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";

            // Display available times in labels
            for (int i = 0; i < availableTimes.Rows.Count; i++)
            {
                string time = availableTimes.Rows[i]["time"].ToString();
                switch (i)
                {
                    case 0:
                        label4.Text = time;
                        break;
                    case 1:
                        label5.Text = time;
                        break;
                    case 2:
                        label7.Text = time;
                        break;
                    case 3:
                        label8.Text = time;
                        break;
                    case 4:
                        label9.Text = time;
                        break;
                }
            }
        }

        public DataTable GetTop5AvailableTimes(DateTime selectedDate)
        {
            string connectionString = Config.ConnectionString;
            DataTable availableTimes = new DataTable();

            // Construct the SQL query
            string query = @"
                WITH PotentialTimes AS (
                    -- Generate a series of potential appointment times in 30-minute intervals
                    SELECT CONVERT(TIME, '09:00:00') AS PotentialTime
                    UNION ALL
                    SELECT DATEADD(MINUTE, 30, PotentialTime)
                    FROM PotentialTimes
                    WHERE DATEADD(MINUTE, 30, PotentialTime) <= CONVERT(TIME, '17:00:00') -- Adjust end time as needed
                ),
                BookedTimes AS (
                    -- Get the existing appointment times for the selected date
                    SELECT CONVERT(TIME, time) AS BookedTime
                    FROM view_appointment
                    WHERE CONVERT(DATE, date) = @selectedDate AND status <> 'Finished' -- Adjust 'Finished' as needed
                ),
                AvailableTimes AS (
                    -- Find potential times that are not within 30 minutes of booked times
                    SELECT PotentialTime
                    FROM PotentialTimes
                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM BookedTimes
                        WHERE PotentialTime >= DATEADD(MINUTE, -30, BookedTime) AND PotentialTime <= DATEADD(MINUTE, 30, BookedTime)
                    )
                )
                -- Select the top 5 available times
                SELECT TOP 5 CONVERT(VARCHAR, PotentialTime, 108) AS time  -- Convert time to HH:MM:SS format
                FROM AvailableTimes
                ORDER BY PotentialTime ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add the parameter for the selected date
                        command.Parameters.AddWithValue("@selectedDate", selectedDate.Date);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(availableTimes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching available times: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return availableTimes;
        }



    }
}
