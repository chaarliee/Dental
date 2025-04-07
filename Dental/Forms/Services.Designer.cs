namespace Dental.Forms
{
    partial class Services
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
            this.exit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.add_patient_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dentalDataSet7 = new Dental.DentalDataSet7();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.servicesTableAdapter = new Dental.DentalDataSet7TableAdapters.servicesTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dentalDataSet13 = new Dental.DentalDataSet13();
            this.servicesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.servicesTableAdapter1 = new Dental.DentalDataSet13TableAdapters.servicesTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource1)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Services";
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
            this.add_patient_btn.Location = new System.Drawing.Point(732, 48);
            this.add_patient_btn.Margin = new System.Windows.Forms.Padding(2);
            this.add_patient_btn.Name = "add_patient_btn";
            this.add_patient_btn.Size = new System.Drawing.Size(59, 34);
            this.add_patient_btn.TabIndex = 17;
            this.add_patient_btn.Text = "Add";
            this.add_patient_btn.UseVisualStyleBackColor = false;
            this.add_patient_btn.Click += new System.EventHandler(this.add_patient_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.servicesnameDataGridViewTextBoxColumn,
            this.feesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.servicesBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(7, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(798, 437);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataMember = "services";
            this.servicesBindingSource.DataSource = this.dentalDataSet7;
            // 
            // dentalDataSet7
            // 
            this.dentalDataSet7.DataSetName = "DentalDataSet7";
            this.dentalDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 15;
            // 
            // servicesTableAdapter
            // 
            this.servicesTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(641, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 20;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(184, 56);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 19;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dentalDataSet13
            // 
            this.dentalDataSet13.DataSetName = "DentalDataSet13";
            this.dentalDataSet13.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // servicesBindingSource1
            // 
            this.servicesBindingSource1.DataMember = "services";
            this.servicesBindingSource1.DataSource = this.dentalDataSet13;
            // 
            // servicesTableAdapter1
            // 
            this.servicesTableAdapter1.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 5;
            // 
            // servicesnameDataGridViewTextBoxColumn
            // 
            this.servicesnameDataGridViewTextBoxColumn.DataPropertyName = "services_name";
            this.servicesnameDataGridViewTextBoxColumn.HeaderText = "Service Name";
            this.servicesnameDataGridViewTextBoxColumn.Name = "servicesnameDataGridViewTextBoxColumn";
            // 
            // feesDataGridViewTextBoxColumn
            // 
            this.feesDataGridViewTextBoxColumn.DataPropertyName = "fees";
            this.feesDataGridViewTextBoxColumn.HeaderText = "Fee";
            this.feesDataGridViewTextBoxColumn.Name = "feesDataGridViewTextBoxColumn";
            // 
            // Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.add_patient_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Services";
            this.Text = "Services";
            this.Load += new System.EventHandler(this.Services_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentalDataSet13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_patient_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private DentalDataSet7 dentalDataSet7;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private DentalDataSet7TableAdapters.servicesTableAdapter servicesTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DentalDataSet13 dentalDataSet13;
        private System.Windows.Forms.BindingSource servicesBindingSource1;
        private DentalDataSet13TableAdapters.servicesTableAdapter servicesTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicesnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feesDataGridViewTextBoxColumn;
    }
}