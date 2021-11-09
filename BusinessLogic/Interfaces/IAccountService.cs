using DataAccess.Registration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<IdentityError>> Register(Registration model);
        Task<IEnumerable<IdentityError>> Login(Login model);

    }
}
