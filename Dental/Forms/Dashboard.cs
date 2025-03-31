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

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace Dental.Forms
{
    public partial class Dashboard: Form
    {
        public Dashboard()
        {
            InitializeComponent();
            getTotalAppointmentToday();
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

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendSMSForTodayAppointments();
        }

        private void SendSMSForTodayAppointments()
        {
            string connectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";  // Replace with your actual connection string
            string query = "SELECT phone FROM view_Appointment WHERE CAST(date AS DATE) = CAST(GETDATE() AS DATE)"; // Get phone numbers for today's appointments

            List<string> phoneNumbers = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //phoneNumbers.Add(reader["phone"].ToString());
                                string phoneNumber = "whatsapp:" + reader["phone"].ToString();
                                phoneNumbers.Add(phoneNumber);
                            }
                        }
                    }
                }

                if (phoneNumbers.Count > 0)
                {
                    foreach (string phoneNumber in phoneNumbers)
                    {
                        SendSMS(phoneNumber, "Reminder: You have an appointment today!"); // Send the SMS
                    }
                }
                else
                {
                    MessageBox.Show("No appointments found for today.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching appointment data: " + ex.Message);
            }
        }

        private void SendSMS(string recipientPhoneNumber, string messageBody)
        {
            
          
            //string accountSid = null;  
            //string authToken = null;   

            try
            {
                //TwilioClient.Init(accountSid, authToken);

                //var message = MessageResource.Create(
                //    body: messageBody,
                //    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"), // Your Twilio phone number
                //    to: new Twilio.Types.PhoneNumber(recipientPhoneNumber)
                //);

                //Console.WriteLine(message.Sid); // Optionally, log the message SID
                //MessageBox.Show("SMS sent successfully! Message SID: " + message.Sid); // Consider more informative message
            }
            catch (Twilio.Exceptions.TwilioException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error sending SMS to " + recipientPhoneNumber + ": " + ex.Message);
            }
        }



        /*private void SendSMS()
        {
           
       

           
        }
*/



    }
}
