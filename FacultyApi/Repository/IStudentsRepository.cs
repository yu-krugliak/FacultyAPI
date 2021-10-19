﻿using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface IStudentsRepository
    {
        void Add(Student student);
        Student Get(int id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetAllFiltered(int? groupId, bool? expelled, string secondName);

        void Update(Student student);
        void Delete(int id);

    }
}