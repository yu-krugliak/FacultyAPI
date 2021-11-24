using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Db.IRepository;
using Db.Models.Students;
using FacultyApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FacultyApi.API.V2.Controllers
{
    [Attributes.V2, ApiRoute]
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
            _logger.Log(LogLevel.Information, /*null*/ $"Message");

            try
            {
                var newStudent = _mapper.Map<Student>(student);
                var result = await _studentsRepository.AddAsync(newStudent, cancellationToken);
                if (result == null)
                {
                    throw new ArgumentNullException(nameof(result));
                }

                return Ok(student);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                return BadRequest(ex);
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
