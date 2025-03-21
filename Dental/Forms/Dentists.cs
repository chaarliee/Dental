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
    public partial class Dentists: Form
    {
        public Dentists()
        {
            InitializeComponent();
        }

    

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AddDentists addDentistControl = new AddDentists();
            //this.Controls.Add(addDentistControl);
            //addDentistControl.BringToFront();

            AddDentists addDentistControl = new AddDentists();
            addDentistControl.DentistAdded += AddDentistControl_DentistAdded; // Subscribe to the event
            this.Controls.Add(addDentistControl);
            addDentistControl.BringToFront();
        }

        private void AddDentistControl_DentistAdded(object sender, EventArgs e)
        {
            loadData(); // Call the loadData method
        }


        private void loadData()
        {
            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";
            string query = "SELECT * FROM Dental.laravel_user.Dentists";
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
