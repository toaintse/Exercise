using DemoListAndFilter.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoListAndFilter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Subject> subjects = new List<Subject>();
            using (APContext context = new APContext())
            {
                dgvCourses.DataSource = context.Courses
                    .Include(x => x.Subject)
                    .Include(x => x.Instructor)
                    .Select(x => new
                    {
                        x.CourseId,
                        x.CourseCode,
                        x.CourseDescription,
                        SubjectName = x.Subject.SubjectName,
                        InstructorName = x.Instructor.InstructorFirstName + " " + x.Instructor.InstructorLastName
                    })
                    .ToList();
                subjects = context.Subjects.ToList();
            }
            Subject s = new Subject();
            s.SubjectId = 0;
            s.SubjectName = "All subjects";
            subjects.Insert(0, s);
            cbSubjects.DisplayMember = "SubjectName";
            cbSubjects.ValueMember = "SubjectId";
            cbSubjects.DataSource = subjects;
        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            string code = tbCode.Text.Trim();
            int subjectId = Convert.ToInt32(cbSubjects.SelectedValue);
            using (APContext context = new APContext())
            {
                dgvCourses.DataSource = context.Courses
                    .Where(x => x.CourseCode.Contains(code))
                    .Where(x => (subjectId == 0) || x.SubjectId == subjectId)
                    .Include(x => x.Subject)
                    .Include(x => x.Instructor)
                    .Select(x => new
                    {
                        x.CourseId,
                        x.CourseCode,
                        x.CourseDescription,
                        SubjectName = x.Subject.SubjectName,
                        InstructorName = x.Instructor.InstructorFirstName + " " + x.Instructor.InstructorLastName
                    })
                    .ToList();                
            }
        }
    }
}