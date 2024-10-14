using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado.Models
{
  
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
