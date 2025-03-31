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
    public partial class Billing: Form
    {
        public Billing()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dentalDataSet10.View_appointment' table. You can move, or remove it, as needed.
            this.view_appointmentTableAdapter1.Fill(this.dentalDataSet10.View_appointment);
            // TODO: This line of code loads data into the 'dentalDataSet6.View_appointment' table. You can move, or remove it, as needed.

        }
    }
}
