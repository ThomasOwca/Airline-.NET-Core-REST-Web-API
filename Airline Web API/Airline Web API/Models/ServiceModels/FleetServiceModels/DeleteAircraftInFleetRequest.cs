using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.FleetServiceModels
{
    public class DeleteAircraftInFleetRequest : BaseServiceRequest
    {
        public int FleetInventoryId { get; set; }
    }
}
