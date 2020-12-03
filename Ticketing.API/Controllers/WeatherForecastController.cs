using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("[controller]")] //Ho scritto cose a proposito nello startup
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int id)
        {//In questo modo, se io ho un parametro in più sa che deve eseguire questo metodo e non l'altro.
            //Ma in questo caso restituisco la stessa cosa per ogni id...dovrei usare l'id nell'implementazione
            //se volessi stampare cose diverse...

            return new WeatherForecast
            {
                Date=DateTime.Now,
                TemperatureC=34,
                Summary="Fatto da me!"
            };
        }
    }
}
