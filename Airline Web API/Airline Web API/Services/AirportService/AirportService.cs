using Airline_Web_API.Data;
using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Models.ServiceModels.AirportServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.AirportService
{
    public class AirportService : IAirport
    {
        private readonly ApplicationDbContext _context;

        public AirportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public GetAirportResponse GetAirport(GetAirportRequest request)
        {
            var response = new GetAirportResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                // Query this airport where the AirportId matches in the database. Essentially this is a SQL WHERE clause.
                var airport = _context.Airports.FirstOrDefault(Airport => Airport.Id == request.AirportId);

                if (airport != null)
                {
                    response.Airport = airport;
                    response.IsSuccessful = true;
                    response.Message = "Airport was found.";
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

        public GetAllAirportResponse GetAllAirport(GetAllAirportRequest request)
        {
            var response = new GetAllAirportResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var airport = _context.Airports.ToList();

                if (airport != null || airport.Count != 0)
                {
                    response.Airport = airport;
                    response.IsSuccessful = true;
                    response.Message = "Airports were found.";
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Airports were found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public PostAirportResponse PostAirport(PostAirportRequest request)
        {
            var response = new PostAirportResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                _context.Add(request.NewAirport);
                _context.SaveChanges();

                response.IsSuccessful = true;
                response.Message = "Airport successfully added to database.";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.ToString();
            }

            return response;
        }

        public PutAirportResponse PutAirport(PutAirportRequest request)
        {
            var response = new PutAirportResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                _context.Update(request.UpdatedAirport);
                _context.SaveChanges();

                response.IsSuccessful = true;
                response.Message = "Airport successfully updated in the database.";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.ToString();
            }

            return response;
        }

        public DeleteAirportResponse DeleteAirport(DeleteAirportRequest request)
        {
            var response = new DeleteAirportResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var airportToDelete = _context.Airports.FirstOrDefault(airport => airport.Id == request.AirportId);

                if (airportToDelete != null)
                {
                    _context.Remove(airportToDelete);
                    _context.SaveChanges();

                    response.IsSuccessful = true;
                    response.Message = "Airport successfully removed.";
                }
                else
                {
                    response.Message = "Airport was not removed.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
            }

            return response;
        }
    }
}
