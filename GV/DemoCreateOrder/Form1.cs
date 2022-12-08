using DemoCreateOrder.Logics;
using DemoCreateOrder.Models;

namespace DemoCreateOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            cbCustomers.DisplayMember = "CompanyName";
            cbCustomers.ValueMember = "CustomerID";
            cbCustomers.DataSource = manager.GetCustomers();

            cbEmployees.DisplayMember = "Fullname";
            cbEmployees.ValueMember = "EmployeeID";
            cbEmployees.DataSource = manager.GetEmployees()
                .Select(x => new
                {
                    Fullname = x.FirstName + " " + x.LastName,
                    x.EmployeeId
                })
                .ToList();

            cbShippers.DisplayMember = "CompanyName";
            cbShippers.ValueMember = "ShipperID";
            cbShippers.DataSource = manager.GetShippers();

            lbProducts.DisplayMember = "ProductName";
            lbProducts.ValueMember = "ProductID";
            lbProducts.DataSource = manager.GetProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamic products = lbProducts.SelectedItems;
            Order order = new Order();
            order.EmployeeId = Convert.ToInt32(cbEmployees.SelectedValue);
            order.CustomerId = cbCustomers.SelectedValue.ToString();
            order.ShipVia = Convert.ToInt32(cbShippers.SelectedValue);
            order.OrderDate = DateTime.Now;
            order.RequiredDate = dtpRequiredDate.Value;
            order.ShipName = tbName.Text;
            order.ShipAddress = tbAddress.Text;
            try
            {
                Manager manager = new Manager();
                manager.AddOrder(order, products);
                MessageBox.Show("adding successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error. {Environment.NewLine} {ex.Message}");
            }
        }
    }
}