using Dental.Forms;
using Dental.Forms.Dialogs;
using Dental.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();

            //linkLabel1.Visible = false;
            linkLabel2.Visible = false;
        }

        public static class GlobalVariables
        {
            public static string LoggedInUsername { get; set; }
            public static bool IsAdmin { get; set; }

            public static string LoggedInName { get; set; }

        }


        

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = login_username.Text;
            string password = login_password.Text;

            if (username == "admin" && password == "admin")
            {
                GlobalVariables.LoggedInUsername = username;
                GlobalVariables.IsAdmin = true;
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();

               
            }
            else if (username == "user" && password == "user")
            {

                GlobalVariables.LoggedInUsername = username;
                GlobalVariables.IsAdmin = false;
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();

            }
            else {

                string connectionString = Config.ConnectionString;
                string query = "SELECT * FROM Users WHERE Email = @username AND Password = @password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // User found
                            //GlobalVariables.LoggedInUsername = username;
                            bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                            // Optionally store if the user is an admin
                            GlobalVariables.IsAdmin = isAdmin;
                            GlobalVariables.LoggedInName = reader["Fullname"].ToString();

                            MessageBox.Show("Welcome " + GlobalVariables.LoggedInName, "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            GlobalVariables.LoggedInUsername = username;

                         

                                MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Login error: " + ex.Message);
                    }
                }
                //MessageBox.Show("Invalid username or password");
            }





            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPass forgotpassControl = new ForgotPass();
            forgotpassControl.forgotPass += forgotpassControl_forgotPass; // Subscribe to the event
            this.Controls.Add(forgotpassControl);
            forgotpassControl.BringToFront();
        }

        private void forgotpassControl_forgotPass(object sender, EventArgs e)
        {
            // Call the loadData method
        }
    }
}
