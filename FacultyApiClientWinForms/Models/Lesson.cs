using System;
using System.ComponentModel;

namespace FacultyApiClientWinForms.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public DateTime? Semester { get; set; }

        [Browsable(false)]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        [Browsable(false)]
        public int LecturerId { get; set; }
        public string LecturerSecondName { get; set; }

        [Browsable(false)]
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public DateTime DayAndTime { get; set; }
    }
}