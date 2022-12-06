using Demo0612.Models;
using Demo0612.Logics;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

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
            Manager manager = new Manager();

            cbBook.DisplayMember = "Title";
            cbBook.ValueMember = "ID";
            cbBook.DataSource = manager.GetBooks();

            cbYear.Text = cbYear.Items[0].ToString();

            lb.DisplayMember = "Name";
            lb.ValueMember = "ID";
            lb.DataSource = manager.GetAuthors();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (PRN211_Demo1Context context = new PRN211_Demo1Context())
            {
                try
                {
                    Book book = cbBook.SelectedItem as Book;
                    var authorlist = lb.SelectedItems;
                    if(authorlist != null)
                    {
                        DialogResult result = MessageBox.Show("Do you really want to remove this author?", "Confirm", MessageBoxButtons.YesNo);
                        if(result == DialogResult.Yes)
                        {
                            foreach (Author author in authorlist)
                            {
                                var author1 = context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == author.Id);
                                var book1 = context.Books.FirstOrDefault(x => x.Id == book.Id);
                                author1.Books.Remove(book1);
                                context.SaveChanges();
                            }
                        }
                        
                    }

                    

                    
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void cbBook_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (PRN211_Demo1Context context = new PRN211_Demo1Context())
            {
                try
                {
                    Book book = cbBook.SelectedItem as Book;
                    List<Author> authorList = context.Authors
                        .Include(x => x.Books).ToList();

                    cbYear.Text = book.Year.ToString();


                    lb.ClearSelected();
                    for (int i = 0; i < authorList.Count; i++)
                    {
                        foreach (Book book1 in authorList[i].Books)
                        {
                            if (book1.Id == book.Id)
                            {
                                lb.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {

                }
            }

        }
    }
}