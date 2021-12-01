using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Db.IRepository;
using Db.Models;
using Db.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace Db.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly Context _context;

        public StudentsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Student> AddAsync(Student student, CancellationToken cancellationToken)
        {
            ///*s*/student.StudentId = null;

            await _context.Students.AddAsync(student, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return student;
        }

        public async Task<Student> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.StudentId == id, cancellationToken);
        }

        public async Task<List<Student>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Students
                .Include(s => s.EducationType)
                .Include(s => s.Group)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Student>> GetAllFilteredAsync(Guid? groupId, bool? expelled, string secondName, CancellationToken cancellationToken)
        {
            var students = _context.Students
                .Include(s => s.EducationType)
                .Include(s => s.Group)
                .AsNoTracking();

            if (groupId != null)
                students = students.Where(s => s.GroupId == groupId);

            if (expelled != null)
                students = students.Where(s => s.Expelled == expelled);

            if (secondName != null)
                students = students.Where(s => s.SecondName.ToLower().Contains(secondName.ToLower()));

            return await students.ToListAsync(cancellationToken);
        }

        public async Task<Student> UpdateAsync(Student student, CancellationToken cancellationToken)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);
            return student;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var record = new Student() { StudentId = id };

            _context.Students.Attach(record);
            _context.Students.Remove(record);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}