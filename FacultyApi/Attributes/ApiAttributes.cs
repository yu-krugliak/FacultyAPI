using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyApi.Attributes
{
    public class V1 : ApiVersionAttribute
    {
        public V1() : base(new ApiVersion(1, 0))
        { }
    }

    //public class ApiRouteAttribute : RouteAttribute
    //{
    //    public ApiRouteAttribute 
    //}
}
