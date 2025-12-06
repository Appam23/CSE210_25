using System;
using System.Collections.Generic;
using OrderingSystem;

class Program
    {
        static void Main()
        {
            // Create addresses
            Address addrUS = new Address("123 Main St", "Springfield", "IL", "USA");
            Address addrIntl = new Address("456 High Road", "London", "Greater London", "United Kingdom");

            // Create customers
            Customer customerUS = new Customer("Alice Johnson", addrUS);
            Customer customerIntl = new Customer("Mohammed Ali", addrIntl);

            // Create products
            Product p1 = new Product("Wireless Mouse", "WM-100", 25.99m, 2);
            Product p2 = new Product("Keyboard", "KB-200", 45.50m, 1);
            Product p3 = new Product("USB-C Cable", "UC-10", 8.75m, 3);
            Product p4 = new Product("Laptop Stand", "LS-55", 39.99m, 1);

            // Create first order (US customer)
            Order order1 = new Order(customerUS);
            order1.AddProduct(p1);
            order1.AddProduct(p2);

            // Create second order (International customer)
            Order order2 = new Order(customerIntl);
            order2.AddProduct(p3);
            order2.AddProduct(p4);

            // Display orders
            List<Order> orders = new List<Order> { order1, order2 };
            int idx = 1;
            foreach (Order order in orders)
            {
                Console.WriteLine($"Order #{idx}");
                Console.WriteLine("Packing Label:");
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine();
                Console.WriteLine("Shipping Label:");
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine();
                Console.WriteLine($"Total Price: {order.GetTotalPrice():C}");
                Console.WriteLine(new string('-', 40));
                idx++;
            }
        }
    }
