using DemoFilterAndPaging.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoFilterAndPaging.Logics
{
    
    public class Manager
    {
        NorthwindContext context = new NorthwindContext();
        public List<Order> GetOrders(int empId, string cusId, DateTime fromDate, DateTime toDate, int fromIndex, int numberItems)
        {
            List<Order> orders = context.Orders.Where(x => x.OrderDate != null &&
                                                            ((DateTime)x.OrderDate).Date >= fromDate.Date &&
                                                            ((DateTime)x.OrderDate).Date <= toDate.Date)
                                                .Include(x => x.Employee)
                                                .Include(x => x.Customer)
                                                .ToList();
            if (empId != 0)
                orders = orders.Where(x => x.EmployeeId == empId).ToList();
            if (!String.IsNullOrEmpty(cusId))
                orders = orders.Where(x => (x.CustomerId != null && x.CustomerId.Equals(cusId))).ToList();
            orders = orders.Skip(fromIndex - 1).Take(numberItems).ToList();
            return orders;
        }

        public int GetTotalNumberOrders(int empId, string cusId, DateTime fromDate, DateTime toDate)
        {
            List<Order> orders = context.Orders.Where(x => x.OrderDate != null &&
                                                            ((DateTime)x.OrderDate).Date >= fromDate.Date &&
                                                            ((DateTime)x.OrderDate).Date <= toDate.Date).ToList();
            if (empId != 0)
                orders = orders.Where(x => x.EmployeeId == empId).ToList();
            if (!String.IsNullOrEmpty(cusId))
                orders = orders.Where(x => (x.CustomerId != null && x.CustomerId.Equals(cusId))).ToList();
            return orders.Count;    
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public List<Product> GetProducts()
        {
            return context.Products.Include(x => x.Category).Include(x => x.Supplier).ToList();
        }

        public bool ExistsProduct(int id)
        {
            return context.Products.FirstOrDefault(x => x.ProductId == id) != null;
        }

        public List<Product> GetProducts(List<int> productIds)
        {
            return context.Products.Where(x => productIds.Contains(x.ProductId)).ToList();
            
        }
    }
}
