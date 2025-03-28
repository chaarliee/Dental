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
    public partial class Services: Form
    {
        public Services()
        {
            InitializeComponent();
            loadData();
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

        private void loadData()
        {
            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";
            string query = "SELECT * FROM Services";
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
    }
}
