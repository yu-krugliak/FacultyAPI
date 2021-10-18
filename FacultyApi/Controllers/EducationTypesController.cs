using System;
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
        public IEnumerable<EducationType> GetAll()
        {
            _logger.LogInformation($"EducationTypesGetAll");

            return _educationTypesRepository.GetAll();
        }


        [HttpGet()]
        [Route("{id:int}")]
        public EducationType Get(int id)
        {
            return _educationTypesRepository.Get(id);
        }


        [HttpPost]
        public int Post([FromBody] EducationType educationType)
        {
            _logger.LogInformation($"EducationTypesPost:\n{JsonConvert.SerializeObject(educationType)}");
            _educationTypesRepository.Update(educationType);
            return 1;
        }


        [HttpPut]
        public int Put([FromBody] EducationType educationType)
        {
            _educationTypesRepository.Add(educationType);
            return 1;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public int Delete(int id)
        {
            _educationTypesRepository.Delete(id);
            return 1;
        }
    }
}
