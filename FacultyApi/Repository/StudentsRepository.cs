using System;
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
            ///*s*/student.StudentId = null;

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public Student Get(Guid id)
        {
            return _context.Students
                .AsNoTracking()
                .FirstOrDefault(s => s.StudentId == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(s => s.EducationType)
                .Include(s => s.Group)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Student> GetAllFiltered(int? groupId, bool? expelled, string secondName)
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

            return students;
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var record = new Student() { StudentId = id };

            _context.Students.Attach(record);
            _context.Students.Remove(record);
            _context.SaveChanges();
        }
    }
}