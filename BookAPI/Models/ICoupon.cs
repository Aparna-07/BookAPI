using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface ICoupon
    {
        Coupon GetCoupon(decimal total);
        Coupon InsertCoupon(Coupon coupon);
        Coupon UpdateCoupon(Coupon coupon);
        void DeleteCoupon(string code);
    }
}
