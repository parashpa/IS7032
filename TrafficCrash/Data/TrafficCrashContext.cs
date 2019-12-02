using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrafficCrashVehicles;

namespace TrafficCrash.Models
{
    public class TrafficCrashContext : DbContext
    {
        public TrafficCrashContext (DbContextOptions<TrafficCrashContext> options)
            : base(options)
        {
        }

        public DbSet<TrafficCrashVehicles.TrafficCrashVehicle> TrafficCrashVehicle { get; set; }
    }
}
