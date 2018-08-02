using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PassWeb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext()
        { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}