using DemoCreateOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCreateOrder.Logics
{
    internal class Manager
    {
        NorthwindContext context = new NorthwindContext();
        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public List<Shipper> GetShippers()
        {
            return context.Shippers.ToList();
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public void AddOrder(Order order, dynamic products)
        {
            foreach(var product in products)
            {
                OrderDetail detail = new OrderDetail();
                detail.ProductId = product.ProductId;
                detail.Quantity = 1;
                detail.UnitPrice = (product.UnitPrice==null)?0: (decimal)product.UnitPrice;
                detail.Discount = 0;
                order.OrderDetails.Add(detail);
            }
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
