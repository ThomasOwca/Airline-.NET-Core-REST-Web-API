using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline_Web_API.Models.Entities;
using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Models.ServiceModels.PassengerServiceModels;
using Airline_Web_API.Services.PassengerService;
using Microsoft.AspNetCore.Mvc;

namespace Airline_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : Controller
    {
        private readonly IPassenger _passengerService;

        public PassengerController(IPassenger passengerService)
        {
            _passengerService = passengerService;
        }

        // GET: api/passenger
        [HttpGet]
        public IActionResult GetAllPassenger()
        {
            var response = new GetAllPassengerResponse();

            try
            {
                response = _passengerService.GetAllPassenger(new GetAllPassengerRequest());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            if (response.IsSuccessful)
                return Ok(response.Passengers);
            else
                return BadRequest(response.Message);
        }

        // GET: api/passengers/{passengerId}
        [HttpGet("{passengerId:int}")]
        public IActionResult GetPassenger([FromRoute] int passengerId)
        {
            var response = new GetPassengerResponse();

            try
            {
                response = _passengerService.GetPassenger(new GetPassengerRequest { PassengerId = passengerId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            if (response.IsSuccessful)
                return Ok(response.Passenger);
            else
                return BadRequest(response.Message);
        }

        // POST: api/passengers
        [HttpPost]
        public IActionResult CreatePassenger([FromBody] Passenger passenger)
        {
            var response = new PostPassengerResponse();

            try
            {
                response = _passengerService.PostPassenger(new PostPassengerRequest { NewPassenger = passenger });
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

        // PUT: api/passenger/update
        [HttpPut("update")]
        public IActionResult UpdatePassenger([FromBody] Passenger passenger)
        {
            var response = new PutPassengerResponse();

            try
            {
                response = _passengerService.PutPassenger(new PutPassengerRequest { UpdatePassenger = passenger });
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

        // DELETE: api/passengers/{passengerId}
        [HttpDelete("{passengerId:int}")]
        public IActionResult DeletePassenger([FromRoute] int passengerId)
        {
            var response = new DeletePassengerResponse();

            try
            {
                response = _passengerService.DeletePassenger(new DeletePassengerRequest { PassengerId = passengerId });
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
