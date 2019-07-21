using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline_Web_API.Models.Entities;
using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Services.AircraftService;
using Microsoft.AspNetCore.Mvc;

namespace Airline_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : Controller
    {
        private readonly IAircraft _aircraftService;

        public AircraftController(IAircraft aircraftService)
        {
            _aircraftService = aircraftService;
        }

        // GET: api/aircraft
        [HttpGet]
        public IActionResult GetAllAircraft()
        {
            var response = new GetAllAircraftResponse();

            try
            {
                response = _aircraftService.GetAllAircraft(new GetAllAircraftRequest());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            if (response.IsSuccessful)
                return Ok(response.Aircraft);
            else
                return BadRequest(response.Message);
        }

        // GET: api/aircraft/{aircraftId}
        [HttpGet("{aircraftId:int}")]
        public IActionResult GetAircraft([FromRoute] int aircraftId)
        {
            var response = new GetAircraftResponse();

            try
            {
                response = _aircraftService.GetAircraft(new GetAircraftRequest { AircraftId = aircraftId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            if (response.IsSuccessful)
                return Ok(response.Aircraft);
            else
                return BadRequest(response.ToString());
        }

        // POST: api/aircraft
        [HttpPost]
        public IActionResult CreateAircraft([FromBody] Aircraft aircraft)
        {
            var response = new PostAircraftResponse();

            try
            {
                response = _aircraftService.PostAircraft(new PostAircraftRequest { NewAircraft = aircraft });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            if (response.IsSuccessful)
                return Ok(response.Message);
            else
                return BadRequest(response.Message);
        }

        // PUT: api/aircraft/update
        [HttpPut("update")]
        public IActionResult UpdateAircraft([FromBody] Aircraft aircraft)
        {
            return Ok();
        }

        // DELETE: api/aircraft/{aircraftId}
        [HttpDelete("{aircraftId:int}")]
        public IActionResult DeleteAircraft([FromRoute] int aircraftId)
        {
            return Ok();
        }
    }
}