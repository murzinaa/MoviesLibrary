using DataAccess.Entities;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        //User AddUser(User user);
        Task AddUser(User user);
        Task<User> GetCurrentUser(User user);
    }
}
