using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FirstWebApp.Logics
{
    public class Manager
    {
        NorthwindContext context;
        public Manager()
        {
            context = new NorthwindContext();
        }

        public Product GetProduct(int productId)
        {
            return context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .FirstOrDefault(x => x.ProductId == productId);
        }

        public List<Product> GetProducts(int categoryId)
        {
            var list = context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier);
            if (categoryId != 0)
                return list
                    .Where(x => x.CategoryId == categoryId)
                    .OrderByDescending(x => x.ProductId)
                    .ToList();
            else return list.OrderByDescending(x => x.ProductId).ToList();
             
        }

        public void InsertProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            Product p = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (p != null)
            {
                p.CategoryId = product.CategoryId;
                p.SupplierId = product.SupplierId;
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                p.Discontinued = product.Discontinued;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            Product p = context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (p != null)
            {
                List<OrderDetail> orderDetails = context.OrderDetails.Where(x => x.ProductId == productId).ToList();
                context.OrderDetails.RemoveRange(orderDetails);
                context.Products.Remove(p);
                context.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public List<Supplier> GetSuppliers()
        {
            return context.Suppliers.ToList();
        }

    }
}
