using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliveController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Yes I am Alive!");
        }
    }
}
