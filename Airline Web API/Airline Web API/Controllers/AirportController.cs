using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline_Web_API.Models.Entities;
using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Models.ServiceModels.AirportServiceModels;
using Airline_Web_API.Services.AirportService;
using Microsoft.AspNetCore.Mvc;

namespace Airline_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : Controller
    {
        private readonly IAirport _airportService;

        public AirportController(IAirport airportService)
        {
            _airportService = airportService;
        }

        // GET: api/airport
        [HttpGet]
        public IActionResult GetAllAirport()
        {
            var response = new GetAllAirportResponse();

            try
            {
                response = _airportService.GetAllAirport(new GetAllAirportRequest());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            if (response.IsSuccessful)
                return Ok(response.Airport);
            else
                return BadRequest(response.Message);
        }

        // GET: api/airport/{airportId}
        [HttpGet("{airportId:int}")]
        public IActionResult GetAirport([FromRoute] int airportId)
        {
            var response = new GetAirportResponse();

            try
            {
                response = _airportService.GetAirport(new GetAirportRequest { AirportId = airportId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            if (response.IsSuccessful)
                return Ok(response.Airport);
            else
                return BadRequest(response.ToString());
        }

        // POST: api/airport
        [HttpPost]
        public IActionResult CreateAirport([FromBody] Airport airport)
        {
            var response = new PostAirportResponse();

            try
            {
                response = _airportService.PostAirport(new PostAirportRequest { NewAirport = airport });
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

        // PUT: api/airport/update
        [HttpPut("update")]
        public IActionResult UpdateAirport([FromBody] Airport airport)
        {
            var response = new PutAirportResponse();

            try
            {
                response = _airportService.PutAirport(new PutAirportRequest { UpdatedAirport = airport });
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

        // DELETE: api/airport/{airportId}
        [HttpDelete("{airportId:int}")]
        public IActionResult DeleteAirport([FromRoute] int airportId)
        {
            var response = new DeleteAirportResponse();

            try
            {
                response = _airportService.DeleteAirport(new DeleteAirportRequest { AirportId = airportId });
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
    }
}