using PassWeb.Domain.Models;
using PassWeb.Infrastructure;
using PassWeb.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassWeb.Inf.Repositories
{
    public class PassResetTokenRepository : IPassResetTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public PassResetTokenRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Add(PassResetToken token)
        {
            _context.PassResetTokens.Add(token);
            _context.SaveChanges();
        }
    }
}
