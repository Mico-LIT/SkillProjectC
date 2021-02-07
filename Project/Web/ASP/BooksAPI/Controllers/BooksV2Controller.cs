using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BooksAPI.Models.Books;

namespace BooksAPI.Controllers
{
    public class BooksV2Controller : ApiController
    {
        private BooksAPIContext _booksDb = new BooksAPIContext();

        [HttpGet]
        public IHttpActionResult Books()
        {
            return Ok(_booksDb.Books);
        }

        [HttpGet]
        public IHttpActionResult Book(int entityId)
        {
            var book = _booksDb.Books.FirstOrDefault(x => x.BookId == entityId);
            if (book == null)
                return NotFound();

            return Ok(_booksDb.Books);
        }

        [HttpGet]
        [Route("~/api/BooksV2/BookByHtml")]
        public IHttpActionResult BookByHtml()
        {
            return new HttpContentResult(_booksDb.Books.First());
        }
    }
}
