using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.AirportServiceModels
{
    public class DeleteAirportRequest : BaseServiceRequest
    {
        public int AirportId { get; set; }
    }
}
