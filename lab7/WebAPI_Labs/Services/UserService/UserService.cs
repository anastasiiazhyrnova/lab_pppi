using WebAPI_Labs.DTO;
using WebAPI_Labs.Extensions;
using WebAPI_Labs.Models;

namespace WebAPI_Labs.Services.UserService
{
    public class UserService : IUserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = new List<User>
            {
                new User { Id = 1, Username = "Alice", Email = "alice@example.com", Password = "password" },
                new User { Id = 2, Username = "Bob", Email = "bob@example.com", Password = "password" },
                new User { Id = 3, Username = "Charlie", Email = "charlie@example.com", Password = "password" },
                new User { Id = 4, Username = "Dave", Email = "dave@example.com", Password = "password" },
                new User { Id = 5, Username = "Eve", Email = "eve@example.com", Password = "password" },
                new User { Id = 6, Username = "Frank", Email = "frank@example.com", Password = "password" },
                new User { Id = 7, Username = "Grace", Email = "grace@example.com", Password = "password" },
                new User { Id = 8, Username = "Heidi", Email = "heidi@example.com", Password = "password" },
                new User { Id = 9, Username = "Ivan", Email = "ivan@example.com", Password = "password" },
                new User { Id = 10, Username = "Judy", Email = "judy@example.com", Password = "password" }
            };
        }

        public async Task<Response<User>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = _users
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<User>> GetAsync(int id)
        {
            try
            {
                var user = _users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return await Task.FromResult(new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    });
                }

                return await Task.FromResult(new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "Success",
                    Data = new List<User> { user }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<User>> PostAsync(UserDto userDto)
        {
            try
            {
                int id = 1;
                if (_users.Any())
                {
                    id = _users.Max(u => u.Id) + 1;
                }
                var user = userDto.ToUser(id);
                _users.Add(user);

                return await Task.FromResult(new Response<User>
                {
                    Code = 201,
                    Success = true,
                    Message = "User created",
                    Data = new List<User> { user }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<User>> PutAsync(int id, UserDto userDto)
        {
            try
            {
                var userIndex = _users.FindIndex(u => u.Id == id);
                if (userIndex == -1)
                {
                    return await Task.FromResult(new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    });
                }

                var user = userDto.ToUser(id);
                _users[userIndex] = user;

                return await Task.FromResult(new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "User updated",
                    Data = new List<User> { user }
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<Response<User>> DeleteAsync(int id)
        {
            try
            {
                var userIndex = _users.FindIndex(u => u.Id == id);
                if (userIndex == -1)
                {
                    return await Task.FromResult(new Response<User>
                    {
                        Code = 404,
                        Success = false,
                        Message = "User not found"
                    });
                }

                _users.RemoveAt(userIndex);

                return await Task.FromResult(new Response<User>
                {
                    Code = 200,
                    Success = true,
                    Message = "User deleted"
                });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new Response<User>
                {
                    Code = 500,
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }

}
