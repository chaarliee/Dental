using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dental.Model;

namespace Dental.Forms.Dialogs
{
    public partial class AddPatients: UserControl
    {
        public AddPatients()
        {
            InitializeComponent();

          
        }

        private void LoadCompanies()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT id, company FROM Insurance_company";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                try
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow noneRow = dt.NewRow();
                    noneRow["id"] = DBNull.Value;
                    noneRow["company"] = "None";
                    dt.Rows.InsertAt(noneRow, 0);


                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "company";
                    comboBox1.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading companies: " + ex.Message);
                }
            }


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
            string connectionString = Config.ConnectionString;
            string query = "INSERT INTO Patients (first_name, last_name, address, gender, DOB, phone, email, created_At, age, insurance,insuranceNum) " +
                    "VALUES (@first_name, @last_name, @address, @gender, @DOB, @phone, @email, @created_At, @age, @insurance, @insuranceNum)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@first_name", first_name.Text);
                command.Parameters.AddWithValue("@last_name", last_name.Text);
                command.Parameters.AddWithValue("@address", address.Text);
                command.Parameters.AddWithValue("@gender", gender.Text);
                command.Parameters.AddWithValue("@DOB", dateTimePickerDOB.Value.Date);
                command.Parameters.AddWithValue("@age", int.Parse(age.Text));
                command.Parameters.AddWithValue("@phone", phone.Text);
                command.Parameters.AddWithValue("@email", email.Text);
                command.Parameters.AddWithValue("@created_At", DateTime.Now);
                command.Parameters.AddWithValue("@insuranceNum", insuranceNum.Text);

                if (comboBox1.SelectedValue == null || comboBox1.SelectedValue == DBNull.Value)
                {
                    command.Parameters.AddWithValue("@insurance", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@insurance", Convert.ToInt32(comboBox1.SelectedValue));
                }


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Patient information saved successfully.");
                    PatientAdded?.Invoke(this, EventArgs.Empty); // Raise the event
                    CloseControl();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the data: " + ex.Message);
                }
            }
        }

        public event EventHandler PatientAdded;

        private void age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        private void AddPatients_Load(object sender, EventArgs e)
        {
            LoadCompanies();
        }
    }
}
