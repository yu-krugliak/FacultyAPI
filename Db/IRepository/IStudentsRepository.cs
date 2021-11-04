using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FacultyApi.DataBase;

namespace FacultyApi.Repository
{
    public interface IStudentsRepository
    {
        Task<Student> AddAsync(Student student, CancellationToken token);
        Task<Student> GetAsync(Guid id, CancellationToken token);
        Task<List<Student>> GetAllAsync(CancellationToken token);
        Task<List<Student>> GetAllFilteredAsync(Guid? groupId, bool? expelled, string secondName, CancellationToken token);

        Task<Student> UpdateAsync(Student student, CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);

    }
}