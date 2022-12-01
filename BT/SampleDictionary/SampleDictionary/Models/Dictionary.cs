using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SampleDictionary.Models
{
    public partial class Dictionary
    {

        public int WordId { get; set; }
        public string Word { get; set; } = null!;
        public DateTime EditDate { get; set; }
        public string Meaning { get; set; } = null!;
        public int Id { get; set; }

        public virtual WordType IdNavigation { get; set; } = null!;

        public Dictionary(string line)
        {
            string[] items = line.Split("|");
            if (items.Length != 6) throw new FormatException("so luong item du lieu khac 6");
            WordId = Int32.Parse(items[0]);
            Word = items[1];
            EditDate = DateTime.Parse(items[2]);
            Meaning = items[3];
            Id = Int32.Parse(items[4]);
            WordType wordType = new WordType();
            wordType.TypeName = items[5];
            IdNavigation = wordType;

        }

        public static void WriteToFile(List<Dictionary> dictionaryList, string Filename)
        {
            using (StreamWriter writer = new StreamWriter(Filename))
            {
                foreach (Dictionary d in dictionaryList)
                    writer.WriteLine(d.ToStringLine());
                writer.Close();
            }
        }

        public Dictionary()
        {
        }

        public string ToStringLine()
        {
            return $"{WordId}|{Word}|{EditDate}|{Meaning}|{Id}|{IdNavigation.TypeName}";
        }
    }
}
