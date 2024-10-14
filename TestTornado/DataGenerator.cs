using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTornado
{
    public class DataGenerator
    {
        public static RootObject  GetData()
        {
            var data = new RootObject(GetStockItems(), GetCustomers());
            return data;
        }
            

        public static List<StockItem> GetStockItems()
        {
            var stock = new List<StockItem>
            {
                new() { Name = "Keyboard", Quantity = "200" },
                new () { Name = "Mouse", Quantity = "10000" },
                new () { Name = "Laptop", Quantity = "10" }
            };
            return stock;
        }

        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
            new Customer
            {
                Name = "约翰亨利 John Henry",
                Email ="john.henry@quantios.com",
                Orders =
                [
                    new()
                    {
                        Name = "Laptop", Id = "P001", Quantity = 1, Price = 1000m, Discount = 100m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Mouse", Id = "P002", Quantity = 2, Price = 25m, Discount = 0m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Keyboard", Id = "P003", Quantity = 1, Price = 50m, Discount = 0m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Laptop 2", Id = "P004", Quantity = 1, Price = 3000m, Discount = 10m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Mouse 2", Id = "P005", Quantity = 2, Price = 25m, Discount = 0m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Keyboard 2", Id = "P006", Quantity = 1, Price = 50m, Discount = 0m, OutOfStock = false
                    }
                ]
            },
            new Customer
            {
                Name = "Jane Smith",
                Email ="jane.smith@quantios.com",
                Orders = new List<Order>
                {
                     new()
                    {
                        Name = "Smartphone", Id = "P004", Quantity = 1, Price = 800m, Discount = 50m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Charger", Id = "P005", Quantity = 1, Price = 20m, Discount = 0m, OutOfStock = true
                    },
                     new()
                    {
                        Name = "Smartphone 2", Id = "P006", Quantity = 1, Price = 800m, Discount = 50m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Charger 2", Id = "P005", Quantity = 1, Price = 20m, Discount = 0m, OutOfStock = true
                    }
                }
            },
            new Customer
            {
                Name = "Alice Johnson",
                Email ="alice.johnson@quantios.com",
                Orders = new List<Order>
                {
                     new()
                    {
                        Name = "Tablet", Id = "P006", Quantity = 1, Price = 300m, Discount = 25m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Tablet Case", Id = "P007", Quantity = 1, Price = 30m, Discount = 5m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Stylus Pen", Id = "P008", Quantity = 1, Price = 15m, Discount = 0m, OutOfStock = true
                    },
                     new()
                    {
                        Name = "Tablet 2", Id = "P016", Quantity = 1, Price = 1500m, Discount = 10m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Tablet Case 2", Id = "P007", Quantity = 1, Price = 30m, Discount = 5m, OutOfStock = false
                    },
                     new()
                    {
                        Name = "Stylus Pen 2", Id = "P008", Quantity = 1, Price = 15m, Discount = 0m, OutOfStock = true
                    }
                }
            }
        };
            
        }
    }
}
