using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Lecturer
    {
        [Key]
        public int? LecturerId { get; set; }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string Degree { get; set; }
        public string Position { get; set; }

        public string PhoneNumber { get; set; }

         public ICollection<Subject> Subjects { get; set; }
    }
}