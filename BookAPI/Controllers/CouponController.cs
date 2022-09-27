using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookAPI.Controllers
{
    public class CouponController : ApiController
    {
        ICoupon repository = new CouponService();

        [HttpGet]
        public IHttpActionResult Get(decimal total)
        {
            var data = repository.GetCoupon(total);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Coupon coupon)
        {
            var data = repository.InsertCoupon(coupon);
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Put(Coupon coupon)
        {
            var data = repository.UpdateCoupon(coupon);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string code)
        {
            repository.DeleteCoupon(code);
            return Ok();
        }
    }
}
