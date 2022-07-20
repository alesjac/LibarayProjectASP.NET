using AutoMapper;
using LibraryASPNETAlesja.DbModel;
using LibraryASPNETAlesja.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryASPNETAlesja.App_Start
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            Mapper.CreateMap<Book, BookDTO>();
            Mapper.CreateMap<BookDTO, Book>();
            
        }
    }
}