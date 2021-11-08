using System;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class UpdateStudentModel
    {
        public Guid StudentId { get; set; }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public DateTime YearEntry { get; set; }
        public string PhoneNumber { get; set; }

        public bool Expelled { get; set; }

        public Guid? GroupId { get; set; }
        public Guid? EducationTypeId { get; set; }
    }
}