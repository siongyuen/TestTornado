using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado
{
    public class RootObject
    {
        public RootObject(List<StockItem> stockItems, List<Customer> customers) 
        { 
            Stock = stockItems;
            Customers = customers;

        }
        public List<StockItem> Stock { get; set; }
        public List<Customer> Customers { get; set; }
        
    }

    public class StockItem
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }

    public class Customers
    {
        public List<Customer> customers { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool OutOfStock { get; set; }
    }
}
