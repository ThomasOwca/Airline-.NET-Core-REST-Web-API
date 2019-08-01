using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.Entities
{
    public class FlightStatus
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
