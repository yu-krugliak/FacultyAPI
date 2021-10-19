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

namespace FacultyApi.Controllers
{
    [Route("[controller]")]
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
        public IActionResult GetFiltered([FromQuery] int? groupId)
        {
            _logger.LogInformation($"Lessons GetFiltered");

            var lesson = _lessonsRepository
                .GetAllFiltered(groupId)
                .Select(l => new LessonDto(l));

            return Ok(lesson);
        }

        [HttpGet()]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"LessonGet, id: {id}");

            var lesson = _lessonsRepository.Get(id);
            if (lesson == null)
            {
                return NotFound("Lesson not found.");
            }

            return Ok(lesson);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LessonDto lesson)
        {
            _logger.LogInformation($"LessonPost:\n{JsonConvert.SerializeObject(lesson)}");

            var id = lesson.LessonId ?? 0;
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

            _lessonsRepository.Update(newLesson);

            return Ok("Lesson updated.");
        }

        [HttpPut]
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

            _lessonsRepository.Add(newLesson);

            return Ok("New Lesson created.");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"LessonDelete, id: {id}");

            _lessonsRepository.Delete(id);
            return Ok("Lesson deleted.");
        }
    }
}
