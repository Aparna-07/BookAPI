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

        [HttpPost]
        public IHttpActionResult Post(Orders orders)
        {
            var data = repo.InsertOrder(orders);
            if (data == 0)
                return NotFound();
            return Ok(data);
        }

        [Route("api/order/item")]
        [HttpPost]
        public IHttpActionResult PostItem(OrderItem item)
        {
            var data = repo.InsertItem(item);
            return Ok(data);
        }
    }
}
