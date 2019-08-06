using Airline_Web_API.Data;
using Airline_Web_API.Models.Entities;
using Airline_Web_API.Models.ServiceModels.FlightServiceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.FlightService
{
    public class FlightService : IFlight
    {
        private readonly ApplicationDbContext _context;

        public FlightService(ApplicationDbContext context)
        {
            _context = context;
        }

        public GetFlightsResponse GetFlights(GetFlightsRequest request)
        {
            var response = new GetFlightsResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var flight = _context.Flights
                    .Include(fare => fare.Aircraft)
                    .Include(fare => fare.Status)
                    .ToList();

                if (flight != null && flight.Count !=0)
                {
                    response.IsSuccessful = true;
                    response.Message = "The flight was found.";
                    response.AirlineFlight = flight;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "The flight was not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        GetFlightByFlightIdResponse GetFlightByFlightId(GetFlightByFlightIdRequest request)
        {
            var response = new GetFlightByFlightIdResponse
            {
                IsSuccessful = false,
                Message = "",
            };

            try
            {
                var flight = _context.Flights
                    .Include(fare => fare.Aircraft)
                    .Include(fare => fare.Status)
                    .Include(fare => fare.FlightId == request.FlightId)
                    .ToList();

                if (flight != null)
                {
                    response.IsSuccessful = true;
                    response.Message = "The flight was found.";
                    response.AirlineFlight = flight;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "The flight was not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public PostFlightResponse PostFlight(PostFlightRequest request)
        {
            var response = new PostFlightResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            Flight flight = new Flight();

            if (request.Flight.Id > 0)
                flight = _context.Flights.FirstOrDefault(fare => fare.Id == request.Flight.Id);
            else
            {
                response.Message = "This flight is currently unavailable to schedule.";
            }

            try
            {

            }
        }
        //Next
    }
}
