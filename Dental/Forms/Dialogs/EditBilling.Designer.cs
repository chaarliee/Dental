namespace Dental.Forms.Dialogs
{
    partial class EditBilling
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_discount = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button_total = new System.Windows.Forms.Button();
            this.total_textbox = new System.Windows.Forms.Label();
            this.panelServicesEdit = new System.Windows.Forms.Panel();
            this.servicequantity_0 = new System.Windows.Forms.NumericUpDown();
            this.servicecombobox_0 = new System.Windows.Forms.ComboBox();
            this.serviceprice_0 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelServicesEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicequantity_0)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_discount
            // 
            this.checkBox_discount.AutoSize = true;
            this.checkBox_discount.Location = new System.Drawing.Point(8, 254);
            this.checkBox_discount.Name = "checkBox_discount";
            this.checkBox_discount.Size = new System.Drawing.Size(68, 17);
            this.checkBox_discount.TabIndex = 151;
            this.checkBox_discount.Text = "Discount";
            this.checkBox_discount.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 23);
            this.button3.TabIndex = 150;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button_total
            // 
            this.button_total.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_total.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_total.Location = new System.Drawing.Point(139, 254);
            this.button_total.Name = "button_total";
            this.button_total.Size = new System.Drawing.Size(42, 23);
            this.button_total.TabIndex = 149;
            this.button_total.Text = "Total";
            this.button_total.UseVisualStyleBackColor = false;
            this.button_total.Click += new System.EventHandler(this.button_total_Click);
            // 
            // total_textbox
            // 
            this.total_textbox.AutoSize = true;
            this.total_textbox.Location = new System.Drawing.Point(184, 258);
            this.total_textbox.Name = "total_textbox";
            this.total_textbox.Size = new System.Drawing.Size(10, 13);
            this.total_textbox.TabIndex = 146;
            this.total_textbox.Text = "-";
            // 
            // panelServicesEdit
            // 
            this.panelServicesEdit.Controls.Add(this.servicequantity_0);
            this.panelServicesEdit.Controls.Add(this.servicecombobox_0);
            this.panelServicesEdit.Controls.Add(this.serviceprice_0);
            this.panelServicesEdit.Location = new System.Drawing.Point(6, 76);
            this.panelServicesEdit.Name = "panelServicesEdit";
            this.panelServicesEdit.Size = new System.Drawing.Size(313, 172);
            this.panelServicesEdit.TabIndex = 145;
            // 
            // servicequantity_0
            // 
            this.servicequantity_0.Location = new System.Drawing.Point(132, 2);
            this.servicequantity_0.Name = "servicequantity_0";
            this.servicequantity_0.Size = new System.Drawing.Size(66, 20);
            this.servicequantity_0.TabIndex = 96;
            // 
            // servicecombobox_0
            // 
            this.servicecombobox_0.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.servicecombobox_0.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.servicecombobox_0.DisplayMember = "FullName";
            this.servicecombobox_0.FormattingEnabled = true;
            this.servicecombobox_0.Location = new System.Drawing.Point(0, 2);
            this.servicecombobox_0.Name = "servicecombobox_0";
            this.servicecombobox_0.Size = new System.Drawing.Size(125, 21);
            this.servicecombobox_0.TabIndex = 79;
            this.servicecombobox_0.ValueMember = "Id";
            // 
            // serviceprice_0
            // 
            this.serviceprice_0.Location = new System.Drawing.Point(204, 3);
            this.serviceprice_0.Name = "serviceprice_0";
            this.serviceprice_0.Size = new System.Drawing.Size(100, 20);
            this.serviceprice_0.TabIndex = 81;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(207, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 144;
            this.label17.Text = "Price";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(135, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 143;
            this.label16.Text = "Quantity";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 142;
            this.label15.Text = "Services";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 15);
            this.label14.TabIndex = 140;
            this.label14.Text = "Services Details";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(163, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 138;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(244, 321);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 139;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 152;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_discount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_total);
            this.Controls.Add(this.total_textbox);
            this.Controls.Add(this.panelServicesEdit);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "EditBilling";
            this.Size = new System.Drawing.Size(328, 358);
            this.Load += new System.EventHandler(this.EditBilling_Load);
            this.panelServicesEdit.ResumeLayout(false);
            this.panelServicesEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicequantity_0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_discount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_total;
        private System.Windows.Forms.Label total_textbox;
        private System.Windows.Forms.Panel panelServicesEdit;
        private System.Windows.Forms.NumericUpDown servicequantity_0;
        private System.Windows.Forms.ComboBox servicecombobox_0;
        private System.Windows.Forms.TextBox serviceprice_0;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
    }
}
