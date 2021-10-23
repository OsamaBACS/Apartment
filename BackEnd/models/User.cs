using System.ComponentModel.DataAnnotations;

namespace BackEnd.models
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] Password { get; set; }
        
        public byte[] PasswordKey { get; set; }
    }
}