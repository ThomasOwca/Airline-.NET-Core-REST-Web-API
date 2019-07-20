using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Models.Entities
{
    public class Fleet
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }
        public DateTime PurchaseDate { get; set; }
        [ForeignKey("StatusId")]
        public AircraftStatus Status { get; set; }


    }
}
