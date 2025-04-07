using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Dental.Forms
{
    partial class Patients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dentalDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet = new Dental.DentalDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.patientsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet2 = new Dental.DentalDataSet2();
            this.patientsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.patientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.add_patient_btn = new System.Windows.Forms.Button();
            this.patientsTableAdapter = new Dental.DentalDataSet2TableAdapters.PatientsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dentalDataSet12 = new Dental.DentalDataSet12();
            this.patientsBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.patientsTableAdapter1 = new Dental.DentalDataSet12TableAdapters.PatientsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patients";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(780, 9);
            this.exit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(18, 18);
            this.exit.TabIndex = 18;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 41);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 4;
            // 
            // dentalDataSetBindingSource
            // 
            this.dentalDataSetBindingSource.DataSource = this.dentalDataSet;
            this.dentalDataSetBindingSource.Position = 0;
            // 
            // dentalDataSet
            // 
            this.dentalDataSet.DataSetName = "DentalDataSet";
            this.dentalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.ageDataGridViewTextBoxColumn,
            this.insurance});
            this.dataGridView1.DataSource = this.patientsBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(0, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(798, 437);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // patientsBindingSource2
            // 
            this.patientsBindingSource2.DataMember = "Patients";
            this.patientsBindingSource2.DataSource = this.dentalDataSet2;
            // 
            // dentalDataSet2
            // 
            this.dentalDataSet2.DataSetName = "DentalDataSet2";
            this.dentalDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // add_patient_btn
            // 
            this.add_patient_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.add_patient_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_patient_btn.FlatAppearance.BorderSize = 0;
            this.add_patient_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.add_patient_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.add_patient_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_patient_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_patient_btn.ForeColor = System.Drawing.Color.White;
            this.add_patient_btn.Location = new System.Drawing.Point(730, 47);
            this.add_patient_btn.Margin = new System.Windows.Forms.Padding(2);
            this.add_patient_btn.Name = "add_patient_btn";
            this.add_patient_btn.Size = new System.Drawing.Size(59, 34);
            this.add_patient_btn.TabIndex = 14;
            this.add_patient_btn.Text = "Add";
            this.add_patient_btn.UseVisualStyleBackColor = false;
            this.add_patient_btn.Click += new System.EventHandler(this.add_patient_btn_Click);
            this.add_patient_btn.Paint += new System.Windows.Forms.PaintEventHandler(this.patient_btn_Paint);
            // 
            // patientsTableAdapter
            // 
            this.patientsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 15;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 16;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dentalDataSet12
            // 
            this.dentalDataSet12.DataSetName = "DentalDataSet12";
            this.dentalDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientsBindingSource3
            // 
            this.patientsBindingSource3.DataMember = "Patients";
            this.patientsBindingSource3.DataSource = this.dentalDataSet12;
            // 
            // patientsTableAdapter1
            // 
            this.patientsTableAdapter1.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "first_name";
            this.dataGridViewTextBoxColumn1.HeaderText = "first_name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "last_name";
            this.dataGridViewTextBoxColumn2.HeaderText = "last_name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "address";
            this.dataGridViewTextBoxColumn3.HeaderText = "address";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "phone";
            this.dataGridViewTextBoxColumn4.HeaderText = "phone";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "email";
            this.dataGridViewTextBoxColumn5.HeaderText = "email";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DOB";
            this.dataGridViewTextBoxColumn6.HeaderText = "DOB";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "gender";
            this.dataGridViewTextBoxColumn7.HeaderText = "gender";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "created_At";
            this.dataGridViewTextBoxColumn8.HeaderText = "created_At";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // insurance
            // 
            this.insurance.DataPropertyName = "insurance";
            this.insurance.HeaderText = "insurance";
            this.insurance.Name = "insurance";
            this.insurance.Width = 5;
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.add_patient_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Patients";
            this.Text = "Patients";
            this.Load += new System.EventHandler(this.Patients_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void add_btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(btn.Parent.BackColor);
            using (Brush brush = new SolidBrush(btn.BackColor))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, btn.Height, btn.Height, 70, 160);
                    path.AddArc(btn.Width - btn.Height, 0, btn.Height, btn.Height, 250, 160);
                    path.CloseFigure();
                    g.FillPath(brush, path);
                }
            }
            TextRenderer.DrawText(g, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void patient_btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(btn.Parent.BackColor);
            using (Brush brush = new SolidBrush(btn.BackColor))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, btn.Height, btn.Height, 90, 180);
                    path.AddArc(btn.Width - btn.Height, 0, btn.Height, btn.Height, 270, 180);
                    path.CloseFigure();
                    g.FillPath(brush, path);
                }
            }
            TextRenderer.DrawText(g, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource dentalDataSetBindingSource;
        private DentalDataSet dentalDataSet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource patientsBindingSource;
        private System.Windows.Forms.Button add_patient_btn;
        private BindingSource patientsBindingSource1;
        private DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dOBDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private DentalDataSet2 dentalDataSet2;
        private BindingSource patientsBindingSource2;
        private DentalDataSet2TableAdapters.PatientsTableAdapter patientsTableAdapter;
        private Button button1;
        private Button button2;
        private DentalDataSet12 dentalDataSet12;
        private BindingSource patientsBindingSource3;
        private DentalDataSet12TableAdapters.PatientsTableAdapter patientsTableAdapter1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn insurance;
    }
}