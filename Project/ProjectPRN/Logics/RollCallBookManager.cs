using ProjectPRN.Models;

namespace ProjectPRN.Logics
{
    public class RollCallBookManager
    {
        APContext context = new APContext();

        public List<RollCallBook> GetRCB()
        {
            return context.RollCallBooks.ToList();
        }
    }
}
