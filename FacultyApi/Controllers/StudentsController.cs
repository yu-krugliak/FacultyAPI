﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FacultyApi.DataBase;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FacultyApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentsRepository studentsRepository, ILogger<StudentsController> logger)
        {
            _studentsRepository = studentsRepository;
            _logger = logger;
        }

        //[HttpGet()]
        //public IActionResult GetAll()
        //{
        //    _logger.LogInformation($"StudentsGetAll");

        //    var student = _studentsRepository
        //        .GetAll()
        //        .Select(s => new StudentDto(s));

        //    return Ok(student);
        //}

        [HttpGet]
        public async Task<IActionResult> GetFiltered([FromQuery] Guid? groupId, [FromQuery] bool? expelled, [FromQuery] string secondName, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Students GetFiltered");

            var student = await _studentsRepository
                .GetAllFilteredAsync(groupId, expelled, secondName, cancellationToken);

            if (student.Count == 0)
            {
                return NotFound("Student not found.");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, ReadStudentModel>());
            var studentMapper = config.CreateMapper();
            var newStudent = studentMapper.Map<List<Student>, List<ReadStudentModel>>(student);

            return Ok(newStudent);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"StudentGet, id: {id}");

            var student = await _studentsRepository.GetAsync(id, cancellationToken);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, ReadStudentModel>());
            var studentMapper = config.CreateMapper();
            var newStudent = studentMapper.Map<Student, ReadStudentModel>(student);

            return Ok(newStudent);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateStudentModel student, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"StudentPost:\n{JsonConvert.SerializeObject(student)}");

            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateStudentModel, Student>());
                var studentMapper = config.CreateMapper();
                var newStudent = studentMapper.Map<UpdateStudentModel, Student>(student);

                await _studentsRepository.UpdateAsync(newStudent, cancellationToken);
                return Ok(newStudent);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> AddAsync([FromBody] CreateStudentModel student, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"StudentPut:\n{JsonConvert.SerializeObject(student)}");

            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateStudentModel, Student>());
                var studentMapper = config.CreateMapper();
                var newStudent = studentMapper.Map<CreateStudentModel, Student>(student);

                await _studentsRepository.AddAsync(newStudent, cancellationToken);
                return Ok(newStudent);
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
