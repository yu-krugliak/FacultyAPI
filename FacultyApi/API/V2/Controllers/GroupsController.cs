using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FacultyApi.Attributes;
using Db.IRepository;
using Db.Models.Basic;

namespace FacultyApi.API.V2.Controllers
{
    [Attributes.V2, ApiRoute]
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


        [HttpPost]
        public IActionResult Put([FromBody] Group group)
        {
            _logger.LogInformation($"GroupPut:\n{JsonConvert.SerializeObject(group)}");

            try
            {
                _groupsRepository.Add(group);
                return Ok(group);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation($"GroupDelete, id: {id}");

            _groupsRepository.Delete(id);
            return Ok("Group deleted.");
        }

    }
}
