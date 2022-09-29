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
    public class AuthController : ApiController
    {
        AuthService repository = new AuthService();

        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            var data = repository.Register(user);
            return Ok(data);
        }

        [Route("api/auth/login")]
        [HttpPost]
        public IHttpActionResult Post(Credentials credentials)
        {
            var data = repository.Login(credentials);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult Get(string email)
        {
            var data = repository.CheckAdmin(email);
            return Ok(data);
        }
    }
}
