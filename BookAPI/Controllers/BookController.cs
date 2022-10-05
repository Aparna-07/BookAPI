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
    public class BookController : ApiController
    {
        IBook repository = new BookService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBooks();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/book/getbyid")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var data = repository.GetBookById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/book/getbytitle")]
        [HttpGet]
        public IHttpActionResult GetByTitle(string name)
        {
            var data = repository.GetBookByName(name);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/book/getbycatid")]
        [HttpGet]
        public IHttpActionResult GetByCatId(int id)
        {
            var data = repository.GetBookByCatId(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/book/getbycatname")]
        [HttpGet]
        public IHttpActionResult GetByCatName(string name)
        {
            var data = repository.GetBookByCatName(name);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/book/getbyauthor")]
        [HttpGet]
        public IHttpActionResult GetByAuthor(string author)
        {
            var data = repository.GetBookByAuthor(author);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/book/getbyisbn")]
        [HttpGet]
        public IHttpActionResult GetByISBN(long isbn)
        {
            var data = repository.GetBookByISBN(isbn);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("api/book/getbyfeatured")]
        [HttpGet]
        public IHttpActionResult GetByFeatured()
        {
            var data = repository.GetFeaturedBooks();
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            var data = repository.InsertBook(book);
            return Ok(data);
        }
        [HttpPut]
        public IHttpActionResult Put(Book book)
        {
            var data = repository.UpdateBook(book);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            repository.DeleteBook(id);
            return Ok();
        }
    }
}
