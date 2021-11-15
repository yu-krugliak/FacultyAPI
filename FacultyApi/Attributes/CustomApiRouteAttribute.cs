using Microsoft.AspNetCore.Mvc;

namespace FacultyApi.Attributes
{
    //public class ApiRouteAttribute : RouteAttribute
    //{
    //    public ApiRouteAttribute 
    //}

    public class ApiRouteAttribute : RouteAttribute
    {
        public ApiRouteAttribute () : base("api/v{version:apiVersion}/[controller]")
        { }
    }

}
