using System;
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
    public class EducationTypesController : ControllerBase
    {
        private readonly IEducationTypesRepository _educationTypesRepository;
        private readonly ILogger<EducationTypesController> _logger;
        private readonly IMapper _mapper;
        public EducationTypesController(IEducationTypesRepository educationTypesRepository, ILogger<EducationTypesController> logger, IMapper mapper)
        {
            _educationTypesRepository = educationTypesRepository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"EducationTypesGetAll");

            var education = await _educationTypesRepository
                .GetAllAsync(cancellationToken);

            if (education.Count == 0)
            {
                return NotFound("Education types not found.");
            }

            var newEducation = _mapper.Map<List<ReadEducationModel>>(education);
            return Ok(newEducation);
        }
        

        [HttpGet()]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"EducationTypesGet, id: {id}");

            var education = await _educationTypesRepository.GetAsync(id, cancellationToken);
            if (education == null)
            {
                return NotFound("Education Types not found.");
            }

            var newEducation = _mapper.Map<ReadEducationModel>(education);
            return Ok(newEducation);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEducationModel educationType, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"EducationTypesPost:\n{JsonConvert.SerializeObject(educationType)}");

            try
            {
                var newEducation = _mapper.Map<EducationType>(educationType);
                await _educationTypesRepository.UpdateAsync(newEducation, cancellationToken);

                return Ok(educationType);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public async Task<IActionResult> AddAsync([FromBody] CreateEducationModel educationType, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"EducationTypePut:\n{JsonConvert.SerializeObject(educationType)}");

            try
            {
                var newEducation = _mapper.Map<EducationType>(educationType);
                await _educationTypesRepository.AddAsync(newEducation, cancellationToken);

                return Ok(educationType);
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
            _logger.LogInformation($"EducationTypeDelete, id: {id}");

            await _educationTypesRepository.DeleteAsync(id, cancellationToken);
            return Ok("Education type deleted.");
        }
    }
}
