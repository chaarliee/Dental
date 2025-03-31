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
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 10);
            XFont titleFont = new XFont("Verdana", 12);

            // Define layout parameters (adjust these to fine-tune the appearance)
            double margin = 20;
            double tableTop = 100;
            double tableRowHeight = 20;
            double totalColumnWidth = 50; // Width for the number cells (44, 29, 15)
            double appointmentColumnX = margin; // X-coordinate for "Total Appointment"
            double appointmentLabelWidth = 80; // Width for "Total Patient" and "Completed"/"Cancelled" labels
            double serviceTableX = margin; // X-coordinate for the service table
            double serviceTableY = tableTop + tableRowHeight * 3; // Adjusted table position
            double totalRevenueX = margin;  // Adjusted Revenue position
            double totalRevenueY = serviceTableY + tableRowHeight * 6; // Adjusted Revenue position

            // Draw the title
            gfx.DrawString("Dental Services Report", titleFont, XBrushes.Black, margin, 50);

            // Draw the Total Appointment title
            gfx.DrawString("Total Appointment", font, XBrushes.Black, appointmentColumnX, tableTop);

            // Draw the table for Total Patient, Completed, Cancelled
            double appointmentTableY = tableTop + 5 + font.GetHeight(); // Position table below title
            gfx.DrawRectangle(XPens.Black, XBrushes.LightSteelBlue, appointmentColumnX, appointmentTableY, appointmentLabelWidth, tableRowHeight); // Total Patient label
            gfx.DrawRectangle(XPens.Black, XBrushes.LightSteelBlue, appointmentColumnX + appointmentLabelWidth, appointmentTableY, totalColumnWidth, tableRowHeight); // Total Patient value
            gfx.DrawRectangle(XPens.Black, XBrushes.LightSteelBlue, appointmentColumnX + appointmentLabelWidth + totalColumnWidth, appointmentTableY, appointmentLabelWidth, tableRowHeight); // Completed label
            gfx.DrawRectangle(XPens.Black, XBrushes.LightSteelBlue, appointmentColumnX + appointmentLabelWidth + totalColumnWidth + appointmentLabelWidth, appointmentTableY, totalColumnWidth, tableRowHeight); // Completed value
            gfx.DrawRectangle(XPens.Black, XBrushes.LightSteelBlue, appointmentColumnX + appointmentLabelWidth * 2 + totalColumnWidth * 2, appointmentTableY, appointmentLabelWidth, tableRowHeight); // Cancelled label
            gfx.DrawRectangle(XPens.Black, XBrushes.LightSteelBlue, appointmentColumnX + appointmentLabelWidth * 2 + totalColumnWidth * 2 + appointmentLabelWidth, appointmentTableY, totalColumnWidth, tableRowHeight); // Cancelled value

            // Draw header labels
            gfx.DrawString("Total Patient", font, XBrushes.Black, appointmentColumnX + 5, appointmentTableY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);
            gfx.DrawString("Completed", font, XBrushes.Black, appointmentColumnX + appointmentLabelWidth + totalColumnWidth + 5, appointmentTableY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);
            gfx.DrawString("Cancelled", font, XBrushes.Black, appointmentColumnX + appointmentLabelWidth * 2 + totalColumnWidth * 2 +5 , appointmentTableY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);

            // Draw the data
            gfx.DrawString(totalPatients.ToString(), font, XBrushes.Black, appointmentColumnX + appointmentLabelWidth + 5, appointmentTableY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);
            gfx.DrawString(completedAppointments.ToString(), font, XBrushes.Black, appointmentColumnX + appointmentLabelWidth + totalColumnWidth + appointmentLabelWidth + 5, appointmentTableY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);
            gfx.DrawString(canceledAppointments.ToString(), font, XBrushes.Black, appointmentColumnX + appointmentLabelWidth * 2 + totalColumnWidth * 2 + appointmentLabelWidth + 5, appointmentTableY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);

            // Draw service table headers
            double currentY = serviceTableY;
            gfx.DrawString("Services", font, XBrushes.Black, serviceTableX, currentY);
            gfx.DrawString("Quantity", font, XBrushes.Black, serviceTableX + totalColumnWidth+50, currentY);
            gfx.DrawString("Total", font, XBrushes.Black, serviceTableX + totalColumnWidth + 100, currentY);

            // Draw service table rows
            currentY += tableRowHeight;
            for (int i = 0; i < serviceDetails.Count; i++)
            {
                gfx.DrawRectangle(XPens.Black, XBrushes.LightGray, serviceTableX, currentY, totalColumnWidth * 2 + 150, tableRowHeight);

                // Calculate vertical position for service name (center in cell)
                double serviceNameY = currentY + (tableRowHeight - font.GetHeight()) / 2;
                gfx.DrawString(serviceDetails[i].ServiceName, font, XBrushes.Black, serviceTableX + 5, serviceNameY + font.GetHeight() / 2);

                // Calculate X position for quantity
                double quantityX = serviceTableX + totalColumnWidth + 50;
                gfx.DrawString("X" + serviceDetails[i].Quantity, font, XBrushes.Black, quantityX, currentY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);

                // Calculate X position for price
                double priceX = serviceTableX + totalColumnWidth + 100;
                gfx.DrawString("P" + serviceDetails[i].Price.ToString("#,##0"), font, XBrushes.Black, priceX, currentY + (tableRowHeight - font.GetHeight()) / 2 + font.GetHeight() / 2);

                currentY += tableRowHeight;
            }

            // Draw Total Revenue
            gfx.DrawString("Revenue: P" + totalRevenue.ToString("#,##0.00"), new XFont("Verdana", 14), XBrushes.Black, totalRevenueX, totalRevenueY+40);

            // Save the PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog.Title = "Save PDF Report";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
                MessageBox.Show("PDF report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
