using System;

namespace Db.Models.Basic
{
    public class LecturerDto
    {
        public LecturerDto() { }
        public LecturerDto(Lecturer lecturer)
        {
            LecturerId = lecturer.LecturerId;
            SecondName = lecturer.SecondName;
            FirstName = lecturer.FirstName;
            MiddleName = lecturer.MiddleName;
            Degree = lecturer.Degree;
            Position = lecturer.Position;
            PhoneNumber = lecturer.PhoneNumber;
        }

        public Guid LecturerId { get; set; }

        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string Degree { get; set; }
        public string Position { get; set; }

        public string PhoneNumber { get; set; }
    }
}