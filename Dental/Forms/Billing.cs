using Dental.Forms.Dialogs;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row's data from the data source

                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];

                int appointment_id = int.Parse(selectedRow.Cells[6].Value.ToString());

                //MessageBox.Show("appointment_id: " + appointment_id);
                EditBilling editBillingControl = new EditBilling();
                editBillingControl.fetched_appointment_id = appointment_id;


                //editBillingControl.DisplayData();
                this.Controls.Add(editBillingControl);
                editBillingControl.BillingEdited += editBillingControl_BillingEdited;
                editBillingControl.BringToFront();

            }
        }

        private void editBillingControl_BillingEdited(object sender, EventArgs e)
        {
            loadData(); // Call the loadData method
        }

        public void loadData()
        {

        }

    }
}
