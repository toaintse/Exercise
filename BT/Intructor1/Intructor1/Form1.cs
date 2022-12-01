using Intructor1.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Intructor1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void load()
        {
            List<Department> departments = new List<Department>();
            List<Course> courses = new List<Course>();
            using (APContext context = new APContext())
            {
                dgv.DataSource = context.Instructors
                    .Include(x => x.Department)
                    .Select(x => new
                    {
                        x.InstructorId,
                        x.InstructorFirstName,
                        x.InstructorMidName,
                        x.InstructorLastName,
                        DepartmentName = x.Department.DepartmentName
                    })
                    .ToList();
                departments = context.Departments.ToList();
                courses = context.Courses.ToList();
            }

            Department d = new Department();
            d.DepartmentId = 0;
            d.DepartmentName = "All departments";
            departments.Insert(0, d);
            cbDepartment.DisplayMember = "DepartmentName";
            cbDepartment.ValueMember = "DepartmentId";
            cbDepartment.DataSource = departments;

            Course c = new Course();
            c.CourseId = 0;
            c.CourseCode = "All departments";
            courses.Insert(0, c);
            cbCourse.DisplayMember = "CourseCode";
            cbCourse.ValueMember = "CourseId";
            cbCourse.DataSource = courses;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Search();

        }

        void Search()
        {
            string name = txtName.Text;
            int departmentId = cbDepartment.SelectedIndex;
            int courseId = cbCourse.SelectedIndex;
            using(APContext context = new APContext())
            {
                if(courseId == 0)
                {
                    dgv.DataSource = context.Instructors
                    .Where(x => x.InstructorFirstName.Contains(name) || x.InstructorMidName.Contains(name) || x.InstructorLastName.Contains(name))
                    .Where(x => x.DepartmentId == departmentId || departmentId == 0)
                    .Include(x => x.Department)
                    .Select(x => new
                    {
                        x.InstructorId,
                        x.InstructorFirstName,
                        x.InstructorMidName,
                        x.InstructorLastName,
                        DepartmentName = x.Department.DepartmentName
                    }).ToList();
                }
                else
                {
                    dgv.DataSource = context.Courses
                    .Where(x => x.CourseId == courseId)
                    .Where(x => x.Instructor.InstructorFirstName.Contains(name) || x.Instructor.InstructorMidName.Contains(name) || x.Instructor.InstructorLastName.Contains(name))
                    .Where(x => x.Instructor.Department.DepartmentId == departmentId || departmentId == 0)
                    .Include(x => x.Instructor.Department)
                    .Select(x => new
                    {
                        x.InstructorId,
                        x.Instructor.InstructorFirstName,
                        x.Instructor.InstructorMidName,
                        x.Instructor.InstructorLastName,
                        DepartmentName = x.Instructor.Department.DepartmentName
                    }).ToList();
                }
                
                
            }
        }

        private void cbDepartment_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void cbCourse_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            APContext context = new APContext();
            Instructor instructor = new Instructor();
            instructor.InstructorFirstName = txtName.Text;
            instructor.DepartmentId = Convert.ToInt32(cbDepartment.SelectedValue.ToString());
            
            //instructor.Courses = ;
            context.Instructors.Add(instructor);
            context.SaveChanges();
            load();
        }
    }

}