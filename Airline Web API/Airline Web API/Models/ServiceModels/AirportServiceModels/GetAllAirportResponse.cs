﻿using Airline_Web_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels
{
    public class GetAllAirportResponse : BaseServiceResponse
    {
        public List<Airport> Airport { get; set; }
    }
}
