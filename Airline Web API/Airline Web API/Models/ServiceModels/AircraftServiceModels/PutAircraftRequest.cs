using Airline_Web_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.AircraftServiceModels
{
    public class PutAircraftRequest : BaseServiceRequest
    {
        public Aircraft UpdatedAircraft { get; set; }
    }
}
