using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Db.IRepository;
using Db.Models;
using Db.Models.Basic;
using Microsoft.EntityFrameworkCore;

namespace Db.Repository
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly Context _context;

        public GroupsRepository(Context context)
        {
            _context = context;
        }

        public void Add(Group group)
        {

            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public Group Get(Guid id)
        {
            return _context.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups
                .AsNoTracking()
                .ToList();
        }

        public void Update(Group group)
        {
            _context.Groups.Update(group);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var record = new Group() { GroupId = id };

            _context.Groups.Attach(record);
            _context.Groups.Remove(record);
            _context.SaveChanges();
        }
    }
}