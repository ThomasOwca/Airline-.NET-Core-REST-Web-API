﻿using Airline_Web_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.FleetServiceModels
{
    public class PutAircraftInFleetRequest : BaseServiceRequest
    {
        public int Id { get; set; }
        public Aircraft Aircraft { get; set; }
        public AircraftStatus Status { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
