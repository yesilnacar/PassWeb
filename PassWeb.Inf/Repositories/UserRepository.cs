using PassWeb.Domain.Models;
using PassWeb.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PassWeb.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        ApplicationDbContext _context;

        public UserRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.AsEnumerable();
        }

        public User FindByEmail(string email)
        {
            return _context.Users.Where(p => p.EMailAddress == email).SingleOrDefault();
        }

        public User FindByUserName(string userName)
        {
            return _context.Users.Where(p => p.UserName == userName).SingleOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
