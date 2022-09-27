using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookAPI.Controllers
{
    public class WishlistController : ApiController
    {
        IWishlist wishRepo = new WishlistService();

        [HttpGet]
        public IHttpActionResult Get(int userId)
        {
            var data = wishRepo.GetWishlist(userId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Wishlist wishlist)
        {
            var data = wishRepo.InsertWishlist(wishlist);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(Wishlist wishlist)
        {
            wishRepo.DeleteWishlist(wishlist);
            return Ok();
        }
    }
}
