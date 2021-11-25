using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Db.IRepository;
using Db.Models.Students;
using FacultyApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FacultyApi.API.V1.Controllers
{
    [ApiController]
    [Attributes.V1, ApiRoute]

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
        //        .GetAllFilteredAsync(null, null, null)
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

        [HttpPut]
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
    }
}
