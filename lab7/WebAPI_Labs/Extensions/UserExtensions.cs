using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Extensions
{
    public static class UserExtensions
    {
        public static User ToUser(this UserDto userDto, int id)
        {
            return new User
            {
                Id = id,
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password,
            };
        }
    }
}
