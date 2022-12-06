using Demo0612.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo0612.Logics
{
    internal class BookManager
    {
        public List<Book> GetBooks()
        {
            using (var context = new PRN211_Demo1Context())
            {
                return context.Books.ToList();
            }
        }
    }
}
