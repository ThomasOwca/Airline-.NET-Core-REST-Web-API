using Airline_Web_API.Models.ServiceModels.FleetServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.FleetService
{
    public interface IFleet
    {
        GetFleetResponse GetFleet(GetFleetRequest request);
        GetFleetByAircraftIdResponse GetFleetByAircraftId(GetFleetByAircraftIdRequest request);
        PostAircraftToFleetResponse PostAircraftToFleet(PostAircraftToFleetRequest request);
        PutAircraftInFleetResponse PutAircraftInFleet(PutAircraftInFleetRequest request);
        DeleteAircraftInFleetResponse DeleteAircraftInFleet(DeleteAircraftInFleetRequest request);
    }
}
