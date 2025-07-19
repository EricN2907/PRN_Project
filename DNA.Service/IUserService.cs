using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNA.BussinessObject;

namespace DNA.Service
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string username, string password);
        Task<User?> GetUserByIdAsync(int userId);
        Task<User> RegisterAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> DeactivateUserAsync(int userId);
    }
}
