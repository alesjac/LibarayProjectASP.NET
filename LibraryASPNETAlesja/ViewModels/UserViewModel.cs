using LibraryASPNETAlesja.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryASPNETAlesja.ViewModels
{
    public class UserViewModel
    {

     
        public string FullName { get; set; }
        public string Username { get; set; }
        public int RoleID { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}