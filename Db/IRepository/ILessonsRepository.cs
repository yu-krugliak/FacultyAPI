using System;
using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
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