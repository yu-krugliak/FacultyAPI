using Db.Models.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Db.Models.EducationTypes
{
    public class ReadEducationModel
    {
        public Guid EducationTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}