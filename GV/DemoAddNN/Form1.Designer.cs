namespace DemoAddNN
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
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.cbSubjects = new System.Windows.Forms.ComboBox();
            this.cbTerms = new System.Windows.Forms.ComboBox();
            this.cbInstructors = new System.Windows.Forms.ComboBox();
            this.cbCampuses = new System.Windows.Forms.ComboBox();
            this.lbStudents = new System.Windows.Forms.ListBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(123, 47);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(100, 23);
            this.tbCode.TabIndex = 0;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(123, 97);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(218, 117);
            this.tbDescription.TabIndex = 1;
            // 
            // cbSubjects
            // 
            this.cbSubjects.FormattingEnabled = true;
            this.cbSubjects.Location = new System.Drawing.Point(123, 243);
            this.cbSubjects.Name = "cbSubjects";
            this.cbSubjects.Size = new System.Drawing.Size(121, 23);
            this.cbSubjects.TabIndex = 2;
            // 
            // cbTerms
            // 
            this.cbTerms.FormattingEnabled = true;
            this.cbTerms.Location = new System.Drawing.Point(123, 338);
            this.cbTerms.Name = "cbTerms";
            this.cbTerms.Size = new System.Drawing.Size(121, 23);
            this.cbTerms.TabIndex = 3;
            // 
            // cbInstructors
            // 
            this.cbInstructors.FormattingEnabled = true;
            this.cbInstructors.Location = new System.Drawing.Point(123, 292);
            this.cbInstructors.Name = "cbInstructors";
            this.cbInstructors.Size = new System.Drawing.Size(121, 23);
            this.cbInstructors.TabIndex = 4;
            // 
            // cbCampuses
            // 
            this.cbCampuses.FormattingEnabled = true;
            this.cbCampuses.Location = new System.Drawing.Point(123, 385);
            this.cbCampuses.Name = "cbCampuses";
            this.cbCampuses.Size = new System.Drawing.Size(121, 23);
            this.cbCampuses.TabIndex = 5;
            // 
            // lbStudents
            // 
            this.lbStudents.FormattingEnabled = true;
            this.lbStudents.ItemHeight = 15;
            this.lbStudents.Location = new System.Drawing.Point(363, 77);
            this.lbStudents.Name = "lbStudents";
            this.lbStudents.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbStudents.Size = new System.Drawing.Size(390, 274);
            this.lbStudents.TabIndex = 6;
            // 
            // btSubmit
            // 
            this.btSubmit.Location = new System.Drawing.Point(563, 385);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(190, 23);
            this.btSubmit.TabIndex = 7;
            this.btSubmit.Text = "Create New Course";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "CourseCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Campus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Term";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Instructor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Subject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "List of students";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.lbStudents);
            this.Controls.Add(this.cbCampuses);
            this.Controls.Add(this.cbInstructors);
            this.Controls.Add(this.cbTerms);
            this.Controls.Add(this.cbSubjects);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbCode;
        private TextBox tbDescription;
        private ComboBox cbSubjects;
        private ComboBox cbTerms;
        private ComboBox cbInstructors;
        private ComboBox cbCampuses;
        private ListBox lbStudents;
        private Button btSubmit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}