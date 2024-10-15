

namespace TestTornado
{
    public class RootObject
    {   
        public List<StockItem> Stock { get; set; }
        public List<Customer> Customers { get; set; }
        public string dispatchLabel { get; set; }        
    }

    public class StockItem
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }

  
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
    public class Order
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool OutOfStock { get; set; }
    }
}
