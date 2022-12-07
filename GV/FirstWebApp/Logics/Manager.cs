using FirstWebApp.Models;

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
            return context.Products.FirstOrDefault(x => x.ProductId == productId);
        }
    }
}
