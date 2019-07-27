using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.Entities
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Boolean PremiumPass { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
