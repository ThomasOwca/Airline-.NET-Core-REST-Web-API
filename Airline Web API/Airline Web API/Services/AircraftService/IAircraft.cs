using Airline_Web_API.Models.ServiceModels;
using Airline_Web_API.Models.ServiceModels.AircraftServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.AircraftService
{
    public interface IAircraft
    {
        GetAllAircraftResponse GetAllAircraft(GetAllAircraftRequest request);
        GetAircraftResponse GetAircraft(GetAircraftRequest request);
        PostAircraftResponse PostAircraft(PostAircraftRequest request);
        PutAircraftResponse PutAircraft(PutAircraftRequest request);
    }
}
