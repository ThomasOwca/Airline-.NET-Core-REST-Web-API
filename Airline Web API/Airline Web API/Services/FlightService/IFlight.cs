using Airline_Web_API.Models.ServiceModels.FlightServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.FlightService
{
    public interface IFlight
    {
        GetFlightsResponse GetFlights(GetFlightsRequest request);
        GetFlightByPlaneIdResponse GetFlightByFlightId(GetFlightByPlaneIdRequest request);
        PostFlightResponse PostFlight(PostFlightRequest request);
        PutFlightResponse PutFlight(PutFlightRequest request);
        DeleteFlightResponse DeleteFlight(DeleteFlightRequest request);
    }
}
