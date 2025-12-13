using System;

namespace EventPlanning
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateProvince;
        private string _country;

        public Address(string street, string city, string stateProvince, string country)
        {
            _street = street;
            _city = city;
            _stateProvince = stateProvince;
            _country = country;
        }

        public string Street => _street;
        public string City => _city;
        public string StateProvince => _stateProvince;
        public string Country => _country;

        public string GetFullAddress()
        {
            return $"{Street}, {City}, {StateProvince}, {Country}";
        }
    }
}