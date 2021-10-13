using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet()]
        public IEnumerable<Student> GetAll()
        {
            return _studentsRepository.GetAll();
        }


        [HttpGet()]
        [Route("{id:int}")]
        public Student Get(int id)
        {
            return _studentsRepository.Get(id);
        }

        [HttpPost]
        public int Post([FromBody] Student student)
        {
            _studentsRepository.Update(student);
            return 1;
        }

        [HttpPut]
        public int Put([FromBody] Student student)
        {
            _studentsRepository.Add(student);
            return 1;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public int Delete(int id)
        {
            _studentsRepository.Delete(id);
            return 1;
        }
    }
}
