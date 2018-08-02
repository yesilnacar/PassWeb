using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace PassWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string EMailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        private string salt;
        public string Salt
        {
            get { return salt; }
            set
            {
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    byte[] stringBuffer = new byte[sizeof(decimal)];
                    rng.GetBytes(stringBuffer);

                    salt = BitConverter.ToString(stringBuffer, 0);
                }
            }
        }

        private string GetHashedPassword()
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(Salt + Password));
                return Convert.ToBase64String(computedHash);
            }
        }
    }
}