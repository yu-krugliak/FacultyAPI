using System;
using System.Collections.Generic;
using System.Linq;
using Db.IRepository;
using Db.Models;
using Db.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Db.Repository
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly Context _context;

        public LessonsRepository(Context context)
        {
            _context = context;
        }

        public void Add(UserService lesson)
        {

            _context.Lessons.Add(lesson);
            _context.SaveChanges();
        }

        public UserService Get(Guid id)
        {
            return _context.Lessons
                .AsNoTracking()
                .FirstOrDefault(s => s.LessonId == id);
        }

        public IEnumerable<UserService> GetAll()
        {
            return _context.Lessons
                .Include(s => s.Lecturer)
                .Include(s => s.Group)
                .Include(s => s.Subject)
                .AsNoTracking();
        }

        public IEnumerable<UserService> GetAllFiltered(Guid? groupId)
        {
            var lessons = GetAll();

            if (groupId != null)
                lessons = lessons.Where(s => s.GroupId == groupId);

            return lessons;
        }
        public void Update(UserService lesson)
        {
            _context.Lessons.Update(lesson);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var record = new UserService() { LessonId = id };

            _context.Lessons.Attach(record);
            _context.Lessons.Remove(record);
            _context.SaveChanges();
        }
    }
}