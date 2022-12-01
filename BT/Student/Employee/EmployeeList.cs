using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class EmployeeList
    {
        public static void WriteToFile(List<Employee> employees, string Filename)
        {
            using (StreamWriter writer = new StreamWriter(Filename))
            {
                foreach (Employee e in employees)
                    writer.WriteLine(e.ToStringLine());
                writer.Close();
            }
        }
    }
}
