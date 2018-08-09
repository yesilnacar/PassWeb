using PassWeb.Domain.Models;
using System.Data.Entity;

namespace PassWeb.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext() : base("name=ApplicationDbContext")
        { }
    }
}