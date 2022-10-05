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
    public class CartController : ApiController
    {
        ICart cartRepo = new CartService();

        [HttpGet]
        public IHttpActionResult GetCart(int userId)
        {
            var data = cartRepo.GetCart(userId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/cart/gettotal")]
        [HttpGet]
        public IHttpActionResult GetCartTotal(int userId)
        {
            var data = cartRepo.GetTotal(userId);
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Cart cart)
        {
            var data = cartRepo.InsertCart(cart);
            return Ok(data);
        }
        
        [HttpPut]
        public IHttpActionResult Put(Cart cart)
        {
            var data = cartRepo.UpdateCart(cart);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Cart cart)
        {
            cartRepo.DeleteCart(cart);
            return Ok();
        }

        [Route("api/cart/deletecart")]
        [HttpDelete]
        public IHttpActionResult DeleteFull(int userId)
        {
            cartRepo.DeleteFullCart(userId);
            return Ok();
        }

    }
}
