using System;
using FacultyApi.DataBase;

namespace FacultyApi.Models
{
    public class LessonDto
    {
        public LessonDto(){}

        public LessonDto(Lesson lesson)
        {
            LessonId = lesson.LessonId;
            Semester = lesson.Semester;
            SubjectId = lesson.SubjectId;
            SubjectName = lesson.Subject?.Name;
            LecturerId = lesson.LecturerId;
            LecturerSecondName = lesson.Lecturer.SecondName;
            GroupId = lesson.GroupId;
            GroupName = lesson.Group?.Name;
            DayAndTime = lesson.DayAndTime;
        }

        public int? LessonId { get; set; }
        public DateTime? Semester { get; set; }

        public int? SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int? LecturerId { get; set; }
        public string LecturerSecondName { get; set; }

        public int? GroupId { get; set; }
        public string GroupName { get; set; }

        public DateTime? DayAndTime { get; set; }
    }
}