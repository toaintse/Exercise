
namespace Employee
{
    public partial class Form1 : Form
    {
        static List<Employee> employeeList;
        public Form1()
        {
            employeeList = new List<Employee>();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Employee emp = new Employee();
            Employee emp = employeeList.FirstOrDefault(x => x.Code.Equals(txtCode.Text));
            if (emp != null)
            {
                MessageBox.Show("Code da ton tai");
            }
            else
            {
                if(!String.IsNullOrEmpty(txtName.Text) && !String.IsNullOrEmpty(txtCode.Text))
                {
                    emp = new Employee();
                    emp.Code = txtCode.Text;
                    emp.Name = Convert.ToString(txtName.Text);
                    emp.Dob = Convert.ToDateTime(dtDob.Text);
                    bool gender = true;
                    if (rbtnFemale.Checked)
                    {
                        gender = false;
                    }
                    emp.Gender = gender;
                    emp.Position = cbxPosition.Text;
                    bool type = true;
                    if (!chbTime.Checked)
                    {
                        type = false;
                    }
                    emp.Type = type;
                    emp.Salary = float.Parse(nudSalary.Value.ToString());
                    employeeList.Add(emp);
                }
                else
                {
                    string mess = "";
                    if (String.IsNullOrEmpty(txtName.Text)) 
                    {
                        mess += "Name is not null \n"; 
                    }
                    if(String.IsNullOrEmpty(txtCode.Text))
                    {
                        mess += "Code is not null \n";
                    }
                    MessageBox.Show(mess);
                }
                
            }
            
            //dgv.DataSource = emps.ToArray();
            load();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if(numrow != -1) {
                txtCode.Text = dgv.Rows[numrow].Cells[0].FormattedValue.ToString();
                Employee emp = employeeList.FirstOrDefault(x => x.Code.Equals(txtCode.Text));
                if(emp != null)
                {
                    txtName.Text = emp.Name;
                    dtDob.Text = emp.Dob+"";
                    rbtnMale.Checked = true;
                    if (emp.Gender==false)
                    {
                        rbtnFemale.Checked = true;
                    }
                    cbxPosition.Text = emp.Position;
                    chbTime.Checked = true;
                    if (emp.Type == false)
                    {
                        chbTime.Checked = false;
                    }
                    nudSalary.Value = (decimal)emp.Salary;
                }
                
            }

            
        }

        public void load()
        {
            dgv.DataSource = employeeList.Select(x => new
            {
                Code = x.Code,
                Name = x.Name,
                Dob = x.Dob,
                Gender = x.Gender == true? "Male":"Female",
                Position = x.Position,
                Type = x.Type == true? "IsFullTime":"Parttime",
                Salary = x.Salary
            }).ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbtnMale.Checked = true;
            chbTime.Checked = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Code = txtCode.Text;
            emp.Name = txtName.Text;
            emp.Dob = dtDob.Value;
            emp.Gender = true;
            if (rbtnFemale.Checked)
            {
                emp.Gender = false;
            }
            emp.Position = cbxPosition.Text;
            emp.Type = true;
            if (!chbTime.Checked)
            {
                emp.Type = false;
            }
            emp.Salary = float.Parse(nudSalary.Value.ToString());

            foreach (Employee item in employeeList)
            {
                if (item.Code.Equals(emp.Code))
                {
                    item.Name = emp.Name;
                    item.Dob = emp.Dob;
                    item.Gender = emp.Gender;
                    item.Position = emp.Position;
                    item.Type = emp.Type;
                    item.Salary = emp.Salary;
                    break;
                }
               
            }
            load();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            Employee emp = employeeList.FirstOrDefault(x => x.Code.Equals(code));
            if (emp != null)
            {
                employeeList.Remove(emp);
            }
            load();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = @"D:\";
            fileDialog.Filter = "Text file | *.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog.FileName;
                EmployeeList.WriteToFile(employeeList, filename);
                MessageBox.Show("Ghi file thanh cong.");
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"D:\";
            fileDialog.Filter = "Text file | *.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadFromFile(fileDialog.FileName);
                load();
            }
            
        }
        public void ReadFromFile(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            Employee employee = new Employee(line);
                            employeeList.Add(employee);
                        }
                        catch(Exception ex) {
                            MessageBox.Show("Error " + ex.Message);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File yeu cau khong ton tai");
                return;
            }
        }
    }
}