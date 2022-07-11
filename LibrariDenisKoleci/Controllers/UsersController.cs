using LibrariDenisKoleci.DbModel;

using LibrariDenisKoleci.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Security;

namespace LibrariDenisKoleci.Controllers
{
    public class UsersController : Controller
    {
        private DataContext _dataContext;

        public UsersController()
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
            var users = _dataContext.Users.Include(x => x.UserRole).ToList();
            return View(users);
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}
        //public ActionResult Signup()
        //{
        //    return View();
        //}
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Users");
        }
        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult LoginSettings(LoginViewModel loginView)
        {
            
            bool userExists = _dataContext.Users.Any(x => x.Username == loginView.Username
            && x.Password == loginView.Password);

            var user = _dataContext.Users.FirstOrDefault(x => x.Username == loginView.Username
            && x.Password == loginView.Password);

            if (userExists)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }

         //   ModelState.AddModelError("", "Username or password is wrong. Please try again!");
           //ViewBag.Message = "Username or password is wrong. Please try again!";
            return View("LoginFailure", loginView);

        }
        public ActionResult SignUp()
        {
            //    _dataContext.Users.Add(user);
            //    _dataContext.SaveChanges(); 
            //    return RedirectToAction("Login");
            var roles = _dataContext.UserRoles.ToList();
            var signupViewModel = new SignupViewModel
            {
                UserRoles = roles,
                User = new User()
            };
            return View(signupViewModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {

                return View("New", user);
            }

            if (user.Id == 0)
                _dataContext.Users.Add(user);
            else
            {
                var userInDb = _dataContext.Users.Single(c => c.Id == user.Id);
                userInDb.FullName = user.FullName;
                userInDb.Username = user.Username;
                userInDb.Password = user.Password;
                userInDb.UserRoleID = user.UserRoleID;
            }

            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var userInDb = _dataContext.Users.Single(c => c.Id == id);
            _dataContext.Users.Remove(userInDb);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Users");

        }
    }
}