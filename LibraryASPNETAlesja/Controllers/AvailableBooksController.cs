using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LibraryASPNETAlesja.DbModel;

namespace LibraryASPNETAlesja.Controllers
{
    public class AvailableBooksController : Controller
    {
        private DataContext _dataContext;
        public AvailableBooksController()
        {
            _dataContext = new DataContext();

        }
        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
        }


        [HttpGet]
        public ActionResult Index()
        {
            var rentals = _dataContext.Rents.
                    Include(c => c.Book).Include(c => c.Reader).ToList();
            IEnumerable<Book> books; 


                // Create a collection of person-pet pairs. Each element in the collection
                // is an anonymous type containing both the person's name and their pet's name.
            books =
    (from b in _dataContext.Books
     join r in _dataContext.Rents on b.Id equals r.BookID
     where r.Status == "Returned" select b).ToList();



          

            return View(books);
        }
    }
}