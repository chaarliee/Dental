using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dental.Model;
using System.Data.SqlClient;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.UniversalAccessibility.Drawing;
using System.Net.Mail;
using System.Net;

namespace Dental.Forms.Dialogs
{
    public partial class EditBilling: UserControl
    {

        public event EventHandler BillingEdited;

        public string connectionString = Config.ConnectionString;
        public int fetched_appointment_id { get; set; }

        public int totalServices;

        public int service_counter = 1;

        public string current_status;

        public string patient_email;



        public EditBilling()
        {
            InitializeComponent();
        }

        private void EditBilling_Load(object sender, EventArgs e)
        {
            LoadServices(fetched_appointment_id);

            calculateTotal();

            refreshServices(connectionString, fetched_appointment_id);
            getAppointmentDetails();

        }

        public void getAppointmentDetails()
        {
            string query = "SELECT * FROM vw_AppointmentFullDetails WHERE Id = @appointment_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@appointment_id", fetched_appointment_id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Handle status-related UI logic
                            current_status = reader["status"].ToString();
                            if (current_status == "Finished")
                            {
                                btnSave.Text = "Print";
                                btnCancel.Visible = false;
                            }

                            // ✅ Set labels from view
                            label_patient.Text = reader["PatientFirstName"].ToString();
                            label_dentist.Text = reader["DentistName"].ToString();
                            label_date.Text = Convert.ToDateTime(reader["date"]).ToString("yyyy-MM-dd");
                            label_time.Text = TimeSpan.Parse(reader["time"].ToString()).ToString(@"hh\:mm");
                            label_status.Text = reader["status"].ToString();

                            patient_email = reader["PatientEmail"].ToString();

                            // Optional: load more data like reason, phone, email, etc.
                            // label_email.Text = reader["PatientEmail"].ToString();
                            // label_phone.Text = reader["PatientPhone"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the appointment details: " + ex.Message);
                }
            }
        }


        public void LoadServices(int appointment_id)
        {
            panelServicesEdit.Controls.Clear();

           

            // 1. Fill Panel with Controls and Empty Combo Data
            //FillPanelWithControls(connectionString);

            // 2. Set Control Data from DB
            SetControlDataFromDB(connectionString, appointment_id);
        }

        private void SetControlDataFromDB(string connectionString, int appointment_id)
        {
            string query = "SELECT * FROM appointment_services WHERE appointment_id = @appointment_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@appointment_id", appointment_id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int yOffset = 0;
                        int rowIndex = 0;

                        while (reader.Read())
                        {
                            int serviceId = Convert.ToInt32(reader["services_id"]);

                            // 🧠 Fetch service fee and fixed flag
                            decimal serviceFee = 0;
                            bool isFixed = false;
                            GetServiceFeeAndFixed(serviceId, out serviceFee, out isFixed);

                            // 👇 Create controls
                            ComboBox comboBoxService = new ComboBox
                            {
                                Location = new Point(0, yOffset),
                                Size = new Size(125, 21),
                                DataSource = GetDynamicDataSource(),
                                DisplayMember = "services_name",
                                ValueMember = "Id",
                                Name = "servicecombobox_" + rowIndex
                            };
                            comboBoxService.SelectedValue = serviceId;

                            NumericUpDown numericUpDownQty = new NumericUpDown
                            {
                                Location = new Point(132, yOffset),
                                Size = new Size(66, 20),
                                Name = "servicequantity_" + rowIndex,
                                Value = Convert.ToDecimal(reader["quantity"]),
                                Enabled = !isFixed // disable if fixed
                            };

                            TextBox textBoxPrice = new TextBox
                            {
                                Location = new Point(203, yOffset),
                                Size = new Size(100, 20),
                                Name = "serviceprice_" + rowIndex,
                                Text = serviceFee.ToString(),
                            };

                            Button button = new Button
                            {
                                Location = new Point(308, yOffset),
                                Size = new Size(25, 23),
                                Name = "btnclose_" + rowIndex,
                                Text = "X",
                                Tag = service_counter
                                //Name = "serviceprice_" + service_counter,

                            };

                            button.Click += RemoveServiceRow_Click;


                            // 👇 Add controls
                            panelServicesEdit.Controls.Add(comboBoxService);
                            panelServicesEdit.Controls.Add(numericUpDownQty);
                            panelServicesEdit.Controls.Add(textBoxPrice);
                            panelServicesEdit.Controls.Add(button);

                            yOffset += 30;
                            rowIndex++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the services: " + ex.Message);
                }
            }
        }

        private void RemoveServiceRow_Click(object sender, EventArgs e)
        {
            Button closeButton = sender as Button;
            if (closeButton?.Tag == null) return;

            string index = closeButton.Tag.ToString();
            List<Control> controlsToRemove = new List<Control>();

            // Gather all controls with the same suffix index
            foreach (Control ctrl in panelServicesEdit.Controls)
            {
                if (ctrl.Name.EndsWith("_" + index))
                {
                    controlsToRemove.Add(ctrl);
                }
            }

            // Remove them from the panel
            foreach (var ctrl in controlsToRemove)
            {
                panelServicesEdit.Controls.Remove(ctrl);
                ctrl.Dispose(); // Free memory
            }

            // Repack remaining controls vertically
            RepackServiceRows();
        }

        private void RepackServiceRows()
        {
            int yOffset = 0;
            int newIndex = 0;

            // Get all control sets by index
            var grouped = panelServicesEdit.Controls
                .Cast<Control>()
                .GroupBy(ctrl => ctrl.Name.Split('_').Last())
                .ToList();

            panelServicesEdit.Controls.Clear(); // Clear old layout

            foreach (var group in grouped.OrderBy(g => g.First().Location.Y))
            {
                // Recreate controls with new index and layout
                ComboBox comboBox = group.OfType<ComboBox>().FirstOrDefault();
                NumericUpDown qty = group.OfType<NumericUpDown>().FirstOrDefault();
                TextBox price = group.OfType<TextBox>().FirstOrDefault();
                Button closeBtn = group.OfType<Button>().FirstOrDefault();

                if (comboBox != null)
                {
                    comboBox.Location = new Point(0, yOffset);
                    comboBox.Name = "servicecombobox_" + newIndex;
                    panelServicesEdit.Controls.Add(comboBox);
                }

                if (qty != null)
                {
                    qty.Location = new Point(132, yOffset);
                    qty.Name = "servicequantity_" + newIndex;
                    panelServicesEdit.Controls.Add(qty);
                }

                if (price != null)
                {
                    price.Location = new Point(203, yOffset);
                    price.Name = "serviceprice_" + newIndex;
                    panelServicesEdit.Controls.Add(price);
                }

                if (closeBtn != null)
                {
                    closeBtn.Location = new Point(308, yOffset);
                    closeBtn.Name = "btnclose_" + newIndex;
                    closeBtn.Tag = newIndex;
                    panelServicesEdit.Controls.Add(closeBtn);
                }

                yOffset += 30;
                newIndex++;
            }

            service_counter = newIndex; // Keep counter accurate
        }



        private void GetServiceFeeAndFixed(int serviceId, out decimal fee, out bool isFixed)
        {
            fee = 0;
            isFixed = false;

            string query = "SELECT fees, fixed FROM services WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", serviceId);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fee = Convert.ToDecimal(reader["fees"]);
                            isFixed = Convert.ToBoolean(reader["fixed"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching service info: " + ex.Message);
                }
            }
        }


        private DataTable GetDynamicDataSource()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, services_name FROM services";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }


        public void calculateTotal()
        {

            decimal total_price = 0;
            decimal quantity = 0;
            decimal price = 0;
            decimal discount = 0;

            if (checkBox_discount.Checked)
            {
                discount = 0.10M;
            }
            else
            {
                discount = 0;

            }


            foreach (Control control in panelServicesEdit.Controls)
            {


                if (control is NumericUpDown)
                {
                    NumericUpDown numericUpDownQty = (NumericUpDown)control;
                    if (!string.IsNullOrEmpty(numericUpDownQty.Text))
                    {
                        quantity = decimal.Parse(numericUpDownQty.Text);
                    }
                    else
                    {
                        quantity = 0;
                    }
                }

                if (control is TextBox)
                {
                    TextBox textBoxPrice = (TextBox)control;
                    if (!string.IsNullOrEmpty(textBoxPrice.Text))
                    {
                        price = decimal.Parse(textBoxPrice.Text);
                    }
                    else
                    {
                        price = 0;
                    }


                    decimal itemTotal = price * quantity;
                    decimal itemDiscount = itemTotal * discount;
                    decimal discountedItemTotal = itemTotal - itemDiscount;

                    total_price += discountedItemTotal;
                    //total_price += price * quantity;


                    Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);
                    System.Console.WriteLine("count: " + price + " * " + quantity + " = " + total_price);


                }



            }
            total_textbox.Text = total_price.ToString();


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

        public enum XFontStyleee
        {
            Regular = 0,
            Bold = 1,
            Italic = 2,
            BoldItalic = 3
        }

        public (string patientName, string address, string age, string date, string contact, string subtotal, string discount, string totalDue) GetAppointmentSummary(int fetched_appointment_id)
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT PatientFirstName, address, age, Date, PatientPhone, total, discount, has_discount FROM vw_AppointmentFullDetails WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", fetched_appointment_id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string patientName = reader["PatientFirstName"].ToString();
                            string address = reader["address"].ToString();
                            string age = reader["age"].ToString();
                            string date = Convert.ToDateTime(reader["Date"]).ToString("MM-dd-yyyy");
                            string contact = reader["PatientPhone"].ToString();
                            string subtotal = Convert.ToDecimal(reader["total"]).ToString("0.00");
                            string discount = reader["has_discount"].ToString() == "Yes" ? "10%" : "0%";

                            // Calculate totalDue (if discount is applied)
                            decimal total = Convert.ToDecimal(reader["total"]);
                            decimal totalDue = discount == "10%" ? total * 0.90m : total;

                            return (patientName, address, age, date, contact, subtotal, discount, totalDue.ToString("0.00"));
                        }
                        else
                        {
                            MessageBox.Show("Appointment not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching appointment details: " + ex.Message);
                }
            }

            // Return defaults if failed
            return ("", "", "", "", "", "", "", "");
        }

        public (string applicationName, string address, string phone) GetClinicInfo()
        {
            string connectionString = Config.ConnectionString;
            string query = "SELECT TOP 1 application_name, address, phone FROM Settings";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string appName = reader["application_name"].ToString();
                            string clinicAddress = reader["address"].ToString();
                            string phone = reader["phone"].ToString();

                            return (appName, clinicAddress, phone);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching clinic info: " + ex.Message);
                }
            }

            // Return default empty strings if failed
            return ("", "", "");
        }

        public void GetDataForServiceReport( out string[] services, out int[] quantities, out decimal[] totals)
        {
            string connectionString = Config.ConnectionString;
            List<string> servicesList = new List<string>();
            List<int> quantitiesList = new List<int>();
            List<decimal> totalsList = new List<decimal>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = @"
                SELECT 
                    services_name,
                    quantity,
                    price
                FROM view_appointment_services
                WHERE appointment_id = @AppointmentID";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", fetched_appointment_id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                servicesList.Add(reader["services_name"].ToString());
                                quantitiesList.Add(Convert.ToInt32(reader["quantity"]));
                                totalsList.Add(Convert.ToDecimal(reader["price"]));
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
                services = new string[0];
                quantities = new int[0];
                totals = new decimal[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                services = new string[0];
                quantities = new int[0];
                totals = new decimal[0];
            }
        }






        public void printBilling() {
            // Dummy data (replace with actual variables or pull from DB/UI)

            var details = GetAppointmentSummary(fetched_appointment_id);
            var clinicInfo = GetClinicInfo();

            string processBY = Form1.GlobalVariables.LoggedInName ?? "-";


            string patientName = details.patientName;
            string address = details.address;
            string age = details.age;
            string date = details.date;
            string contact = clinicInfo.phone;
            string subtotal = details.subtotal;
            string discount = details.discount;
            string totalDue = details.totalDue;

            string[] services;
            int[] quantities;
            decimal[] totals;

            GetDataForServiceReport(out services, out quantities, out totals);

            //        var services = new List<(string Desc, int Qty, decimal Price, decimal Total)>
            //{
            //    ("Extraction", 1, 200, 200),
            //    ("Cleaning", 2, 500, 1000)
            //};

            // Create PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Billing Receipt";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont headerFont = new XFont("Arial", 18);
            XFont subHeaderFont = new XFont("Arial", 10);
            XFont boldFont = new XFont("Arial", 10);
            XFont normalFont = new XFont("Arial", 10);



            double y = 40;
            double left = 40;

            // Clinic Info
            gfx.DrawString(clinicInfo.applicationName, headerFont, XBrushes.Black, new XPoint(left, y));
            y += 25;
            gfx.DrawString("Cebu Business Hotel Cor. Junquera Street, Colon, Cebu City, Philippines", normalFont, XBrushes.Black, new XPoint(left, y));
            y += 20;
            gfx.DrawString($"Contact: {contact}", normalFont, XBrushes.Black, new XPoint(left, y));
            y += 20;
            gfx.DrawLine(XPens.Black, left, y, 550, y);
            y += 20;

            // Patient Info
            gfx.DrawString("Patient:", boldFont, XBrushes.Black, new XPoint(left, y));
            gfx.DrawString(patientName, normalFont, XBrushes.Black, new XPoint(left + 60, y));

            gfx.DrawString("Age:", boldFont, XBrushes.Black, new XPoint(300, y));
            gfx.DrawString(age, normalFont, XBrushes.Black, new XPoint(340, y));
            y += 20;

            gfx.DrawString("Address:", boldFont, XBrushes.Black, new XPoint(left, y));
            gfx.DrawString(address, normalFont, XBrushes.Black, new XPoint(left + 60, y));

            gfx.DrawString("Date:", boldFont, XBrushes.Black, new XPoint(300, y));
            gfx.DrawString(date, normalFont, XBrushes.Black, new XPoint(340, y));
            y += 30;

            // Services Header
            gfx.DrawString("Services Rendered", headerFont, XBrushes.Black, new XPoint(left, y));
            y += 25;

            // Table headers
            gfx.DrawString("Description", boldFont, XBrushes.Black, new XPoint(left, y));
            gfx.DrawString("Qty", boldFont, XBrushes.Black, new XPoint(left + 200, y));
            gfx.DrawString("Unit Price", boldFont, XBrushes.Black, new XPoint(left + 260, y));
            gfx.DrawString("Total", boldFont, XBrushes.Black, new XPoint(left + 360, y));
            y += 20;

            // Service rows
            //foreach (var item in services)
            //{
            //    gfx.DrawString(item.Desc, normalFont, XBrushes.Black, new XPoint(left, y));
            //    gfx.DrawString(item.Qty.ToString(), normalFont, XBrushes.Black, new XPoint(left + 200, y));
            //    gfx.DrawString(item.Price.ToString("0.00"), normalFont, XBrushes.Black, new XPoint(left + 260, y));
            //    gfx.DrawString(item.Total.ToString("0.00"), normalFont, XBrushes.Black, new XPoint(left + 360, y));
            //    y += 18;
            //}
            if (services != null && services.Length > 0)
            {
                for (int i = 0; i < services.Length; i++)
                {
                    gfx.DrawString(services[i], normalFont, XBrushes.Black, new XPoint(left, y));
                    gfx.DrawString($"x{quantities[i]}", normalFont, XBrushes.Black, new XPoint(left + 200, y));
                    gfx.DrawString(totals[i].ToString("N2"), normalFont, XBrushes.Black, new XPoint(left + 260, y));

                    int totalprice = quantities[i] * (int)totals[i];

                     gfx.DrawString(totalprice.ToString(), normalFont, XBrushes.Black, new XPoint(left + 360, y));
                    //
                    y += 18;
                   
                }
            }
            else
            {
                gfx.DrawString("No service data found.", normalFont, XBrushes.Black, new XPoint(left + 260, y));
            }


            y += 20;
            gfx.DrawString("Subtotal:", boldFont, XBrushes.Black, new XPoint(left, y));
            gfx.DrawString(subtotal, normalFont, XBrushes.Black, new XPoint(left + 100, y));
            y += 18;

            gfx.DrawString("Discount:", boldFont, XBrushes.Black, new XPoint(left, y));
            gfx.DrawString(discount, normalFont, XBrushes.Black, new XPoint(left + 100, y));
            y += 18;

            gfx.DrawString("Total Amount Due:", boldFont, XBrushes.Black, new XPoint(left, y));
            gfx.DrawString(totalDue, normalFont, XBrushes.Black, new XPoint(left + 130, y));
            y += 40;

            gfx.DrawString("Proccessed By:", boldFont, XBrushes.Black, new XPoint(left, y));
            gfx.DrawString(processBY, normalFont, XBrushes.Black, new XPoint(left + 130, y));
            y += 40;
            // Footer
            gfx.DrawString("Thank you for choosing Serrato Dental Clinic!", boldFont, XBrushes.Black, new XPoint(left, y));
            y += 20;
            gfx.DrawString("For Inquiries, please contact us at"+ clinicInfo.phone, normalFont, XBrushes.Black, new XPoint(left, y));

            // Save
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BillingReceipt.pdf");
            document.Save(filePath);
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (current_status == "Finished")
            {
                printBilling();
            }
            else {

                if (!Paid.Checked && !Unpaid.Checked)
                {
                    MessageBox.Show("Please select whether the payment is Paid or Unpaid before proceeding.");
                    return;
                }

                int appointmentId = fetched_appointment_id;

                if (appointmentId > 0)
                {
                    string connectionString = Config.ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlTransaction transaction = null;

                        try
                        {
                            connection.Open();
                            transaction = connection.BeginTransaction();

                            // Prepare discount flags
                            string hasDiscount = checkBox_discount.Checked ? "Yes" : "No";
                            decimal total = 0;

                            if (!decimal.TryParse(total_textbox.Text, out total))
                            {
                                MessageBox.Show("Invalid total amount.");
                                return;
                            }

                            // Update Appointments
                            string updateAppointmentQuery = @"
                                UPDATE Appointments 
                                SET status = 'Finished', 
                                    total = @total, 
                                    has_discount = @has_discount 
                                WHERE id = @AppointmentID";

                            using (SqlCommand appointmentCommand = new SqlCommand(updateAppointmentQuery, connection, transaction))
                            {
                                appointmentCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);
                                appointmentCommand.Parameters.AddWithValue("@total", total);
                                appointmentCommand.Parameters.AddWithValue("@has_discount", hasDiscount);
                                MessageBox.Show("appointment_services delete." + appointmentId + "-" + total + "-" + hasDiscount);

                                int rowsAffected = appointmentCommand.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("Appointment not found.");
                                    transaction.Rollback();
                                    return;
                                }
                            }

                            string deleteQuery = "DELETE FROM appointment_services WHERE appointment_id = @AppointmentID";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                                int rowsDeleted = deleteCmd.ExecuteNonQuery();
                                MessageBox.Show($"Deleted {rowsDeleted} service rows for appointment ID: {appointmentId}");
                            }

                            // Insert new rows
                            string insertQuery = @"INSERT INTO appointment_services 
                                    (appointment_id, services_id, quantity, price, status, created_At) 
                                    VALUES (@appointment_id, @services_id, @quantity, @price, @status, @created_At)";

                            // Count inserted rows for confirmation
                            int insertCount = 0;

                            // Loop through only ComboBoxes
                            foreach (Control control in panelServicesEdit.Controls.OfType<ComboBox>())
                            {
                                string index = control.Name.Split('_').Last();

                                ComboBox serviceBox = control as ComboBox;
                                NumericUpDown qtyBox = panelServicesEdit.Controls.Find($"servicequantity_{index}", false).FirstOrDefault() as NumericUpDown
                                                      ?? panelServicesEdit.Controls.Find($"Dservicequantity_{index}", false).FirstOrDefault() as NumericUpDown;

                                TextBox priceBox = panelServicesEdit.Controls.Find($"serviceprice_{index}", false).FirstOrDefault() as TextBox
                                                 ?? panelServicesEdit.Controls.Find($"Dserviceprice_{index}", false).FirstOrDefault() as TextBox;

                                if (serviceBox?.SelectedValue != null && qtyBox != null && priceBox != null)
                                {
                                    try
                                    {
                                        int serviceId = Convert.ToInt32(serviceBox.SelectedValue);
                                        int quantity = (int)qtyBox.Value;
                                        decimal price = 0;
                                        decimal.TryParse(priceBox.Text, out price);

                                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection, transaction))
                                        {
                                            insertCmd.Parameters.AddWithValue("@appointment_id", appointmentId);
                                            insertCmd.Parameters.AddWithValue("@services_id", serviceId);
                                            insertCmd.Parameters.AddWithValue("@quantity", quantity);
                                            insertCmd.Parameters.AddWithValue("@price", price);
                                            insertCmd.Parameters.AddWithValue("@status", Paid.Checked ? "Paid" : "Unpaid");
                                            insertCmd.Parameters.AddWithValue("@created_At", DateTime.Now);

                                            insertCmd.ExecuteNonQuery();
                                            insertCount++;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Error inserting service: {ex.Message}");
                                    }
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show($"Updated appointment. {insertCount} service rows inserted.");
                            SendConfirmationEmail(patient_email);
                            CloseControl();
                        }
                        catch (Exception ex)
                        {
                            transaction?.Rollback();
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Appointment ID.");
                }
            }
                
            
            
        }

        private void SendConfirmationEmail(string recipientEmail)
        {
            try
            {
                string feedbackFormLink = "https://docs.google.com/forms/d/e/1FAIpQLSda9jDMS6HcqcR0_MRUWCCruFv0-pwgMD4VbKFX30EGcZRltw/viewform?usp=header"; // Replace with your actual Google Form link

                string subject = "We value your feedback - Serrato Dental Clinic";
                string body = $"Dear Patient,\n\nThank you for visiting Serrato Dental Clinic.\nWe would appreciate it if you could take a moment to provide feedback on your recent appointment.\n\nPlease click the link below to complete our short feedback form:\n{feedbackFormLink}\n\nThank you!\n\n- Serrato Dental Clinic";

                string senderEmail = Config.Email_Sender;
                string senderPassword = Config.Email_Password;
                string smtpHost = Config.Email_SMTP;
                int smtpPort = Config.Email_PORT;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(senderEmail);
                mailMessage.To.Add(recipientEmail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = false;

                SmtpClient smtpClient = new SmtpClient
                {
                    Host = smtpHost,
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true
                };

                smtpClient.Send(mailMessage);
                Console.WriteLine($"Feedback form sent to {recipientEmail}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send feedback form: " + ex.Message);
            }
        }


        private void button_total_Click(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = Config.ConnectionString; // Replace with your actual connection string

            refreshServices(connectionString, fetched_appointment_id);

            calculateTotal();
        }

        private void refreshServices(string connectionString, int appointment_id)
        {
            string query = "SELECT * FROM appointment_services WHERE appointment_id = @appointment_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@appointment_id", appointment_id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int yOffset = 0;
                        int rowIndex = 0;
                        while (reader.Read())
                        {
                            int serviceId = Convert.ToInt32(reader["services_id"]);

                            // 🔄 Fetch current fee and fixed status from services table
                            decimal fee;
                            bool isFixed;
                            GetServiceFeeAndFixed(serviceId, out fee, out isFixed);

                            ComboBox comboBox = (ComboBox)panelServicesEdit.Controls["servicecombobox_" + rowIndex];
                            if (comboBox != null)
                            {
                                comboBox.SelectedValue = serviceId;
                            }

                            NumericUpDown numericUPdown = (NumericUpDown)panelServicesEdit.Controls["servicequantity_" + rowIndex];
                            if (numericUPdown != null)
                            {
                                numericUPdown.Value = Convert.ToDecimal(reader["quantity"]);
                                numericUPdown.Enabled = !isFixed; // 🔐 Disable if fixed
                            }

                            TextBox textBox = (TextBox)panelServicesEdit.Controls["serviceprice_" + rowIndex];
                            if (textBox != null)
                            {
                                textBox.Text = fee.ToString("0.00");
                            }

                            yOffset += 30;
                            rowIndex++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the services: " + ex.Message);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddServiceRow();
        }

        private void AddServiceRow()
        {

            System.Console.WriteLine("count: " + panelServicesEdit.Controls.Count / 4);

            if (panelServicesEdit.Controls.Count / 4 >= 5)
            {
                MessageBox.Show("You have reached the required number of services.");
            }
            else
            {
                int yOffset = panelServicesEdit.Controls.Count / 4 * 30;

                ComboBox comboBoxService = new ComboBox
                {
                    Location = new Point(0, yOffset),
                    Size = new Size(125, 21),
                    DataSource = GetDynamicDataSource(),
                    //DataSource = comboBox1Services.DataSource,
                    DisplayMember = "services_name",
                    ValueMember = "Id",
                    Name = "servicecombobox_" + service_counter
                };

           

                NumericUpDown numericUpDownQty = new NumericUpDown
                {
                    Location = new Point(132, yOffset),
                    Size = new Size(66, 20),
                    //Name = "servicequantity_" + service_counter
                     Name = "servicequantity_" + service_counter
                    
                };

                TextBox textBoxPrice = new TextBox
                {
                    Location = new Point(203, yOffset),
                    Size = new Size(100, 20),
                    Name = "serviceprice_" + service_counter,
                    //Name = "serviceprice_" + service_counter,

                };

                Button button1 = new Button
                {
                    Location = new Point(308, yOffset),
                    Size = new Size(25, 23),
                    Name = "btnclose_" + service_counter,
                    Text = "X",
                    Tag = service_counter
                    //Name = "serviceprice_" + service_counter,

                };

                button1.Click += RemoveServiceRow_Click;







                panelServicesEdit.Controls.Add(comboBoxService);
                panelServicesEdit.Controls.Add(numericUpDownQty);
                panelServicesEdit.Controls.Add(textBoxPrice);
                panelServicesEdit.Controls.Add(button1);

                comboBoxService.SelectedIndexChanged += comboBoxService_SelectedIndexChanged;


                service_counter++;
            }// else

        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBox textBoxPrice = (TextBox)panelServicesEdit.Controls["Dserviceprice_" + comboBox.Name.Split('_')[1]];

            if (comboBox.SelectedValue != null)
            {
                int selectedServiceId = (int)comboBox.SelectedValue;
                string connectionString = Config.ConnectionString;
                string query = "SELECT fees FROM Services WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedServiceId);
                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                textBoxPrice.Text = result.ToString();
                            }
                            else
                            {
                                textBoxPrice.Text = "0"; // Or any default value you want
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error fetching fees: " + ex.Message);
                            textBoxPrice.Text = "0"; // Or any default value you want
                        }
                    }
                }
            }



        }

    }
}
