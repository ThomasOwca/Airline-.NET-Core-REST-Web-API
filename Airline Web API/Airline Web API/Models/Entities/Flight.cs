using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.Entities
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }
        [ForeignKey("DepartureAirportId")]
        public Airport DepAirport { get; set; }
        [ForeignKey("DestinationAirportId")]
        public Airport DesAirport { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime SheduledDestinationTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ActualLandTime { get; set; }
        [ForeignKey("StatusId")]
        public FlightStatus Status { get; set; }
    }
}
