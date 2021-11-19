using System;
using System.Collections.Generic;
using Db.Models.Basic;

namespace Db.IRepository
{
    public interface ILessonsRepository
    {
        void Add(UserService lesson);
        UserService Get(Guid id);
        IEnumerable<UserService> GetAll();
        IEnumerable<UserService> GetAllFiltered(Guid? groupId);

        void Update(UserService lesson);
        void Delete(Guid id);

    }
}