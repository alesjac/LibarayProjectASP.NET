using LibrariDenisKoleci.DbModel;
using LibrariDenisKoleci.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LibrariDenisKoleci.Controllers
{
    public class BooksController : Controller
    {

        private DataContext _dataContext;

        public BooksController()
        {
            _dataContext = new DataContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
        }


        // GET: Books
        [HttpGet]
        public ActionResult Index()
        {
           // var books = _dataContext.Books.Include(x => x.Category).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult ViewBook()
        {
            var books = _dataContext.Books.Include(x => x.Category).ToList();
            return View(books);
        }

        //Add new book
        public ActionResult New()
        {
            var categories = _dataContext.Categories.ToList();
            var viewModel = new NewBookViewModel
            {
                Book = new Book(),
                Categories = categories
            };
            return View(viewModel);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewBookViewModel
                {
                    Book = book,
                    Categories = _dataContext.Categories.ToList()
                };

                return View("New", viewModel);
            }

            if (book.Id == 0)
                _dataContext.Books.Add(book);
            else
            {
                var bookInDb = _dataContext.Books.FirstOrDefault(c => c.Id == book.Id);
                bookInDb.Title = book.Title;
                bookInDb.Author = book.Author;
                bookInDb.CatgoryID = book.CatgoryID;
                bookInDb.PlaceInShelf = book.PlaceInShelf;
            }
         
            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var book = _dataContext.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();

            var viewModel = new NewBookViewModel
            {
                Book = book,
                Categories = _dataContext.Categories.ToList()

            };
            return View("New", viewModel);
        }
    }
}