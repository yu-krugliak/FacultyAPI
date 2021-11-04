using System;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Lesson
    {
        [Key] 
        public Guid LessonId { get; set; }
        public DateTime Semester { get; set; }

        public Guid? SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid? LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public Guid? GroupId { get; set; }
        public Group Group { get; set; }

        public DateTime DayAndTime { get; set; }
    }
}