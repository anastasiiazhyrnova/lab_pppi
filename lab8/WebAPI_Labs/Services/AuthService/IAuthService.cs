using WebAPI_Labs.DTO;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.AuthService
{
    public interface IAuthService
    {
        Task<Response<AuthResult>> LoginAsync(LoginRequest request);
        Task<Response<UserResponse>> RegisterAsync(RegisterRequest request);
    }
}
