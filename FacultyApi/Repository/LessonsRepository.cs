using System;
using System.Collections.Generic;
using System.Linq;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.Repository
{
    class LessonsRepository : ILessonsRepository
    {
        private readonly Context _context;

        public LessonsRepository(Context context)
        {
            _context = context;
        }

        public void Add(Lesson lesson)
        {

            _context.Lessons.Add(lesson);
            _context.SaveChanges();
        }

        public Lesson Get(Guid id)
        {
            return _context.Lessons
                .AsNoTracking()
                .FirstOrDefault(s => s.LessonId == id);
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _context.Lessons
                .Include(s => s.Lecturer)
                .Include(s => s.Group)
                .Include(s => s.Subject)
                .AsNoTracking();
        }

        public IEnumerable<Lesson> GetAllFiltered(Guid? groupId)
        {
            var lessons = GetAll();

            if (groupId != null)
                lessons = lessons.Where(s => s.GroupId == groupId);

            return lessons;
        }
        public void Update(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var record = new Lesson() { LessonId = id };

            _context.Lessons.Attach(record);
            _context.Lessons.Remove(record);
            _context.SaveChanges();
        }
    }
}