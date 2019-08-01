using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.FlightServiceModels
{
    public class DeleteFlightRequest : BaseServiceRequest
    {
        public int FlightInventoryId { get; set; }
    }
}
