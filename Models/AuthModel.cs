using System.ComponentModel.DataAnnotations;

namespace bookglobe_backend.Models
{
    public class AuthModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}