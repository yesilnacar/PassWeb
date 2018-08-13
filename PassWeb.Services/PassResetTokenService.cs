using PassWeb.Domain.Models;
using PassWeb.Interfaces.IRepositories;
using PassWeb.Interfaces.IServices;
using System;
using System.Security.Cryptography;

namespace PassWeb.Services
{
    public class PassResetTokenService : IPassResetTokenService
    {
        private readonly IPassResetTokenRepository passResetTokenRepo;

        public PassResetTokenService(IPassResetTokenRepository _passResetTokenRepo)
        {
            passResetTokenRepo = _passResetTokenRepo;
        }

        public string GenerateToken(User user)
        {
            string token;

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] stringBuffer = new byte[sizeof(decimal)];
                rng.GetBytes(stringBuffer);

                token = BitConverter.ToString(stringBuffer, 0);
            }

            SaveTokenInfo(user, token);

            return token;
        }

        private void SaveTokenInfo(User user, string token)
        {
            var passResetToken = new PassResetToken()
            {
                Token = token,
                User = user,
                GeneratedDateTime = DateTime.Now
            };
            passResetTokenRepo.Add(passResetToken);
        }
    }
}
