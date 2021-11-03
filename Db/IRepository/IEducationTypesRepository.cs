using System;
using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface IEducationTypesRepository
    {
        void Add(EducationType educationType);
        EducationType Get(Guid id);
        IEnumerable<EducationType> GetAll();

        void Update(EducationType educationTypes);
        void Delete(Guid id);

    }
}