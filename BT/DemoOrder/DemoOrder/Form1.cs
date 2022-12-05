using DemoOrder.Logics;
using DemoOrder.Models;
using Microsoft.VisualBasic.Devices;
using System.Runtime.Serialization;

namespace DemoOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomerManager customerManager = new CustomerManager();
            EmployeeManager employeeManager = new EmployeeManager();
            ShipperManager shipperManager = new ShipperManager();
            ProductManager productManager = new ProductManager();

            cbCustomer.DisplayMember = "CompanyName";
            cbCustomer.ValueMember = "customerID";
            cbCustomer.DataSource = customerManager.GetCustomers();

            cbEmployee.DisplayMember = "Fullname";
            cbEmployee.ValueMember = "EmployeeID";
            cbEmployee.DataSource = employeeManager.GetEmployees()
                .Select(x => new
                {
                    x.EmployeeId,
                    Fullname = x.LastName + " " + x.FirstName
                })
                .ToList();

            cbShipper.DisplayMember = "CompanyName";
            cbShipper.ValueMember = "ShipperID";
            cbShipper.DataSource = shipperManager.GetShippers();

            lb.DisplayMember = "ProductName";
            lb.ValueMember = "ProductID";
            lb.DataSource = productManager.GetProducts();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            NorthwindContext context = new NorthwindContext();
            //List<int> productIds = new List<int>();

            order.CustomerId = cbCustomer.SelectedValue.ToString();
            order.EmployeeId = Convert.ToInt32(cbEmployee.SelectedValue.ToString());
            order.OrderDate = DateTime.Now;
            order.RequiredDate = DateTime.Parse(dtpReDate.Text);
            order.ShipVia = Convert.ToInt32(cbShipper.SelectedValue.ToString());
            foreach (Product item in lb.SelectedItems)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ProductId = Convert.ToInt32(item.ProductId);
                orderDetail.UnitPrice = item.UnitPrice.Value;
                orderDetail.Quantity = 1;
                orderDetail.Discount = 0;
                order.OrderDetails.Add(orderDetail);
            }
            context.Orders.Add(order);
            context.SaveChanges();
            
            MessageBox.Show("Adding successfully");
        }
    }
}