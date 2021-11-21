using MoviesLibrary.DataAccess.Entities;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        //User AddUser(User user);
        Task AddUser(User user);
        Task<User> GetCurrentUser(User user);
    }
}
