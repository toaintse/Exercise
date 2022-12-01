using System.Windows.Forms;

namespace Student
{
    public partial class Form1 : Form
    {
        static List<Student> students;
        public Form1()
        {
            students = new List<Student>(); 
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            if (student.Id == null) MessageBox.Show("Id not null");
            student.Id = Convert.ToInt32(txtID.Text);
            
            student.Name = Convert.ToString(txtName.Text);
            student.Dob = Convert.ToDateTime(dtDOB.Text);
            student.Major = cbMajor.Text;
            student.Gpa = float.Parse(nudGPA.Value.ToString());
            students.Add(student);
            dgv.DataSource = students.ToArray();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtID.Text = dgv.Rows[numrow].Cells[0].Value.ToString();
            txtName.Text = dgv.Rows[numrow].Cells[1].Value.ToString();
            dtDOB.Text = dgv.Rows[numrow].Cells[2].Value.ToString();
            cbMajor.Text = dgv.Rows[numrow].Cells[3].Value.ToString();
            //nudGPA.Value = dgv.Rows[numrow].Cells[4].Value.ToString();
        }

        public void saveFile(string filename)
        {
            using(StreamWriter sw = new StreamWriter(filename))
            {
                foreach(Student student in students)
                {
                    sw.WriteLine(student.ToString());
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;

                MessageBox.Show(fileName);
                saveFile(fileName);
            }
        }
    }
}