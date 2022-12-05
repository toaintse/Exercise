using DemoOrder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOrder.Logics
{
    internal class ProductManager
    {
        public List<Product> GetProducts()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

    }
}
