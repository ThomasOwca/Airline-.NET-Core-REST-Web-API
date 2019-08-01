using Airline_Web_API.Data;
using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Models.ServiceModels.PassengerServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.PassengerService
{
    public class PassengerService : IPassenger
    {
        private readonly ApplicationDbContext _context;

        public PassengerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public GetPassengerResponse GetPassenger(GetPassengerRequest request)
        {
            var response = new GetPassengerResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var passenger = _context.Passengers.FirstOrDefault(passenger_ => passenger_.Id == request.PassengerId);

                if (passenger != null)
                {
                    response.Passenger = passenger;
                    response.IsSuccessful = true;
                    response.Message = "Passenger was found.";
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Passenger was not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public GetAllPassengerResponse GetAllPassenger(GetAllPassengerRequest request)
        {
            var response = new GetAllPassengerResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var passenger = _context.Passengers.ToList();

                if (passenger != null || passenger.Count != 0)
                {
                    response.Passengers = passenger;
                    response.IsSuccessful = true;
                    response.Message = "Passengers were found.";
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "Passengers were not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public PostPassengerResponse PostPassenger(PostPassengerRequest request)
        {
            var response = new PostPassengerResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                _context.Add(request.NewPassenger);
                _context.SaveChanges();

                response.IsSuccessful = true;
                response.Message = "Passenger successfully added to database.";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.ToString();
            }

            return response;
        }

        public PutPassengerResponse PutPassenger(PutPassengerRequest request)
        {
            var response = new PutPassengerResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                _context.Update(request.UpdatePassenger);
                _context.SaveChanges();

                response.IsSuccessful = true;
                response.Message = "Passenger successfully updated in the database.";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public DeletePassengerResponse DeletePassenger(DeletePassengerRequest request)
        {
            var response = new DeletePassengerResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var passengerToDelete = _context.Passengers.FirstOrDefault(passenger => passenger.Id == request.PassengerId);

                if (passengerToDelete != null)
                {
                    _context.Remove(passengerToDelete);
                    _context.SaveChanges();

                    response.IsSuccessful = true;
                    response.Message = "Passenger successfully removed.";
                }
                else
                {
                    response.Message = "Passenger was not removed.";
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
