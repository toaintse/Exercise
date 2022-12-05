using DemoOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOrder.Logics
{
    internal class CustomerManager
    {
        public List<Customer> GetCustomers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Customers.ToList();
            }
        }
    }
}
