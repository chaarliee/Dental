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
    public partial class AddUser : UserControl
    {
        public event EventHandler UserAdded;
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Input Validation
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determine if admin
            bool isAdmin = radioYes.Checked;

            // SQL insert
            string query = "INSERT INTO Users (Email, Password, Fullname, IsAdmin) VALUES (@Email, @Password, @Fullname, @IsAdmin)";

            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                command.Parameters.AddWithValue("@Password", txtPassword.Text); // Consider hashing in production
                command.Parameters.AddWithValue("@Fullname", txtFullname.Text.Trim());
                command.Parameters.AddWithValue("@IsAdmin", isAdmin);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("User saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(); // optional: clear the form

                    UserAdded?.Invoke(this, EventArgs.Empty); // Raise the event
                    CloseControl();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ClearForm()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtFullname.Text = "";
            radioYes.Checked = false;
            radioNo.Checked = true;
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
    }
}
