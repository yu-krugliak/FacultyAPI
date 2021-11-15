using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using FacultyApi.Models;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FacultyApi.Attributes;


namespace FacultyApi.V2.Controllers
{
    [Attributes.V2, ApiRouteAttribute]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly ILogger<LessonsController> _logger;

        public LessonsController(ILessonsRepository lessonsRepository, ILogger<LessonsController> logger)
        {
            _lessonsRepository = lessonsRepository;
            _logger = logger;
        }

        
        [HttpPost]
        public IActionResult Put([FromBody] LessonDto lesson)
        {
            _logger.LogInformation($"LessonPut:\n{JsonConvert.SerializeObject(lesson)}");

            var newLesson = new Lesson()
            {
                Semester = lesson.Semester ?? DateTime.MinValue,
                SubjectId = lesson.SubjectId,
                LecturerId = lesson.LecturerId,
                GroupId = lesson.GroupId,
                DayAndTime = lesson.DayAndTime ?? DateTime.MinValue
            };

            try
            {
                _lessonsRepository.Add(newLesson);
                return Ok(newLesson);
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
            _logger.LogInformation($"LessonDelete, id: {id}");

            _lessonsRepository.Delete(id);
            return Ok("Lesson deleted.");
        }
    }
}
