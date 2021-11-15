using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class V2 : ApiVersionAttribute
    {
        public V2() : base(new ApiVersion(2, 0))
        { }
    }

}
