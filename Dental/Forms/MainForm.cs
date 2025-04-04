using Dental.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental.Forms
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();

            loadMainForm(new Dashboard());
        }

        public void loadMainForm(object Form)
        {

            string loggedUsername = Form1.GlobalVariables.LoggedInUsername;
         if (loggedUsername == "user" || loggedUsername == "admin")
            {
                if (this.mainpanel.Controls.Count > 0)
                    this.mainpanel.Controls.RemoveAt(0);

                Form f = Form as Form;
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                this.mainpanel.Controls.Add(f);
                this.mainpanel.Tag = f;
                f.Show();
            }
            else
            {
                Application.Exit();
            }




          

        }


        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            loadMainForm(new Dashboard());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadMainForm(new Patients());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadMainForm(new Dentists());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadMainForm(new Appointments());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadMainForm(new Reports());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadMainForm(new Settings());
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadMainForm(new Services());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadMainForm(new Billing());
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user clicked "Yes"
            if (result == DialogResult.Yes)
            {

                Form1.GlobalVariables.LoggedInUsername = string.Empty; // Or null, depending on your preference

                // Find and close the MainForm (assuming it's the active MDI child or an owned form)
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm.GetType().Name == "MainForm") // Replace "MainForm" with the actual class name of your main form
                    {
                        openForm.Close();
                        break; // Assuming you only have one instance of MainForm open
                    }
                }

                // Show Form1 (your login form)
                Form1 loginForm = new Form1();
                loginForm.Show();

                // Optionally, close the current form if it's not Form1
                if (this.GetType().Name != "Form1")
                {
                    this.Close();
                }



            }


        }




    }
}
