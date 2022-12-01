using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    internal class Student
    {
        //field - property
        int id; //private field

        public int Id //public property
        {
            get { return id; }
            set { id = value; }
        }

        public string Name { get; set; }//viet tat
        public DateTime Dob { get; set; }
        public string Major { get; set; }
        public float Gpa { get; set; }

        public Student()
        {

        }

        public Student(string line)
        {
            string[] items = line.Split("|");
            if (items.Length != 5) throw new FormatException("so luong item du lieu khac 5");
            Id = Convert.ToInt32(items[0]);
            Name = items[1];
            Dob = Convert.ToDateTime(items[2]);
            Major = items[3];
            Gpa = Convert.ToSingle(items[4]);
        }

        public override string? ToString()
        {
            return id + "\t" + Name + "\t" + Dob.ToShortDateString() + "\t" + Major + "\t" + Gpa;
        }
    }
}
