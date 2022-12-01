using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLoging.Models
{
    internal class MyLog
    {
        public string Id { get; set; }
        public DateTime AccessTime { get; set; }
        public string Status { get; set; }

        public MyLog(string id, DateTime accessTime, string status)
        {
            Id = id;
            AccessTime = accessTime;
            Status = status;
        }
    }
}
