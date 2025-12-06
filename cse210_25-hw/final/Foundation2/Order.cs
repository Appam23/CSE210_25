using System;
using System.Collections.Generic;
using System.Text;

    public class Order
    {
        private Customer _customer;
        private List<Product> _products;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (Product product in _products)
            {
                total += product.GetTotalCost();
            }

            // Add shipping cost
            if (_customer.LivesInUSA())
            {
                total += 5.00m;
            }
            else
            {
                total += 35.00m;
            }

            return total;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Product product in _products)
            {
                sb.AppendLine($"{product.Name} (ID: {product.ProductId})");
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            return $"{_customer.Name}\n{_customer.Address.GetAddressString()}";
        }
    }
