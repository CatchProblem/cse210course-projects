using System;
using System.Collections.Generic;
using ProductOrderingSystem;

namespace ProductOrderingSystemDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Addresses
            Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
            Address address2 = new Address("456 King Rd", "Toronto", "ON", "Canada");

            // Create Customers
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            // Create Products
            Product prod1 = new Product("Widget", "W123", 10.0m, 2);
            Product prod2 = new Product("Gadget", "G456", 5.5m, 3);
            Product prod3 = new Product("Thingamajig", "T789", 7.25m, 1);

            Product prod4 = new Product("Doohickey", "D321", 12.99m, 2);
            Product prod5 = new Product("Whatsit", "W654", 4.75m, 4);

            // Create Orders
            List<Product> order1Products = new List<Product> { prod1, prod2, prod3 };
            List<Product> order2Products = new List<Product> { prod4, prod5 };

            Order order1 = new Order(order1Products, customer1);
            Order order2 = new Order(order2Products, customer2);

            // Display Order 1 Details
            Console.WriteLine("ORDER 1");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");

            // Display Order 2 Details
            Console.WriteLine("ORDER 2");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}\n");
        }
    }
}