using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface ILecturersRepository
    {
        void Add(Lecturer lecturer);
        Lecturer Get(int id);
        IEnumerable<Lecturer> GetAll();
        IEnumerable<Lecturer> GetAllFiltered(int? subjectId, string degree, string secondName);

        void Update(Lecturer lecturer);
        void Delete(int id);

    }
}