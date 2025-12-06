using System;

namespace OrderingSystem
{
    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _pricePerUnit;
        private int _quantity;

        public Product(string name, string productId, decimal pricePerUnit, int quantity)
        {
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity;
        }

        public string Name => _name;
        public string ProductId => _productId;
        public decimal PricePerUnit => _pricePerUnit;
        public int Quantity => _quantity;

        public decimal GetTotalCost()
        {
            return _pricePerUnit * _quantity;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {ProductId}) x{Quantity} @ {PricePerUnit:C} each";
        }
    }
}