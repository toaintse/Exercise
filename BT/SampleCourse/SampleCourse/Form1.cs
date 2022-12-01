using Microsoft.EntityFrameworkCore;
using SampleCourse.Models;

namespace SampleCourse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void load()
        {
            List<Subject> subjects = new List<Subject>();
            using (APContext context = new APContext())
            {
                dgv.DataSource = context.Courses
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            int sujectId = Convert.ToInt32(cbSubject.SelectedValue);
            using(APContext context = new APContext())
            {
                dgv.DataSource = _context.Courses
                    .Where(x => x.CourseCode.Contains(code))
                    .Where(x => ())
            }
        }
    }
}