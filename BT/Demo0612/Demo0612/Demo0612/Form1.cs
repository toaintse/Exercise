using Demo0612.Models;
using Demo0612.Logics;
namespace Demo0612
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BookManager bookManager = new BookManager();
            AuthorManager authorManager = new AuthorManager();

            cbBook.DisplayMember = "Title";
            cbBook.ValueMember = "ID";
            cbBook.DataSource = bookManager.GetBooks();

            cbYear.Text = cbYear.Items[0].ToString();

            lb.DisplayMember = "Name";
            lb.ValueMember = "ID";
            lb.DataSource = authorManager.GetAuthors();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void cbBook_TextChanged(object sender, EventArgs e)
        {

        }
    }
}