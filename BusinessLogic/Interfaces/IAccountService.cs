using Microsoft.AspNetCore.Identity;
using MoviesLibrary.DataAccess.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<IdentityError>> Register(Registration model);
        Task<IEnumerable<IdentityError>> Login(Login model);

    }
}
