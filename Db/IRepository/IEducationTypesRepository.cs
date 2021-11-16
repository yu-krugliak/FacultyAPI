using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Db.Models.EducationTypes;

namespace Db.IRepository
{
    public interface IEducationTypesRepository
    {
        Task<EducationType> AddAsync(EducationType educationType, CancellationToken cancellationToken);
        Task<EducationType> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<List<EducationType>> GetAllAsync(CancellationToken cancellationToken);

        Task<EducationType> UpdateAsync(EducationType educationTypes, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}