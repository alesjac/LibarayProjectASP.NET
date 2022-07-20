using LibraryASPNETAlesja.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryASPNETAlesja.Controllers
{
    public class CategoriesController : Controller
    {
        private DataContext _dataContext;
        public CategoriesController()
        {
            _dataContext = new DataContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
        }
        // GET: Categories/index
        public ViewResult Index()
        {
            var categories = _dataContext.Categories.ToList();
            return View(categories);
        }


        public ActionResult New()
        {
            var categories = new Category();


            return View(categories);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("New", category);
            }

            if (category.Id == 0)
                _dataContext.Categories.Add(category);
            else
            {
                var categoryInDb = _dataContext.Categories.Single(c => c.Id == category.Id);
                categoryInDb.Name = category.Name;
            }

            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }

        public ActionResult Edit(int id)
        {
            var category = _dataContext.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return HttpNotFound();

            return View("New", category);
        }
    }
}