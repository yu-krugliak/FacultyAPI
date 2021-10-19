﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacultyApi.DataBase;
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
    public class EducationTypesController : ControllerBase
    {
        private readonly IEducationTypesRepository _educationTypesRepository;
        private readonly ILogger<EducationTypesController> _logger;
        public EducationTypesController(IEducationTypesRepository educationTypesRepository, ILogger<EducationTypesController> logger)
        {
            _educationTypesRepository = educationTypesRepository;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"EducationTypesGetAll");

            var education = _educationTypesRepository
                .GetAll();

            return Ok(education);
        }
        

        [HttpGet()]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"EducationTypesGet, id: {id}");

            var education = _educationTypesRepository.Get(id);
            if (education == null)
            {
                return NotFound("Education Types not found.");
            }

            return Ok(education);
        }


        [HttpPost]
        public IActionResult Post([FromBody] EducationType educationType)
        {
            _logger.LogInformation($"EducationTypesPost:\n{JsonConvert.SerializeObject(educationType)}");

            _educationTypesRepository.Update(educationType);
            return Ok("Education Type updated.");
        }


        [HttpPut]
        public IActionResult Put([FromBody] EducationType educationType)
        {
            _logger.LogInformation($"EducationTypePut:\n{JsonConvert.SerializeObject(educationType)}");

            _educationTypesRepository.Add(educationType);
            return Ok("New education type created.");
        }
      

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"EducationTypeDelete, id: {id}");

            _educationTypesRepository.Delete(id);
            return Ok("Education type deleted.");
        }
    }
}
