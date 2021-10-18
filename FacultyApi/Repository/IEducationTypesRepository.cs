using System.Collections.Generic;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface IEducationTypesRepository
    {
        void Add(EducationType educationType);
        EducationType Get(int id);
        IEnumerable<EducationType> GetAll();

        void Update(EducationType educationTypes);
        void Delete(int id);

    }
}