using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        public WeatherForecastController(
            DataContext context,
            ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get(CancellationToken ct)
        {
            var t = await _context.Values.ToListAsync(ct);
            return Ok(t);
        }
    }
}