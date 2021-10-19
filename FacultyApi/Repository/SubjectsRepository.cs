using System.Collections.Generic;
using System.Linq;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.Repository
{
    class SubjectsRepository : ISubjectsRepository
    {
        private readonly Context _context;

        public SubjectsRepository(Context context)
        {
            _context = context;
        }

        public void Add(Subject subject)
        {
            subject.SubjectId = null;

            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public Subject Get(int id)
        {
            return _context.Subjects.Find(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects                   
                .AsNoTracking();
        }

        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = new Subject() { SubjectId = id };

            _context.Subjects.Attach(record);
            _context.Subjects.Remove(record);
            _context.SaveChanges();
        }
    }
}