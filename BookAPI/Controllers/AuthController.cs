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
        [Route("api/auth/checkduplicate")]
        [HttpGet]
        public IHttpActionResult GetDuplicateEmail(string email)
        {
            var data = repository.CheckDuplicateEmail(email);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetUsers();
            return Ok(data);
        }

        [Route("api/auth/activate")]
        [HttpGet]
        public IHttpActionResult GetActivate(int userId)
        {
            repository.ActivateUser(userId);
            return Ok();
        }


        [Route("api/auth/deactivate")]
        [HttpGet]
        public IHttpActionResult GetDeactivate(int userId)
        {
            repository.DeactivateUser(userId);
            return Ok();
        }

        [Route("api/auth/updatename")]
        [HttpGet]
        public IHttpActionResult UpdateName(string name, [FromUri] int userId)
        {
            var data = repository.UpdateUsername(name, userId);
            return Ok(data);
        }

        [Route("api/auth/updateemail")]
        [HttpGet]
        public IHttpActionResult UpdateEmail(string email, [FromUri] int userId)
        {
            var data = repository.UpdateEmail(email, userId);
            return Ok(data);
        }

        [Route("api/auth/updatepass")]
        [HttpGet]
        public IHttpActionResult UpdatePassword(string password, int userId)
        {
            var data = repository.UpdatePassword(password, userId);
            return Ok(data);
        }
    }
}
