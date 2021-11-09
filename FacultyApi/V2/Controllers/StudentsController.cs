using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FacultyApi.DataBase;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FacultyApi.V2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]

    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly ILogger<StudentsController> _logger;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsRepository studentsRepository, ILogger<StudentsController> logger, IMapper mapper)
        {
            _studentsRepository = studentsRepository;
            _logger = logger;
            _mapper = mapper;
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
        public async Task<IActionResult> GetFiltered([FromQuery] Guid? groupId, [FromQuery] bool? expelled, [FromQuery] string secondName, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Students GetFiltered");

            var student = await _studentsRepository
                .GetAllFilteredAsync(groupId, expelled, secondName, cancellationToken);

            if (student.Count == 0)
            {
                return NotFound("Student not found.");
            }

            var newStudent = _mapper.Map<List<ReadStudentModel>>(student);
            return Ok(newStudent);
        }
        //[ApiVersion(1,0)]
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"StudentGet, id: {id}");

            var student = await _studentsRepository.GetAsync(id, cancellationToken);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var newStudent = _mapper.Map<ReadStudentModel>(student);
            return Ok(newStudent);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateStudentModel student, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"StudentPost:\n{JsonConvert.SerializeObject(student)}");

            try
            {
                var newStudent = _mapper.Map<Student>(student);
                await _studentsRepository.UpdateAsync(newStudent, cancellationToken);

                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync([FromBody] CreateStudentModel student, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"StudentPut:\n{JsonConvert.SerializeObject(student)}");

            try
            {
                var newStudent = _mapper.Map<Student>(student);
                await _studentsRepository.AddAsync(newStudent, cancellationToken);

                return Ok(student);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"StudentDelete, id: {id}");

            await _studentsRepository.DeleteAsync(id, cancellationToken);
            return Ok("Student deleted.");
        }
    }
}
