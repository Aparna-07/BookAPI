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
    public class AddressController : ApiController
    {
        IAddress addressRepo = new AddressService();

        [HttpGet]
        public IHttpActionResult Get(int userId)
        {
            var data = addressRepo.GetAddress(userId);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Address address)
        {
            var data = addressRepo.InsertAddress(address);
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult Put(Address address)
        {
            var data = addressRepo.UpdateAddress(address);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int userId)
        {
            addressRepo.DeleteAddress(userId);
            return Ok();
        }
    }
}
