using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    internal class Employee
    {
        public string Code { get; set; }

        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public bool? Gender { get; set; }
        public string Position { get; set; }
        public bool? Type { get; set; }
        public float Salary { get; set; }

        public Employee()
        {

        }

        public Employee(string line)
        {
            string[] items = line.Split("|");
            if (items.Length != 7) throw new FormatException("so luong item du lieu khac 7");
            Code = items[0];
            Name = items[1];
            Dob = Convert.ToDateTime(items[2]);
            Gender = Convert.ToBoolean(items[3]);
            Position = items[4];
            Type = Convert.ToBoolean(items[5]);
            Salary = Convert.ToSingle(items[6]);
        }

        public string ToStringLine()
        {
            return $"{Code}|{Name}|{Dob.ToShortDateString()}|{Gender}|{Position}|{Type}|{Salary}";
        }



        public override string? ToString()
        {
            return Code + "\t" + Name + "\t" + Dob.ToShortDateString() + "\t" + Gender + "\t" + Position + "\t" + Type +"\t" + Salary;
        }
    }
}
