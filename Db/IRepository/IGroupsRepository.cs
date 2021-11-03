using System;
using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
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