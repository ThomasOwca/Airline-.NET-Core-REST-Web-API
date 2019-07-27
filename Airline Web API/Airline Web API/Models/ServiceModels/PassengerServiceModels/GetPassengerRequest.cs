using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels.PassengerServiceModels
{
    public class GetPassengerRequest : BaseServiceRequest
    {
        public int PassengerId { get; set; }
    }
}
