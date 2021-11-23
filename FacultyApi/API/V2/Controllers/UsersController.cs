using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Db.IRepository;
using Db.Models.Students;
using Microsoft.AspNetCore.Authorization;
using FacultyApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FacultyApi.Auth;

namespace FacultyApi.API.V2.Controllers
{
    [Attributes.V2, ApiRoute]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService; 
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            _logger.LogInformation($"Authentication");

            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation($"Getting all users");

            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
