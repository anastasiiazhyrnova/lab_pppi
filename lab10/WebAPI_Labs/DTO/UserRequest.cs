using System.ComponentModel.DataAnnotations;

namespace WebAPI_Labs.DTO
{
    public class UserRequest
    {
        [StringLength(15)]
        public string FirstName { get; set; } = "";

        [StringLength(15)]
        public string LastName { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; } = "";
    }
}
