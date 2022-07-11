using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrariDenisKoleci.DbModel
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}