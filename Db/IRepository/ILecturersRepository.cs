using System;
using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface ILecturersRepository
    {
        void Add(Lecturer lecturer);
        Lecturer Get(Guid id);
        IEnumerable<Lecturer> GetAll();
        IEnumerable<Lecturer> GetAllFiltered(Guid? subjectId, string degree, string secondName);

        void Update(Lecturer lecturer);
        void Delete(Guid id);

    }
}