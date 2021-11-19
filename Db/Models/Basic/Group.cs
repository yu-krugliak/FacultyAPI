using Db.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Db.Models.Basic
{
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<UserService> Lessons { get; set; }

    }
}