using Dental.Forms;
using Dental.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            linkLabel1.Visible = false;
            linkLabel2.Visible = false;
        }

        public static class GlobalVariables
        {
            public static string LoggedInUsername { get; set; }
        }


        private void label2_Click(object sender, EventArgs e)
        {

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

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();

               
            }
            else if (username == "user" && password == "user")
            {

                GlobalVariables.LoggedInUsername = username;

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();

            }
            else {
                MessageBox.Show("Invalid username or password");
            }





            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

       


    }
}
