using System;
using System.ComponentModel.DataAnnotations;

namespace PassWeb.Domain.Models
{
    public class PassResetToken
    {
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime GeneratedDateTime { get; set; }

        public User User { get; set; }
    }
}
