using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly MovieContext context;
        public UserService(MovieContext context)
        {
            this.context = context;

        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
