using LibrariDenisKoleci.DbModel;
using LibrariDenisKoleci.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrariDenisKoleci.Controllers
{
    public class RentsController : Controller
    {
        private DataContext _dataContext;
        public RentsController()
        {
            _dataContext = new DataContext();

        }
        protected override void Dispose(bool disposing)
        {
            _dataContext.Dispose();
        }

        [HttpGet]
        public ActionResult ListOfBookRents()
        {
            // var books = _dataContext.Books.Include(x => x.Category).ToList();
            return View();
        }



        public ActionResult NewBookRentForm()
        {
            var books = _dataContext.Books.ToList();
            var readers = _dataContext.Readers.ToList();

            var viewModel = new BookRentViewModel
            {
                Books = books,
                Readers = readers,
                Rent = new Rent()
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookRentViewModel
                {
                    Rent = rent,
                    Books = _dataContext.Books.ToList(),
                    Readers = _dataContext.Readers.ToList(),
                };

                return View("NewBookLoanForm", viewModel);
            }


            
            var bookFromDbSelected = _dataContext.Books.FirstOrDefault(m => m.Id == rent.BookID);
            var rentAlreadyInDb = _dataContext.Rents.FirstOrDefault(m => m.BookID == rent.BookID && m.ReaderID == rent.ReaderID);
            if (rentAlreadyInDb==null)
            {


                if (rent.Id == 0)
                {

                    if (bookFromDbSelected.NumberAvaiable == 0)
                    {
                        return View("Sorry", bookFromDbSelected);
                    }

                    
                    if (bookFromDbSelected.NumberAvaiable > 0)
                    {
                        try
                        {
                            bookFromDbSelected.NumberAvaiable--;
                            rent.Status = "Rented"; 
                            _dataContext.Rents.Add(rent);

                            _dataContext.SaveChanges();
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }

                        }
                    }
                    //else
                    //{
                    //    try
                    //    {
                    //        rent.Status = "Rented";
                    //        _dataContext.Rents.Add(rent);
                    //        _dataContext.SaveChanges();
                    //    }
                    //    catch (DbEntityValidationException ex)
                    //    {
                    //        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    //        {
                    //            foreach (var validationError in entityValidationErrors.ValidationErrors)
                    //            {
                    //                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    //            }
                    //        }

                    //    }

                    //}


                }
                //else
                //{

                //    var rentInDb = _dataContext.Rents.FirstOrDefault(m => m.Id == rent.Id);
                //    rentInDb.BookID = rent.BookID;
                //    rentInDb.ReaderID = rent.ReaderID;

                //    rentInDb.Status = rent.Status;


                //    if (rent.Status.Equals("Returned"))
                //        bookFromDbSelected.NumberAvaiable++;
                //    if (rent.Status.Equals("Rented"))
                //        bookFromDbSelected.NumberAvaiable--;
                //    _dataContext.SaveChanges();
                //}

            }else
            //if (rentAlreadyInDb.BookID==rent.BookID && rentAlreadyInDb.ReaderID==rent.ReaderID)
            {
                //   return Content("<script language='javascript' type='text/javascript'>alert('There is already a rent record with these details. Try again!');</script>");
               
                if (rent.Status != rentAlreadyInDb.Status)
                {

                    

                    try
                    {
                        var rentInDb = _dataContext.Rents.FirstOrDefault(m => m.Id == rent.Id);
                        if (rentInDb == null)
                        {
                            var viewModel = new BookRentViewModel
                            {
                                Rent = rent,
                                Books = _dataContext.Books.ToList(),
                                Readers = _dataContext.Readers.ToList(),
                            };
                            ViewBag.Message = "There is already a rent record with these details. Try again!";
                            return View("NewBookRentForm", viewModel);
                        }
                        rentInDb.BookID = rent.BookID;
                        rentInDb.ReaderID = rent.ReaderID;
                        //rentInDb.DateOfRent=rent.DateOfRent;

                        rentInDb.Status = rent.Status;
                        //rentInDb.DateReturned=rent.DateReturned;


                        if (rent.Status.Equals("Returned"))
                            bookFromDbSelected.NumberAvaiable++;
                        if (rent.Status.Equals("Rented"))
                            bookFromDbSelected.NumberAvaiable--;
                        _dataContext.SaveChanges();
                    }
                      catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }

                    }
                }
                else
                {
                    //var viewModel = new BookRentViewModel
                    //{
                    //    Rent = rent,
                    //    Books = _dataContext.Books.ToList(),
                    //    Readers = _dataContext.Readers.ToList(),
                    //};
                    //ViewBag.Message = "There is already a rent record with these details. Try again!";
                    //return View("NewBookRentForm", viewModel);
                }
                
                
            }
            



           // _dataContext.SaveChanges();

            return RedirectToAction("ListOfBookRents", "Rents");
        }


        public ActionResult Edit(int id)
        {
            var rent = _dataContext.Rents.SingleOrDefault(c => c.Id == id);
            if (rent == null)
                return HttpNotFound();

            var viewModel = new BookRentViewModel
            {
                Rent = rent,
                Readers = _dataContext.Readers.ToList(),
                Books = _dataContext.Books.ToList()

            };


            return View("NewBookRentForm", viewModel);
        }
    }
}