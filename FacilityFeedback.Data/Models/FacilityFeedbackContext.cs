using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Data.Models
{
    public class FacilityFeedbackContext : DbContext
    {
        public FacilityFeedbackContext(DbContextOptions<FacilityFeedbackContext> options) : base(options) { 

        }

        public DbSet<Device> Device { get; set; } = null!;
        public DbSet<DeviceType> DeviceType { get; set; } = null!;
        public DbSet<Floor> Floor { get; set; } = null!;
        public DbSet<Problem> Problem { get; set; } = null!;
        public DbSet<Room> Room { get; set; } = null!;
        public DbSet<RoomType> RoomType { get; set; } = null!;
        public DbSet<TaskProcess> TaskProcess { get; set; } = null!;
        public DbSet<ResourceMaterial> ResourceMaterial { get; set; } = null!;
    }
}
