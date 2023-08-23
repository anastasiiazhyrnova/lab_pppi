using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI_Labs.DTO;
using WebAPI_Labs.Extensions;
using WebAPI_Labs.Models;
using WebAPI_Labs.Services.PasswordService;
using WebAPI_Labs.Services.UserService;

namespace WebAPI_Labs.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly IConfiguration _configuration;

        public AuthService(IUserService userService, IPasswordService passwordService, IConfiguration configuration)
        {
            _userService = userService;
            _passwordService = passwordService;
            _configuration = configuration;
        }

        public async Task<Response<AuthResult>> LoginAsync(LoginRequest request)
        {
            try
            {
                var userResponse = await _userService.GetByEmailAsync(request.Email);
                if (!userResponse.Success)
                {
                    return new Response<AuthResult>
                    {
                        Code = userResponse.Code,
                        Success = false,
                        Message = "Invalid email or password"
                    };
                }
                var user = userResponse.Data.First();

                if (!_passwordService.VerifyPassword(request.Password, user.Password))
                {
                    user.FailedLoginAttempts++;
                    await _userService.UpdateAsync(user.Id, user);

                    return new Response<AuthResult>
                    {
                        Code = 401,
                        Success = false,
                        Message = "Invalid email or password"
                    };
                }

                user.FailedLoginAttempts = 0;
                user.LastLoginDate = DateTime.Now;
                await _userService.UpdateAsync(user.Id, user);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]!);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return new Response<AuthResult>
                {
                    Code = 200,
                    Success = true,
                    Message = "Login successful",
                    Data = new List<AuthResult> { new AuthResult { Username = $"{user.FirstName} {user.LastName}", Token = tokenString } }
                };
            }
            catch (Exception ex)
            {
                return new Response<AuthResult>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<UserResponse>> RegisterAsync(RegisterRequest request)
        {
            try
            {
                var existingUserResponse = await _userService.GetByEmailAsync(request.Email);
                if (existingUserResponse.Success)
                {
                    return new Response<UserResponse>
                    {
                        Code = 400,
                        Success = false,
                        Message = "Email already in use"
                    };
                }

                request.Password = _passwordService.HashPassword(request.Password);

                var response = await _userService.PostAsync(request.ToDto());
                return new Response<UserResponse>() { 
                    Code = response.Code,
                    Success = response.Success,
                    Message = response.Message,
                    Data = response.Data.Select(x => x.ToDto()).ToList()
                };
            }
            catch (Exception ex)
            {
                return new Response<UserResponse>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
