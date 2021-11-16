using System;
using System.Collections.Generic;
using Db.Models.Basic;

namespace Db.IRepository
{
    public interface IGroupsRepository
    {
        void Add(Group group);
        Group Get(Guid id);
        IEnumerable<Group> GetAll();

        void Update(Group group);
        void Delete(Guid id);

    }
}