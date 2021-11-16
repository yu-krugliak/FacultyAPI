using System;
using System.Collections.Generic;
using Db.Models.Basic;

namespace Db.IRepository
{
    public interface ILessonsRepository
    {
        void Add(Lesson lesson);
        Lesson Get(Guid id);
        IEnumerable<Lesson> GetAll();
        IEnumerable<Lesson> GetAllFiltered(Guid? groupId);

        void Update(Lesson lesson);
        void Delete(Guid id);

    }
}