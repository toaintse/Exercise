using ProjectTakeAtt.Logics;

namespace ProjectTakeAtt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbView.SelectedIndex == 0)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbView.Text = cbView.Items[0].ToString();

            SubjectManager subjectManager = new SubjectManager();
            InstructorManager instrutorManager = new InstructorManager();
            StudentManager studentManager = new StudentManager();

            
            
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}