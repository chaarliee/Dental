﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Data.SqlClient;
using Dental.Model;

namespace Dental.Forms.Dialogs
{
    public partial class AddServices: UserControl
    {
        public AddServices()
        {
            InitializeComponent();
        }

        public event EventHandler ServicesAdded;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseControl();
        }

        private void CloseControl()
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int fixedValue = checkBox1.Checked ? 1 : 0;

            string connectionString = Config.ConnectionString;
            string query = "INSERT INTO services (services_name, fees, fixed) VALUES (@services_name, @fees, @fixed)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@services_name", services.Text);
                    command.Parameters.AddWithValue("@fees", fees.Text);
                    command.Parameters.AddWithValue("@fixed", fixedValue);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Services information saved successfully.");
                        ServicesAdded?.Invoke(this, EventArgs.Empty); // Raise the event
                        CloseControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the data: " + ex.Message);
                    }
                }
            }



        }



    }
}
