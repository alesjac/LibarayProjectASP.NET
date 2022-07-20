using LibraryASPNETAlesja.DbModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryASPNETAlesja.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
   
        public string Author { get; set; }

        public int CatgoryID { get; set; }
        public virtual Category Category { get; set; }
        public string PlaceInShelf { get; set; }
        public int NumberInStock { get; set; }
        public int NumberAvaiable { get; set; }
    }
}