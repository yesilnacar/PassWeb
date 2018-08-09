using PassWeb.Domain.Models;
using PassWeb.Interfaces.IRepositories;
using PassWeb.Interfaces.IServices;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PassWeb.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepo;

        public LoginService(IUserRepository _userRepo)
        {
            userRepo = _userRepo;
        }

        public bool AreValidUserCredentials(string userName, string password)
        {
            User user = userRepo.FindByUserName(userName);

            if (user == null)
                return false;

            string hashedPassword = GenerateHashedPassword(user.Salt, password);
            if (hashedPassword.Equals(user.HashedPassword))
                return true;

            return false;
        }

        private string GenerateHashedPassword(string salt, string password)
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(salt + password));
                return Convert.ToBase64String(computedHash);
            }
        }
    }
}
