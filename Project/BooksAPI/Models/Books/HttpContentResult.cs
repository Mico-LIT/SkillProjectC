using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BooksAPI.Models.Books
{
    public class HttpContentResult : IHttpActionResult
    {
        private readonly Book model;

        public HttpContentResult(Book book)
        {
            this.model = book;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            string bookInfo = "<html><head><meta charset=utf-8 /></head></body>" +
         "<h1>" + model.Title + "</h1><p>" + model.Genre + "</p><p>"
         + model.Description + "</p>" + "</body></html>";

            var response = new HttpResponseMessage();

            response.Content = new StringContent(bookInfo);

            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");

            return Task.FromResult(response);
        }
    }
}