using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly MovieContext _context;
        public UserService(MovieContext context)
        {
            _context = context;

        }
        public async void AddUser(User user)
        {
            var users = from u in _context.Users
                          select u;
            if ((await users.Where(u => u.UserName.Contains(user.UserName)).ToListAsync()).Count == 0)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            
        }

        public async Task<User> GetCurrentUser(User user)
        {
            var users = from u in _context.Users
                        select u;
            var usersList = await users.Where(u => u.UserName.Contains(user.UserName)).ToListAsync();
            if (usersList.Count == 0)
            {
                AddUser(user);
                return await users.Where(u => u.UserName.Contains(user.UserName)).FirstAsync();
            }
            return usersList[0];
            //throw new System.NotImplementedException();
        }
    }
}
