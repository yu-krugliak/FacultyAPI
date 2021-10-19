using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface ILessonsRepository
    {
        void Add(Lesson lesson);
        Lesson Get(int id);
        IEnumerable<Lesson> GetAll();
        IEnumerable<Lesson> GetAllFiltered(int? groupId);

        void Update(Lesson lesson);
        void Delete(int id);

    }
}