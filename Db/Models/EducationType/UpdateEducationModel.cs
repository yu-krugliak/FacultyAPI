using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class UpdateEducationModel
    {       
        public Guid EducationTypeId { get; set; }
        public string Name { get; set; }
    }
}