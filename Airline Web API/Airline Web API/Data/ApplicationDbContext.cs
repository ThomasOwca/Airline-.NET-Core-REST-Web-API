using Airline_Web_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Fleet> Fleet { get; set; }
        public DbSet<AircraftStatus> AircraftStatuses { get; set; }
    }
}
