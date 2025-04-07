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
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using System.Net.Http.Headers;

using RestSharp;

//using Telesign;
//using Telesign.RestClient;
//using Telesign.RestClient.PhoneNumbers;
//using Telesign.RestClient.SMS;



using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Dental.Model;
using System.Net.Http;
using Twilio.TwiML.Messaging;
using static System.Net.WebRequestMethods;
using System.Collections.Specialized;


namespace Dental.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            getTotalAppointmentToday();
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

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SendEmailRemindersForTodayAppointments()
        {
            string connectionString = Config.ConnectionString;  // Replace with your actual connection string
            string query = "SELECT email, date, time FROM view_Appointment WHERE CAST(date AS DATE) = CAST(GETDATE() AS DATE)"; // Get email, date, and time for today's appointments

            List<AppointmentEmailData> appointmentEmails = new List<AppointmentEmailData>();

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
                                appointmentEmails.Add(new AppointmentEmailData
                                {
                                    Email = reader["email"].ToString(),
                                    Date = Convert.ToDateTime(reader["date"]),
                                    Time = reader["time"].ToString()
                                });
                            }
                        }
                    }
                }

                if (appointmentEmails.Count > 0)
                {
                    foreach (AppointmentEmailData appointment in appointmentEmails)
                    {
                        SendAppointmentReminderEmail(appointment.Email, appointment.Date, appointment.Time);
                    }
                }
                else
                {
                    MessageBox.Show("No appointments found for today to send email reminders.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching appointment data: " + ex.Message);
            }
        }

        private void SendAppointmentReminderEmail(string recipientEmail, DateTime appointmentDate, string appointmentTime)
        {
            string senderEmail = Config.Email_Sender; // Replace with your email address
            string senderPassword = Config.Email_Password; // Replace with your email password (use secure storage!)
            string smtpHost = Config.Email_SMTP; // Replace with your SMTP server hostname
            int smtpPort = Config.Email_PORT; // Replace with your SMTP server port (usually 587 for TLS)

            string subject = "Appointment Reminder";
            string body = $"Dear Patient,\n\nThis is a friendly reminder of your appointment on {appointmentDate.ToShortDateString()} at {appointmentTime}.\n\nSincerely,\nThe Dental Clinic";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = false; // Set to true if you want to send HTML emails

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpHost;
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true; // Use SSL/TLS for secure communication


            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Email reminder sent to {recipientEmail}");
                // Optionally, you could log this or update the UI
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Error sending email to {recipientEmail}: {ex.Message}");
                MessageBox.Show($"Error sending email to {recipientEmail}: {ex.Message}");
            }
            finally
            {
                smtpClient.Dispose(); // Clean up resources
                mailMessage.Dispose();
            }
        }

        // Helper class to store appointment data
        private class AppointmentEmailData
        {
            public string Email { get; set; }
            public DateTime Date { get; set; }
            public string Time { get; set; }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SendEmailRemindersForTodayAppointments();
            //SendSMSForTodayAppointments();



        }






      



























        //private void SendSMSForTodayAppointments()
        //{
        //    string connectionString = Config.ConnectionString;  // Replace with your actual connection string
        //    string query = "SELECT phone FROM view_Appointment WHERE CAST(date AS DATE) = CAST(GETDATE() AS DATE)"; // Get phone numbers for today's appointments

        //    List<string> phoneNumbers = new List<string>();

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        //phoneNumbers.Add(reader["phone"].ToString());
        //                        string phoneNumber = "whatsapp:" + reader["phone"].ToString();
        //                        phoneNumbers.Add(phoneNumber);
        //                    }
        //                }
        //            }
        //        }

        //        if (phoneNumbers.Count > 0)
        //        {
        //            foreach (string phoneNumber in phoneNumbers)
        //            {
        //                //SendSMS(phoneNumber, "Reminder: You have an appointment today!"); // Send the SMS
        //               //add code here for sms
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("No appointments found for today.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error fetching appointment data: " + ex.Message);
        //    }
        //}

      

        private void Dashboard_Load(object sender, EventArgs e)
        {
            getNumberPatients();
            getNumberPatientsCreatedThisMonth();
            getTotalRevenueToday();


         }
        public void getTotalRevenueToday()
        {

            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "SELECT SUM(total) FROM Appointments WHERE status = 'Finished' AND CONVERT(DATE, date) = CONVERT(DATE, GETDATE())";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        decimal totalAmount = 0;

                        if (result != DBNull.Value && result != null)
                        {
                            totalAmount = Convert.ToDecimal(result);
                        }

                        label11.Text = totalAmount.ToString("C"); // "C" formats as currency

                        // Use the totalAmount variable (e.g., display it in a label)
                        // labelTotalAmount.Text = totalAmount.ToString("C"); // "C" formats as currency
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message)
            }


        }


        public void getNumberPatientsCreatedThisMonth()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT COUNT(*) FROM patients WHERE DATEPART(yyyy, created_At) = DATEPART(yyyy, GETDATE()) AND DATEPART(mm, created_At) = DATEPART(mm, GETDATE())";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int patientCount = (int)command.ExecuteScalar();
                        // Do something with patientCount (e.g., set it to a label)
                        label14.Text = patientCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, display an error message)
            }
        }


        public void getNumberPatients(){

            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            string query = "SELECT COUNT(*) FROM patients"; // Count all rows

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int patientCount = (int)command.ExecuteScalar(); // ExecuteScalar returns a single value

                        label7.Text = patientCount.ToString(); // Set the label's text
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Handle errors gracefully
                label7.Text = "Error"; // Or some default error message
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            string apiKey = "1576|IdbSlwTWJ0JlvrpklWxhbwaeJ0Byzq7brF0Gk46d"; // Replace with your actual PhilSMS API key
           // string recipientNumber = "+639273662765"; // Replace with the recipient's phone number (including country code)
            string senderId = "PhilSMS"; // Replace with your sender ID (e.g., your business name)
            string smsMessage = "Reminder: You have an appointment today with DentalCare!";

            string connectionString = Config.ConnectionString;
            string query = @"SELECT DISTINCT p.phone 
                     FROM Appointments a
                     JOIN Patients p ON a.patient_id = p.Id
                     WHERE 
                         CAST(a.date AS DATE) = CAST(GETDATE() AS DATE)
                         AND a.status = 'Scheduled'
                         AND p.phone IS NOT NULL
                         AND LTRIM(RTRIM(p.phone)) <> ''";

            List<string> phoneNumbers = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            phoneNumbers.Add(reader["phone"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching phone numbers: " + ex.Message);
                    return;
                }
            }

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                foreach (var rawNumber in phoneNumbers)
                {
                    string formattedNumber = rawNumber.StartsWith("+") ? rawNumber : $"+63{rawNumber.TrimStart('0')}";

                    var payload = new
                    {
                        recipient = formattedNumber,
                        sender_id = senderId,
                        type = "plain",
                        message = smsMessage
                    };

                    var jsonPayload = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    try
                    {
                        HttpResponseMessage response = await client.PostAsync("https://app.philsms.com/api/v3/sms/send", content);
                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"✅ SMS sent to {formattedNumber}");
                        }
                        else
                        {
                            string error = await response.Content.ReadAsStringAsync();
                            Console.WriteLine($"❌ Failed to send to {formattedNumber}: {error}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❗ Error sending to {rawNumber}: {ex.Message}");
                    }
                }

                MessageBox.Show("SMS reminders sent to today's appointments.");
            }
            //try
            //{
            //    using (HttpClient client = new HttpClient())
            //    {
            //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            //        var payload = new
            //        {
            //            recipient = recipientNumber,
            //            sender_id = senderId,
            //            type = "plain",
            //            message = smsMessage
            //        };

            //        var jsonPayload = JsonConvert.SerializeObject(payload);
            //        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            //        HttpResponseMessage response = await client.PostAsync("https://app.philsms.com/api/v3/sms/send", content);

            //        if (!response.IsSuccessStatusCode)
            //        {
            //            string errorResponse = await response.Content.ReadAsStringAsync();
            //            MessageBox.Show($"Error sending SMS. Status Code: {response.StatusCode}, Response: {errorResponse}");
            //            Console.WriteLine($"Error sending SMS. Status Code: {response.StatusCode}, Response: {errorResponse}");
            //            return;
            //        }

            //        string responseBody = await response.Content.ReadAsStringAsync();
            //        MessageBox.Show("SMS sent successfully!\n" + responseBody);
            //        Console.WriteLine(responseBody);
            //    }
            //}
            //catch (HttpRequestException ex)
            //{
            //    MessageBox.Show("Error sending SMS (HTTP): " + ex.Message);
            //    Console.WriteLine($"HttpRequestException: {ex.Message}");
            //}
            //catch (JsonException ex)
            //{
            //    MessageBox.Show("Error sending SMS (JSON): " + ex.Message);
            //    Console.WriteLine($"JsonException: {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error sending SMS (General): " + ex.Message);
            //    Console.WriteLine($"Exception: {ex.Message}");
            //}


        }

        //public static async Task<bool> SendSmsAsync(string phoneNumber, string message, string senderName = "SEMAPHORE")
        //{
        //   // string apiUrl = "https://semaphore.co/api/v4/messages";
        //    string apiUrl = "https://api.semaphore.co/api/v4/priority";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var requestBody = new Dictionary<string, string>
        //        {
        //            { "apikey", Config.Semaphore_ApiKey },
        //            { "number", phoneNumber },
        //            { "message", message },
        //            { "sendername", senderName } // Optional
        //        };

        //        var content = new FormUrlEncodedContent(requestBody);

        //        try
        //        {
        //            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string responseContent = await response.Content.ReadAsStringAsync();
        //                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

        //                Console.WriteLine("SMS sent successfully!");
        //                return true;
        //            }
        //            else
        //            {
        //                string errorContent = await response.Content.ReadAsStringAsync();
        //                Console.Error.WriteLine($"Error sending SMS: {response.StatusCode} - {errorContent}");
        //                return false;
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.Error.WriteLine($"HTTP Request Exception: {ex.Message}");
        //            return false;
        //        }
        //        catch (JsonException ex)
        //        {
        //            Console.Error.WriteLine($"JSON Exception: {ex.Message}");
        //            return false;
        //        }
        //    }
        //}

        private async void button3_Click(object sender, EventArgs e)
        {
            //using philsms
            string apiKey = "YOUR_PHILSMS_API_KEY"; // Replace with your PhilSMS API key
            string toNumber = "639123456789"; // Replace with the recipient's phone number
            string messageText = "Hello from PhilSMS!"; // Replace with your SMS message

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var payload = new
                {
                    to = toNumber,
                    message = messageText
                };

                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://app.philsms.com/api/v3/sms/send", content);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("SMS sent successfully!\n" + responseBody);
                    Console.WriteLine(responseBody);

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Error sending SMS: " + ex.Message);
                    Console.WriteLine($"HttpRequestException: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"JSON Error: {ex.Message}");
                    Console.WriteLine($"JSON Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"General Error: {ex.Message}");
                    Console.WriteLine($"General Error: {ex.Message}");
                }

            }
        }





    }
}
