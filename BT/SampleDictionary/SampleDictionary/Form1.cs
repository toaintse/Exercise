using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleDictionary.Models;
using System.Diagnostics.CodeAnalysis;

namespace SampleDictionary
{
    
    public partial class Form1 : Form
    {
        Dictionary dictionary = null;
        private readonly MyDB2Context _context = new MyDB2Context();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = new DataGridViewRow();
            //row = dgv.Rows[e.RowIndex];
            //txtWord.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtMean.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            //cbType.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
            if(e.RowIndex != -1)
            {
                int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                dictionary = _context.Dictionaries.FirstOrDefault(x => x.WordId == id);
                txtWord.Text = dictionary.Word;
                txtMean.Text = dictionary.Meaning;
                cbType.Text = dictionary.IdNavigation.TypeName;
            }


        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            dictionary = new Dictionary();
            dictionary.Word = txtWord.Text.Trim();
            dictionary.EditDate = DateTime.Now;
            dictionary.Meaning = txtMean.Text.Trim();
            dictionary.Id = 1;
            using(MyDB2Context context = new MyDB2Context())
            {
                context.Add(dictionary);
                context.SaveChanges();
            }
            //Clear();
            //populateDataGridView();
            load();
            MessageBox.Show("Add success.");
        }

        public void load()
        {
            cbType.DataSource = _context.WordTypes.ToList();
            dgv.DataSource = _context.Dictionaries.ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using(MyDB2Context context = new MyDB2Context())
            {
                if(dictionary!= null)
                {
                    context.Dictionaries.Remove(dictionary);
                    context.SaveChanges();
                    dictionary = null;
                }
                load();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWord.Text = "";
            txtMean.Text = "";
            cbType.Text = "";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"D:\";
            fileDialog.Filter = "Text file | *.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadFromFile(fileDialog.FileName);
            }
        }

        public void ReadFromFile(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    List<Dictionary> dictionaryList = new List<Dictionary>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            Dictionary dictionary = new Dictionary(line);
                            dictionaryList.Add(dictionary);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex.Message);
                        }
                    }
                    dgv.DataSource = null;
                    dgv.DataSource = dictionaryList;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File yeu cau khong ton tai");
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = @"D:\";
            fileDialog.Filter = "Text file | *.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Dictionary> dictionaryList = _context.Dictionaries.ToList();
                string filename = fileDialog.FileName;
                Dictionary.WriteToFile(dictionaryList, filename);
                MessageBox.Show("Ghi file thanh cong.");
            }
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
        }

        //void Clear()
        //{
        //    txtWord.Text = txtMean.Text = cbType.Text = "";
        //    btnInsert.Text = "Save";
        //    btnDelete.Enabled = false;
        //    dic.WordId = 0;
        //}
        //void populateDataGridView()
        //{
        //    dgv.AutoGenerateColumns = false;
        //    using(MyDB2Context context = new MyDB2Context())
        //    {
        //        dgv.DataSource = context.Dictionaries.ToList<Dictionary>();
        //    }
        //}
    }
}