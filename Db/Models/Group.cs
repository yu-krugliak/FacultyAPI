using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Lesson> Lessons { get; set; }

    }
}