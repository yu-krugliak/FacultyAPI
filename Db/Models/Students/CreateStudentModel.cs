using System;
using System.ComponentModel.DataAnnotations;

namespace Db.Models.Students
{
    public class CreateStudentModel
    {
        public string FamilienName { get; set; }
        public string Name { get; set; }
        public string MidName { get; set; }

        public DateTime YearEntry { get; set; }
        public string PhoneNumber { get; set; }

        public bool Expelled { get; set; }

        public Guid? GroupId { get; set; }
        public Guid? EducationTypeId { get; set; }
    }
}