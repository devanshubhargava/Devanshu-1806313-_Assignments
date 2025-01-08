using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Country.Models;

namespace Country.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=ConnectionToDatabse")
        {
        }

        public DbSet<Contry> Countries { get; set; }
    }
}