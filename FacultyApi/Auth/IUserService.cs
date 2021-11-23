using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Db.Models.Students;
using FacultyApi.Auth;

namespace FacultyApi.Auth
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(Guid id);

    }
}