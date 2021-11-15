using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using FacultyApi.Models;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FacultyApi.Attributes;


namespace FacultyApi.V2.Controllers
{
    [Attributes.V2, ApiRouteAttribute]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturersRepository _lecturersRepository;
        private readonly ILogger<LecturersController> _logger;
        public LecturersController(ILecturersRepository lecturersRepository, ILogger<LecturersController> logger)
        {
            _lecturersRepository = lecturersRepository;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Put([FromBody] Lecturer lecturer)
        {
            _logger.LogInformation($"LecturerPut:\n{JsonConvert.SerializeObject(lecturer)}");

            try
            {
                _lecturersRepository.Add(lecturer);
                return Ok(lecturer);
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
            _logger.LogInformation($"LecturerDelete, id: {id}");

            _lecturersRepository.Delete(id);
            return Ok("Lecturer deleted.");
        }

    }
}
