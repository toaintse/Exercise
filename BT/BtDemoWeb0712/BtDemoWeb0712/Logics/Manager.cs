using BtDemoWeb0712.Models;

namespace BtDemoWeb0712.Logics
{
    public class Manager
    {
        NorthwindContext context;
        public Manager()
        {
            context = new NorthwindContext();
        }

        public Customer GetCustomer(string customerId)
        {
            return context.Customers.FirstOrDefault(x => x.CustomerId.Equals(customerId));
        }

        public Order GetOrder(int orderId)
        {
            return context.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }
    }
}
