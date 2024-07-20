using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewApiController : ControllerBase
    {
        [HttpGet(Name = "GetNewApi")]
        public string GetNewApi()
        {
            return "Hello from NewApiController!";
        }
    }
}