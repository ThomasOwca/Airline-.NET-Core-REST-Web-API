using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Models.ServiceModels.AirportServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.AirportService
{
    public interface IAirport
    {
        GetAllAirportResponse GetAllAirport(GetAllAirportRequest request);
        GetAirportResponse GetAirport(GetAirportRequest request);
        PostAirportResponse PostAirport(PostAirportRequest request);
        PutAirportResponse PutAirport(PutAirportRequest request);
        DeleteAirportResponse DeleteAirport(DeleteAirportRequest request);
    }
}
