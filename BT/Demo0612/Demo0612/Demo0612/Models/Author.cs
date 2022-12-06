using System;
using System.Collections.Generic;

namespace Demo0612.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        
    }
}
