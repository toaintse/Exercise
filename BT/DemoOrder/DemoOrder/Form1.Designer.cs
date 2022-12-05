namespace DemoOrder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.cbShipper = new System.Windows.Forms.ComboBox();
            this.lb = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpReDate = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cutomer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Shipper";
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(140, 20);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(121, 23);
            this.cbEmployee.TabIndex = 3;
            // 
            // cbCustomer
            // 
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(140, 65);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(121, 23);
            this.cbCustomer.TabIndex = 4;
            // 
            // cbShipper
            // 
            this.cbShipper.FormattingEnabled = true;
            this.cbShipper.Location = new System.Drawing.Point(140, 112);
            this.cbShipper.Name = "cbShipper";
            this.cbShipper.Size = new System.Drawing.Size(121, 23);
            this.cbShipper.TabIndex = 5;
            // 
            // lb
            // 
            this.lb.FormattingEnabled = true;
            this.lb.ItemHeight = 15;
            this.lb.Location = new System.Drawing.Point(414, 20);
            this.lb.Name = "lb";
            this.lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lb.Size = new System.Drawing.Size(266, 289);
            this.lb.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "RequiredDate";
            // 
            // dtpReDate
            // 
            this.dtpReDate.Location = new System.Drawing.Point(140, 173);
            this.dtpReDate.Name = "dtpReDate";
            this.dtpReDate.Size = new System.Drawing.Size(200, 23);
            this.dtpReDate.TabIndex = 8;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(106, 257);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(186, 23);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "CreateOrder";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 329);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dtpReDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.cbShipper);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbEmployee;
        private ComboBox cbCustomer;
        private ComboBox cbShipper;
        private ListBox lb;
        private Label label4;
        private DateTimePicker dtpReDate;
        private Button btnCreate;
    }
}