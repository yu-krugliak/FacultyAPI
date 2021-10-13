using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacultyApi.DataBase;
using FacultyApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace FacultyApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsRepository _groupsRepository;

        public GroupsController(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
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
        /// <response code="400">If the item is null</response>            
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var groups = _groupsRepository.GetAll();

            if (groups == null) 
                return NotFound();

            return Ok(groups);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var group = _groupsRepository.Get(id);

            if (group == null)
            {
                NotFound();
            }

            return Ok(group);
        }

        [HttpPost]
        public int Post([FromBody] Group group)
        {
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
        public int Delete([FromQuery] int id)
        {
            _groupsRepository.Delete(id);
            return 1;
        }
    }
}
