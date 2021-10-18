using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FacultyApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentsRepository studentsRepository, ILogger<StudentsController> logger)
        {
            _studentsRepository = studentsRepository;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"StudentsGetAll");

            var student = _studentsRepository
                .GetAll()
                .Select(s => new DtoStudent(s))
                .ToList();

            if (!student.Any())
            {
                return NotFound("Students list empty.");
            }

            return Ok(student);
        }


        [HttpGet()]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var student = _studentsRepository.Get(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public int Post([FromBody] DtoStudent student)
        {
            _logger.LogInformation($"StudentsPost:\n{JsonConvert.SerializeObject(student)}");

            var id = student.StudentId ?? 0;
            var oldStudent = _studentsRepository.Get(id);

            var newStudent = new Student()
            {
                StudentId = id,
                FirstName = student.FirstName ?? oldStudent.FirstName,
                SecondName = student.SecondName ?? oldStudent.SecondName,
                MiddleName = student.MiddleName ?? oldStudent.MiddleName,
                YearEntry = student.YearEntry ?? oldStudent.YearEntry,
                PhoneNumber = student.PhoneNumber ?? oldStudent.PhoneNumber,
                Expelled = student.Expelled ?? oldStudent.Expelled,
                EducationTypeId = student.EducationTypeId ?? oldStudent.EducationTypeId,
                GroupId = student.GroupId ?? oldStudent.GroupId,
            };
            _studentsRepository.Update(newStudent);
            return 1;
        }

        [HttpPut]
        public int Put([FromBody] DtoStudent student)
        {
            var newStudent = new Student()
            {
                StudentId = null,
                FirstName = student.FirstName,
                SecondName = student.SecondName,
                MiddleName = student.MiddleName,
                YearEntry = student.YearEntry ?? DateTime.MinValue,
                PhoneNumber = student.PhoneNumber,
                Expelled = student.Expelled ?? false,
                EducationTypeId = student.EducationTypeId,
                GroupId = student.GroupId,
            };
            _studentsRepository.Add(newStudent);
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
