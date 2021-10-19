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
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"SubjectGet, id: {id}");

            var subject = _SubjectsRepository.Get(id);
            if (subject == null)
            {
                return NotFound("Subject not found.");
            }

            return Ok(subject);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Subject subject)
        {
            _logger.LogInformation($"SubjectPost:\n{JsonConvert.SerializeObject(subject)}");

            _SubjectsRepository.Update(subject);
            return Ok("Subject updated.");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Subject subject)
        {
            _logger.LogInformation($"SubjectPut:\n{JsonConvert.SerializeObject(subject)}");

            _SubjectsRepository.Add(subject);
            return Ok("New subject created.");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"SubjectDelete, id: {id}");

            _SubjectsRepository.Delete(id);
            return Ok("Subject deleted.");
        }
    }
}
