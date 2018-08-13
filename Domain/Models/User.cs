using System.ComponentModel.DataAnnotations;

namespace PassWeb.Domain.Models
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

        public byte[] Hash { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }
    }
}