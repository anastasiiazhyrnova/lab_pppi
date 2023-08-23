using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.UserService
{
    public interface IUserService
    {
        Task<Response<User>> GetAllAsync();
        Task<Response<User>> GetAsync(int id);
        Task<Response<User>> PostAsync(UserDto user);
        Task<Response<User>> PutAsync(int id, UserDto user);
        Task<Response<User>> DeleteAsync(int id);
    }
}
