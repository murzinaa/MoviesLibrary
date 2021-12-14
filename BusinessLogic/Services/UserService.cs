using Microsoft.EntityFrameworkCore;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess;
using MoviesLibrary.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly MovieContext _context;
        public UserService(MovieContext context)
        {
            _context = context;

        }
        public async Task AddUser(User user)
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
                await AddUser(user);
                return await users.Where(u => u.UserName.Contains(user.UserName)).FirstOrDefaultAsync();
            }
            return usersList[0];
        }
    }
}
