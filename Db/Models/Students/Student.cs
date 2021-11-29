using Db.Models.Basic;
using Db.Models.EducationTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Db.Models.Students
{
    public class Student
    {
        [JsonPropertyName("studentId")]
        public Guid StudentId { get; set; }

        [JsonPropertyName("secondName")]
        public string SecondName { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("yearEntry")]
        public DateTime YearEntry { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("expelled")]
        public bool Expelled { get; set; }
        [JsonPropertyName("groupId")]
        public Guid? GroupId { get; set; }
        [JsonPropertyName("group")]
        public Group Group { get; set; }

        [JsonPropertyName("educationTypeId")]
        public Guid? EducationTypeId { get; set; }
        [JsonPropertyName("educationType")]
        public EducationType EducationType { get; set; }
    }
}