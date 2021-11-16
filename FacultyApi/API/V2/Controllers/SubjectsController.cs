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

namespace FacultyApi.API.V2.Controllers
{
    [Attributes.V2, ApiRoute]
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


        [HttpPost]
        public IActionResult Put([FromBody] Subject subject)
        {
            _logger.LogInformation($"SubjectPut:\n{JsonConvert.SerializeObject(subject)}");

            try
            {
                _SubjectsRepository.Add(subject);
                return Ok(subject);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation($"SubjectDelete, id: {id}");

            _SubjectsRepository.Delete(id);
            return Ok("Subject deleted.");
        }
    }
}
