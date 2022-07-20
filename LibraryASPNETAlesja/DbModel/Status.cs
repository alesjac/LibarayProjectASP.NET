﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryASPNETAlesja.DbModel
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }    
    }
}