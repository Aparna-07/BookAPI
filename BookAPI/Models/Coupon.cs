using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Coupon
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
        public int MinimumSpend { get; set; }
        public DateTime Expiry { get; set; }

        public Coupon(string code, string description, int discount, int minimumSpend, DateTime expiry)
        {
            Code = code;
            Description = description;
            Discount = discount;
            MinimumSpend = minimumSpend;
            Expiry = expiry;
        }
    }
}