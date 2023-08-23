using System.ComponentModel.DataAnnotations;

namespace WebAPI_Labs.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(15)]
        public string FirstName { get; set; } = "";

        [StringLength(15)]
        public string LastName { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; } = "";

        public DateTime LastLoginDate { get; set; } = DateTime.Now;

        public int FailedLoginAttempts { get; set; } = 0;
    }

}
