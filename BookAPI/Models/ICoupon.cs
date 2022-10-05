using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface ICoupon
    {
        List<Coupon> GetCoupon(decimal total);
        List<Coupon> GetAllCoupon();
        Coupon GetCouponByCode(string code);
        Coupon InsertCoupon(Coupon coupon);
        Coupon UpdateCoupon(Coupon coupon);
        void DeleteCoupon(string code);
    }
}
