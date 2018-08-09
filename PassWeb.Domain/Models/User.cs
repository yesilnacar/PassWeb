using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace PassWeb.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        //[Index(IsUnique=true)]
        //[ServerSideRemote]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string EMailAddress { get; set; }

        public byte[] Hash { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public void GenerateHashedPassword(string password)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] stringBuffer = new byte[sizeof(decimal)];
                rng.GetBytes(stringBuffer);

                Salt = BitConverter.ToString(stringBuffer, 0);
            }

            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(Salt + password));
                HashedPassword = Convert.ToBase64String(computedHash);
                Hash = sha.Hash;
            }
        }
    }
}