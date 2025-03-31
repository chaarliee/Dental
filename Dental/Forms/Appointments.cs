using Dental.Forms.Dialogs;
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

            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";
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
            this.view_appointmentTableAdapter2.Fill(this.dentalDataSet5.View_appointment);
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
    }
}
