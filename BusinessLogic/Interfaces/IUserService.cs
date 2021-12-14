using MoviesLibrary.DataAccess.Entities;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task<User> GetCurrentUser(User user);
    }
}
