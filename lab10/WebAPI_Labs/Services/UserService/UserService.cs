using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using WebAPI_Labs.Data;
using WebAPI_Labs.DTO;
using WebAPI_Labs.Extensions;
using WebAPI_Labs.Models;
using WebAPI_Labs.Services.PasswordService;

namespace WebAPI_Labs.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IPasswordService _passwordService;

        public UserService(ApplicationContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<Response<User>> GetAllAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = users
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<User>> GetAsync(int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null)
                {
                    return new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    };
                }

                return new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = new List<User> { user }
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<User>> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    return new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    };
                }

                return new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = new List<User> { user }
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<User>> PostAsync(UserRequest userDto)
        {
            try
            {
                if (await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(userDto.Email)) != null)
                {
                    return new Response<User>
                    {
                        Code = 400,
                        Success = false,
                        Message = "This email is already used"
                    };
                }

                var user = userDto.ToUser();
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new Response<User>
                {
                    Code = 201,
                    Success = true,
                    Message = "User created",
                    Data = new List<User> { user }
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<User>> UpdateAsync(int id, User user)
        {
            try
            {
                if (await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(user.Email)) != null)
                {
                    return new Response<User>
                    {
                        Code = 400,
                        Success = false,
                        Message = "This email is already used"
                    };
                }

                var userIndex = await _context.Users.FindAsync(id);
                if (userIndex == null)
                {
                    return new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    };
                }

                user.Password = _passwordService.HashPassword(user.Password);

                _context.Entry(userIndex).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();

                return new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "User updated",
                    Data = new List<User> { user }
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }


        public async Task<Response<User>> PutAsync(int id, UserRequest userDto)
        {
            try
            {
                var userIndex = await _context.Users.FindAsync(id);
                if (userIndex == null)
                {
                    return new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    };
                }

                User? user = await _context.Users.FirstOrDefaultAsync(user => user.Email.Equals(userDto.Email));

                if (user != null && user.Id != id)
                {
                    return new Response<User>
                    {
                        Code = 400,
                        Success = false,
                        Message = "This email is already used"
                    };
                }

                var userToUpdate = userDto.ToUser();
                userToUpdate.Id = id;
                userToUpdate.Password = _passwordService.HashPassword(userToUpdate.Password);

                _context.Entry(userIndex).CurrentValues.SetValues(userToUpdate);
                await _context.SaveChangesAsync();

                return new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "User updated",
                    Data = new List<User> { userToUpdate }
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<User>> DeleteAsync(int id)
        {
            try
            {
                var userIndex = await _context.Users.FindAsync(id);
                if (userIndex == null)
                {
                    return new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    };
                }

                _context.Users.Remove(userIndex);
                await _context.SaveChangesAsync();

                return new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "User deleted"
                };
            }
            catch (Exception ex)
            {
                return new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
