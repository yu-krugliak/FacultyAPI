using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FacultyApi.Attributes;
using FacultyApi.DataBase;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FacultyApi.V2.Controllers
{
    [Attributes.V2, ApiRouteAttribute]
    [ApiController]


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


        [HttpPost]
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
