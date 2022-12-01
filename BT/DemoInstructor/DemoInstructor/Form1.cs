using DemoInstructor.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoInstructor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Department> departments = new List<Department>();
            List<Course> courses = new List<Course>();
            using (APContext context = new APContext())
            {
                dgv.DataSource = context.Instructors
                    .Include(x => x.Department)
                    //.Include(x => x.Instructor)
                    .Select(x => new
                    {
                        x.InstructorId,
                        x.InstructorFirstName,
                        x.InstructorMidName,
                        x.InstructorLastName,
                        DepartmentName = x.Department.DepartmentName //+ " " + x.Instructor.InstructorLastName
                    })
                    .ToList();
                departments = context.Departments.ToList();
                courses = context.Courses.ToList();
            }
            //Subject s = new Subject();
            //s.SubjectId = 0;
            //s.SubjectName = "All subjects";
            //subjects.Insert(0, s);
            //cbSubjects.DisplayMember = "SubjectName";
            //cbSubjects.ValueMember = "SubjectId";
            //cbSubjects.DataSource = subjects;

            Department d = new Department();
            d.DepartmentId = 0;
            d.DepartmentName = "All departments";
            departments.Insert(0, d);
            cbDepartment.DisplayMember = "DepartmentName";
            cbDepartment.ValueMember = "DepartmentId";
            cbDepartment.DataSource = departments;

            Course c = new Course();
            c.CourseId = 0;
            c.CourseCode = "All courses";
            courses.Insert(0, c);
            cbCourse.DisplayMember = "CourseCode";
            cbCourse.ValueMember = "CourseId";
            cbCourse.DataSource = courses;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            int departmentId = Convert.ToInt32(cbDepartment.SelectedValue);
            int courseId = Convert.ToInt32(cbCourse.SelectedValue);
            using (APContext context = new APContext())
            {
                if (courseId == 0)
                {
                    dgv.DataSource = context.Instructors
                    .Where(x => x.InstructorFirstName.Contains(name) || x.InstructorMidName.Contains(name) || x.InstructorLastName.Contains(name))
                    .Where(x => (departmentId == 0) || x.DepartmentId == departmentId)
                    .Include(x => x.Department)
                    .Select(x => new
                    {
                        x.InstructorId,
                        x.InstructorFirstName,
                        x.InstructorMidName,
                        x.InstructorLastName,
                        DepartmentName = x.Department.DepartmentName //+ " " + x.Instructor.InstructorLastName
                    })
                    .ToList();
                }
                else
                {
                    dgv.DataSource = context.Courses
                        .Where(x => x.CourseId == courseId)
                        .Where(x => x.Instructor.InstructorFirstName.Contains(name) || x.Instructor.InstructorMidName.Contains(name) || x.Instructor.InstructorLastName.Contains(name))
                        .Where(x => (departmentId == 0) || x.Instructor.Department.DepartmentId == departmentId)
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
    }
}