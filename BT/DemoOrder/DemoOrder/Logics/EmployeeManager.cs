using DemoOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOrder.Logics
{
    internal class EmployeeManager
    {
        public List<Employee> GetEmployees()
        {
            using (var context = new NorthwindContext())
            {
                return context.Employees.ToList();
            }
        }
    }
}
