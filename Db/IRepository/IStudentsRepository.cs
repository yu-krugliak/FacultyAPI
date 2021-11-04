using System;
using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface IStudentsRepository
    {
        void Add(Student student);
        Student Get(Guid id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetAllFiltered(Guid? groupId, bool? expelled, string secondName);

        void Update(Student student);
        void Delete(Guid id);

    }
}