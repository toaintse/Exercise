using BtDemoWeb0712.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BtDemoWeb0712.Logics
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

        public Customer GetCustomer(string customerId)
        {
            return context.Customers.FirstOrDefault(x => x.CustomerId.Equals(customerId));
        }

        public Order GetOrder(int? orderId)
        {
            return context.Orders.Include(x => x.OrderDetails).FirstOrDefault(x => x.OrderId == orderId);
        }

        public OrderDetail GetOrderDetail(int? productId, int? orderId)
        {
            return context.OrderDetails.Include(x => x.Order).FirstOrDefault(x => x.OrderId == orderId && x.ProductId == productId);
        }

        public List<OrderDetail> GetOrderDetails (int? orderId)
        {
            var list = context.OrderDetails
                .Include(x => x.Product)
                .Include(x => x.Order);
            if(orderId != 0)
            return list.Where(x => x.OrderId == orderId)
                    .OrderByDescending(x => x.ProductId)
                    .ToList();
            else return list.OrderByDescending(x => x.ProductId).ToList();
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

        public void EditQuantity(int? productId, int? orderId, int? quantity)
        {
            OrderDetail o = context.OrderDetails.Include(x => x.Order).FirstOrDefault(x => x.OrderId == orderId && x.ProductId == productId);
            if(quantity > 0)
            {
                if (o != null)
                {
                    o.OrderId = o.OrderId;
                    o.ProductId = o.ProductId;
                    o.Quantity = (short)quantity;
                    o.UnitPrice = o.UnitPrice;
                    context.SaveChanges();
                }
            }
            else if(quantity == 0)
            {
                RemoveQuantity((int)productId, (int)orderId);
            }else if(quantity < 0){

            }
            
        }


        public void RemoveQuantity(int pId,int oId)
        {
            //List<Order> order = context.Orders.Include(x=>x.OrderDetails).Where(x => x.OrderId == oId).ToList();
            //if(order != null)
            //{
            //    foreach (Order item in order)
            //    {
            //        foreach (OrderDetail item1 in item.OrderDetails)
            //        {
            //            if (item1.ProductId == pId)
            //            {
            //                item1.Quantity = 0;
            //                context.SaveChanges();
            //            }
                        

            //        }
            //    }
                
            //}
            var order = context.Orders.Include(x => x.OrderDetails).FirstOrDefault(x => x.OrderId == oId);
            var orderDetail = order.OrderDetails.FirstOrDefault(x => x.ProductId == pId);
            order.OrderDetails.Remove(orderDetail);
            //orderDetail.Quantity = 0;
            //order.OrderDetails.Add(orderDetail);
            context.SaveChanges();
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
