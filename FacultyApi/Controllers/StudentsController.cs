using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using FacultyApi.Models;
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

        //[HttpGet()]
        //public IActionResult GetAll()
        //{
        //    _logger.LogInformation($"StudentsGetAll");

        //    var student = _studentsRepository
        //        .GetAll()
        //        .Select(s => new StudentDto(s));

        //    return Ok(student);
        //}

        [HttpGet]
        public IActionResult GetFiltered([FromQuery]int? groupId, [FromQuery] bool? expelled, [FromQuery] string secondName)
        {
            _logger.LogInformation($"Students GetFiltered");

            var student = _studentsRepository
                .GetAllFiltered(groupId, expelled, secondName)
                .Select(s => new StudentDto(s));

            return Ok(student);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInformation($"StudentGet, id: {id}");

            var student = _studentsRepository.Get(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentDto student)
        {
            _logger.LogInformation($"StudentPost:\n{JsonConvert.SerializeObject(student)}");

            var id = student.StudentId; //?? Guid.Empty;
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

            return Ok("Student updated.");
        }

        [HttpPut]
        public IActionResult Put([FromBody] StudentDto student)
        {
            _logger.LogInformation($"StudentPut:\n{JsonConvert.SerializeObject(student)}");

            var newStudent = new Student()
            {
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

            return Ok("New student created.");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation($"StudentDelete, id: {id}");

            _studentsRepository.Delete(id);
            return Ok("Student deleted.");
        }
    }
}
