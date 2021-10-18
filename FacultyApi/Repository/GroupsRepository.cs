using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FacultyApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FacultyApi.Repository
{
    class GroupsRepository : IGroupsRepository
    {
        private readonly Context _context;

        public GroupsRepository(Context context)
        {
            _context = context;
        }

        public void Add(Group group)
        {
            group.GroupId = null;
            
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public Group Get(int id)
        {
            return _context.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups                   ///TODO
                .AsNoTracking()
                .ToList();
        }

        public void Update(Group group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = new Group() { GroupId = id };  ///TODO

            _context.Groups.Attach(record);
            _context.Groups.Remove(record);
            _context.SaveChanges();
        }
    }
}