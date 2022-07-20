using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryASPNETAlesja.DbModel
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
      
        [ForeignKey("Book")]
  
        [Display(Name = "Name of the book")]
        public int BookID { get; set; }
        public Book Book { get; set; }


        
        [ForeignKey("Reader")]
        [Display(Name = "Name of the reader")]
        public int ReaderID { get; set; }
        public Reader Reader { get; set; }

        //[Display(Name = "Date of rent")]
        //public DateTime DateOfRent { get; set; }


        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Date of return")]
        public string Status { get; set; }



    }
}