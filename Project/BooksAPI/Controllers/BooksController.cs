using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BooksAPI.App_Start.Attribute;
using BooksAPI.DTOs;
using BooksAPI.Models;

// TODO API
namespace BooksAPI.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BooksAPIContext db = new BooksAPIContext();

        private static readonly Expression<Func<Book, BookDto>> AsBookDto =
        x => new BookDto
        {
            Title = x.Title,
            Author = x.Author.Name,
            Genre = x.Genre
        };

        // GET: api/Books
        [Route("")]
        public IQueryable<BookDto> GetBooks()
        {
            return db.Books.Include(b=>b.Author).Select(AsBookDto);
        }

        [Route("~/api/Authors/{authorId:int}/books")]
        public IQueryable<BookDto> GetBookByAuthor(int authorId)
        {
            return db.Books.Include(x => x.Author)
                .Where(x => x.Author.AuthorId == authorId)
                .Select(AsBookDto);
        }

        [Route("date/{pubdate:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
        [Route("date/{*pubdate:datetime:regex(\\d{4}/\\d{2}/\\d{2})}")]
        public IQueryable<BookDto> GetBooks(DateTime pubdate)
        {
            return db.Books
                .Where(x => DbFunctions.TruncateTime(x.PublishDate) == DbFunctions.TruncateTime(pubdate))
                .Select(AsBookDto);
        }

        // GET: api/Books/5
        [Route("{id:int}")]
        [ResponseType(typeof(BookDto))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookDto book = await db.Books
                .Where(x=>x.BookId == id)
                .Include(x=>x.Author)
                .Select(AsBookDto)
                .FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [Route("{id:int}/details")]
        [ResponseType(typeof(BookDetailDto))]
        public async Task<IHttpActionResult> GetBookDetail(int id)
        {
            BookDetailDto bookDetailDto = await db.Books.
                Where(x => x.BookId == id).
                Include(x => x.Author).
                Select(x => new BookDetailDto()
                {
                    Author = x.Author.Name,
                    Description = x.Description,
                    Genre = x.Genre,
                    Price = x.Price,
                    PublishDate = x.PublishDate,
                    Title = x.Title
                }).FirstOrDefaultAsync();

            if (bookDetailDto == null)
            {
                return NotFound();
            }

            return Ok(bookDetailDto);
        }

        [Route("{genre}")]
        public IQueryable<BookDto> GetBooksByGenre(string genre)
        {
            return db.Books.
                Where(x => x.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).
                Select(AsBookDto);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BookId)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [Route("")]
        //[ValidateModel]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookId == id) > 0;
        }
    }
}