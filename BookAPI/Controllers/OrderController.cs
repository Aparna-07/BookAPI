using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookAPI.Controllers
{
    public class OrderController : ApiController
    {
        OrderService repo = new OrderService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repo.GetAllOrders();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/order/getitems")]
        [HttpGet]
        public IHttpActionResult GetItems(int orderId)
        {
            var data = repo.GetOrderItems(orderId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(int userId)
        {
            var data = repo.GetOrdersByUser(userId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
