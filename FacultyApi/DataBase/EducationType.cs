﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class EducationType
    {
        [Key]
        public int? EducationTypeId { get; set; }
        public string Name { get; set; }

        //public ICollection<Student> Students { get; set; }
    }
}