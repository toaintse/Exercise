using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoOrder.Models;

namespace DemoOrder.Logics
{
    internal class ShipperManager
    {
        public List<Shipper> GetShippers()
        {
            using (var context = new NorthwindContext())
            {
                return context.Shippers.ToList();
            }
        }
    }
}
