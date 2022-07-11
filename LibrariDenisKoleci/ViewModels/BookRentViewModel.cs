using LibrariDenisKoleci.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrariDenisKoleci.ViewModels
{
    public class BookRentViewModel
    {
        public Rent Rent { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Reader> Readers { get; set; }
    }
}