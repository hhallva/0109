namespace OrderManagementApp.Models
{
    // Класс Customer (клиент)
    public class Customer
    {
        public int Id { get; set; }
        public string Name;
        public string Email;
        public List<Order> Orders { get; set; }
    }
}
