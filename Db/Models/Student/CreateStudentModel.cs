using System;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class CreateStudentModel
    {
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