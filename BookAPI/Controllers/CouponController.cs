using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CouponController : ApiController
    {
        ICoupon repository = new CouponService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCoupon();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(decimal total)
        {
            var data = repository.GetCoupon(total);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/coupon/getbycode")]
        [HttpGet]
        public IHttpActionResult GetByCode(string code)
        {
            var data = repository.GetCouponByCode(code);
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
