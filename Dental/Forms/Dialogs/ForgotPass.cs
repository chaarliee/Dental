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
using System.Net.Mail;
using System.Net;
using Dental.Model;

namespace Dental.Forms.Dialogs
{
    public partial class ForgotPass: UserControl
    {

        public event EventHandler forgotPass;
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtbox_Email.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            string connectionString = Config.ConnectionString;
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("User with this email does not exist.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    return;
                }
            }

            MessageBox.Show(email);

            // ✅ Generate system password
            string newPassword = GenerateSecurePassword();

            // ✅ Update password in DB
            string updateQuery = "UPDATE Users SET Password = @Password WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@Password", newPassword);
                updateCommand.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    int rows = updateCommand.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        // ✅ Send email with new password
                        SendAppointmentReminderEmail(email, DateTime.Today, newPassword);
                        MessageBox.Show("Password reset and sent to email successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Password update failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message);
                }
            }
        }

        private void SendAppointmentReminderEmail(string recipientEmail, DateTime appointmentDate, string generatedPassword)
        {
            string senderEmail = Config.Email_Sender;         // Your sender email from config
            string senderPassword = Config.Email_Password;    // Secure password (use app-specific password if needed)
            string smtpHost = Config.Email_SMTP;              // e.g., "smtp.gmail.com"
            int smtpPort = Config.Email_PORT;                 // e.g., 587 for TLS

            string subject = "Password Reset - Dental System";
            string body = $"Dear User,\n\nYour password has been reset.\n\nNew Password: {generatedPassword}\n\n" +
                          $"Please login and change your password immediately.\n\n" +
                          $"Date Requested: {appointmentDate.ToShortDateString()}\n\n" +
                          $"Thank you,\nDental Clinic System";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = false;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpHost;
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Email with new password sent to {recipientEmail}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message);
            }
        }


        private string GenerateSecurePassword(int length = 10)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();

            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }




    }
}
