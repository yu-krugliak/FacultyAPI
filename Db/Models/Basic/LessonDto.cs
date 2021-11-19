using System;

namespace Db.Models.Basic
{
    public class LessonDto
    {
        public LessonDto() { }

        public LessonDto(UserService lesson)
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

        public Guid LessonId { get; set; }
        public DateTime? Semester { get; set; }

        public Guid? SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Guid? LecturerId { get; set; }
        public string LecturerSecondName { get; set; }

        public Guid? GroupId { get; set; }
        public string GroupName { get; set; }

        public DateTime? DayAndTime { get; set; }
    }
}