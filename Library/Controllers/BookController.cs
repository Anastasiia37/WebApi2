using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Models;

namespace Library.Controllers
{
    public class BookController : ApiController
    {
        private IRepository _repo = null;
        
        public BookController()
        {
            _repo = BookRepository.getInstance();            
        }

        // GET: api/book/names
        [Route("api/book/names")]        
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _repo.GetAll();
        }

        // GET: api/book/5
        [HttpGet]
        public IHttpActionResult GetBook(int id)
        {
            if (_repo.GetById(id) == null)
            {
                return NotFound();
            }            
            return Ok(_repo.GetById(id));
        }

        // POST: api/book
        [HttpPost]
        public void AddNewBook([FromBody]Book book)
        {
            _repo.Add(book);
            return;
        }

        // PUT: api/book/5
        [HttpPut]
        public void UpdateBook(int id, [FromBody]string author)
        {
            _repo.Update(id, author);
            return;
        }

        // DELETE: api/book/delete/5
        [Route("api/book/delete/{id}")]
        [HttpDelete]
        public void DeleteBook(int id)
        {
            _repo.DeleteBook(id);
            return;
        }
    }
}
