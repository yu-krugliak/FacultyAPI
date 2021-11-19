using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Db.Auth;
using Db.Models.Auth;
using Db.Models.Students;

namespace Db.IRepository
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(Guid id);

    }
}