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
    public partial class Appointments: Form
    {
        public Appointments()
        {
            InitializeComponent();
           
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'view_appointment.View_appointment' table. You can move, or remove it, as needed.
            this.view_appointmentTableAdapter.Fill(this.view_appointment.View_appointment);
            //// TODO: This line of code loads data into the 'dentalDataSet4.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter1.Fill(this.dentalDataSet4.Appointments);
            //// TODO: This line of code loads data into the 'dentalDataSet3.Appointments' table. You can move, or remove it, as needed.
            //this.appointmentsTableAdapter.Fill(this.dentalDataSet3.Appointments);

        }

        private void add_appointment_btn_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointmentControl = new AddAppointment();
            addAppointmentControl.AppointmentAdded += addAppointmentControl_AppointmentAdded; // Subscribe to the event
            this.Controls.Add(addAppointmentControl);
            addAppointmentControl.BringToFront();

        }

        private void addAppointmentControl_AppointmentAdded(object sender, EventArgs e)
        {
            loadData(); // Call the loadData method
        }

        private void loadData()
        {
            this.appointmentsTableAdapter1.Fill(this.dentalDataSet4.Appointments);
        }
    }
}
