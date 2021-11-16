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
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsRepository _lessonsRepository;
        private readonly ILogger<LessonsController> _logger;

        public LessonsController(ILessonsRepository lessonsRepository, ILogger<LessonsController> logger)
        {
            _lessonsRepository = lessonsRepository;
            _logger = logger;
        }

        //[HttpGet()]
        //public IActionResult GetAll()
        //{
        //    _logger.LogInformation($"LessonsGetAll");

        //    var lesson = _LessonsRepository
        //        .GetAll()
        //        .Select(l => new LessonDto(l));

        //    return Ok(lesson);
        //}

        [HttpGet]
        public IActionResult GetFiltered([FromQuery] Guid? groupId)
        {
            _logger.LogInformation($"Lessons GetFiltered");

            var lesson = _lessonsRepository
                .GetAllFiltered(groupId)
                .Select(l => new LessonDto(l));

            return Ok(lesson);
        }

        [HttpGet()]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInformation($"LessonGet, id: {id}");

            var lesson = _lessonsRepository.Get(id);
            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            return Ok(lesson);
        }

        [HttpPut]
        public IActionResult Post([FromBody] LessonDto lesson)
        {
            _logger.LogInformation($"LessonPost:\n{JsonConvert.SerializeObject(lesson)}");

            var id = lesson.LessonId;
            var oldLesson = _lessonsRepository.Get(id);

            var newLesson = new Lesson()
            {
                LessonId = id,
                Semester = lesson.Semester ?? oldLesson.Semester,
                SubjectId = lesson.SubjectId ?? oldLesson.SubjectId,
                LecturerId = lesson.LecturerId ?? oldLesson.LecturerId,
                GroupId = lesson.GroupId ?? oldLesson.GroupId,
                DayAndTime = lesson.DayAndTime ?? oldLesson.DayAndTime
            };

            try
            {
                _lessonsRepository.Update(newLesson);
                return Ok(newLesson);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
