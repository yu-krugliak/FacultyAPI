using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"EducationTypesGetAll");

            var education = await _educationTypesRepository
                .GetAllAsync(cancellationToken);

            return Ok(education);
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

            return Ok(education);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] EducationType educationType, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"EducationTypesPost:\n{JsonConvert.SerializeObject(educationType)}");

            try
            {
                await _educationTypesRepository.UpdateAsync(educationType, cancellationToken);
                return Ok(educationType);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public async Task<IActionResult> AddAsync([FromBody] EducationType educationType, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"EducationTypePut:\n{JsonConvert.SerializeObject(educationType)}");

            try
            {
                await _educationTypesRepository.AddAsync(educationType, cancellationToken);
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
