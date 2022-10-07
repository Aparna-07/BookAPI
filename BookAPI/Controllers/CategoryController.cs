using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookAPI.Models;
using System.Web.Http.Cors;

namespace BookAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        ICategory repository = new CategoryService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCategories();
            if (data == null)
                return NotFound();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var data = repository.GetCategoryById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/category/getbyname")]
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var data = repository.GetCategoryByName(name);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Post(Category cat)
        {
            var data = repository.InsertCategory(cat);
            return Ok(data);
        }
        [HttpPut]
        public IHttpActionResult Put(Category cat)
        {
            var data = repository.UpdateCategory(cat);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteCategory(id);
            return Ok();
        }
    }
}
