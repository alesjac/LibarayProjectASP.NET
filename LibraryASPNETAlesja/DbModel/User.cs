using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LibraryASPNETAlesja.DbModel
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full name of user")]
        public string FullName { get; set; }
        public string Username { get; set; }

        
        public string Password { get; set; }

        [Required]
        [ForeignKey("UserRole")]
        [Display(Name = "Role of the user")]
        public int UserRoleID { get; set; }
        public  UserRole UserRole { get; set; }
    }

    

    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}