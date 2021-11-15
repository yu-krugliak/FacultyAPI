using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class V1 : ApiVersionAttribute
    {
        public V1() : base(new ApiVersion(1, 0))
        { }
    }

}
