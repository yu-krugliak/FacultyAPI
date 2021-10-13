using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FacultyApi.DataBase
{
    public class Group
    {
        [Key]
        public int? GroupId { get; set; }
        public string Name { get; set; }

        //public ICollection<Student> Students { get; set; }
    }
}