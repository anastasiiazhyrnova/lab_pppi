using System.ComponentModel.DataAnnotations;

namespace WebAPI_Labs.DTO
{
    public class RegisterRequest
    {
        [Required, StringLength(15)]
        public string FirstName { get; set; } = "";
        [Required, StringLength(15)]
        public string LastName { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
