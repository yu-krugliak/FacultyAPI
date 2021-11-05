using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface IStudentsRepository
    {
        Task<Student> AddAsync(Student student, CancellationToken cancellationToken);
        Task<Student> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Student>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<Student>> GetAllFilteredAsync(Guid? groupId, bool? expelled, string secondName, CancellationToken cancellationToken);

        Task<Student> UpdateAsync(Student student, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}