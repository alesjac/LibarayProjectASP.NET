using AutoMapper;
using LibraryASPNETAlesja.DbModel;
using LibraryASPNETAlesja.DTO;
using System;
using System.Data.Entity;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryASPNETAlesja.Controllers.API
{
    public class BooksController : ApiController
    {
        private DataContext _dataContext;

        public BooksController()
        {
            _dataContext = new DataContext();   
        }

        // GET /api/books -- by convention
        public IEnumerable<Book> GetBooks()
        {
            return _dataContext.Books
                    .Include(c => c.Category).ToList();
        }

        public IHttpActionResult GetBook(int id)
        { 
            var book = _dataContext.Books.SingleOrDefault(c=>c.Id == id);
            if (book == null)
                return NotFound();  

            return Ok(book);
        }

       
        //POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(Book book)
        {
            //validate object
            if (!ModelState.IsValid)
                return BadRequest();

            

            _dataContext.Books.Add(book);   
            _dataContext.SaveChanges();


           
            return Created(new Uri(Request.RequestUri+"/"+book.Id), book);

        }


        //PUT /api/books
        [HttpPut]
        public void UpdateBook(int id, Book book)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var bookInDb = _dataContext.Books.SingleOrDefault(c => c.Id == id);

            if(bookInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            _dataContext.SaveChanges();
        }


        //DELETE /api/books
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
                var bookInDb = _dataContext.Books.SingleOrDefault(c => c.Id == id);

                if (bookInDb == null)
                       return NotFound();


            _dataContext.Books.Remove(bookInDb);

                _dataContext.SaveChanges();

                return Ok();
  
        }
    }
}
