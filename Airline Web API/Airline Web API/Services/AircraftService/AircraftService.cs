using Airline_Web_API.Data;
using Airline_Web_API.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.AircraftService
{
    public class AircraftService : IAircraft
    {
        private readonly ApplicationDbContext _context;

        public AircraftService(ApplicationDbContext context)
        {
            _context = context;
        }

        public GetAircraftResponse GetAircraft(GetAircraftRequest request)
        {
            var response = new GetAircraftResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                // Query this aircraft where the AircraftId matches in the database. Essentially this is a SQL WHERE clause.
                var aircraft = _context.Aircraft.FirstOrDefault(plane => plane.Id == request.AircraftId);

                if (aircraft != null)
                {
                    response.Aircraft = aircraft;
                    response.IsSuccessful = true;
                    response.Message = "Aircraft was found.";
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Aircrat was not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public GetAllAircraftResponse GetAllAircraft(GetAllAircraftRequest request)
        {
            var response = new GetAllAircraftResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var aircraft = _context.Aircraft.ToList();

                if (aircraft != null || aircraft.Count != 0)
                {
                    response.Aircraft = aircraft;
                    response.IsSuccessful = true;
                    response.Message = "Aircraft were found.";
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Aircraft were not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public PostAircraftResponse PostAircraft(PostAircraftRequest request)
        {
            // Needs to actually use business logic here.
            return new PostAircraftResponse();
        }
    }
}
