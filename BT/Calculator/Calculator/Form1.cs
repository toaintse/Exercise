using System.Data;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private int firstValue = 0;
        private int secondValue = 0;
        private int result = 0;
        private string operators = "+";
        public Form1()
        {
            InitializeComponent();
            GenerateButtons();
        }

        void GenerateButtons()
        {
            string[] ButtonLabels = { "7", "8", "9", "+", "4", "5", "6", "-", "1", "2", "3", "*", "+-", "0", "=", "%" };
            int width = (flowLayoutPanel1.Width - 8 * DefaultMargin.Left) / 4;
            int height = (flowLayoutPanel1.Height - 8 * DefaultMargin.Top) / 4;
            for (int i = 0; i < ButtonLabels.Length; i++)
            {
                Button b = new Button(); //khai bao kieu control, tao doi tuong control
                b.Text = ButtonLabels[i];//gan thuoc tinh cho control
                b.Width = width;
                b.Height = height;
                flowLayoutPanel1.Controls.Add(b); //add control vao 1 container nao do tren form
                if (i == 3) b.Click += OnPlusButton_Click; //Cong
                else if (i == 7) b.Click += OnSubButton_Click; //Tru
                else if (i == 11) b.Click += OnMultiButton_Click; //Nhan
                else if (i == 12) b.Click += OnMinusButton_Click; //Doi dau
                else if (i == 14) b.Click += OnEqualButton_Click; //Bang
                else if (i == 15) b.Click += OnModuleButton_Click; //Chia du
                else b.Click += OnNumberButton_Click;
            }
        }

        private void OnPlusButton_Click(object sender, EventArgs e)
        {
            firstValue = int.Parse(txtCode.Text);
            txtCode.Clear();
            operators = "+";
        }
        private void OnSubButton_Click(object sender, EventArgs e)
        {
            firstValue = int.Parse(txtCode.Text);
            txtCode.Clear();
            operators = "-";
        }
        private void OnMultiButton_Click(object sender, EventArgs e)
        {
            firstValue = int.Parse(txtCode.Text);
            txtCode.Clear();
            operators = "*";
        }
        private void OnMinusButton_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Contains("-"))
            {
                txtCode.Text = txtCode.Text.Trim('-');
            }
            else
            {
                txtCode.Text = "-" + txtCode.Text;
            }
        }
        private void OnEqualButton_Click(object sender, EventArgs e)
        {
            switch (operators)
            {
                case "+":
                    secondValue = int.Parse(txtCode.Text);
                    result = firstValue + secondValue;
                    txtCode.Text = result.ToString();
                    break;
                case "-":
                    secondValue = int.Parse(txtCode.Text);
                    result = firstValue - secondValue;
                    txtCode.Text = result.ToString();
                    break;
                case "*":
                    secondValue = int.Parse(txtCode.Text);
                    result = firstValue * secondValue;
                    txtCode.Text = result.ToString();
                    break;
                case "%":
                    secondValue = int.Parse(txtCode.Text);
                    if(secondValue != 0)
                    {
                        result = firstValue % secondValue;
                        txtCode.Text = result.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Input number != 0");
                    }
                    break;
            }
        }
        private void OnModuleButton_Click(object sender, EventArgs e)
        {
            firstValue = int.Parse(txtCode.Text);
            txtCode.Clear();
            operators = "%";
        }

        private void OnNumberButton_Click(object sender, EventArgs e)
        {
            txtCode.Text += ((Button)sender).Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            firstValue = 0;
            secondValue = 0;
            txtCode.Text = "0";
        }

        private void btnBS_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != String.Empty)
                txtCode.Text = txtCode.Text.Substring(0, txtCode.Text.Length - 1);
        }
    }
}