using Airline_Web_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.PassengerServiceModels
{
    public class GetPassengerResponse : BaseServiceResponse
    {
        public Passenger Passenger { get; set; }
    }
}
