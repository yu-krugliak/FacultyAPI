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
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"GroupGet, id: {id}");

            var group = _groupsRepository.Get(id);
            if (group == null)
            {
                return NotFound("Group not found.");
            }

            return Ok(group);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Group group)
        {
            _logger.LogInformation($"GroupPost:\n{JsonConvert.SerializeObject(group)}");

            _groupsRepository.Update(group);
            return Ok("Group updated.");
        }


        [HttpPut]
        public IActionResult Put([FromBody] Group group)
        {
            _logger.LogInformation($"GroupPut:\n{JsonConvert.SerializeObject(group)}");

            _groupsRepository.Add(group);
            return Ok("New group created.");
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"GroupDelete, id: {id}");

            _groupsRepository.Delete(id);
            return Ok("Group deleted.");
        }

    }
}
