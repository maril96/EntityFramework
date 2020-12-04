using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esercitazione.Work.Core.BusinessLayer;

namespace Esercitazione.Work.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
       

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("The application is running");
        }
    }
}
