using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace FacultyApiClientWinForms.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public DateTime YearEntry { get; set; }
        public string PhoneNumber { get; set; }
        public bool Expelled { get; set; }

        [Browsable(false)]
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        [Browsable(false)]
        public int EducationTypeId { get; set; }
        public string Education { get; set; }
    }
}