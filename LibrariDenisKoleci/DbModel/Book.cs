using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibrariDenisKoleci.DbModel
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Display(Name ="Category of the book")]
        public int CatgoryID { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Place In Shelf")]

        public string PlaceInShelf { get; set; }
        [Display(Name ="Number in stock")]
        [Range(1,20)]
        
        public int NumberAvaiable { get; set; }

        //[Required]
        //[ForeignKey("Status")]
        //[Display(Name ="Status of book")]
        //public int StatusID { get; set; }
        //public virtual Status Status { get; set; }  

    }
}