using System;

namespace OrderingSystem
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

        // Returns true if the address is in the USA (accepts common variants)
        public bool IsInUSA()
        {
            if (string.IsNullOrWhiteSpace(_country)) return false;
            string countryNormalized = _country.Trim().ToLowerInvariant();
            return countryNormalized == "usa"
                || countryNormalized == "us"
                || countryNormalized == "united states"
                || countryNormalized == "united states of america";   
        }

        // Returns a multi-line address suitable for a shipping label
        public string GetAddressString()
        {
            return $"{Street}\n{City}, {StateProvince}\n{Country}";
        }
    }
}