using Airline_Web_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.FlightServiceModels
{
    public class PutFlightRequest : BaseServiceRequest
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public FlightStatus Status { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
