using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Building { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Pincode { get; set; }
        public int UserId { get; set; }

        public Address(int addressId, string building, string city, string country, int pincode, int userId)
        {
            AddressId = addressId;
            Building= building;
            City = city;
            Country = country;
            Pincode = pincode;
            UserId = userId;

        }
    }
}