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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace Dental.Forms.Dialogs
{
    public partial class AddAppointment: UserControl
    {
        public AddAppointment()
        {
            InitializeComponent();
            LoadPatients();
            LoadDentist(); 
            LoadServices();
        }

        public int service_counter = 1;
        public int select_patient;
        public event EventHandler AppointmentAdded;

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

        private void LoadPatients()
        {
            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";
            string query = "SELECT * FROM Patients";


            DataTable dataTable = GetDataFromSql(connectionString, query);

            comboBoxPatients.DataSource = dataTable;
            comboBoxPatients.DisplayMember = "first_name"; // Or some other single column.

            //To display the whole row, you would have to customize the display member.
            //This can be done using the format event.
            comboBoxPatients.Format += comboBoxPatients_Format;

            /* using (SqlConnection connection = new SqlConnection(connectionString))
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
                             comboBoxPatients.DataSource = dt;
                             comboBoxPatients.DisplayMember = "first_name";
                             comboBoxPatients.ValueMember = "Id";
                         }
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show("An error occurred while loading the patients: " + ex.Message);
                     }
                 }
             }*/
        }

        public class Person
        {
            public int Id { get; set; }
            public string first_name { get; set; }

            public string last_name { get; set; }
            public int address { get; set; }
            public string phone { get; set; }

            public string age { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string DOB { get; set; }

            // Override ToString() to customize the display in the combobox
            public override string ToString()
            {
                return $"{first_name} (ID: {Id},First_name: {first_name},Last_name: {last_name}, Address: {address}, Phone: {phone}, Email: {email}, Gender: {gender}, DOB: {DOB},Age: {age})";
            }
        }


        private void LoadDentist()
        {
            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";
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
                            comboBox2.DataSource = dt;
                            comboBox2.DisplayMember = "FullName";
                            comboBox2.ValueMember = "Id";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the patients: " + ex.Message);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string paymentStatus;

            if (unpaid.Checked)
            {
                paymentStatus = "Unpaid";
            }
            else if (paid.Checked)
            {
                paymentStatus = "Paid";
            }
            else
            {
                paymentStatus = "Unpaid";
            }


                string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";
            string query = "INSERT INTO Appointments (patient_id, dentist_id, date, time, reason, status,created_At) VALUES (@patient_id, @dentist_id, @date, @time, @reason, @status,@created_At)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@patient_id", select_patient);
                    command.Parameters.AddWithValue("@dentist_id", comboBox2.SelectedValue);
                    command.Parameters.AddWithValue("@date", date_datepicker.Text);
                    command.Parameters.AddWithValue("@time", time_datepicker.Text);
                    command.Parameters.AddWithValue("@reason", reason.Text);
                    //command.Parameters.AddWithValue("@phone", phone.Text);
                    command.Parameters.AddWithValue("@status", paymentStatus);
                    command.Parameters.AddWithValue("@created_At", DateTime.Now);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Appointment information saved successfully.");
                        AppointmentAdded?.Invoke(this, EventArgs.Empty); // Raise the event
                        CloseControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while saving the data: " + ex.Message);
                    }
                }
            }
        }

        private void LoadServices()
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
                            comboBox1Services.DataSource = dt;
                            comboBox1Services.DisplayMember = "services_name";
                            comboBox1Services.ValueMember = "Id";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the services: " + ex.Message);
                    }
                }
            }
        }

        private DataTable GetDynamicDataSource()
        {
            DataTable dt = new DataTable();
            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;"; // Replace with your actual connection string
            string query = "SELECT Id, services_name FROM services";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }


        private void AddServiceRow()
        {
            if (service_counter == 5)
            {
                MessageBox.Show("You have reached the required number of services.");
            }
            else
            {
                int yOffset = panelServices.Controls.Count / 3 * 30;

                ComboBox comboBoxService = new ComboBox
                {
                    Location = new Point(0, yOffset),
                    Size = new Size(125, 21),
                    DataSource = GetDynamicDataSource(),
                    //DataSource = comboBox1Services.DataSource,
                    DisplayMember = "services_name",
                    ValueMember = "Id",
                    Name = "servicecombobox_" + panelServices.Controls.Count
                };

                //comboBoxService.Name = "servicecombobox_" + panelServices.Controls.Count;

                System.Console.WriteLine("Added ComboBox with name: " + comboBoxService.Name);

                System.Console.WriteLine("count: " + service_counter);


                if (panelServices.Controls.Count > 0)
                {
                    Control lastControl = panelServices.Controls[panelServices.Controls.Count - 1];
                    if (lastControl is ComboBox)
                    {
                        System.Console.WriteLine("Last Combobox Name: " + lastControl.Name);
                    }
                }


                NumericUpDown numericUpDownQty = new NumericUpDown
                {
                    Location = new Point(132, yOffset),
                    Size = new Size(66, 20)
                };

                TextBox textBoxPrice = new TextBox
                {
                    Location = new Point(203, yOffset),
                    Size = new Size(100, 20)
                };

                panelServices.Controls.Add(comboBoxService);
                panelServices.Controls.Add(numericUpDownQty);
                panelServices.Controls.Add(textBoxPrice);

                service_counter++;
            }// else
            
        }

      

       


        private void buttonAddService_Click_1(object sender, EventArgs e)
        {
            AddServiceRow();
        }


        private void comboBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPatients.SelectedItem != null)
            {
                if (comboBoxPatients.DataSource is DataTable dataTable)
                {
                    DataRow selectedRow = ((DataRowView)comboBoxPatients.SelectedItem).Row;

                    int id = (int)selectedRow["Id"];
                    string name = selectedRow["first_name"].ToString();
                    string address = selectedRow["address"].ToString();
                    string phone = selectedRow["Phone"].ToString();
                    string gender = selectedRow["Gender"].ToString();
                    string email = selectedRow["Email"].ToString();
                    string dob = selectedRow["DOB"].ToString();
                    string age = selectedRow["Age"].ToString();


                    select_patient = id;
                    label_gender.Text = gender;
                    label_dob.Text = dob;
                    label_age.Text = age;
                    label_phone.Text = phone;
                    label_email.Text = email;
                    label_address.Text = address;


                    Console.WriteLine($"Selected: ID={id}, Name={name}, Address={address}");
                }
                else if (comboBoxPatients.DataSource is List<Person> people)
                {
                    Person selectedPerson = (Person)comboBoxPatients.SelectedItem;

                    Console.WriteLine($"Selected: ID={selectedPerson.Id}, Name={selectedPerson.first_name}, Address={selectedPerson.address}, Phone={selectedPerson.phone}");
                }

            }
        }


        private DataTable GetDataFromSql(string connectionString, string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void comboBoxPatients_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is DataRow row)
            {
                e.Value = $"{row["first_name"]} (ID: {row["Id"]}, Age: {row["age"]}, Address: {row["address"]}, Phone: {row["phone"]}, Email: {row["email"]}, Gender: {row["gender"]}, DOB: {row["DOB"]},Age: {row["Age"]})";
                //return $"{first_name} (ID: {Id},First_name: {first_name},Last_name: {last_name}, Address: {address}, Phone: {phone}, Email: {email}, Gender: {gender})";
            }
        }
    }

     
    }
