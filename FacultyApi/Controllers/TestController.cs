//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using FacultyApi.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace FacultyApi.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class TestController : ControllerBase
//    {
//        [HttpGet]
//        public Test Get()
//        {
//            return new Test()
//            {
//                Id = 1,
//                Name = "Apple",
//                Cost = 20.11m
//            };
//        }

//        [HttpGet]
//        [Route("withcost/{cost}/get")]
//        public Test GetCost(decimal cost)
//        {
//            return new Test()
//            {
//                Id = 1,
//                Name = "Apple",
//                Cost = cost
//            };
//        }

//        [HttpGet]
//        [Route("query")]
//        public Test GetCostQuery([FromQuery]decimal cost,[FromQuery]string name)
//        {
//            return new Test()
//            {
//                Id = 1,
//                Name = name,
//                Cost = cost
//            };
//        }

//        [HttpPost]
//        public Test Post([FromBody]Test test)
//        {
//            test.Cost *= 10;
//            return test;
//        }
//    }
//}
