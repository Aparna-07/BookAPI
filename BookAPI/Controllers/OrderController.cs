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

        [Route("api/order/getbyuser")]
        [HttpGet]
        public IHttpActionResult GetByUser(int userId)
        {
            var data = repo.GetOrderByUser(userId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/order/getitems")]
        [HttpGet]
        public IHttpActionResult GetOrderItems(int orderId)
        {
            var data = repo.GetOrderItems(orderId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            var data = repo.InsertOrder(order);
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
