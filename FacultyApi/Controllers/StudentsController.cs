using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public async Task<IActionResult> GetFiltered([FromQuery]Guid? groupId, [FromQuery] bool? expelled, [FromQuery] string secondName, CancellationToken token = default)
        {
            _logger.LogInformation($"Students GetFiltered");

            var student = await _studentsRepository
                .GetAllFilteredAsync(groupId, expelled, secondName, token);

            return Ok(student.Select(s => new StudentDto(s)));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken token = default)
        {
            _logger.LogInformation($"StudentGet, id: {id}");

            var student = await _studentsRepository.GetAsync(id, token);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] StudentDto student, CancellationToken token = default)
        {
            _logger.LogInformation($"StudentPost:\n{JsonConvert.SerializeObject(student)}");

            var id = student.StudentId; //?? Guid.Empty;
            var oldStudent = await _studentsRepository.GetAsync(id, token);

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

            try
            {
                await _studentsRepository.UpdateAsync(newStudent, token);
                return Ok(newStudent);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync([FromBody] StudentDto student, CancellationToken token = default)
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

            try
            {
                await _studentsRepository.AddAsync(newStudent, token);
                return Ok(newStudent);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken token = default)
        {
            _logger.LogInformation($"StudentDelete, id: {id}");

            await _studentsRepository.DeleteAsync(id, token);
            return Ok("Student deleted.");
        }
    }
}
