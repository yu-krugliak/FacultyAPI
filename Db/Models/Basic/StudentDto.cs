using Db.Models.Students;
using System;

namespace Db.Models.Basic
{
    public class StudentDto
    {
        public StudentDto() { }

        public StudentDto(Student student)
        {
            StudentId = student.StudentId;
            SecondName = student.SecondName;
            FirstName = student.FirstName;
            MiddleName = student.MiddleName;
            YearEntry = student.YearEntry;
            PhoneNumber = student.PhoneNumber;
            Expelled = student.Expelled;
            GroupId = student.GroupId;
            GroupName = student.Group?.Name;
            EducationTypeId = student.EducationTypeId;
            Education = student.EducationType?.Name;
        }

        public Guid StudentId { get; set; }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public DateTime? YearEntry { get; set; }
        public string PhoneNumber { get; set; }

        public bool? Expelled { get; set; }

        public Guid? GroupId { get; set; }
        public string GroupName { get; set; }
        public Guid? EducationTypeId { get; set; }
        public string Education { get; set; }
    }
}