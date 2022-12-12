using BT1212.Models;
using Microsoft.EntityFrameworkCore;

namespace BT1212.Logics
{
    public class Manager
    {
        NorthwindContext context = new NorthwindContext();
        public List<Employee> GetEmployees(int? birthYear, string? country, int? reportTo)
        {
            List<Employee> employees = context.Employees.ToList();
            if(birthYear != 0)
            {
                employees = employees.Where(x=>((DateTime)x.BirthDate).Year == birthYear).ToList();
            }
            if (!country.Equals(""))
            {
                employees = employees.Where(x => x.Country.Equals(country)).ToList();
            }
            if(reportTo != 0)
            {
                employees = employees.Where(x => x.ReportsTo == reportTo).ToList();
            }
            return employees;
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }


        public Employee GetEmployee(int empId)
        {
            return context.Employees.FirstOrDefault(x => x.EmployeeId == empId);
        }

        public void DeleteOrderByIdEmployeeId(int id)
        {
            foreach (Order item in context.Orders.Include(x => x.Employee).Include(x => x.OrderDetails).Where(x => x.EmployeeId == id))
            {
                foreach (OrderDetail item1 in item.OrderDetails)
                {
                    item.OrderDetails.Remove(item1);
                }
                
            }
            //var order = context.Orders.Include(x=>x.Employee).Include(x=>x.OrderDetails).FirstOrDefault(x => x.EmployeeId == id);
            context.Orders.RemoveRange(context.Orders.Where(x => x.EmployeeId == id));
            
            context.SaveChanges();
            //context.Orders.Remove(order);
            //context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            foreach (Employee item in context.Employees.Include(x=>x.ReportsToNavigation).Where(x=>x.ReportsTo == id).ToList())
            {
                DeleteOrderByIdEmployeeId(item.EmployeeId);
            }
            context.Employees.RemoveRange(context.Employees.Where(x=>x.ReportsTo ==id));
            DeleteOrderByIdEmployeeId(id);
            context.Employees.Remove(GetEmployee(id));
            context.SaveChanges();
        }


    }
}
