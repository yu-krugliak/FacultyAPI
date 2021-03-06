using System;
using System.Collections.Generic;
using System.Linq;
using Db.IRepository;
using Db.Models;
using Db.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Db.Repository
{
    public class LecturersRepository : ILecturersRepository
    {
        private readonly Context _context;

        public LecturersRepository(Context context)
        {
            _context = context;
        }

        public void Add(Lecturer lecturer)
        {
            //lecturer.LecturerId = null;

            _context.Lecturers.Add(lecturer);
            _context.SaveChanges();
        }

        public Lecturer Get(Guid id)
        {
            return _context.Lecturers.Find(id);
        }

        public IEnumerable<Lecturer> GetAll()
        {
            return _context.Lecturers
                .Include(l => l.Subjects)
                .AsNoTracking();
        }

        public IEnumerable<Lecturer> GetAllFiltered(Guid? subjectId, string degree, string secondName)
        {
            var lecturer = GetAll();

            if (subjectId != null)
                lecturer = lecturer.Where(l => l.Subjects.Any(s => s.SubjectId == subjectId));

            if (degree != null)
                lecturer = lecturer.Where(l => l.Degree.ToLower().Contains(degree.ToLower()));

            if (secondName != null)
                lecturer = lecturer.Where(l => l.SecondName.ToLower().Contains(secondName.ToLower()));

            return lecturer;
        }

        public void Update(Lecturer lecturer)
        {
            _context.Lecturers.Update(lecturer);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var record = new Lecturer() { LecturerId = id };

            _context.Lecturers.Attach(record);
            _context.Lecturers.Remove(record);
            _context.SaveChanges();
        }
    }
}