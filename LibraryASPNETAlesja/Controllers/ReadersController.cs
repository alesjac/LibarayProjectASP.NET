using LibraryASPNETAlesja.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryASPNETAlesja.Controllers
{
    public class ReadersController : Controller
    {

        private DataContext _dataContext;

        public ReadersController()
        {
            _dataContext = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
        }
        // GET: Readers
        public ActionResult Index()
        {
            var readers = _dataContext.Readers.ToList();
            return View(readers);
        }

        public ActionResult New()
        {
            var readers = new Reader();


            return View(readers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Reader reader)
        {
            if (!ModelState.IsValid)
            {
                return View("New", reader);
            }

            if (reader.Id == 0)
                _dataContext.Readers.Add(reader);
            else
            {
                var readerInDb = _dataContext.Readers.Single(c => c.Id == reader.Id);
                readerInDb.FullName = reader.FullName;
            }

            _dataContext.SaveChanges();

            //TODO jo index por tek rental a book
            return RedirectToAction("Index", "Readers");
            //other TODO rregullo display name te fields
        }

        public ActionResult Edit(int id)
        {
            var reader = _dataContext.Readers.SingleOrDefault(c => c.Id == id);
            if (reader == null)
                return HttpNotFound();

            return View("New", reader);
        }
    }
}