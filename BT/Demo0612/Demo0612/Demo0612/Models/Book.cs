using System;
using System.Collections.Generic;

namespace Demo0612.Models
{
    public partial class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Author> Authors { get; set; }

        
    }
}
