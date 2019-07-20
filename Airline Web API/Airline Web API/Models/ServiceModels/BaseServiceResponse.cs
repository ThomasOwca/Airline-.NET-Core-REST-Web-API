using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.ServiceModels
{
    public class BaseServiceResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
