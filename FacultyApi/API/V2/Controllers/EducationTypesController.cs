using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Db.IRepository;
using Db.Models.EducationTypes;
using FacultyApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FacultyApi.API.V2.Controllers
{
    [Attributes.V2, ApiRoute]
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

        [HttpPost]
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
