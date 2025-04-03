using DevExpress.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using DevExpress.Emf;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using Dental.Model;



namespace Dental.Forms
{


    public partial class Reports : Form
    {

        private int totalPatients = 44;
        private int totalAppointments = 44;
        private int completedAppointments = 29;
        private int canceledAppointments = 15;
        private List<ServiceDetail> serviceDetails = new List<ServiceDetail>
        {
            new ServiceDetail { ServiceName = "Extraction", Quantity = 12, Price = 14000 },
            new ServiceDetail { ServiceName = "Veneers", Quantity = 4, Price = 28000 },
            new ServiceDetail { ServiceName = "Cleaning", Quantity = 8, Price = 7200 },
            new ServiceDetail { ServiceName = "Braces", Quantity = 2, Price = 40000 },
            new ServiceDetail { ServiceName = "Whitening", Quantity = 3, Price = 2850 }
        };
        private decimal totalRevenue = 92050;

        public string Total_Revenue { get; set; }
        public string Total_finished { get; set; }
        public string Total_cancelled { get; set; }
        public string Total_scheduled { get; set; }




        public Reports()
        {
            InitializeComponent();
            InitializeMonthComboBox();
        }

        public class ServiceDetail
        {
            public string ServiceName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }



        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitializeMonthComboBox()
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (comboBox3.SelectedIndex == 1)
            {
                comboBoxPatient.Visible = false;
                label2.Visible = false;
            }
            else 
            {
                comboBoxPatient.Visible = true;
                label2.Visible = true;
                //comboBoxPatient.Visible = false;
                //comboBoxMonthDate.Visible = true;
                //comboBoxYearDate.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 1)
            {
                generateMonthlyPDF();
            }
            else
            {
                

                generatePatientReportPDF((int)comboBoxPatient.SelectedValue);
            }

        }

    

        

        public void generateMonthlyPDF()
        {

            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 12);
                XFont headerFont = new XFont("Arial", 14);

                // Data for the report (replace with your actual data retrieval logic)
                string reportMonth = comboBoxMonthDate.SelectedItem.ToString() + " " + int.Parse(comboBoxYearDate.SelectedItem.ToString());
                int totalAppointments = int.Parse(Total_scheduled);
                int completedAppointments = int.Parse(Total_finished);
                int cancelledAppointments = int.Parse(Total_cancelled);
                decimal totalRevenue = decimal.Parse(Total_Revenue);

                string[] services;
                int[] quantities;
                decimal[] totals;

                GetDataForServiceReport(out services, out quantities, out totals);

                // Layout parameters (adjust as needed)
                int xStart = 50;
                int yStart = 50;
                int lineHeight = 20;
                int tableXStart = 50;
                int tableYStart = yStart + 100;
                int columnWidth1 = 100;
                int columnWidth2 = 80;
                int columnWidth3 = 80;

                try
                {
                    // Report Title
                    gfx.DrawString("Dental Services Report", headerFont, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopCenter);
                    yStart += lineHeight * 2;

                    // Month
                    gfx.DrawString(reportMonth, font, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopCenter);
                    yStart += lineHeight * 2;

                    // Appointment Stats
                    gfx.DrawString($"Total Appointment: {totalAppointments}", font, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopLeft);
                    yStart += lineHeight;

                    gfx.DrawString($"Completed: {completedAppointments}", font, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopLeft);
                    yStart += lineHeight;

                    gfx.DrawString($"Cancelled: {cancelledAppointments}", font, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopLeft);
                    yStart += lineHeight * 2;

                    tableYStart += 70;

                    // Table Headers
                    gfx.DrawString("Services", headerFont, XBrushes.Black, new XRect(tableXStart, tableYStart, columnWidth1, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Quantity", headerFont, XBrushes.Black, new XRect(tableXStart + columnWidth1, tableYStart, columnWidth2, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Total", headerFont, XBrushes.Black, new XRect(tableXStart + columnWidth1 + columnWidth2, tableYStart, columnWidth3, 20), XStringFormats.TopLeft);

                    tableYStart += lineHeight;

                    // Table Data
                    if (services != null && services.Length > 0)
                    {
                        for (int i = 0; i < services.Length; i++)
                        {
                            gfx.DrawString(services[i], font, XBrushes.Black, new XRect(tableXStart, tableYStart, columnWidth1, 20), XStringFormats.TopLeft);
                            gfx.DrawString($"x{quantities[i]}", font, XBrushes.Black, new XRect(tableXStart + columnWidth1, tableYStart, columnWidth2, 20), XStringFormats.TopLeft);
                            gfx.DrawString(totals[i].ToString("N2"), font, XBrushes.Black, new XRect(tableXStart + columnWidth1 + columnWidth2, tableYStart, columnWidth3, 20), XStringFormats.TopLeft);
                            tableYStart += lineHeight;
                        }
                    }
                    else
                    {
                        gfx.DrawString("No service data found.", font, XBrushes.Black, new XRect(tableXStart, tableYStart, page.Width - tableXStart * 2, 20), XStringFormats.TopLeft);
                    }

                    yStart = tableYStart + lineHeight;

                    // Revenue
                    gfx.DrawString($"Revenue: {totalRevenue.ToString("N2")}", headerFont, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopLeft);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save PDF Report";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        document.Save(saveFileDialog.FileName);
                        MessageBox.Show("PDF report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }

                    //document.Save("MonthlyReport.pdf");
                    //MessageBox.Show("Monthly report PDF generated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating report: " + ex.Message);
                }
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            
                getPatients();
        }


        public void getPatients()
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Select both first_name (for display) and id (for ValueMember)
                    string query = "SELECT id, first_name FROM Patients"; // Adjust column names if needed

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            comboBoxPatient.DataSource = dt;
                            comboBoxPatient.DisplayMember = "first_name"; // Column to display
                            comboBoxPatient.ValueMember = "Id";        // Column with the ID value
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patients: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selected_report = comboBox3.SelectedIndex;
            int selectedPatientID = (int)comboBoxPatient.SelectedValue;
            //comboBox1.SelectedValue.ToString();
            //string selectedMonth = comboBoxMonthDate.SelectedItem.ToString();
            //string selectedYear = comboBoxYearDate.SelectedItem.ToString();

            //MessageBox.Show("test."+ selectedPatientID);

            if (selected_report == 1)
            { //display mothjly report
                getDataForMonthlyReport();
                displayMonthlyReport();
              
            }
            else
            { //display patient report

                displayPatientReport(selectedPatientID);
            }
        }

        public void getDataForMonthlyReport()
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the selected month and year from the ComboBoxes
                    int selectedMonth = comboBoxMonthDate.SelectedIndex + 1; // ComboBox is 0-based
                    int selectedYear = int.Parse(comboBoxYearDate.SelectedItem.ToString());

                    // SQL query to fetch the data
                    string selectQuery = @"
                    SELECT 
                        COUNT(*) AS TotalScheduledAppointment,
                        SUM(total) AS TotalRevenue,
                        COUNT(CASE WHEN status = 'Finished' THEN 1 END) AS FinishedAppointments,
                        COUNT(CASE WHEN status = 'Cancelled' THEN 1 END) AS CancelledAppointments
                    FROM view_appointment
                    WHERE MONTH(date) = @SelectedMonth AND YEAR(date) = @SelectedYear";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@SelectedMonth", selectedMonth);
                        command.Parameters.AddWithValue("@SelectedYear", selectedYear);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // If there's data
                            {
                                // Retrieve data from the reader
                                decimal totalRevenue = reader.IsDBNull(reader.GetOrdinal("TotalRevenue")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalRevenue"));
                                int finishedAppointments = reader.IsDBNull(reader.GetOrdinal("FinishedAppointments")) ? 0 : reader.GetInt32(reader.GetOrdinal("FinishedAppointments"));
                                int cancelledAppointments = reader.IsDBNull(reader.GetOrdinal("CancelledAppointments")) ? 0 : reader.GetInt32(reader.GetOrdinal("CancelledAppointments"));
                                int totalScheduledAppointments = reader.IsDBNull(reader.GetOrdinal("TotalScheduledAppointment")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalScheduledAppointment"));
                                // Now you have the data!
                                // You can store it in variables, display it in UI controls, etc.
                                // Example:
                                Total_Revenue = totalRevenue.ToString();
                                Total_finished = finishedAppointments.ToString();
                                Total_cancelled = cancelledAppointments.ToString();
                                Total_scheduled = totalScheduledAppointments.ToString();
                                // MessageBox.Show($"Total Revenue: {totalRevenue}\nFinished Appointments: {finishedAppointments}\nCancelled Appointments: {cancelledAppointments}");

                            }
                            else
                            {
                                MessageBox.Show("No data found for the selected month and year.");
                                // Handle the case where no data is returned
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                // Log the error
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the error
            }
        }

        public void displayMonthlyReport()
        {
            // Clear any existing controls in the panel
            panelReport.Controls.Clear();

            // Data for the report (replace with your actual data retrieval logic)
            string reportMonth = comboBoxMonthDate.SelectedItem.ToString() + " "+ int.Parse(comboBoxYearDate.SelectedItem.ToString());
            int totalAppointments = int.Parse(Total_scheduled);
            int completedAppointments = int.Parse(Total_finished);
            int cancelledAppointments = int.Parse(Total_cancelled);
            decimal totalRevenue = decimal.Parse(Total_Revenue);
            // int totalRevenue = int.Parse(Total_Revenue); // Use decimal for currency

            string[] services;
            int[] quantities;
            decimal[] totals;

            GetDataForServiceReport(out services, out quantities, out totals);

            // Now you can use the arrays:
           



            //string[] services = { "Extraction", "Veneers", "Cleaning", "Braces" };
            //int[] quantities = { 12, 4, 8, 2 };
            //decimal[] totals = { 14000, 28000, 7200, 40000 };

            // Layout parameters (adjust as needed)
            int xStart = 20;
            int yStart = 20;
            int lineHeight = 20;
            int tableXStart = 20;
            int tableYStart = yStart + 100;
            int columnWidth1 = 100;
            int columnWidth2 = 80;
            int columnWidth3 = 80;

            // Create and add controls

            // Report Title
            Label titleLabel = CreateLabel("Dental Services Report", 16, true, xStart, yStart);
            panelReport.Controls.Add(titleLabel);
            yStart += lineHeight * 2;

            // Month
            Label monthLabel = CreateLabel(reportMonth, 12, false, xStart, yStart);
            panelReport.Controls.Add(monthLabel);
            yStart += lineHeight * 2;

            // Appointment Stats
            Label totalApptLabel = CreateLabel($"Total Appointment: {totalAppointments}", 12, false, xStart, yStart);
            panelReport.Controls.Add(totalApptLabel);
            yStart += lineHeight;

            Label completedLabel = CreateLabel($"Completed: {completedAppointments}", 12, false, xStart, yStart);
            panelReport.Controls.Add(completedLabel);
            yStart += lineHeight;

            Label cancelledLabel = CreateLabel($"Cancelled: {cancelledAppointments}", 12, false, xStart, yStart);
            panelReport.Controls.Add(cancelledLabel);
            yStart += lineHeight * 2;

            tableYStart += 70;
            // Table Headers
            Label servicesHeaderLabel = CreateLabel("Services", 12, true, tableXStart, tableYStart);
            panelReport.Controls.Add(servicesHeaderLabel);

            Label quantityHeaderLabel = CreateLabel("Quantity", 12, true, tableXStart + columnWidth1, tableYStart);
            panelReport.Controls.Add(quantityHeaderLabel);

            Label totalHeaderLabel = CreateLabel("Total", 12, true, tableXStart + columnWidth1 + columnWidth2, tableYStart);
            panelReport.Controls.Add(totalHeaderLabel);

            tableYStart += lineHeight;

            // Table Data

            if (services.Length > 0)
            {
                //for (int i = 0; i < services.Length; i++)
                //{
                //    Console.WriteLine($"Service: {services[i]}, Quantity: {quantities[i]}, Total: {totals[i]}");
                //}
                for (int i = 0; i < services.Length; i++)
                {
                    Label serviceLabel = CreateLabel(services[i], 12, false, tableXStart, tableYStart);
                    panelReport.Controls.Add(serviceLabel);

                    Label quantityLabel = CreateLabel($"x{quantities[i]}", 12, false, tableXStart + columnWidth1, tableYStart);
                    panelReport.Controls.Add(quantityLabel);

                    Label totalLabel = CreateLabel(totals[i].ToString("N2"), 12, false, tableXStart + columnWidth1 + columnWidth2, tableYStart); // "N2" for currency format
                    panelReport.Controls.Add(totalLabel);

                    tableYStart += lineHeight;
                }


            }
            else
            {
                Console.WriteLine("No service data found.");
            }
           
            yStart = tableYStart + lineHeight; // Adjust yStart for Revenue label

            // Revenue
            Label revenueLabel = CreateLabel($"Revenue: {totalRevenue.ToString("N2")}", 12, true, xStart, yStart);

            panelReport.Controls.Add(revenueLabel);

        }

        private Label CreateLabel(string text, int fontSize, bool bold, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Arial", fontSize, bold ? FontStyle.Bold : FontStyle.Regular);
            label.AutoSize = true;
            label.Location = new Point(x, y);
            return label;
        }

        public void GetDataForServiceReport(out string[] services, out int[] quantities, out decimal[] totals)
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string
            List<string> servicesList = new List<string>();
            List<int> quantitiesList = new List<int>();
            List<decimal> totalsList = new List<decimal>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the selected month and year from the ComboBoxes
                    int selectedMonth = comboBoxMonthDate.SelectedIndex + 1; // ComboBox is 0-based
                    int selectedYear = int.Parse(comboBoxYearDate.SelectedItem.ToString());

                    // SQL query to fetch the data
                    string selectQuery = @"
                    SELECT 
                        services_name,
                         SUM(quantity) AS Quantity,
                        SUM(price) AS TotalPrice
                    FROM view_appointment_services
                    WHERE MONTH(date) = @SelectedMonth AND YEAR(date) = @SelectedYear
                    GROUP BY services_name";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@SelectedMonth", selectedMonth);
                        command.Parameters.AddWithValue("@SelectedYear", selectedYear);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // Loop through all rows
                            {
                                servicesList.Add(reader["services_name"].ToString());
                                quantitiesList.Add(Convert.ToInt32(reader["Quantity"]));
                                totalsList.Add(Convert.ToDecimal(reader["TotalPrice"]));
                            }
                        }
                    }
                }

                // Convert lists to arrays for output
                services = servicesList.ToArray();
                quantities = quantitiesList.ToArray();
                totals = totalsList.ToArray();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                // Log the error
                services = new string[0];
                quantities = new int[0];
                totals = new decimal[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the error
                services = new string[0];
                quantities = new int[0];
                totals = new decimal[0];
            }
        }


        public void GetPatientAppointmentInfo(int patientId, out int totalAppointments, out string patientFirstName)
        {
            string connectionString =Config.ConnectionString; // Replace with your actual connection string
            totalAppointments = 0;
            patientFirstName = "";

            int selectedMonth = comboBoxMonthDate.SelectedIndex + 1; // ComboBox is 0-based
            int selectedYear = int.Parse(comboBoxYearDate.SelectedItem.ToString());


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = @"
                    SELECT 
                        COUNT(*) AS TotalAppointments,
                        first_name
                    FROM view_appointment
                   WHERE patient_id = @PatientId
                      AND MONTH(date) = @SelectedMonth
                      AND YEAR(date) = @SelectedYear
                    GROUP BY first_name"; // Group by first_name to avoid potential multiple rows

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", patientId);
                        command.Parameters.AddWithValue("@SelectedMonth", selectedMonth);
                        command.Parameters.AddWithValue("@SelectedYear", selectedYear);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // If there's data
                            {
                                totalAppointments = Convert.ToInt32(reader["TotalAppointments"]);
                                patientFirstName = reader["first_name"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No appointments found for this patient.");
                                // Handle the case where no data is returned
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                // Log the error
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                // Log the error
            }
        }



        public void displayPatientReport(int patientId)
        {

            // Clear any existing controls in the panel
            panelReport.Controls.Clear();

            int patient_totalAppointments;

            string patientFirstName;

            GetPatientAppointmentInfo(patientId, out patient_totalAppointments, out patientFirstName);


            DataRowView selectedRow = (DataRowView)comboBoxPatient.SelectedItem;


            // Data for the report (replace with your actual data retrieval logic)
            string reportMonth = comboBoxMonthDate.SelectedItem.ToString() + " " + int.Parse(comboBoxYearDate.SelectedItem.ToString());
            string patientName = selectedRow["first_name"].ToString(); // Replace with actual patient name
            int totalAppointments = patient_totalAppointments; // Replace with actual total appointments

            // Clinic History Data (Retrieve from view_appointment_services)
            List<ClinicHistoryItem> clinicHistory = GetPatientClinicHistoryFromView(patientId);

            // Layout parameters (adjust as needed)
            int xStart = 20;
            int yStart = 20;
            int lineHeight = 20;
            int tableXStart = 20;
            int tableYStart = yStart + 100;
            int columnWidth1 = 100;
            int columnWidth2 = 150;
            int columnWidth3 = 80;

            try
            {
                // Report Title
                Label titleLabel = CreateLabelPatient("Dental Patient Report", 16, true, xStart, yStart);
                panelReport.Controls.Add(titleLabel);
                yStart += lineHeight * 2;

                // Month
                Label monthLabel = CreateLabelPatient(reportMonth, 12, false, xStart, yStart);
                panelReport.Controls.Add(monthLabel);
                yStart += lineHeight * 2;

                // Patient Name
                Label patientNameLabel = CreateLabelPatient($"Patient Name: {patientName}", 12, false, xStart, yStart);
                panelReport.Controls.Add(patientNameLabel);
                yStart += lineHeight;

                // Total Appointments
                Label totalApptLabel = CreateLabelPatient($"Total Appointment: {totalAppointments}", 12, false, xStart, yStart);
                panelReport.Controls.Add(totalApptLabel);
                yStart += lineHeight * 2;

                // Clinic History Header
                Label clinicHistoryHeaderLabel = CreateLabelPatient("Clinic History", 14, true, xStart, yStart);
                panelReport.Controls.Add(clinicHistoryHeaderLabel);
                yStart += lineHeight;

                tableYStart += 90;

                // Table Headers
                Label dateHeaderLabel = CreateLabelPatient("Date", 12, true, tableXStart, tableYStart);
                panelReport.Controls.Add(dateHeaderLabel);

                Label dentistNameHeaderLabel = CreateLabelPatient("Dentist Name", 12, true, tableXStart + columnWidth1, tableYStart);
                panelReport.Controls.Add(dentistNameHeaderLabel);

                Label servicesHeaderLabel = CreateLabelPatient("Services", 12, true, tableXStart + columnWidth1 + columnWidth2, tableYStart);
                panelReport.Controls.Add(servicesHeaderLabel);

                Label feeHeaderLabel = CreateLabelPatient("Fee", 12, true, tableXStart + columnWidth1 + columnWidth2 + columnWidth3, tableYStart);
                panelReport.Controls.Add(feeHeaderLabel);

                tableYStart += lineHeight;

                // Table Data
                if (clinicHistory != null && clinicHistory.Count > 0)
                {
                    foreach (var historyItem in clinicHistory)
                    {
                        Label dateLabel = CreateLabelPatient(historyItem.Date.ToShortDateString(), 12, false, tableXStart, tableYStart);
                        panelReport.Controls.Add(dateLabel);

                        Label dentistNameLabel = CreateLabelPatient(historyItem.DentistName, 12, false, tableXStart + columnWidth1, tableYStart);
                        panelReport.Controls.Add(dentistNameLabel);

                        Label servicesLabel = CreateLabelPatient(historyItem.Services, 12, false, tableXStart + columnWidth1 + columnWidth2, tableYStart);
                        panelReport.Controls.Add(servicesLabel);

                        Label feeLabel = CreateLabelPatient(historyItem.Fee.ToString("N2"), 12, false, tableXStart + columnWidth1 + columnWidth2 + columnWidth3, tableYStart);
                        panelReport.Controls.Add(feeLabel);

                        tableYStart += lineHeight;
                    }
                }
                else
                {
                    Label noHistoryLabel = CreateLabelPatient("No clinic history found for this patient.", 12, false, tableXStart, tableYStart);
                    panelReport.Controls.Add(noHistoryLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }

        }

        private class ClinicHistoryItem
        {
            public DateTime Date { get; set; }
            public string DentistName { get; set; }
            public string Services { get; set; }
            public decimal Fee { get; set; }
        }

        private List<ClinicHistoryItem> GetPatientClinicHistoryFromView(int patientId)
        {
            // Replace with your actual database connection and query
            string connectionString = Config.ConnectionString;
            List<ClinicHistoryItem> history = new List<ClinicHistoryItem>();

            int selectedMonth = comboBoxMonthDate.SelectedIndex + 1; // ComboBox is 0-based
            int selectedYear = int.Parse(comboBoxYearDate.SelectedItem.ToString());


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        date,
                        FullName AS DentistName,
                        services_name AS Services,
                        price AS Fee
                    FROM view_appointment_services
                    WHERE patient_id = @PatientId
                      AND MONTH(date) = @SelectedMonth
                      AND YEAR(date) = @SelectedYear";// Using patient_id from the view

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", patientId);
                        command.Parameters.AddWithValue("@SelectedMonth", selectedMonth);
                        command.Parameters.AddWithValue("@SelectedYear", selectedYear);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClinicHistoryItem item = new ClinicHistoryItem();
                                item.Date = (DateTime)reader["date"];
                                item.DentistName = reader["DentistName"].ToString();
                                item.Services = reader["Services"].ToString();
                                item.Fee = Convert.ToDecimal(reader["Fee"]); // Ensure correct conversion
                                history.Add(item);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return history;
        }

        private Label CreateLabelPatient(string text, int fontSize, bool bold, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Arial", fontSize, bold ? FontStyle.Bold : FontStyle.Regular);
            label.AutoSize = true;
            label.Location = new Point(x, y);
            return label;
        }

        public void generatePatientReportPDF(int patientId)
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 12);
                XFont headerFont = new XFont("Arial", 14);

                // Data for the report (replace with your actual data retrieval logic)
                string reportMonth = comboBoxMonthDate.SelectedItem.ToString() + " " + int.Parse(comboBoxYearDate.SelectedItem.ToString());
                string patientName;
                int totalAppointments;

                GetPatientAppointmentInfo(patientId, out totalAppointments, out patientName);

                // Clinic History Data (Retrieve from view_appointment_services)
                List<ClinicHistoryItem> clinicHistory = GetPatientClinicHistoryFromView(patientId);

                // Layout parameters (adjust as needed)
                int xStart = 50;
                int yStart = 50;
                int lineHeight = 20;
                int tableXStart = 50;
                int tableYStart = yStart + 100;
                int columnWidth1 = 100;
                int columnWidth2 = 150;
                int columnWidth3 = 80;

                try
                {
                    // Report Title
                    gfx.DrawString("Dental Patient Report", headerFont, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopCenter);
                    yStart += lineHeight * 2;

                    // Month
                    gfx.DrawString(reportMonth, font, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopCenter);
                    yStart += lineHeight * 2;

                    // Patient Name
                    gfx.DrawString($"Patient Name: {patientName}", font, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopLeft);
                    yStart += lineHeight;

                    // Total Appointments
                    gfx.DrawString($"Total Appointment: {totalAppointments}", font, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopLeft);
                    yStart += lineHeight * 2;

                    // Clinic History Header
                    gfx.DrawString("Clinic History", headerFont, XBrushes.Black, new XRect(xStart, yStart, page.Width - xStart * 2, 20), XStringFormats.TopLeft);
                    yStart += lineHeight;

                    tableYStart += 90;

                    // Table Headers
                    gfx.DrawString("Date", headerFont, XBrushes.Black, new XRect(tableXStart, tableYStart, columnWidth1, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Dentist Name", headerFont, XBrushes.Black, new XRect(tableXStart + columnWidth1, tableYStart, columnWidth2, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Services", headerFont, XBrushes.Black, new XRect(tableXStart + columnWidth1 + columnWidth2, tableYStart, columnWidth3, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Fee", headerFont, XBrushes.Black, new XRect(tableXStart + columnWidth1 + columnWidth2 + columnWidth3, tableYStart, columnWidth3, 20), XStringFormats.TopLeft);

                    tableYStart += lineHeight;

                    // Table Data
                    if (clinicHistory != null && clinicHistory.Count > 0)
                    {
                        foreach (var historyItem in clinicHistory)
                        {
                            gfx.DrawString(historyItem.Date.ToShortDateString(), font, XBrushes.Black, new XRect(tableXStart, tableYStart, columnWidth1, 20), XStringFormats.TopLeft);
                            gfx.DrawString(historyItem.DentistName, font, XBrushes.Black, new XRect(tableXStart + columnWidth1, tableYStart, columnWidth2, 20), XStringFormats.TopLeft);
                            gfx.DrawString(historyItem.Services, font, XBrushes.Black, new XRect(tableXStart + columnWidth1 + columnWidth2, tableYStart, columnWidth3, 20), XStringFormats.TopLeft);
                            gfx.DrawString(historyItem.Fee.ToString("N2"), font, XBrushes.Black, new XRect(tableXStart + columnWidth1 + columnWidth2 + columnWidth3, tableYStart, columnWidth3, 20), XStringFormats.TopLeft);
                            tableYStart += lineHeight;
                        }
                    }
                    else
                    {
                        gfx.DrawString("No clinic history found for this patient.", font, XBrushes.Black, new XRect(tableXStart, tableYStart, page.Width - tableXStart * 2, 20), XStringFormats.TopLeft);
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save PDF Report";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        document.Save(saveFileDialog.FileName);
                        MessageBox.Show("PDF report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating report: " + ex.Message);
                }
            }
        }







    }
}
