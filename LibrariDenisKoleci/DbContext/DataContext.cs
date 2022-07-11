using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LibrariDenisKoleci.DbModel;
using LibrariDenisKoleci.Models;

namespace LibrariDenisKoleci
{
    //initialize every time we call db
    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(connectionString)
        {

        }

        public DataContext() : base("Data Source = ALESJA; " +
                                    "Initial Catalog = LibrariDKdb; " +
                                    "Integrated Security = True; " +
                                    "multipleactiveresultsets = True; " +
                                    "timeout = 1000; " +
                                    "Connection Timeout = 1000;")
        {

        }

        public DbSet<Book> Books { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Reader> Readers{ get; set; }

        public  DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }  
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}