using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.AircraftServiceModels
{
    public class DeleteAircraftRequest : BaseServiceRequest
    {
        public int AircraftId { get; set; }
    }
}
