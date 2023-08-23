using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Extensions
{
    public static class UserExtensions
    {
        public static User ToUser(this UserRequest userDto, int id)
        {
            return new User
            {
                Id = id,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Password = userDto.Password,
                DateOfBirth = userDto.DateOfBirth,
            };
        }

        public static UserRequest ToDto(this RegisterRequest request)
        {
            return new UserRequest
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth
            };
        }

        public static UserResponse ToDto(this User user)
        {
            return new UserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };
        }
    }
}
