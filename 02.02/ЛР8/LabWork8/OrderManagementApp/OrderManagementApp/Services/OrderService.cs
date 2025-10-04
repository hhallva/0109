using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Context;

namespace OrderManagementApp
{
    // Сервис для работы с заказами
    public class OrderService
    {
        private readonly AppDbContext _dbContext;
        const int DiscountMinAmount = 10000;
        const double DiscountPercent = 0.1;
        const double Tax = 0.2;

        public OrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void PrintOrderDetails(int orderId)
        {
            var order = _dbContext.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == orderId);
            Console.WriteLine("Order Id: " + order.Id);
            Console.WriteLine("Total: " + order.Total);
            Console.WriteLine("Express Shipping: " + (order.IsExpress ? "Yes" : "No"));
            Console.WriteLine("Customer Email: " + order.Customer.Email);
        }

        public double CalculateFinalPrice(Order order)
        {
            double discount = 0;

            if (order.Total > DiscountMinAmount)
                discount = order.Total * DiscountPercent;
            return order.Total - discount + (order.Total * Tax);
        }
    }
}
