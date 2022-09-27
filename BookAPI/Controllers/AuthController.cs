using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookAPI.Controllers
{
    public class AuthController : ApiController
    {
        AuthService repository = new AuthService();

        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            var data = repository.Register(user);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(Credentials credentials)
        {
            var data = repository.Login(credentials);
            if (data == null)
                return NotFound();
            return Ok(data);
        }
    }
}
