using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface ISubjectsRepository
    {
        void Add(Subject subject);
        Subject Get(int id);
        IEnumerable<Subject> GetAll();

        void Update(Subject subject);
        void Delete(int id);

    }
}