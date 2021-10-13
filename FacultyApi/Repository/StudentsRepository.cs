using System.Collections.Generic;
using System.Linq;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.Repository
{
    class StudentsRepository : IStudentsRepository
    {
        private readonly Context _context;

        public StudentsRepository(Context context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            student.StudentId = null;

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public Student Get(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(s => s.EducationType)
                .Include(s => s.Group)
                .AsNoTracking()
                .ToList();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = new Student() { StudentId = id };

            _context.Students.Attach(record);
            _context.Students.Remove(record);
            _context.SaveChanges();
        }
    }
}