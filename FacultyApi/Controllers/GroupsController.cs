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
        public IEnumerable<Group> GetAll()
        {
            _logger.LogInformation($"GroupsGetAll");

            return _groupsRepository.GetAll();
        }


        [HttpGet()]
        [Route("{id:int}")]
        public Group Get(int id)
        {
            return _groupsRepository.Get(id);
        }


        [HttpPost]
        public int Post([FromBody] Group group)
        {
            _logger.LogInformation($"GroupsPost:\n{JsonConvert.SerializeObject(group)}");
            _groupsRepository.Update(group);
            return 1;
        }


        [HttpPut]
        public int Put([FromBody] Group group)
        {
            _groupsRepository.Add(group);
            return 1;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public int Delete(int id)
        {
            _groupsRepository.Delete(id);
            return 1;
        }


        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        ///// <response code="400">If the item is null</response>            
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //var groups = _groupsRepository.GetAll();

                    //if (groups == null) 
                    //    return NotFound();

                    //return Ok(groups);
        //[HttpGet]
                //[Route("{id:int}")]
                //public IActionResult Get(int id)
                //{
                //    var group = _groupsRepository.Get(id);

                //    if (group == null)
                //    {
                //        NotFound();
                //    }

                //    return Ok(group);
                //}

    }
}
