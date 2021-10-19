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

namespace FacultyApi.Controllers
{
    [Route("[controller]")]
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


        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    _logger.LogInformation($"LecturersGetAll");

        //    var lecturers = _LecturersRepository
        //            .GetAll();

        //    return Ok(lecturers);
        //}


        [HttpGet]
        public IActionResult GetFiltered([FromQuery] int? subjectId, [FromQuery] string degree, [FromQuery] string secondName)
        {
            _logger.LogInformation($"Lecturers GetFiltered");

            var lecturers = _lecturersRepository
                .GetAllFiltered(subjectId, degree, secondName)
                .Select(l => new LecturerDto(l));

            return Ok(lecturers);
        }

        [HttpGet()]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"LecturerGet, id: {id}");

            var lecturer = _lecturersRepository.Get(id);
            if (lecturer == null)
            {
                return NotFound("Lecturer not found.");
            }

            return Ok(lecturer);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Lecturer lecturer)
        {
            _logger.LogInformation($"LecturerPost:\n{JsonConvert.SerializeObject(lecturer)}");

            _lecturersRepository.Update(lecturer);
            return Ok("Lecturer updated.");
        }


        [HttpPut]
        public IActionResult Put([FromBody] Lecturer lecturer)
        {
            _logger.LogInformation($"LecturerPut:\n{JsonConvert.SerializeObject(lecturer)}");

            _lecturersRepository.Add(lecturer);
            return Ok("New Lecturer created.");
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"LecturerDelete, id: {id}");

            _lecturersRepository.Delete(id);
            return Ok("Lecturer deleted.");
        }

    }
}
