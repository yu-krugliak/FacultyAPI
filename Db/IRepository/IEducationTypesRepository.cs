using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface IEducationTypesRepository
    {
        Task<EducationType> AddAsync(EducationType educationType, CancellationToken token);
        Task<EducationType> GetAsync(Guid id, CancellationToken token);
        Task<List<EducationType>> GetAllAsync(CancellationToken token);

        Task<EducationType> UpdateAsync(EducationType educationTypes, CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);

    }
}