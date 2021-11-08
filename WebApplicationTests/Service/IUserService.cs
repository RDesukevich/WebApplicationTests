using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTests.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationTests.Models;

namespace WebApplicationTests.Service
{
   public interface IUserService
   {
        IEnumerable<User> Get();
        Task<User> GetUserAsync(string login);
        public Task<bool> CheckForEnableAsync(string login, string password);
        public Task<User> GetUserByLoginAndPasswordAsync(string login, string password);
        public Task<User> AddUserAsync(User user);
    }

    public class UserService : IUserService
    {
        private readonly AppDb _db;

        public UserService(AppDb db)
        {
            _db = db;
        }

        public IEnumerable<User> Get()
        {
            return _db.Users;
        }

        public async Task<User> GetUserAsync(string login)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<bool> CheckForEnableAsync(string login, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(o => o.Login == login && o.Password == password);
            return user != null;
        }

        public async Task<User> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _db.Users.Include(o => o.Role).
                FirstOrDefaultAsync(o => o.Login == login && o.Password == password);
        }

        public async Task<User> AddUserAsync(User user)
        {
            user.Role = await _db.Roles.FirstOrDefaultAsync(o => o.Name == "User");
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
