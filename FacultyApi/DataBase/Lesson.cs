using System;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Lesson
    {
        [Key] 
        public int? LessonId { get; set; }
        public DateTime Semester { get; set; }

        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int? LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public DateTime DayAndTime { get; set; }
    }
}