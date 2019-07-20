using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Airline_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : Controller
    {
        // GET: api/aircraft
        [HttpGet]
        public IActionResult Aircraft()
        {
            // Implement logic for retrieving aircraft in here.
            return Ok();
        }

        // GET: api/aircraft
        [HttpPost]
        public IActionResult Aircraft([FromBody] Aircraft aircraft)
        {
            return Ok();
        }
    }
}