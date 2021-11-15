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
using FacultyApi.Attributes;


namespace FacultyApi.V1.Controllers
{
    [Attributes.V1, ApiRouteAttribute]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsRepository _groupsRepository;
        private readonly ILogger<GroupsController> _logger;
        public GroupsController(IGroupsRepository groupsRepository, ILogger<GroupsController> logger)
        {
            _groupsRepository = groupsRepository;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"GroupsGetAll");

            var group = _groupsRepository
                    .GetAll();

            return Ok(group);
        }


        [HttpGet()]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInformation($"GroupGet, id: {id}");

            var group = _groupsRepository.Get(id);
            if (group == null)
            {
                return NotFound("Group not found.");
            }

            return Ok(group);
        }


        [HttpPut]
        public IActionResult Post([FromBody] Group group)
        {
            _logger.LogInformation($"GroupPost:\n{JsonConvert.SerializeObject(group)}");

            try
            {
                _groupsRepository.Update(group);
                return Ok(group);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
