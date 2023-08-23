using System.ComponentModel.DataAnnotations;

namespace WebAPI_Labs.DTO
{
    public class UserResponse
    {
        [StringLength(15)]
        public string FirstName { get; set; } = "";

        [StringLength(15)]
        public string LastName { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        public DateTime DateOfBirth { get; set; }
    }
}
