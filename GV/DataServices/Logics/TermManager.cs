using DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Logics
{
    public class TermManager
    {
        public List<Term> GetTerms()
        {
            using (var context = new APContext())
            {
                return context.Terms.ToList();
            }
        }
    }
}
