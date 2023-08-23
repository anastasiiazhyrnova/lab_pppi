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
                new User { Id = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", DateOfBirth = new DateTime(1990, 1, 1), Password = "password", LastLoginDate = DateTime.Now, FailedLoginAttempts = 0 },
                new User { Id = 2, FirstName = "Bob", LastName = "Johnson", Email = "bob@example.com", DateOfBirth = new DateTime(1991, 2, 2), Password = "password", LastLoginDate = DateTime.Now, FailedLoginAttempts = 0 },
                new User { Id = 3, FirstName = "Charlie", LastName = "Williams", Email = "charlie@example.com", DateOfBirth = new DateTime(1992, 3, 3), Password = "password", LastLoginDate = DateTime.Now, FailedLoginAttempts = 0 },
                new User { Id = 4, FirstName = "Dave", LastName = "Brown", Email = "dave@example.com", DateOfBirth = new DateTime(1993, 4, 4), Password = "password", LastLoginDate = DateTime.Now, FailedLoginAttempts = 0 },
                new User { Id = 5, FirstName = "Eve", LastName = "Jones", Email = "eve@example.com", DateOfBirth = new DateTime(1994, 5, 5), Password = "password", LastLoginDate = DateTime.Now, FailedLoginAttempts = 0 },
                new User { Id=6, FirstName="Frank", LastName="Miller", Email="frank@example.com", DateOfBirth=new DateTime(1995,6,6), Password="password", LastLoginDate=DateTime.Now, FailedLoginAttempts=0},
                new User{Id=7, FirstName="Grace", LastName="Davis", Email="grace@example.com", DateOfBirth=new DateTime(1996,7,7), Password="password", LastLoginDate=DateTime.Now, FailedLoginAttempts=0},
                new User{Id=8, FirstName="Heidi", LastName="Garcia", Email="heidi@example.com", DateOfBirth=new DateTime(1997,8,8), Password="password", LastLoginDate=DateTime.Now, FailedLoginAttempts=0},
                new User{Id=9, FirstName="Ivan", LastName="Rodriguez", Email="ivan@example.com", DateOfBirth=new DateTime(1998,9,9), Password="password", LastLoginDate=DateTime.Now, FailedLoginAttempts=0},
                new User{Id=10, FirstName="Judy", LastName="Wilson", Email="judy@example.com", DateOfBirth=new DateTime(1999,10,10), Password="password", LastLoginDate=DateTime.Now, FailedLoginAttempts=0}
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

        public async Task<Response<User>> GetByEmailAsync(string email)
        {
            try
            {
                var user = _users.FirstOrDefault(u => u.Email == email);
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

        public async Task<Response<User>> PostAsync(UserRequest userDto)
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

        public async Task<Response<User>> PutAsync(int id, UserRequest userDto)
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

        public async Task<Response<User>> UpdateAsync(int id, User user)
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
