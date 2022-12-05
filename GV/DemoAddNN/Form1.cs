using System.Runtime.Serialization;
using DataServices.Logics;
using DataServices.Models;

namespace DemoAddNN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SubjectManager subjectManager = new SubjectManager();
            TermManager termManager = new TermManager();
            InstrutorManager instrutorManager = new InstrutorManager();
            CampusManager campusManager = new CampusManager();
            StudentManager studentManager = new StudentManager();

            cbSubjects.DisplayMember = "SubjectName";
            cbSubjects.ValueMember = "SubjectId";
            cbSubjects.DataSource = subjectManager.GetSubjects();

            cbTerms.DisplayMember = "TermName";
            cbTerms.ValueMember = "TermId";
            cbTerms.DataSource = termManager.GetTerms();

            cbCampuses.DisplayMember = "CampusName";
            cbCampuses.ValueMember = "CampusId";
            cbCampuses.DataSource = campusManager.GetCampuses();

            cbInstructors.DisplayMember = "Fullname";
            cbInstructors.ValueMember = "InstructorId";
            cbInstructors.DataSource = instrutorManager.GetInstructors()
                .Select(x => new
                {
                    x.InstructorId,
                    Fullname = x.InstructorLastName + " " + x.InstructorMidName + " " + x.InstructorFirstName
                })
                .ToList();

            lbStudents.DisplayMember = "Fullname";
            lbStudents.ValueMember = "StudentId";
            lbStudents.DataSource = studentManager.GetStudents()
                .Select(x => new
                {
                    x.StudentId,
                    Fullname = x.LastName + " " + x.MidName + " " + x.FirstName
                })
                .ToList();
        }

        private Course GetCourseInfo()
        {
            Course course = new Course();
            course.CourseCode = tbCode.Text.Trim();
            course.CourseDescription = tbDescription.Text.Trim();
            course.SubjectId = Convert.ToInt32(cbSubjects.SelectedValue);
            course.InstructorId = Convert.ToInt32(cbInstructors.SelectedValue);
            course.TermId = Convert.ToInt32(cbTerms.SelectedValue);
            course.CampusId = Convert.ToInt32(cbCampuses.SelectedValue);
            return course;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            Course course = GetCourseInfo();
            List<int> studentIds = new List<int>();
            foreach(dynamic item in lbStudents.SelectedItems)
            {
                studentIds.Add( (int) item.StudentId);
            }
            CourseManager courseManager = new CourseManager();
            courseManager.AddCourse(course, studentIds);
            MessageBox.Show("Adding successful");
        }
    }
}