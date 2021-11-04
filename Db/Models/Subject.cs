using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }
        public string Name { get; set; }

        public Guid? LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}