using System;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Student
    {
        public Guid StudentId { get; set; }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        //public string Name1 { get; set; }
        //public string Name2 { get; set; }
        //public string Name3 { get; set; }
        //public string Name4 { get; set; }


        public DateTime YearEntry { get; set; }
        public string PhoneNumber { get; set; }

        public bool Expelled { get; set; }

        public Guid? GroupId { get; set; }
        public Group Group { get; set; }

        public Guid? EducationTypeId { get; set; }
        public EducationType EducationType { get; set; }
    }
}