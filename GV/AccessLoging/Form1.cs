using AccessLoging.Models;
using System.Web;

namespace AccessLoging
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> mykeys = new Dictionary<string, string>();
        List<MyLog> myLogs = new List<MyLog>();
        public Form1()
        {
            InitializeComponent();
            mykeys.Add("1645", "Technicians");
            mykeys.Add("1689", "Technicians");
            mykeys.Add("8345", "Custodians");
            mykeys.Add("9998", "Scientist");
            mykeys.Add("1006", "Scientist");
            mykeys.Add("1007", "Scientist");
            mykeys.Add("1008", "Scientist");
            GenerateButtons();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("time", "Access Time");
            dataGridView1.Columns["time"].DataPropertyName = "AccessTime";
            dataGridView1.Columns.Add("status", "Status");
            dataGridView1.Columns["status"].DataPropertyName = "Status";
        }

        void GenerateButtons()
        {
            string[] ButtonLabels = { "1", "2", "3", "C", "4", "5", "6", "#", "7", "8", "9", "0" };
            int width = (flowLayoutPanel1.Width - 8 * DefaultMargin.Left) / 4;
            int height = (flowLayoutPanel1.Height - 8 * DefaultMargin.Top) / 4;
            for(int i=0; i<ButtonLabels.Length; i++)
            {
                Button b = new Button(); //khai bao kieu control, tao doi tuong control
                b.Text = ButtonLabels[i];//gan thuoc tinh cho control
                b.Width = width;
                b.Height = height;
                flowLayoutPanel1.Controls.Add(b); //add control vao 1 container nao do tren form
                if (i == 3) b.Click += OnClearButton_Click;
                else if (i == 7) b.Click += OnOkButton_Click;
                else b.Click += OnNumberButton_Click;
            }
        }

        private void OnNumberButton_Click(object sender, EventArgs e)
        {
            tbCode.Text += ((Button)sender).Text;
        }

        private void OnClearButton_Click(object sender, EventArgs e)
        {
            if (tbCode.Text != String.Empty)
                tbCode.Text = tbCode.Text.Substring(0, tbCode.Text.Length - 1);
        }

        private void OnOkButton_Click(object sender, EventArgs e)
        {
            if (tbCode.Text.Equals(String.Empty)) return;
            string code = tbCode.Text;
            if (mykeys.ContainsKey(code))
                myLogs.Add(new MyLog(code, DateTime.Now, mykeys[code]));
            else myLogs.Add(new MyLog("", DateTime.Now, "Restricted Access!"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = myLogs;
            tbCode.Text = String.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}