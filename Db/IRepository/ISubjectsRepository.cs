using System;
using System.Collections.Generic;
using Db.Models.Basic;

namespace Db.IRepository
{
    public interface ISubjectsRepository
    {
        void Add(Subject subject);
        Subject Get(Guid id);
        IEnumerable<Subject> GetAll();

        void Update(Subject subject);
        void Delete(Guid id);

    }
}