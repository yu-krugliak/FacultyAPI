using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FacultyApi.Attributes;
using Db.IRepository;
using Db.Models.Basic;

namespace FacultyApi.API.V1.Controllers
{
    [Attributes.V1, ApiRoute]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsRepository _SubjectsRepository;
        private readonly ILogger<SubjectsController> _logger;

        public SubjectsController(ISubjectsRepository SubjectsRepository, ILogger<SubjectsController> logger)
        {
            _SubjectsRepository = SubjectsRepository;
            _logger = logger;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"SubjectsGetAll");

            var subject = _SubjectsRepository
                .GetAll();

            return Ok(subject);
        }


        [HttpGet()]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInformation($"SubjectGet, id: {id}");

            var subject = _SubjectsRepository.Get(id);
            if (subject == null)
            {
                return NotFound("Subject not found.");
            }

            return Ok(subject);
        }

        [HttpPut]
        public IActionResult Post([FromBody] Subject subject)
        {
            _logger.LogInformation($"SubjectPost:\n{JsonConvert.SerializeObject(subject)}");

            try
            {
                _SubjectsRepository.Update(subject);
                return Ok(subject);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
