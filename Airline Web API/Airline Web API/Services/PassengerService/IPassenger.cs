using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Models.ServiceModels.PassengerServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.PassengerService
{
    public interface IPassenger
    {
        GetAllPassengerResponse GetAllPassenger(GetAllPassengerRequest request);
        GetPassengerResponse GetPassenger(GetPassengerRequest request);
        PostPassengerResponse PostPassenger(PostPassengerRequest request);
        PutPassengerResponse PutPassenger(PutPassengerRequest request);
        DeletePassengerResponse DeletePassenger(DeletePassengerRequest request);
    }
}
