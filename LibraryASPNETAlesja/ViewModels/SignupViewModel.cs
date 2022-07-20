using LibraryASPNETAlesja.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryASPNETAlesja.ViewModels
{
    public class SignupViewModel
    {
        public User User { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}