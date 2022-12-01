using System;
using System.Collections.Generic;

namespace SampleDictionary.Models
{
    public partial class WordType
    {
        public WordType()
        {
            Dictionaries = new HashSet<Dictionary>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Dictionary> Dictionaries { get; set; }

        public override string? ToString()
        {
            return TypeName;
        }
    }
}
