using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Db.Models.EducationTypes
{
    public class UpdateEducationModel
    {
        public Guid EducationTypeId { get; set; }
        public string Name { get; set; }
    }
}