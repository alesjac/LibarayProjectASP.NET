using LibrariDenisKoleci.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrariDenisKoleci.ViewModels
{
    public class NewBookViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Book Book { get; set; }
        //public IEnumerable<Reader> Readers { get; set; }
    }
}