using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.UserService
{
    public interface IUserService
    {
        Task<Response<User>> GetAllAsync();
        Task<Response<User>> GetAsync(int id);
        Task<Response<User>> GetByEmailAsync(string email);
        Task<Response<User>> PostAsync(UserRequest user);
        Task<Response<User>> PutAsync(int id, UserRequest user);
        Task<Response<User>> UpdateAsync(int id, User user);
        Task<Response<User>> DeleteAsync(int id);
    }
}
