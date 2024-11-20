namespace RaizesUrbanaWeb.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public User User { get; set; }
        public decimal Total { get; set; }
    }


public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
