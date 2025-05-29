using System;
using System.Collections.Generic;
using System.Text;

namespace ProductOrderingSystem
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public string GetStreet() => _street;
        public string GetCity() => _city;
        public string GetStateOrProvince() => _stateOrProvince;
        public string GetCountry() => _country;

        public bool IsInUSA()
        {
            string countryLower = _country.Trim().ToLower();
            return countryLower == "usa" ||
                   countryLower == "united states" ||
                   countryLower == "united states of america";
        }

        public string GetFullAddress()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }

    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName() => _name;
        public Address GetAddress() => _address;

        public bool IsInUSA()
        {
            return _address.IsInUSA();
        }
    }

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

        public string GetName() => _name;
        public string GetProductId() => _productId;
        public decimal GetPricePerUnit() => _pricePerUnit;
        public int GetQuantity() => _quantity;

        public decimal GetTotalCost()
        {
            return _pricePerUnit * _quantity;
        }
    }

    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(List<Product> products, Customer customer)
        {
            _products = products;
            _customer = customer;
        }

        public List<Product> GetProducts() => _products;
        public Customer GetCustomer() => _customer;

        public decimal CalculateTotalCost()
        {
            decimal productsTotal = 0;
            foreach (Product product in _products)
            {
                productsTotal += product.GetTotalCost();
            }
            decimal shipping = _customer.IsInUSA() ? 5m : 35m;
            return productsTotal + shipping;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (Product product in _products)
            {
                sb.AppendLine($"Product: {product.GetName()}, ID: {product.GetProductId()}");
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Shipping Label:");
            sb.AppendLine(_customer.GetName());
            sb.AppendLine(_customer.GetAddress().GetFullAddress());
            return sb.ToString();
        }
    }
}