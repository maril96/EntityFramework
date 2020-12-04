using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esercitazione.Work.Core.BusinessLayer;
using Esercitazione.Work.Core.Model;

namespace Esercitazione.Work.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private DataService dataService;
        public WorkController(DataService service)
        {
            this.dataService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            dataService.Get();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID");

            dataService.GetEmployee(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Employee e)
        {
            if (e == null) return BadRequest("Invalid input");

            dataService.Add(e);
                return Ok(e);
        }

        [HttpPut]
        public IActionResult Put(Employee e)
        {
            if (e == null) return BadRequest("Invalid input");
            
            dataService.Update(e);
            return Ok(e);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID");
            dataService.DeleteEmployee(id);
            return Ok();
        }

        [HttpGet("{e}")]
        public IActionResult Get(Employee e)
        {
            if (e == null) return BadRequest("Invalid input");
            var id = e.EmployeeID;
            dataService.GetCollegues(id);
            return Ok();
        }
    }
}
