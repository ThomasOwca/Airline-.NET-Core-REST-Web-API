using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.Entities
{
    public class Aircraft
    {
        [Key]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int MaxCapacity { get; set; }
    }
}
