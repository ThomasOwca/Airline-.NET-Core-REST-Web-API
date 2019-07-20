using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline_Web_API.Models.Entities;
using Airline_Web_API.Models.ServiceModels.FleetServiceModels;
using Airline_Web_API.Services.FleetService;
using Microsoft.AspNetCore.Mvc;

namespace Airline_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FleetController : Controller
    {
        private readonly IFleet _fleetService;

        public FleetController(IFleet fleetService)
        {
            _fleetService = fleetService;
        }

        // GET: api/Fleet
        [HttpGet]
        public IActionResult GetEntireFleet()
        {
            var response = new GetFleetResponse();

            try
            {
                response = _fleetService.GetFleet(new GetFleetRequest());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (response.IsSuccessful)
                return Ok(response.AirlineAircraft);
            else
                return BadRequest(response.Message);
        }

        // GET: api/Fleet/{aircraftId}
        [HttpGet("{aircraftId:int}")]
        public IActionResult GetFleetByAircraft([FromRoute] int aircraftId) 
        {
            var response = new GetFleetByAircraftIdResponse();

            try
            {
                response = _fleetService.GetFleetByAircraftId(new GetFleetByAircraftIdRequest { AircraftId = aircraftId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (response.IsSuccessful)
                return Ok(response.AirlineAircraft);
            else
                return BadRequest(response.Message);
        }

        // POST: api/Fleet
        [HttpPost]
        public IActionResult PostAircraftToFleet([FromBody] Aircraft aircraft)
        {
            var response = new PostAircraftToFleetResponse();

            try
            {
                response = _fleetService.PostAircraftToFleet(new PostAircraftToFleetRequest { Aircraft = aircraft });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (response.IsSuccessful)
                return Ok(response.Message);
            else
                return BadRequest(response.Message);
        }

    }
}