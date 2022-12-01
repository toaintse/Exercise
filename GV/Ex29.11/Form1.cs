
using Ex29._11.Logics;
using Ex29._11.Models;

namespace Ex29._11
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();  
        public Form1()
        {
            InitializeComponent();
        }

        Student GetStudentInfo()
        {
            Student s = new Student();
            s.Id = Convert.ToInt32(tbID.Text);
            s.Name = tbName.Text;
            s.Dob = dtpDob.Value;
            s.Major = cbMajors.SelectedItem.ToString();
            s.Gpa = (float) nudGPA.Value;
            return s;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                students.Add(GetStudentInfo());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;
            }
            catch (FormatException)
            {
                MessageBox.Show("Du lieu nao do ko dung format, hay kiem tra lai.");
            }
            
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = @"D:\";
            fileDialog.Filter = "Text file | *.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog.FileName;
                StudentList.WriteToFile(students, filename);
                MessageBox.Show("Ghi file thanh cong.");
            }
            
        }
    }
}