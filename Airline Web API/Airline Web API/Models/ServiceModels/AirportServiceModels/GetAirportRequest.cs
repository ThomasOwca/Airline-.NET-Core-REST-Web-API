﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels
{
    public class GetAirportRequest : BaseServiceRequest
    {
        public int AirportId { get; set; }
    }
}