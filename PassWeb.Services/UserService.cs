using PassWeb.Domain.Models;
using PassWeb.Interfaces.IRepositories;
using PassWeb.Interfaces.IServices;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PassWeb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;

        public UserService(IUserRepository _userRepo)
        {
            userRepo = _userRepo;
        }

        public void Add(RegisterViewModel registerVM)
        {
            var user = new User
            {
                UserName = registerVM.UserName,
                EMailAddress = registerVM.Email
            };
            GenerateHashedPassword(registerVM.Password, user);

            userRepo.Add(user);
        }

        private void GenerateHashedPassword(string password, User user)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] stringBuffer = new byte[sizeof(decimal)];
                rng.GetBytes(stringBuffer);

                user.Salt = BitConverter.ToString(stringBuffer, 0);
            }

            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(user.Salt + password));
                user.HashedPassword = Convert.ToBase64String(computedHash);
                user.Hash = sha.Hash;
            }
        }

        public User Find(string email)
        {
            return userRepo.FindByEmail(email);
        }
    }
}
