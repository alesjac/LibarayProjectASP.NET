using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace LibraryASPNETAlesja
{
    public class LContextFactory : IDbContextFactory<DataContext>
    {
        public DataContext Create()
        { 
            return new DataContext();   
        }
    }
}