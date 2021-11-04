using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly Context _context;

        public StudentsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Student> AddAsync(Student student, CancellationToken token)
        {
            ///*s*/student.StudentId = null;

            await _context.Students.AddAsync(student, token);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetAsync(Guid id, CancellationToken token)
        {
            return await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<List<Student>> GetAllAsync(CancellationToken token)
        {
            return await _context.Students
                .Include(s => s.EducationType)
                .Include(s => s.Group)
                .AsNoTracking()
                .ToListAsync(token);
        }

        public async Task<List<Student>> GetAllFilteredAsync(Guid? groupId, bool? expelled, string secondName, CancellationToken token)
        {
            var students = _context.Students
                .Include(s => s.EducationType)
                .Include(s => s.Group)
                .AsNoTracking();

            if (groupId != null)
                await Task.Run(() => 
                    students = students.Where(s => s.GroupId == groupId)
                );

            if (expelled != null)
                await Task.Run(() =>
                    students = students.Where(s => s.Expelled == expelled)
                );

            if (secondName != null)
                await Task.Run(() =>
                    students = students.Where(s => s.SecondName.ToLower().Contains(secondName.ToLower()))
                );

            return await students.ToListAsync(token);
        }

        public async Task<Student> UpdateAsync(Student student, CancellationToken token)
        {
            await Task.Run(() =>
                _context.Students.Update(student),
                token
            );

            await _context.SaveChangesAsync(token);
            return student;
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var record = new Student() { StudentId = id };

            _context.Students.Attach(record);
            await Task.Run(() =>
                _context.Students.Remove(record),
                token
            );

            await _context.SaveChangesAsync(token);
        }
    }
}