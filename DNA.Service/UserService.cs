using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DNA.BussinessObject;
using DNA.Repository;

namespace DNA.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            // For now, use simple string comparison
            // In production, replace with proper BCrypt after installing the package
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password && u.IsActive);
            
            if (user != null)
            {
                // Update last login date
                user.LastLoginDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> RegisterAsync(User user)
        {
            // Store password directly for now
            // In production, replace with BCrypt.HashPassword after installing the package
            user.CreatedDate = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null || user.PasswordHash != oldPassword)
                return false;

            // Update password directly for now
            user.PasswordHash = newPassword;
            user.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.IsActive = false;
            user.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
