using MyDrSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyDrSite.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}