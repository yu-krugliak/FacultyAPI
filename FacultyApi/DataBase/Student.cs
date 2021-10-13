using System;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Student
    {
        [Key]
        public int? StudentId { get; set; }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public DateTime YearEntry { get; set; }
        public string PhoneNumber { get; set; }

        public bool Expelled { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public int? EducationTypeId { get; set; }
        public EducationType EducationType { get; set; }
    }
}