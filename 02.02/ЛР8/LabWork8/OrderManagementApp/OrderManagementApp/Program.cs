﻿// Исходный код приложения для рефакторинга

using OrderManagementApp.Context;
using OrderManagementApp.Models;

namespace OrderManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();

            var customerService = new CustomerService(dbContext);
            var orderService = new OrderService(dbContext);

            var customer = new Customer { Name = "Alice", Email = "alice@example.com" };
            customerService.AddCustomer(customer);

            var order = new Order { Total = 1200, IsExpress = true, Customer = customer };
            orderService.AddOrder(order);

            customerService.PrintCustomerInfo(customer.Id);
            orderService.PrintOrderDetails(order.Id);

            Console.WriteLine("Final Price: " + orderService.CalculateFinalPrice(order));
        }
    }
}
