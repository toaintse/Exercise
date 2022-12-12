namespace ProjectTakeAtt
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.takeAttendentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbView = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.takeAttendentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "View";
            // 
            // takeAttendentToolStripMenuItem
            // 
            this.takeAttendentToolStripMenuItem.Name = "takeAttendentToolStripMenuItem";
            this.takeAttendentToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.takeAttendentToolStripMenuItem.Text = "Take Attendent";
            // 
            // cbView
            // 
            this.cbView.FormattingEnabled = true;
            this.cbView.Items.AddRange(new object[] {
            "Student",
            "Course",
            "Schedule",
            "Instructor"});
            this.cbView.Location = new System.Drawing.Point(281, 74);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(121, 23);
            this.cbView.TabIndex = 1;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(31, 120);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 25;
            this.dgv.Size = new System.Drawing.Size(859, 448);
            this.dgv.TabIndex = 2;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 580);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem takeAttendentToolStripMenuItem;
        private ComboBox cbView;
        private DataGridView dgv;
    }
}