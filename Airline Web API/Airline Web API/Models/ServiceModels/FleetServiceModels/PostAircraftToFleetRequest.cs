using Airline_Web_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.FleetServiceModels
{
    public class PostAircraftToFleetRequest : BaseServiceRequest
    {
        public Aircraft Aircraft { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public AircraftStatus Status { get; set; }
    }
}
