using AutoMapper;
using LibrariDenisKoleci.DbModel;
using LibrariDenisKoleci.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrariDenisKoleci.App_Start
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